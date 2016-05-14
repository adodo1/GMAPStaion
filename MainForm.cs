using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMAPStaion.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GMAPStaion
{
    public partial class MainForm : Form
    {

        private GMapOverlay drawnpolygonsoverlay = null;    // 绘制多边形
        private GMapPolygon drawnpolygon = null;
        private GMapMarker _curentMarker = null;
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
            if (!GMapControl.IsDesignerHosted)
            {
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
                drawnpolygon.Stroke = new Pen(Color.Blue, 1.5f);
                drawnpolygon.Fill = Brushes.Transparent;
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
            MainMap.Invalidate();
            
        }



    }
}
