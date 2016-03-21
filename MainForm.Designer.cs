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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.地图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.谷歌卫星ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.谷歌地图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.百度地图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oSM地图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aGS地图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.必应地图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.下载地图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.影像拼接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.坐标ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.定位坐标ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.航线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.航线设计ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.航程计算ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.日志回放ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.坐标转换ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示网格ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabelInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainMap = new GMAPStaion.Map();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开SHPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem,
            this.地图ToolStripMenuItem,
            this.工具ToolStripMenuItem,
            this.航线ToolStripMenuItem,
            this.坐标ToolStripMenuItem,
            this.设置ToolStripMenuItem,
            this.关于AToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(680, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // 地图ToolStripMenuItem
            // 
            this.地图ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.谷歌卫星ToolStripMenuItem,
            this.谷歌地图ToolStripMenuItem,
            this.百度地图ToolStripMenuItem,
            this.必应地图ToolStripMenuItem,
            this.oSM地图ToolStripMenuItem,
            this.aGS地图ToolStripMenuItem});
            this.地图ToolStripMenuItem.Name = "地图ToolStripMenuItem";
            this.地图ToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.地图ToolStripMenuItem.Text = "地图(&M)";
            // 
            // 谷歌卫星ToolStripMenuItem
            // 
            this.谷歌卫星ToolStripMenuItem.Name = "谷歌卫星ToolStripMenuItem";
            this.谷歌卫星ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.谷歌卫星ToolStripMenuItem.Text = "谷歌卫星";
            // 
            // 谷歌地图ToolStripMenuItem
            // 
            this.谷歌地图ToolStripMenuItem.Name = "谷歌地图ToolStripMenuItem";
            this.谷歌地图ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.谷歌地图ToolStripMenuItem.Text = "谷歌地图";
            // 
            // 百度地图ToolStripMenuItem
            // 
            this.百度地图ToolStripMenuItem.Name = "百度地图ToolStripMenuItem";
            this.百度地图ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.百度地图ToolStripMenuItem.Text = "百度地图";
            // 
            // oSM地图ToolStripMenuItem
            // 
            this.oSM地图ToolStripMenuItem.Name = "oSM地图ToolStripMenuItem";
            this.oSM地图ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.oSM地图ToolStripMenuItem.Text = "OSM地图";
            // 
            // aGS地图ToolStripMenuItem
            // 
            this.aGS地图ToolStripMenuItem.Name = "aGS地图ToolStripMenuItem";
            this.aGS地图ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aGS地图ToolStripMenuItem.Text = "AGS地图";
            // 
            // 必应地图ToolStripMenuItem
            // 
            this.必应地图ToolStripMenuItem.Name = "必应地图ToolStripMenuItem";
            this.必应地图ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.必应地图ToolStripMenuItem.Text = "必应地图";
            // 
            // 工具ToolStripMenuItem
            // 
            this.工具ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.下载地图ToolStripMenuItem,
            this.影像拼接ToolStripMenuItem});
            this.工具ToolStripMenuItem.Name = "工具ToolStripMenuItem";
            this.工具ToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.工具ToolStripMenuItem.Text = "工具(&T)";
            // 
            // 下载地图ToolStripMenuItem
            // 
            this.下载地图ToolStripMenuItem.Name = "下载地图ToolStripMenuItem";
            this.下载地图ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.下载地图ToolStripMenuItem.Text = "下载地图";
            // 
            // 影像拼接ToolStripMenuItem
            // 
            this.影像拼接ToolStripMenuItem.Name = "影像拼接ToolStripMenuItem";
            this.影像拼接ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.影像拼接ToolStripMenuItem.Text = "影像拼接";
            // 
            // 坐标ToolStripMenuItem
            // 
            this.坐标ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.定位坐标ToolStripMenuItem,
            this.坐标转换ToolStripMenuItem});
            this.坐标ToolStripMenuItem.Name = "坐标ToolStripMenuItem";
            this.坐标ToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.坐标ToolStripMenuItem.Text = "坐标(&L)";
            // 
            // 定位坐标ToolStripMenuItem
            // 
            this.定位坐标ToolStripMenuItem.Name = "定位坐标ToolStripMenuItem";
            this.定位坐标ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.定位坐标ToolStripMenuItem.Text = "定位坐标";
            // 
            // 航线ToolStripMenuItem
            // 
            this.航线ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.航线设计ToolStripMenuItem1,
            this.航程计算ToolStripMenuItem1,
            this.日志回放ToolStripMenuItem1});
            this.航线ToolStripMenuItem.Name = "航线ToolStripMenuItem";
            this.航线ToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.航线ToolStripMenuItem.Text = "航线(&P)";
            // 
            // 航线设计ToolStripMenuItem1
            // 
            this.航线设计ToolStripMenuItem1.Name = "航线设计ToolStripMenuItem1";
            this.航线设计ToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.航线设计ToolStripMenuItem1.Text = "航线设计";
            // 
            // 航程计算ToolStripMenuItem1
            // 
            this.航程计算ToolStripMenuItem1.Name = "航程计算ToolStripMenuItem1";
            this.航程计算ToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.航程计算ToolStripMenuItem1.Text = "航程计算";
            // 
            // 日志回放ToolStripMenuItem1
            // 
            this.日志回放ToolStripMenuItem1.Name = "日志回放ToolStripMenuItem1";
            this.日志回放ToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.日志回放ToolStripMenuItem1.Text = "日志回放";
            // 
            // 坐标转换ToolStripMenuItem
            // 
            this.坐标转换ToolStripMenuItem.Name = "坐标转换ToolStripMenuItem";
            this.坐标转换ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.坐标转换ToolStripMenuItem.Text = "坐标转换";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示网格ToolStripMenuItem});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.设置ToolStripMenuItem.Text = "设置(&S)";
            // 
            // 显示网格ToolStripMenuItem
            // 
            this.显示网格ToolStripMenuItem.Name = "显示网格ToolStripMenuItem";
            this.显示网格ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.显示网格ToolStripMenuItem.Text = "显示网格";
            // 
            // toolStripStatusLabelInfo
            // 
            this.toolStripStatusLabelInfo.Name = "toolStripStatusLabelInfo";
            this.toolStripStatusLabelInfo.Size = new System.Drawing.Size(29, 17);
            this.toolStripStatusLabelInfo.Text = "坐标";
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
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开SHPToolStripMenuItem});
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.文件FToolStripMenuItem.Text = "文件(&F)";
            // 
            // 关于AToolStripMenuItem
            // 
            this.关于AToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ToolStripMenuItem});
            this.关于AToolStripMenuItem.Name = "关于AToolStripMenuItem";
            this.关于AToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.关于AToolStripMenuItem.Text = "关于(&A)";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.关于ToolStripMenuItem.Text = "关于...";
            // 
            // 打开SHPToolStripMenuItem
            // 
            this.打开SHPToolStripMenuItem.Name = "打开SHPToolStripMenuItem";
            this.打开SHPToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.打开SHPToolStripMenuItem.Text = "打开SHP";
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
        private System.Windows.Forms.ToolStripMenuItem 地图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 谷歌卫星ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 谷歌地图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 百度地图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 必应地图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oSM地图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aGS地图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 下载地图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 影像拼接ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 航线ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 航线设计ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 航程计算ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 日志回放ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 坐标ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 定位坐标ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 坐标转换ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示网格ToolStripMenuItem;
        private Map MainMap;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelInfo;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开SHPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
    }
}

