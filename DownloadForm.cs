using GMap.NET;
using GMap.NET.MapProviders;
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
    public partial class DownloadForm : Form
    {
        private double _left_lng, _top_lat, _right_lng, _bottom_lat;
        private GMapProvider _provider;

        /// <summary>
        /// 地图下载
        /// </summary>
        /// <param name="provider">地图服务</param>
        /// <param name="left_lng">左_经度 比如109.4</param>
        /// <param name="top_lat">上_纬度 比如24.3</param>
        /// <param name="right_lng">右_经度 比如109.5</param>
        /// <param name="bottom_lat">下_纬度 比如24.2</param>
        public DownloadForm(GMapProvider provider, double left_lng, double top_lat, double right_lng, double bottom_lat)
        {
            InitializeComponent();

            _provider = provider;
            _left_lng = left_lng;
            _top_lat = top_lat;
            _right_lng = right_lng;
            _bottom_lat = bottom_lat;
            Init();
        }
        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {

        }
        /// <summary>
        /// 取消
        /// </summary>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 生成脚本
        /// </summary>
        private void buttonMakePY_Click(object sender, EventArgs e)
        {

        }
    }
}
