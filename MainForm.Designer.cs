namespace GMAPStaion
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOpenSHP = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemMap = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemGoogleSatelliteMap = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemBingMap = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemGaodeMap = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemTenxunMap = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemBaiduMap = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemTianditu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemArcgisMap = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOpenStreetMap = new System.Windows.Forms.ToolStripMenuItem();
            this.工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDownload = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemUnion = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemCache = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAirline = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAirlinePlan = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAirlineSum = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemReplay = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemMeasure = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCoordinateConvert = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemLength = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemArea = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemShowGrid = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAboutMe = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMap = new GMAPStaion.Map();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemBookmark = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelInfo});
            this.statusStrip.Location = new System.Drawing.Point(0, 459);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(680, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "状态栏";
            // 
            // toolStripStatusLabelInfo
            // 
            this.toolStripStatusLabelInfo.Name = "toolStripStatusLabelInfo";
            this.toolStripStatusLabelInfo.Size = new System.Drawing.Size(32, 17);
            this.toolStripStatusLabelInfo.Text = "坐标";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemFile,
            this.toolStripMenuItemMap,
            this.工具ToolStripMenuItem,
            this.toolStripMenuItemAirline,
            this.toolStripMenuItemMeasure,
            this.toolStripMenuItemSetting,
            this.toolStripMenuItemAbout});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(680, 25);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // toolStripMenuItemFile
            // 
            this.toolStripMenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpenSHP});
            this.toolStripMenuItemFile.Name = "toolStripMenuItemFile";
            this.toolStripMenuItemFile.Size = new System.Drawing.Size(58, 21);
            this.toolStripMenuItemFile.Text = "文件(&F)";
            // 
            // toolStripMenuItemOpenSHP
            // 
            this.toolStripMenuItemOpenSHP.Name = "toolStripMenuItemOpenSHP";
            this.toolStripMenuItemOpenSHP.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemOpenSHP.Text = "打开SHP";
            this.toolStripMenuItemOpenSHP.Click += new System.EventHandler(this.toolStripMenuItemOpenSHP_Click);
            // 
            // toolStripMenuItemMap
            // 
            this.toolStripMenuItemMap.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemGoogleSatelliteMap,
            this.toolStripMenuItemBingMap,
            this.toolStripMenuItemGaodeMap,
            this.toolStripMenuItemTenxunMap,
            this.toolStripMenuItemBaiduMap,
            this.toolStripMenuItemTianditu,
            this.toolStripMenuItemArcgisMap,
            this.toolStripMenuItemOpenStreetMap});
            this.toolStripMenuItemMap.Name = "toolStripMenuItemMap";
            this.toolStripMenuItemMap.Size = new System.Drawing.Size(64, 21);
            this.toolStripMenuItemMap.Text = "地图(&M)";
            // 
            // toolStripMenuItemGoogleSatelliteMap
            // 
            this.toolStripMenuItemGoogleSatelliteMap.Name = "toolStripMenuItemGoogleSatelliteMap";
            this.toolStripMenuItemGoogleSatelliteMap.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemGoogleSatelliteMap.Text = "谷歌卫星";
            this.toolStripMenuItemGoogleSatelliteMap.Click += new System.EventHandler(this.toolStripMenuItemGoogleSatelliteMap_Click);
            // 
            // toolStripMenuItemBingMap
            // 
            this.toolStripMenuItemBingMap.Name = "toolStripMenuItemBingMap";
            this.toolStripMenuItemBingMap.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemBingMap.Text = "必应地图";
            this.toolStripMenuItemBingMap.Click += new System.EventHandler(this.toolStripMenuItemBingMap_Click);
            // 
            // toolStripMenuItemGaodeMap
            // 
            this.toolStripMenuItemGaodeMap.Name = "toolStripMenuItemGaodeMap";
            this.toolStripMenuItemGaodeMap.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemGaodeMap.Text = "高德地图";
            this.toolStripMenuItemGaodeMap.Visible = false;
            this.toolStripMenuItemGaodeMap.Click += new System.EventHandler(this.toolStripMenuItemGaodeMap_Click);
            // 
            // toolStripMenuItemTenxunMap
            // 
            this.toolStripMenuItemTenxunMap.Name = "toolStripMenuItemTenxunMap";
            this.toolStripMenuItemTenxunMap.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemTenxunMap.Text = "腾讯地图";
            this.toolStripMenuItemTenxunMap.Visible = false;
            this.toolStripMenuItemTenxunMap.Click += new System.EventHandler(this.toolStripMenuItemTenxunMap_Click);
            // 
            // toolStripMenuItemBaiduMap
            // 
            this.toolStripMenuItemBaiduMap.Name = "toolStripMenuItemBaiduMap";
            this.toolStripMenuItemBaiduMap.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemBaiduMap.Text = "百度地图";
            this.toolStripMenuItemBaiduMap.Visible = false;
            this.toolStripMenuItemBaiduMap.Click += new System.EventHandler(this.toolStripMenuItemBaiduMap_Click);
            // 
            // toolStripMenuItemTianditu
            // 
            this.toolStripMenuItemTianditu.Name = "toolStripMenuItemTianditu";
            this.toolStripMenuItemTianditu.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemTianditu.Text = "天地图";
            this.toolStripMenuItemTianditu.Visible = false;
            this.toolStripMenuItemTianditu.Click += new System.EventHandler(this.toolStripMenuItemTianditu_Click);
            // 
            // toolStripMenuItemArcgisMap
            // 
            this.toolStripMenuItemArcgisMap.Name = "toolStripMenuItemArcgisMap";
            this.toolStripMenuItemArcgisMap.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemArcgisMap.Text = "AGS地图";
            this.toolStripMenuItemArcgisMap.Visible = false;
            this.toolStripMenuItemArcgisMap.Click += new System.EventHandler(this.toolStripMenuItemArcgisMap_Click);
            // 
            // toolStripMenuItemOpenStreetMap
            // 
            this.toolStripMenuItemOpenStreetMap.Name = "toolStripMenuItemOpenStreetMap";
            this.toolStripMenuItemOpenStreetMap.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemOpenStreetMap.Text = "OSM地图";
            this.toolStripMenuItemOpenStreetMap.Visible = false;
            this.toolStripMenuItemOpenStreetMap.Click += new System.EventHandler(this.toolStripMenuItemOpenStreetMap_Click);
            // 
            // 工具ToolStripMenuItem
            // 
            this.工具ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemDownload,
            this.toolStripMenuItemUnion,
            this.toolStripSeparator2,
            this.toolStripMenuItemCache});
            this.工具ToolStripMenuItem.Name = "工具ToolStripMenuItem";
            this.工具ToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.工具ToolStripMenuItem.Text = "工具(&T)";
            // 
            // toolStripMenuItemDownload
            // 
            this.toolStripMenuItemDownload.Name = "toolStripMenuItemDownload";
            this.toolStripMenuItemDownload.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemDownload.Text = "下载地图";
            this.toolStripMenuItemDownload.Click += new System.EventHandler(this.toolStripMenuItemDownload_Click);
            // 
            // toolStripMenuItemUnion
            // 
            this.toolStripMenuItemUnion.Name = "toolStripMenuItemUnion";
            this.toolStripMenuItemUnion.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemUnion.Text = "影像拼接";
            this.toolStripMenuItemUnion.Click += new System.EventHandler(this.toolStripMenuItemUnion_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(121, 6);
            // 
            // toolStripMenuItemCache
            // 
            this.toolStripMenuItemCache.Name = "toolStripMenuItemCache";
            this.toolStripMenuItemCache.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemCache.Text = "缓存地图";
            this.toolStripMenuItemCache.Click += new System.EventHandler(this.toolStripMenuItemCache_Click);
            // 
            // toolStripMenuItemAirline
            // 
            this.toolStripMenuItemAirline.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAirlinePlan,
            this.toolStripMenuItemAirlineSum,
            this.toolStripMenuItemReplay});
            this.toolStripMenuItemAirline.Name = "toolStripMenuItemAirline";
            this.toolStripMenuItemAirline.Size = new System.Drawing.Size(59, 21);
            this.toolStripMenuItemAirline.Text = "航线(&P)";
            // 
            // toolStripMenuItemAirlinePlan
            // 
            this.toolStripMenuItemAirlinePlan.Name = "toolStripMenuItemAirlinePlan";
            this.toolStripMenuItemAirlinePlan.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemAirlinePlan.Text = "航线设计";
            this.toolStripMenuItemAirlinePlan.Click += new System.EventHandler(this.toolStripMenuItemAirlinePlan_Click);
            // 
            // toolStripMenuItemAirlineSum
            // 
            this.toolStripMenuItemAirlineSum.Name = "toolStripMenuItemAirlineSum";
            this.toolStripMenuItemAirlineSum.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemAirlineSum.Text = "航程计算";
            this.toolStripMenuItemAirlineSum.Click += new System.EventHandler(this.toolStripMenuItemAirlineSum_Click);
            // 
            // toolStripMenuItemReplay
            // 
            this.toolStripMenuItemReplay.Name = "toolStripMenuItemReplay";
            this.toolStripMenuItemReplay.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemReplay.Text = "日志回放";
            this.toolStripMenuItemReplay.Click += new System.EventHandler(this.toolStripMenuItemReplay_Click);
            // 
            // toolStripMenuItemMeasure
            // 
            this.toolStripMenuItemMeasure.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemLocation,
            this.toolStripMenuItemCoordinateConvert,
            this.toolStripSeparator1,
            this.toolStripMenuItemLength,
            this.toolStripMenuItemArea,
            this.toolStripSeparator3,
            this.toolStripMenuItemBookmark});
            this.toolStripMenuItemMeasure.Name = "toolStripMenuItemMeasure";
            this.toolStripMenuItemMeasure.Size = new System.Drawing.Size(64, 21);
            this.toolStripMenuItemMeasure.Text = "测量(&M)";
            // 
            // toolStripMenuItemLocation
            // 
            this.toolStripMenuItemLocation.Name = "toolStripMenuItemLocation";
            this.toolStripMenuItemLocation.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemLocation.Text = "定位坐标";
            this.toolStripMenuItemLocation.Click += new System.EventHandler(this.toolStripMenuItemLocation_Click);
            // 
            // toolStripMenuItemCoordinateConvert
            // 
            this.toolStripMenuItemCoordinateConvert.Name = "toolStripMenuItemCoordinateConvert";
            this.toolStripMenuItemCoordinateConvert.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemCoordinateConvert.Text = "坐标转换";
            this.toolStripMenuItemCoordinateConvert.Click += new System.EventHandler(this.toolStripMenuItemCoordinateConvert_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // toolStripMenuItemLength
            // 
            this.toolStripMenuItemLength.Name = "toolStripMenuItemLength";
            this.toolStripMenuItemLength.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemLength.Text = "距离测量";
            this.toolStripMenuItemLength.Click += new System.EventHandler(this.toolStripMenuItemLength_Click);
            // 
            // toolStripMenuItemArea
            // 
            this.toolStripMenuItemArea.Name = "toolStripMenuItemArea";
            this.toolStripMenuItemArea.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemArea.Text = "面积测量";
            this.toolStripMenuItemArea.Click += new System.EventHandler(this.toolStripMenuItemArea_Click);
            // 
            // toolStripMenuItemSetting
            // 
            this.toolStripMenuItemSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemShowGrid});
            this.toolStripMenuItemSetting.Name = "toolStripMenuItemSetting";
            this.toolStripMenuItemSetting.Size = new System.Drawing.Size(59, 21);
            this.toolStripMenuItemSetting.Text = "设置(&S)";
            // 
            // toolStripMenuItemShowGrid
            // 
            this.toolStripMenuItemShowGrid.Name = "toolStripMenuItemShowGrid";
            this.toolStripMenuItemShowGrid.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItemShowGrid.Text = "显示网格";
            this.toolStripMenuItemShowGrid.Click += new System.EventHandler(this.toolStripMenuItemShowGrid_Click);
            // 
            // toolStripMenuItemAbout
            // 
            this.toolStripMenuItemAbout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAboutMe});
            this.toolStripMenuItemAbout.Name = "toolStripMenuItemAbout";
            this.toolStripMenuItemAbout.Size = new System.Drawing.Size(60, 21);
            this.toolStripMenuItemAbout.Text = "关于(&A)";
            // 
            // toolStripMenuItemAboutMe
            // 
            this.toolStripMenuItemAboutMe.Name = "toolStripMenuItemAboutMe";
            this.toolStripMenuItemAboutMe.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemAboutMe.Text = "关于...";
            this.toolStripMenuItemAboutMe.Click += new System.EventHandler(this.toolStripMenuItemAboutMe_Click);
            // 
            // MainMap
            // 
            this.MainMap.Bearing = 0F;
            this.MainMap.CanDragMap = true;
            this.MainMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.MainMap.GrayScaleMode = false;
            this.MainMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.MainMap.LevelsKeepInMemmory = 5;
            this.MainMap.Location = new System.Drawing.Point(0, 25);
            this.MainMap.MarkersEnabled = true;
            this.MainMap.MaxZoom = 2;
            this.MainMap.MinZoom = 2;
            this.MainMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            this.MainMap.Name = "MainMap";
            this.MainMap.NegativeMode = false;
            this.MainMap.PolygonsEnabled = true;
            this.MainMap.RetryLoadTile = 0;
            this.MainMap.RoutesEnabled = true;
            this.MainMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.MainMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.MainMap.ShowTileGridLines = false;
            this.MainMap.Size = new System.Drawing.Size(680, 434);
            this.MainMap.TabIndex = 2;
            this.MainMap.Zoom = 0D;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
            // 
            // toolStripMenuItemBookmark
            // 
            this.toolStripMenuItemBookmark.Name = "toolStripMenuItemBookmark";
            this.toolStripMenuItemBookmark.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemBookmark.Text = "地图书签";
            this.toolStripMenuItemBookmark.Click += new System.EventHandler(this.toolStripMenuItemBookmark_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 481);
            this.Controls.Add(this.MainMap);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "柳州勘测院地面站辅助工具 v1.0";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMap;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemGoogleSatelliteMap;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemBaiduMap;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemBingMap;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenStreetMap;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemArcgisMap;
        private System.Windows.Forms.ToolStripMenuItem 工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDownload;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemUnion;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAirline;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAirlinePlan;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAirlineSum;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemReplay;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMeasure;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLocation;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCoordinateConvert;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSetting;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShowGrid;
        private Map MainMap;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelInfo;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenSHP;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAbout;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAboutMe;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLength;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemArea;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCache;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemGaodeMap;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTenxunMap;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTianditu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemBookmark;
    }
}

