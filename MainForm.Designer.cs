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
            this.toolStripMenuItemGoogleMap = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemBaiduMap = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemBingMap = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOpenStreetMap = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemArcgisMap = new System.Windows.Forms.ToolStripMenuItem();
            this.工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDownload = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemUnion = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAirline = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAirlinePlan = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAirlineSum = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemReplay = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCoordinate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCoordinateConvert = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemShowGrid = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAboutMe = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMap = new GMAPStaion.Map();
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
            this.toolStripStatusLabelInfo.Size = new System.Drawing.Size(29, 17);
            this.toolStripStatusLabelInfo.Text = "坐标";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemFile,
            this.toolStripMenuItemMap,
            this.工具ToolStripMenuItem,
            this.toolStripMenuItemAirline,
            this.toolStripMenuItemCoordinate,
            this.toolStripMenuItemSetting,
            this.toolStripMenuItemAbout});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(680, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            this.menuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip_ItemClicked);
            // 
            // toolStripMenuItemFile
            // 
            this.toolStripMenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpenSHP});
            this.toolStripMenuItemFile.Name = "toolStripMenuItemFile";
            this.toolStripMenuItemFile.Size = new System.Drawing.Size(59, 20);
            this.toolStripMenuItemFile.Text = "文件(&F)";
            // 
            // toolStripMenuItemOpenSHP
            // 
            this.toolStripMenuItemOpenSHP.Name = "toolStripMenuItemOpenSHP";
            this.toolStripMenuItemOpenSHP.Size = new System.Drawing.Size(112, 22);
            this.toolStripMenuItemOpenSHP.Text = "打开SHP";
            // 
            // toolStripMenuItemMap
            // 
            this.toolStripMenuItemMap.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemGoogleSatelliteMap,
            this.toolStripMenuItemGoogleMap,
            this.toolStripMenuItemBaiduMap,
            this.toolStripMenuItemBingMap,
            this.toolStripMenuItemOpenStreetMap,
            this.toolStripMenuItemArcgisMap});
            this.toolStripMenuItemMap.Name = "toolStripMenuItemMap";
            this.toolStripMenuItemMap.Size = new System.Drawing.Size(59, 20);
            this.toolStripMenuItemMap.Text = "地图(&M)";
            // 
            // toolStripMenuItemGoogleSatelliteMap
            // 
            this.toolStripMenuItemGoogleSatelliteMap.Name = "toolStripMenuItemGoogleSatelliteMap";
            this.toolStripMenuItemGoogleSatelliteMap.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemGoogleSatelliteMap.Text = "谷歌卫星";
            // 
            // toolStripMenuItemGoogleMap
            // 
            this.toolStripMenuItemGoogleMap.Name = "toolStripMenuItemGoogleMap";
            this.toolStripMenuItemGoogleMap.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemGoogleMap.Text = "谷歌地图";
            // 
            // toolStripMenuItemBaiduMap
            // 
            this.toolStripMenuItemBaiduMap.Name = "toolStripMenuItemBaiduMap";
            this.toolStripMenuItemBaiduMap.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemBaiduMap.Text = "百度地图";
            // 
            // toolStripMenuItemBingMap
            // 
            this.toolStripMenuItemBingMap.Name = "toolStripMenuItemBingMap";
            this.toolStripMenuItemBingMap.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemBingMap.Text = "必应地图";
            // 
            // toolStripMenuItemOpenStreetMap
            // 
            this.toolStripMenuItemOpenStreetMap.Name = "toolStripMenuItemOpenStreetMap";
            this.toolStripMenuItemOpenStreetMap.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemOpenStreetMap.Text = "OSM地图";
            // 
            // toolStripMenuItemArcgisMap
            // 
            this.toolStripMenuItemArcgisMap.Name = "toolStripMenuItemArcgisMap";
            this.toolStripMenuItemArcgisMap.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemArcgisMap.Text = "AGS地图";
            // 
            // 工具ToolStripMenuItem
            // 
            this.工具ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemDownload,
            this.toolStripMenuItemUnion});
            this.工具ToolStripMenuItem.Name = "工具ToolStripMenuItem";
            this.工具ToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.工具ToolStripMenuItem.Text = "工具(&T)";
            // 
            // toolStripMenuItemDownload
            // 
            this.toolStripMenuItemDownload.Name = "toolStripMenuItemDownload";
            this.toolStripMenuItemDownload.Size = new System.Drawing.Size(118, 22);
            this.toolStripMenuItemDownload.Text = "下载地图";
            // 
            // toolStripMenuItemUnion
            // 
            this.toolStripMenuItemUnion.Name = "toolStripMenuItemUnion";
            this.toolStripMenuItemUnion.Size = new System.Drawing.Size(118, 22);
            this.toolStripMenuItemUnion.Text = "影像拼接";
            // 
            // toolStripMenuItemAirline
            // 
            this.toolStripMenuItemAirline.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAirlinePlan,
            this.toolStripMenuItemAirlineSum,
            this.toolStripMenuItemReplay});
            this.toolStripMenuItemAirline.Name = "toolStripMenuItemAirline";
            this.toolStripMenuItemAirline.Size = new System.Drawing.Size(59, 20);
            this.toolStripMenuItemAirline.Text = "航线(&P)";
            // 
            // toolStripMenuItemAirlinePlan
            // 
            this.toolStripMenuItemAirlinePlan.Name = "toolStripMenuItemAirlinePlan";
            this.toolStripMenuItemAirlinePlan.Size = new System.Drawing.Size(118, 22);
            this.toolStripMenuItemAirlinePlan.Text = "航线设计";
            // 
            // toolStripMenuItemAirlineSum
            // 
            this.toolStripMenuItemAirlineSum.Name = "toolStripMenuItemAirlineSum";
            this.toolStripMenuItemAirlineSum.Size = new System.Drawing.Size(118, 22);
            this.toolStripMenuItemAirlineSum.Text = "航程计算";
            // 
            // toolStripMenuItemReplay
            // 
            this.toolStripMenuItemReplay.Name = "toolStripMenuItemReplay";
            this.toolStripMenuItemReplay.Size = new System.Drawing.Size(118, 22);
            this.toolStripMenuItemReplay.Text = "日志回放";
            // 
            // toolStripMenuItemCoordinate
            // 
            this.toolStripMenuItemCoordinate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemLocation,
            this.toolStripMenuItemCoordinateConvert});
            this.toolStripMenuItemCoordinate.Name = "toolStripMenuItemCoordinate";
            this.toolStripMenuItemCoordinate.Size = new System.Drawing.Size(59, 20);
            this.toolStripMenuItemCoordinate.Text = "坐标(&L)";
            // 
            // toolStripMenuItemLocation
            // 
            this.toolStripMenuItemLocation.Name = "toolStripMenuItemLocation";
            this.toolStripMenuItemLocation.Size = new System.Drawing.Size(118, 22);
            this.toolStripMenuItemLocation.Text = "定位坐标";
            // 
            // toolStripMenuItemCoordinateConvert
            // 
            this.toolStripMenuItemCoordinateConvert.Name = "toolStripMenuItemCoordinateConvert";
            this.toolStripMenuItemCoordinateConvert.Size = new System.Drawing.Size(118, 22);
            this.toolStripMenuItemCoordinateConvert.Text = "坐标转换";
            // 
            // toolStripMenuItemSetting
            // 
            this.toolStripMenuItemSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemShowGrid});
            this.toolStripMenuItemSetting.Name = "toolStripMenuItemSetting";
            this.toolStripMenuItemSetting.Size = new System.Drawing.Size(59, 20);
            this.toolStripMenuItemSetting.Text = "设置(&S)";
            // 
            // toolStripMenuItemShowGrid
            // 
            this.toolStripMenuItemShowGrid.Name = "toolStripMenuItemShowGrid";
            this.toolStripMenuItemShowGrid.Size = new System.Drawing.Size(118, 22);
            this.toolStripMenuItemShowGrid.Text = "显示网格";
            // 
            // toolStripMenuItemAbout
            // 
            this.toolStripMenuItemAbout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAboutMe});
            this.toolStripMenuItemAbout.Name = "toolStripMenuItemAbout";
            this.toolStripMenuItemAbout.Size = new System.Drawing.Size(59, 20);
            this.toolStripMenuItemAbout.Text = "关于(&A)";
            // 
            // toolStripMenuItemAboutMe
            // 
            this.toolStripMenuItemAboutMe.Name = "toolStripMenuItemAboutMe";
            this.toolStripMenuItemAboutMe.Size = new System.Drawing.Size(112, 22);
            this.toolStripMenuItemAboutMe.Text = "关于...";
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
            this.MainMap.Location = new System.Drawing.Point(0, 24);
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
            this.MainMap.Size = new System.Drawing.Size(680, 435);
            this.MainMap.TabIndex = 2;
            this.MainMap.Zoom = 0D;
            this.MainMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainMap_MouseMove);
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
            this.Text = "柳州勘测院地面站辅助工具";
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
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemGoogleMap;
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
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCoordinate;
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
    }
}

