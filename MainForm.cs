using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMAPStaion.Properties;
using MonoShapelib;
using ProjNet.CoordinateSystems;
using ProjNet.CoordinateSystems.Transformations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GMAPStaion
{
    public partial class MainForm : Form
    {

        private GMapOverlay drawnpolygonsoverlay = null;    // 绘制多边形
        private GMapPolygon drawnpolygon = null;
        private GMapOverlay routesOverlay = null;           // 航线图层
        private GMapMarker _curentMarker = null;

        private GMapOverlay waypointlinelay = null;         // WPT航线图层

        private bool _polygongridmode = false;

        public MainForm()
        {
            InitializeComponent();
            Init();
        }


        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            if (!GMapControl.IsDesignerHosted) {
                GMapProviders.GoogleMap.TryCorrectVersion = false;
                GMapProviders.GoogleSatelliteMap.TryCorrectVersion = false;
                GMapProviders.GoogleChinaMap.TryCorrectVersion = false;
                GMapProviders.GoogleChinaSatelliteMap.TryCorrectVersion = false;

                ChangeMap(GMapProviders.GoogleSatelliteMap);
                CheckedMap(toolStripMenuItemGoogleSatelliteMap);
                
                MainMap.MapProvider = GMapProviders.GoogleSatelliteMap;             // 默认地图
                MainMap.Position = new PointLatLng(24.305555555555557, 109.43);     // 地图中心点(北京)GPS坐标
                MainMap.MinZoom = GMapProviders.GoogleSatelliteMap.MinZoom;         // 地图最小比例
                MainMap.MaxZoom = GMapProviders.GoogleSatelliteMap.MaxZoom ?? 24;   // 地图最大比例
                MainMap.Zoom = 18;                                                  // 当前缩放等级
                MainMap.DragButton = MouseButtons.Left;                             // 鼠标平移键

                // 鼠标
                MainMap.MouseDown += MainMap_MouseDown;
                MainMap.MouseMove += MainMap_MouseMove;
                MainMap.MouseUp += MainMap_MouseUp;
                MainMap.OnMapZoomChanged += MainMap_OnMapZoomChanged;

                MainMap.OnMarkerLeave += MainMap_OnMarkerLeave;
                MainMap.OnMarkerEnter += MainMap_OnMarkerEnter;

                // 绘制多边形
                drawnpolygonsoverlay = new GMapOverlay("drawnpolygons");
                MainMap.Overlays.Add(drawnpolygonsoverlay);

                List<PointLatLng> points = new List<PointLatLng>();
                drawnpolygon = new GMapPolygon(points, "drawnpoly");
                drawnpolygon.Stroke = new Pen(Color.Lime, 2.0f);
                drawnpolygon.Fill = Brushes.Transparent;

                // 添加航线图层
                routesOverlay = new GMapOverlay("routes");
                MainMap.Overlays.Add(routesOverlay);

                // 添加WPT航点航线图层
                waypointlinelay = new GMapOverlay("航点航线");
                MainMap.Overlays.Add(waypointlinelay);
            }
        }
        /// <summary>
        /// 鼠标移到图标上
        /// </summary>
        /// <param name="item"></param>
        void MainMap_OnMarkerEnter(GMapMarker item)
        {
            if (!_isMouseDown) {
                _curentMarker = item;
            }
        }
        /// <summary>
        /// 鼠标从图标上离开
        /// </summary>
        /// <param name="item"></param>
        private void MainMap_OnMarkerLeave(GMapMarker item)
        {
            if (!_isMouseDown) {
                _curentMarker = null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private void MainMap_OnMapZoomChanged()
        {
            UpdateCoordinateInfo(null, null, MainMap.Zoom);
        }
        private double _lastlat = 0;        // 上次维度
        private double _lastlng = 0;        // 上次经度
        private double _lastzoom = 0;          // 上次等级
        /// <summary>
        /// 刷新经纬度坐标
        /// </summary>
        /// <param name="e"></param>
        private void UpdateCoordinateInfo(double? lat, double? lng, double? zoom)
        {
            if (lat != null) _lastlat = (double)lat;
            if (lng != null) _lastlng = (double)lng;
            if (zoom != null) _lastzoom = (int)zoom;
            toolStripStatusLabelInfo.Text = string.Format("经度:{0:0.000000} 纬度:{1:0.000000} 级别:{2}", _lastlng, _lastlat, _lastzoom);
        }


        #region 鼠标控制
        private bool _isMouseDraging = false;       // 鼠标是否正在拖动
        private bool _isMouseDown = false;          // 鼠标是否按下
        private int _lastX = 0;                     // 由于莫名其妙的鼠标偏移 所以加上一个小偏移的判断
        private int _lastY = 0;                     // 由于莫名其妙的鼠标偏移 所以加上一个小偏移的判断

        /// <summary>
        /// 鼠标按下
        /// </summary>
        private void MainMap_MouseDown(object sender, MouseEventArgs e)
        {
            PointLatLng point = MainMap.FromLocalToLatLng(e.X, e.Y);
            if (e.Button == MouseButtons.Left && ModifierKeys != Keys.Alt && ModifierKeys != Keys.Control) {
                _isMouseDown = true;
                _isMouseDraging = false;
                _lastX = e.X;
                _lastY = e.Y;
            }
            

        }
        /// <summary>
        /// 鼠标移动
        /// </summary>
        private void MainMap_MouseMove(object sender, MouseEventArgs e)
        {
            PointLatLng point = MainMap.FromLocalToLatLng(e.X, e.Y);
            UpdateCoordinateInfo(point.Lat, point.Lng, MainMap.Zoom);
            
            if (e.Button == MouseButtons.Left && _isMouseDown &&
                (Math.Abs(e.X  - _lastX) >1 || Math.Abs(e.Y - _lastY) > 1)) {
                // 正在拖动地图
                _isMouseDraging = true;

                // 正在移动标记点
                GMarkerGoogle curentMarker = _curentMarker as GMarkerGoogle;
                if (curentMarker != null) {
                    try {
                        // check if this is a grid point
                        if (curentMarker.Tag.ToString().Contains("grid")) {
                            // 移动多边形
                            drawnpolygon.Points[
                                int.Parse(curentMarker.Tag.ToString().Replace("grid", "")) - 1] =
                                new PointLatLng(point.Lat, point.Lng);
                            MainMap.UpdatePolygonLocalPosition(drawnpolygon);   
                            // 移动标记点
                            curentMarker.Position = point;
                            MainMap.Invalidate();
                        }
                    }
                    catch { }
                }
            }

        }
        /// <summary>
        /// 鼠标抬起
        /// </summary>
        private void MainMap_MouseUp(object sender, MouseEventArgs e)
        {
            PointLatLng point = MainMap.FromLocalToLatLng(e.X, e.Y);

            if (e.Button == MouseButtons.Left && _isMouseDown) {
                _isMouseDown = false;
                _curentMarker = null;
                if (_isMouseDraging == false) {
                    if (_polygongridmode == false) return;  // 如果没有在绘制多边形的模式 返回
                    AddPolygonPoint(point.Lat, point.Lng);
                    
                }
            }
        }
        #endregion

        /// <summary>
        /// 显示网格
        /// </summary>
        /// <param name="show"></param>
        private void ShowGrid(bool show)
        {
            MainMap.ShowTileGridLines = show;
        }
        /// <summary>
        /// 
        /// </summary>
        private void toolStripMenuItemShowGrid_Click(object sender, EventArgs e)
        {
            // 显示网格
            toolStripMenuItemShowGrid.Checked = !toolStripMenuItemShowGrid.Checked;
            ShowGrid(toolStripMenuItemShowGrid.Checked);
        }
        /// <summary>
        /// 切换地图
        /// </summary>
        private void ChangeMap(GMapProvider provider)
        {
            MainMap.MapProvider = provider;             // 默认地图
            MainMap.MinZoom = provider.MinZoom;         // 地图最小比例
            MainMap.MaxZoom = provider.MaxZoom ?? 24;   // 地图最大比例
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuItem"></param>
        private void CheckedMap(ToolStripMenuItem menuItem)
        {
            ToolStripDropDownMenu menu = menuItem.Owner as ToolStripDropDownMenu;
            foreach (ToolStripItem item in menu.Items) {
                if (item is ToolStripMenuItem) ((ToolStripMenuItem)item).Checked = false;
            }
            menuItem.Checked = true;
        }
        /// <summary>
        /// 谷歌卫星
        /// </summary>
        private void toolStripMenuItemGoogleSatelliteMap_Click(object sender, EventArgs e)
        {
            ChangeMap(GMapProviders.GoogleSatelliteMap);
            CheckedMap(sender as ToolStripMenuItem);
        }
        /// <summary>
        /// 百度地图
        /// </summary>
        private void toolStripMenuItemBaiduMap_Click(object sender, EventArgs e)
        {
            //ChangeMap(GMapProviders.BaiduMap);
            //CheckedMap(sender as ToolStripMenuItem);
        }
        /// <summary>
        /// 必应地图
        /// </summary>
        private void toolStripMenuItemBingMap_Click(object sender, EventArgs e)
        {
            ChangeMap(GMapProviders.BingSatelliteMap);
            CheckedMap(sender as ToolStripMenuItem);
        }
        /// <summary>
        /// AGS地图
        /// </summary>
        private void toolStripMenuItemArcgisMap_Click(object sender, EventArgs e)
        {
            MessageBox.Show("未添加!");
        }
        /// <summary>
        /// OSM地图
        /// </summary>
        private void toolStripMenuItemOpenStreetMap_Click(object sender, EventArgs e)
        {
            MessageBox.Show("未添加!");
        }
        /// <summary>
        /// 高德地图
        /// </summary>
        private void toolStripMenuItemGaodeMap_Click(object sender, EventArgs e)
        {
            MessageBox.Show("未添加!");
        }
        /// <summary>
        /// 腾讯地图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemTenxunMap_Click(object sender, EventArgs e)
        {
            MessageBox.Show("未添加!");
        }
        /// <summary>
        /// 天地图
        /// </summary>
        private void toolStripMenuItemTianditu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("未添加!");
        }
        /// <summary>
        /// 下载影像 生成一个下载脚本
        /// </summary>
        private void toolStripMenuItemDownload_Click(object sender, EventArgs e)
        {
            DownloadTiles();
        }
        /// <summary>
        /// 影像拼接
        /// </summary>
        private void toolStripMenuItemUnion_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 缓存地图
        /// </summary>
        private void toolStripMenuItemCache_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 航线设计
        /// </summary>
        private void toolStripMenuItemAirlinePlan_Click(object sender, EventArgs e)
        {
            AirlinePlan();
        }
        private bool _isPlanStart = false;
        /// <summary>
        /// 航线设计
        /// </summary>
        private void AirlinePlan(double altitude = 100, double? angle = null, double distance = 80, int spacing = 0)
        {
            if (_isPlanStart) return;
            _isPlanStart = true;

            List<PointLatLngAlt> list = new List<PointLatLngAlt>();
            drawnpolygon.Points.ForEach(x => { list.Add(x); });         // 
            if (angle == null) angle = GetAngleOfLongestSide(list);     // 航线角度
            MainMap.HoldInvalidation = true;                            // 地图暂停刷新

            routesOverlay.Routes.Clear();           // 清除路径
            routesOverlay.Polygons.Clear();         // 清除多边形
            routesOverlay.Markers.Clear();          // 清除标记

            try {
                // add crossover
                //Grid.StartPointLatLngAlt = list[0];

                // 计算航线
                List<PointLatLngAlt> points = Grid.CreateGrid(list, // 测区范围
                    altitude,                                       // 高度
                    distance,                                       // 航线间距
                    spacing,                                        // 拍照间隔
                    (double)angle,                                  // 航线角度
                    0,                                              // 外扩1
                    0,                                              // 外扩2
                    Grid.StartPosition.TopLeft,                     // 起始航点
                    false,
                    0,
                    0);

                if (checkBoxCross.Checked) {
                    // 十字航线
                    Grid.StartPointLatLngAlt = list[list.Count - 1];
                    List<PointLatLngAlt> pointsCross = Grid.CreateGrid(list,    // 测区范围
                        altitude,                                       // 高度
                        distance,                                       // 航线间距
                        spacing,                                        // 拍照间隔
                        (double)angle + 90,                             // 航线角度
                        0,                                              // 外扩1
                        0,                                              // 外扩2
                        Grid.StartPosition.Point,                       // 起始航点
                        false,
                        0,
                        0);
                    points.AddRange(pointsCross);
                }


                if (points.Count == 0) return;

                //
                int strips = 0;     // 航线条数
                int images = 0;     // 照片张数
                int a = 1;
                PointLatLngAlt prevpoint = points[0];
                float routetotal = 0;
                List<PointLatLng> segment = new List<PointLatLng>();
                
                // 
                foreach (var item in points) {
                    // TAG编码：
                    // M-拍照点
                    // S-线段起始
                    // E-线段结束
                    if (item.Tag.Contains("M")) {
                        images++;       // 照片张数加一
                        // 绘制拍照点
                        if (checkBoxInternals.Checked) {
                            routesOverlay.Markers.Add(new GMarkerGoogle(item, GMarkerGoogleType.green) { ToolTipText = a.ToString(), ToolTipMode = MarkerTooltipMode.OnMouseOver });
                            segment.Add(prevpoint);
                            segment.Add(item);
                            prevpoint = item;
                        }
                        #region 拍摄范围 暂时用不到
                        // 绘制拍摄范围 footprint
                        //try
                        //{
                        //    if (TXT_fovH.Text != "")
                        //    {
                        //        double fovh = double.Parse(TXT_fovH.Text);
                        //        double fovv = double.Parse(TXT_fovV.Text);

                        //        double startangle = 0;

                        //        if (!CHK_camdirection.Checked)
                        //        {
                        //            startangle = 90;
                        //        }

                        //        double angle1 = startangle - (Math.Tan((fovv / 2.0) / (fovh / 2.0)) * rad2deg);
                        //        double dist1 = Math.Sqrt(Math.Pow(fovh / 2.0, 2) + Math.Pow(fovv / 2.0, 2));

                        //        double bearing = (double)NUM_angle.Value;// (prevpoint.GetBearing(item) + 360.0) % 360;

                        //        List<PointLatLng> footprint = new List<PointLatLng>();
                        //        footprint.Add(item.newpos(bearing + angle1, dist1));
                        //        footprint.Add(item.newpos(bearing + 180 - angle1, dist1));
                        //        footprint.Add(item.newpos(bearing + 180 + angle1, dist1));
                        //        footprint.Add(item.newpos(bearing - angle1, dist1));

                        //        GMapPolygon poly = new GMapPolygon(footprint, a.ToString());
                        //        poly.Stroke = new Pen(Color.FromArgb(250 - ((a * 5) % 240), 250 - ((a * 3) % 240), 250 - ((a * 9) % 240)), 1);
                        //        poly.Fill = new SolidBrush(Color.FromArgb(40, Color.Purple));
                        //        if (CHK_footprints.Checked)
                        //            routesOverlay.Polygons.Add(poly);
                        //    }
                        //}
                        //catch { }
                        #endregion
                    }
                    else {
                        strips++;   // 航线条数加一
                        if (checkBoxMarkers.Checked) {
                            // 显示航点
                            var marker = new GMapMarkerWP(item, a.ToString()) { ToolTipText = a.ToString(), ToolTipMode = MarkerTooltipMode.OnMouseOver };
                            routesOverlay.Markers.Add(marker);
                        }

                        segment.Add(prevpoint);
                        segment.Add(item);
                        prevpoint = item;
                        a++;    // 航点加一
                    }
                    GMapRoute seg = new GMapRoute(segment, "segment" + a.ToString());
                    seg.Stroke = new Pen(Color.Yellow, 4);
                    seg.Stroke.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
                    seg.IsHitTestVisible = true;
                    if (checkBoxGrid.Checked)
                        routesOverlay.Routes.Add(seg);
                    routetotal = routetotal + (float)seg.Distance;      // 总距离
                    segment.Clear();
                }

                // 绘制完了 写信息
                numericUpDownAngle.Value = (decimal)angle;              // 航线角度
                labelArea.Text = (CalcPolygonArea(list) / 1000000.0).ToString("0.##平方千米");     // 测区面积
                labelDistance.Text = routetotal.ToString("0.#千米");    // 航线长度
                labelLineDistance.Text = distance.ToString("0.#米");    // 航线间距
                labelSpacing.Text = spacing.ToString("0.#米");          // 照片间隔



            }
            catch (Exception ex) {
                throw;
            }
            finally {
                MainMap.HoldInvalidation = true;                    // 重启地图刷新
                _isPlanStart = false;
            }
        }
        /// <summary>
        /// 航程计算
        /// </summary>
        private void toolStripMenuItemAirlineSum_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 日志回访
        /// </summary>
        private void toolStripMenuItemReplay_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 坐标定位
        /// </summary>
        private void toolStripMenuItemLocation_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 坐标转换
        /// </summary>
        private void toolStripMenuItemCoordinateConvert_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 距离测量
        /// </summary>
        private void toolStripMenuItemLength_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 面积测量
        /// </summary>
        private void toolStripMenuItemArea_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 地图书签
        /// </summary>
        private void toolStripMenuItemBookmark_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 关于
        /// </summary>
        private void toolStripMenuItemAboutMe_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 添加SHP文件
        /// </summary>
        private void toolStripMenuItemOpenSHP_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 矩形框选
        /// </summary>
        private void toolStripButtonEnv_Click(object sender, EventArgs e)
        {
            toolStripButtonEnv.Checked = true;
            MainMap.DisableAltForSelection = true;
        }
        /// <summary>
        /// 多边形选择
        /// </summary>
        private void toolStripButtonPolygon_Click(object sender, EventArgs e)
        {
            _polygongridmode = true;
            toolStripButtonPolygon.Checked = true;
        }
        /// <summary>
        /// 平移
        /// </summary>
        private void toolStripButtonPan_Click(object sender, EventArgs e)
        {
            MainMap.DisableAltForSelection = false;
            foreach (ToolStripItem item in toolStripButtonPan.Owner.Items) {
                if (item is ToolStripButton) ((ToolStripButton)item).Checked = false;
            }
            _polygongridmode = false;
            _curentMarker = null;
        }
        /// <summary>
        /// 下载影像
        /// </summary>
        private void toolStripButtonDownload_Click(object sender, EventArgs e)
        {
            DownloadTiles();
        }
        /// <summary>
        /// 下载影像
        /// </summary>
        private void DownloadTiles()
        {
            if (MainMap.SelectedArea.IsEmpty == true) return;
            DownloadForm downloadForm = new DownloadForm(MainMap.MapProvider, MainMap.SelectedArea.Left, MainMap.SelectedArea.Top, MainMap.SelectedArea.Right, MainMap.SelectedArea.Bottom);
            downloadForm.ShowDialog(this);
        }
        /// <summary>
        /// 给多边形添加节点
        /// </summary>
        /// <param name="lat"></param>
        /// <param name="lng"></param>
        private void AddPolygonPoint(double lat, double lng)
        {
            List<PointLatLng> polygonPoints = new List<PointLatLng>();
            if (drawnpolygonsoverlay.Polygons.Count == 0) {
                drawnpolygon.Points.Clear();
                drawnpolygonsoverlay.Polygons.Add(drawnpolygon);
            }

            drawnpolygon.Fill = Brushes.Transparent;

            // remove full loop is exists
            if (drawnpolygon.Points.Count > 1 &&
                drawnpolygon.Points[0] == drawnpolygon.Points[drawnpolygon.Points.Count - 1])
                drawnpolygon.Points.RemoveAt(drawnpolygon.Points.Count - 1); // unmake a full loop

            drawnpolygon.Points.Add(new PointLatLng(lat, lng));
            addpolygonmarkergrid(drawnpolygon.Points.Count.ToString(), lng, lat, 0);
            MainMap.UpdatePolygonLocalPosition(drawnpolygon);
            MainMap.Invalidate();
        }
        /// <summary>
        /// 添加多边形控制点
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="lng"></param>
        /// <param name="lat"></param>
        /// <param name="alt"></param>
        private void addpolygonmarkergrid(string tag, double lng, double lat, int alt)
        {
            try {
                PointLatLng point = new PointLatLng(lat, lng);
                GMarkerGoogle m = new GMarkerGoogle(point, Resources.marker);
                m.ToolTipMode = MarkerTooltipMode.Never;
                m.ToolTipText = "grid" + tag;
                m.Tag = "grid" + tag;
                GMapMarker mar = new GMarkerCross(point);

                drawnpolygonsoverlay.Markers.Add(m);
            }
            catch (Exception ex) {
                //log.Info(ex.ToString());
            }
        }
        /// <summary>
        /// 清除
        /// </summary>
        private void toolStripButtonClear_Click(object sender, EventArgs e)
        {
            if (drawnpolygon == null) return;
            drawnpolygon.Points.Clear();
            drawnpolygonsoverlay.Markers.Clear();

            waypointlinelay.Routes.Clear();

            MainMap.Invalidate();

        }

        #region 航线设计
        /// <summary>
        /// 获取最长边的角度
        /// </summary>
        /// <param name="list">多边形</param>
        /// <returns></returns>
        private double GetAngleOfLongestSide(List<PointLatLngAlt> list)
        {
            if (list.Count == 0) return 0;
            double angle = 0;
            double maxdist = 0;
            PointLatLngAlt last = list[list.Count - 1];
            foreach (var item in list) {
                if (item.GetDistance(last) > maxdist) {
                    angle = item.GetBearing(last);
                    maxdist = item.GetDistance(last);
                }
                last = item;
            }
            return (angle + 360) % 360;
        }
        /// <summary>
        /// 计算区域面积
        /// </summary>
        /// <param name="polygon"></param>
        /// <returns></returns>
        private double CalcPolygonArea(List<PointLatLngAlt> polygon)
        {
            // should be a closed polygon
            // coords are in lat long
            // need utm to calc area

            if (polygon.Count == 0) {
                //CustomMessageBox.Show("Please define a polygon!");
                return 0;
            }

            // close the polygon 闭合范围
            if (polygon[0] != polygon[polygon.Count - 1])
                polygon.Add(polygon[0]); // make a full loop

            CoordinateTransformationFactory ctfac = new CoordinateTransformationFactory();
            GeographicCoordinateSystem wgs84 = GeographicCoordinateSystem.WGS84;
            int utmzone = (int)((polygon[0].Lng - -186.0) / 6.0);
            IProjectedCoordinateSystem utm = ProjectedCoordinateSystem.WGS84_UTM(utmzone, polygon[0].Lat < 0 ? false : true);
            ICoordinateTransformation trans = ctfac.CreateFromCoordinateSystems(wgs84, utm);

            double prod1 = 0;
            double prod2 = 0;

            for (int a = 0; a < (polygon.Count - 1); a++) {
                double[] pll1 = { polygon[a].Lng, polygon[a].Lat };
                double[] pll2 = { polygon[a + 1].Lng, polygon[a + 1].Lat };
                double[] p1 = trans.MathTransform.Transform(pll1);
                double[] p2 = trans.MathTransform.Transform(pll2);
                prod1 += p1[0] * p2[1];
                prod2 += p1[1] * p2[0];
            }

            double answer = (prod1 - prod2) / 2;
            if (polygon[0] == polygon[polygon.Count - 1])
                polygon.RemoveAt(polygon.Count - 1); // unmake a full loop
            return Math.Abs(answer);
        }
        /// <summary>
        /// 格式化时间
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        private string FormatTime(double seconds) {
            if (seconds < 0)
                return "Infinity Seconds";

            double secs = seconds % 60;
            int mins = (int)(seconds / 60) % 60;
            int hours = (int)(seconds / 3600) % 24;

            if (hours > 0) {
                return hours + ":" + mins.ToString("00") + ":" + secs.ToString("00") + " Hours";
            }
            else if (mins > 0) {
                return mins + ":" + secs.ToString("00") + " Minutes";
            }
            else {
                return secs.ToString("0.00") + " Seconds";
            }
        }
        /// <summary>
        /// 参数计算
        /// </summary>
        private void DoCalc()
        {

        }
        #endregion

        /// <summary>
        /// 航线角度
        /// </summary>
        private void numericUpDownAngle_ValueChanged(object sender, EventArgs e)
        {
            AirlinePlan((double)numericUpDownAltitude.Value, (double)numericUpDownAngle.Value, (double)numericUpDownDistance.Value);
            MainMap.Invalidate();
        }
        /// <summary>
        /// 
        /// </summary>
        private void numericUpDownDistance_ValueChanged(object sender, EventArgs e)
        {
            AirlinePlan((double)numericUpDownAltitude.Value, (double)numericUpDownAngle.Value, (double)numericUpDownDistance.Value);
            MainMap.Invalidate();
        }
        /// <summary>
        /// 
        /// </summary>
        private void checkBoxCross_CheckedChanged(object sender, EventArgs e)
        {
            AirlinePlan((double)numericUpDownAltitude.Value, (double)numericUpDownAngle.Value, (double)numericUpDownDistance.Value);
            MainMap.Invalidate();
        }
        /// <summary>
        /// 导出
        /// </summary>
        private void toolStripSplitButtonExport_ButtonClick(object sender, EventArgs e)
        {
            toolStripSplitButtonExport.ShowDropDown();
        }
        /// <summary>
        /// 导出SHP数据
        /// </summary>
        private void toolStripMenuItemExpSHP_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "SHP文件(*.SHP)|*.SHP";
            if (dialog.ShowDialog() != DialogResult.OK) return;


            // 点测试
            {
                DataTable table = new DataTable();
                table.Columns.Add("ID", typeof(int));
                table.Columns.Add("NAME", typeof(string));
                table.Columns.Add("REMARK", typeof(string));
                table.Columns.Add("SHAPE", typeof(SHPRecord));
                // 构造图形
                SHPRecord shprecord = new SHPRecord() { ShapeType = SHPT.POINTZ };
                shprecord.Points.Add(new double[] { 50, 50, 0, 0 });
                // 
                table.Rows.Add(1, "A1", "中文注记", shprecord);
                //
                bool success = ExportSHP(dialog.FileName, table, SHPT.POINTZ);
            }
            // 线测试
            {
                //DataTable table = new DataTable();
                //table.Columns.Add("ID", typeof(int));
                //table.Columns.Add("NAME", typeof(string));
                //table.Columns.Add("REMARK", typeof(string));
                //table.Columns.Add("SHAPE", typeof(SHPRecord));
                //// 构造图形
                //SHPRecord shprecord = new SHPRecord() { ShapeType = SHPT.ARC };
                //shprecord.Parts.Add(0);                                     // 第一个分段 从0号点开始
                //shprecord.Points.Add(new double[] { 0, 0, 0, 0 });          // 节点0
                //shprecord.Points.Add(new double[] { 100, 0, 0, 0 });        // 节点1
                //shprecord.Points.Add(new double[] { 100, 100, 0, 0 });      // 节点2
                //shprecord.Parts.Add(3);                                     // 第二个分段 从3号点开始
                //shprecord.Points.Add(new double[] { 200, 200, 0, 0 });      // 节点3
                //shprecord.Points.Add(new double[] { 300, 200, 0, 0 });      // 节点4
                //// 
                //table.Rows.Add(1, "A1", "中文注记", shprecord);
                ////
                //bool success = ExportSHP(dialog.FileName, table, SHPT.ARC);
            }
            // 测试面
            {
                //DataTable table = new DataTable();
                //table.Columns.Add("ID", typeof(int));
                //table.Columns.Add("NAME", typeof(string));
                //table.Columns.Add("REMARK", typeof(string));
                //table.Columns.Add("SHAPE", typeof(SHPRecord));
                //// 构造图形
                //SHPRecord shprecord = new SHPRecord() { ShapeType = SHPT.POLYGON };
                //shprecord.Parts.Add(0);                                     // 第一个分段 从0号点开始
                //shprecord.Points.Add(new double[] { 0, 0, 0, 0 });          // 节点0
                //shprecord.Points.Add(new double[] { 100, 0, 0, 0 });        // 节点1
                //shprecord.Points.Add(new double[] { 100, 100, 0, 0 });      // 节点2
                //shprecord.Points.Add(new double[] { 0, 100, 0, 0 });        // 节点3
                //shprecord.Points.Add(new double[] { 0, 0, 0, 0 });          // 节点4
                //shprecord.Parts.Add(5);                                     // 第二个分段 从3号点开始
                //shprecord.Points.Add(new double[] { 33.33, 0, 0, 0 });      // 节点5
                //shprecord.Points.Add(new double[] { 50, 80, 0, 0 });        // 节点6
                //shprecord.Points.Add(new double[] { 66.66, 0, 0, 0 });      // 节点7
                //shprecord.Points.Add(new double[] { 33.33, 0, 0, 0 });      // 节点8
                //// 
                //table.Rows.Add(1, "A1", "中文注记", shprecord);
                ////
                //bool success = ExportSHP(dialog.FileName, table, SHPT.POLYGON);
            }


            MessageBox.Show("完成");
        }

        /// <summary>
        /// 导出SHP数据
        /// </summary>
        /// <param name="nameWithoutExt">SHP文件名 不包含扩展名</param>
        /// <param name="table">属性表</param>
        /// <param name="shptype">SHP类别</param>
        /// <returns></returns>
        private bool ExportSHP(string nameWithoutExt, DataTable table, SHPT shptype)
        {
            // TABLE里包含SHPRecord字段
            // 创建SHP文件
            // 创建DBF文件
            // 写入图形
            // 写入属性
            try {
                // 1.创建SHP文件
                SHPHandle hSHP = SHPHandle.Create(nameWithoutExt, shptype);
                if (hSHP == null) throw new Exception("Unable to create SHP:" + nameWithoutExt);
                // 2.创建DBF文件
                DBFHandle hDBF = DBFHandle.Create(nameWithoutExt);
                if (hDBF == null) throw new Exception("Unable to create DBF:" + nameWithoutExt);
                string shapeField = "";
                foreach (DataColumn column in table.Columns) {
                    if (column.DataType == typeof(string)) {
                        if (hDBF.AddField(column.ColumnName, FT.String, 50, 0) < 0)
                            throw new Exception("DBFHandle.AddField(" + column.ColumnName + ",FTString,50,0) failed.");
                    }
                    else if (column.DataType == typeof(int)) {
                        if (hDBF.AddField(column.ColumnName, FT.Double, 8, 0) < 0)
                            throw new Exception("DBFHandle.AddField(" + column.ColumnName + ",Integer,8,0) failed.");
                    }
                    else if (column.DataType == typeof(double)) {
                        if (hDBF.AddField(column.ColumnName, FT.Double, 16, 8) < 0)
                            throw new Exception("DBFHandle.AddField(" + column.ColumnName + ",Double,16,8) failed.");
                    }
                    else if (column.DataType == typeof(DateTime)) {
                        // 不支持
                        //if (hDBF.AddField(column.ColumnName, FT.Logical, 16, 0) < 0)
                        //    throw new Exception("DBFHandle.AddField(" + column.ColumnName + ",Double,16,0) failed.");
                    }
                    else if (column.DataType == typeof(SHPRecord)) {
                        // 图形字段
                        shapeField = column.ColumnName;
                    }
                }
                if (shapeField == "") throw new Exception("Can not found shape field.");
                // 3.写数据
                int record_index = 0;
                foreach (DataRow row in table.Rows) {
                    // 处理图形
                    SHPRecord record = row[shapeField] as SHPRecord;
                    int num_parts = record.NumberOfParts;       // 总共分为几段
                    int[] parts = record.Parts.ToArray();       // 每一个分段的起始节点索引
                    int num_points = record.NumberOfPoints;     // 所有节点总数
                    double[] xs = new double[num_points];       // 所有节点X坐标
                    double[] ys = new double[num_points];       // 所有节点Y坐标
                    double[] zs = new double[num_points];       // 所有节点Z坐标
                    double[] ms = new double[num_points];       // 所有节点M坐标
                    for (int i = 0; i < num_points; i++) {
                        xs[i] = record.Points[i][0];            // X坐标
                        ys[i] = record.Points[i][1];            // Y坐标
                        zs[i] = record.Points[i][2];            // Z值
                        ms[i] = record.Points[i][3];            // M值
                    }
                    // 
                    int field_index = 0;
                    foreach (DataColumn column in table.Columns) {
                        object val = row[column];
                        if (val == null || Convert.IsDBNull(val)) {
                            hDBF.WriteNULLAttribute(record_index, field_index);
                            field_index++;
                        }
                        else if (column.DataType == typeof(string)) {
                            hDBF.WriteStringAttribute(record_index, field_index, Convert.ToString(val));
                            field_index++;
                        }
                        else if (column.DataType == typeof(int)) {
                            hDBF.WriteDoubleAttribute(record_index, field_index, Convert.ToInt32(val));
                            field_index++;
                        }
                        else if (column.DataType == typeof(double)) {
                            hDBF.WriteDoubleAttribute(record_index, field_index, Convert.ToDouble(val));
                            field_index++;
                        }
                        else if (column.DataType == typeof(DateTime)) {
                            // 不支持
                        }
                    }
                    // PS: 节点 "逆时针"是加 "顺时针"是减
                    SHPObject shpobj = SHPObject.Create(shptype,    // 图形类别
                                                        -1,         // 图形ID -1表示新增
                                                        num_parts,  // 总共分为几段
                                                        parts,      // 每一个分段的起始节点索引
                                                        null,       // 每段的类别
                                                        num_points, // 所有节点总数
                                                        xs,         // 所有节点的X坐标
                                                        ys,         // 所有节点的Y坐标
                                                        zs,         // 所有节点的Z值
                                                        ms);        // 所有节点的M值
                    hSHP.WriteObject(-1, shpobj);
                    record_index++;
                }

                hDBF.Close();
                hSHP.Close();
                return true;
            }
            catch (Exception ex) {
                return false;
            }
        }
        /// <summary>
        /// 导入SHP数据
        /// </summary>
        /// <param name="nameWithoutExt"></param>
        /// <returns></returns>
        private bool ImportSHP(string nameWithoutExt)
        {

        }

        /// <summary>
        /// 打开WPT航点文件
        /// </summary>
        private void toolStripMenuItemOpenWPT_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "航线文件(*.WPT)|*.WPT";
            if (dialog.ShowDialog() != DialogResult.OK) return;
            AddWPT(dialog.FileName);
        }
        /// <summary>
        /// 拖拽完成
        /// </summary>
        private void MainMap_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            // 
            foreach (string file in files) {
                string extname = System.IO.Path.GetExtension(file).ToLower();
                switch (extname) {
                    case ".wpt":
                        // 添加WPT航点文件
                        AddWPT(file);
                        break;
                    case ".log":
                        // 添加航飞日志
                        AddLOG(file);
                        break;
                    default:
                        break;
                }
                
            }


        }
        /// <summary>
        /// 拖拽开始
        /// </summary>
        private void MainMap_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                e.Effect = DragDropEffects.Copy;
            }
            else { e.Effect = DragDropEffects.None; }
        }
        /// <summary>
        /// 添加WPT文件
        /// </summary>
        /// <param name="file"></param>
        private void AddWPT(string file)
        {
            WPTFileClass wptfile = new WPTFileClass(file);
            DataTable table = wptfile.GetData;

            List<PointLatLng> points = new List<PointLatLng>();
            foreach (DataRow row in table.Rows) {
                string no = (string)row["NO"];
                double lat = (double)row["LAT"];
                double lng = (double)row["LNG"];
                double att = (double)row["ATT"];
                points.Add(new PointLatLng(lat, lng));
            }
            GMapRoute route = new GMapRoute(points, "WPT LINE");
            route.Stroke = new Pen(Color.Red, 2);
            route.Stroke.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            waypointlinelay.Routes.Add(route);
        }
        /// <summary>
        /// 创建豆腐航线
        /// </summary>
        private void toolStripButtonDoufu_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        private void AddLOG(string file)
        {
            string data = "";
            using (StreamReader reader = new StreamReader(file)) {
                data = reader.ReadToEnd();
                reader.Close();
            }
            OSDControl osdControl = new OSDControl(data);

            List<PointLatLng> points = new List<PointLatLng>();
            double lastlat = 0;
            double lastlng = 0;
            for (int i = 0; i < osdControl.Count; i++) {
                OSDData1 osdData1 = osdControl[i] as OSDData1;
                OSDData2 osdData2 = osdControl[i] as OSDData2;
                if (osdData1 != null) {

                    double lat = osdData1.lat;
                    double lng = osdData1.lng;
                    double att = osdData1.sky_heigh;

                    if (lat > 30 || lat < 18 || lng > 110)
                        continue;
                    if (lat == 0 || lng == 0) continue;
                    if (lat == lastlat || lng == lastlng) continue;

                    lastlat = lat;
                    lastlng = lng;

                    points.Add(new PointLatLng(lat, lng));
                }
            }

            GMapRoute route = new GMapRoute(points, "WPT LINE");
            route.Stroke = new Pen(Color.Lime, 2);
            route.Stroke.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            waypointlinelay.Routes.Add(route);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        private void AddSHP(string file)
        {

        }

    }


}
