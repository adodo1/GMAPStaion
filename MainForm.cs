using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
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
        public MainForm()
        {
            InitializeComponent();

            MainMap.MouseWheel += MainMap_MouseWheel;
            MainMap.MouseMove += MainMap_MouseMove;

            
            
            Init();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainMap_MouseWheel(object sender, MouseEventArgs e)
        {
            UpdateInfo(e);
        }
        /// <summary>
        /// 显示坐标
        /// </summary>
        private void MainMap_MouseMove(object sender, MouseEventArgs e)
        {
            UpdateInfo(e);
        }
        private void UpdateInfo(MouseEventArgs e)
        {
            PointLatLng pnew = MainMap.FromLocalToLatLng(e.X, e.Y);
            toolStripStatusLabelInfo.Text = string.Format("经度:{0:0.000000} 纬度:{1:0.000000} 级别:{2}", pnew.Lng, pnew.Lat, MainMap.Zoom);
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
                
                //MainMap.MapProvider = GMapProviders.GoogleSatelliteMap;           // 默认地图
                MainMap.Position = new PointLatLng(24.3094574737, 109.441029377);     // 地图中心点(北京)GPS坐标
                //MainMap.MinZoom = GMapProviders.BaiduMap.MinZoom;                   // 地图最小比例
                //MainMap.MaxZoom = GMapProviders.BaiduMap.MaxZoom ?? 24;             // 地图最大比例
                MainMap.Zoom = 15;                                                  // 当前缩放等级
                MainMap.DragButton = MouseButtons.Left;                             // 鼠标平移键

                


            }
        }
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
            ChangeMap(GMapProviders.BaiduMap);
            CheckedMap(sender as ToolStripMenuItem);
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
            if (MainMap.SelectedArea.IsEmpty == true) return;
            DownloadForm downloadForm = new DownloadForm(MainMap.MapProvider, MainMap.SelectedArea.Left, MainMap.SelectedArea.Top, MainMap.SelectedArea.Right, MainMap.SelectedArea.Bottom);
            downloadForm.ShowDialog(this);
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
        }
    }
}
