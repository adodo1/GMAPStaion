using GMap.NET;
using GMap.NET.MapProviders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GMAPStaion
{
    public partial class DownloadForm : Form
    {
        private double _left_lng, _top_lat, _right_lng, _bottom_lat;
        private GMapProvider _provider;
        private const long MAX_TILE_APPEND = 10000;     // 用于智能扩展总增加数量 不能超过10000张瓦片
        private const int MAX_BUFFER = 10;              // 上下左右扩展 不能超过20个瓦片

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
            labelMAPNAME.Text = string.Format("{0}", _provider.Name);
            labelLeft.Text = string.Format("经度 左：{0:0.00000}", _left_lng);
            labelRight.Text = string.Format("经度 右：{0:0.00000}", _right_lng);
            labelBottom.Text = string.Format("纬度 下：{0:0.00000}", _bottom_lat);
            labelTop.Text = string.Format("纬度 上：{0:0.00000}", _top_lat);

            dataGridViewTiles.Columns["ColumnLevel"].ReadOnly = true;
            dataGridViewTiles.Columns["ColumnNum"].ReadOnly = true;

            DataTable table = new DataTable("Tiles");
            table.Columns.Add("CHECKED", typeof(bool));
            table.Columns.Add("LEVEL", typeof(string));
            table.Columns.Add("BUFFER", typeof(string));
            table.Columns.Add("NUMBER", typeof(long));

            long tileMinX, tileMaxX, tileMinY, tileMaxY;
            long buffer = 0;

            for (int zoom = _provider.MinZoom; zoom < (_provider.MaxZoom ?? 24) + 1; zoom++) {
                DataRow row = table.NewRow();
                row["CHECKED"] = CheckedTiles(_provider, zoom);
                row["LEVEL"] = string.Format("第{0}级", zoom);
                row["BUFFER"] = 0;
                row["NUMBER"] = CoorExtent(zoom, buffer, out tileMinX, out tileMaxX, out tileMinY, out  tileMaxY);
                table.Rows.Add(row);
            }

            dataGridViewTiles.DataSource = new BindingSource(table, null);

        }
        /// <summary>
        /// 判断瓦片是否可以勾选
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        private bool CheckedTiles(GMapProvider provider, int level)
        {
            if (provider.Name.StartsWith("GOOGLE", StringComparison.OrdinalIgnoreCase) && level >= 19) {
                return false;
            }
            else return true;
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
        /// <summary>
        /// 智能外扩
        /// </summary>
        private void buttonBuffer_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow rowView in dataGridViewTiles.Rows) {
                DataRow row = ((DataRowView)rowView.DataBoundItem).Row as DataRow;
                int zoom = GetZoom(row["LEVEL"]);
                //int buffer = GetBuffer(row["BUFFER"]);
                int buffer;
                long total = AutoCoorExtent(zoom, out buffer);
                row["BUFFER"] = buffer < 0 ? "A" : buffer.ToString();
                row["NUMBER"] = total;
            }
        }
        /// <summary>
        /// 自动纠正缓冲值
        /// </summary>
        private void dataGridViewTiles_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewTiles.Columns[e.ColumnIndex].Name.ToUpper() != "ColumnBuffer".ToUpper())
                return;
            int buffer = 0;
            string value = dataGridViewTiles.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            if (value.ToUpper().StartsWith("A")) dataGridViewTiles.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "A";
            else if (int.TryParse(value, out buffer))
            {
                if (buffer < 0) dataGridViewTiles.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                else dataGridViewTiles.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = buffer;
            }
            else dataGridViewTiles.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;

            //dataGridViewTiles.UpdateCellValue(e.ColumnIndex, e.RowIndex);
        }
        /// <summary>
        /// 自动计算外扩瓦片数量
        /// </summary>
        /// <param name="zoom">瓦片等级</param>
        /// <param name="buffer">外扩大小</param>
        /// <returns>瓦片数量</returns>
        private long AutoCoorExtent(int zoom, out int buffer)
        {
            long tileMinX, tileMaxX, tileMinY, tileMaxY;
            long total = CoorExtent(zoom, 0, out tileMinX, out tileMaxX, out tileMinY, out  tileMaxY);      // 不扩展的情况

            // 先判断全部瓦片数量 如果全部瓦片数量都没有达到 32 * 32 返回全部
            long totalAll = CoorExtent(zoom, int.MaxValue, out tileMinX, out tileMaxX, out tileMinY, out  tileMaxY);
            if (totalAll <= 32 * 32) {
                buffer = -1;
                return totalAll;
            }
            // 从1..20往外扩展 比较扩展后的数量 如果数量大于 TILE_MAX_APPEND 就停止
            for (int n = 1; n <= MAX_BUFFER; n++) {
                long totalTest = CoorExtent(zoom, n, out tileMinX, out tileMaxX, out tileMinY, out  tileMaxY);
                if (totalTest - total > MAX_TILE_APPEND) {
                    buffer = n - 1;
                    return CoorExtent(zoom, n - 1, out tileMinX, out tileMaxX, out tileMinY, out  tileMaxY);
                }
            }
            buffer = MAX_BUFFER;
            return CoorExtent(zoom, MAX_BUFFER, out tileMinX, out tileMaxX, out tileMinY, out  tileMaxY);
        }
        /// <summary>
        /// 计算瓦片范围
        /// </summary>
        /// <param name="zoom">瓦片等级</param>
        /// <param name="buffer">外扩大小</param>
        /// <param name="tileMinX">最小瓦片X坐标</param>
        /// <param name="tileMaxX">最大瓦片X坐标</param>
        /// <param name="tileMinY">最小瓦片Y坐标</param>
        /// <param name="tileMaxY">最大瓦片Y坐标</param>
        /// <returns>瓦片数量</returns>
        private long CoorExtent(int zoom, long buffer, out long tileMinX, out long tileMaxX, out long tileMinY, out long tileMaxY)
        {
            GSize size = _provider.Projection.GetTileMatrixSizeXY(zoom);        // zoom等级的时候所有瓦片的数量 
            GSize sMin = _provider.Projection.GetTileMatrixMinXY(zoom);         // 瓦片最小范围    
            GSize sMax = _provider.Projection.GetTileMatrixMaxXY(zoom);         // 瓦片最大范围
            GPoint left_top = _provider.Projection.FromPixelToTileXY(_provider.Projection.FromLatLngToPixel(_top_lat, _left_lng, zoom));
            GPoint right_bottom = _provider.Projection.FromPixelToTileXY(_provider.Projection.FromLatLngToPixel(_bottom_lat, _right_lng, zoom));

            long xmin = left_top.X;         //
            long xmax = right_bottom.X;     // 
            long ymin = left_top.Y;         // 
            long ymax = right_bottom.Y;     // 
            
            xmin = xmin - buffer;           // 缓冲
            xmax = xmax + buffer;           // 缓冲
            ymin = ymin - buffer;           // 缓冲
            ymax = ymax + buffer;           // 缓冲

            xmin = (long)Clip(xmin, sMin.Width, sMax.Width);
            xmax = (long)Clip(xmax, sMin.Width, sMax.Width);
            ymin = (long)Clip(ymin, sMin.Height, sMax.Height);
            ymax = (long)Clip(ymax, sMin.Height, sMax.Height);

            tileMinX = xmin;
            tileMaxX = xmax;
            tileMinY = ymin;
            tileMaxY = ymax;

            long total = (xmax - xmin + 1) * (ymax - ymin + 1);
            return total;
        }
        /// <summary>
        /// Clips a number to the specified minimum and maximum values.
        /// </summary>
        /// <param name="n">The number to clip.</param>
        /// <param name="minValue">Minimum allowable value.</param>
        /// <param name="maxValue">Maximum allowable value.</param>
        /// <returns>The clipped value.</returns>
        private decimal Clip(decimal value, decimal minValue, decimal maxValue)
        {
            return Math.Min(Math.Max(value, minValue), maxValue);
        }
        /// <summary>
        /// 获取表格中缓冲值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private int GetBuffer(object value)
        {
            int buffer;
            string str = Convert.ToString(value);
            if (str.ToUpper().StartsWith("A")) return int.MaxValue;
            else if (int.TryParse(str, out buffer) && buffer >= 0) return buffer;
            else return 0;
        }
        /// <summary>
        /// 获取表格中等级值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private int GetZoom(object value)
        {
            Match match = Regex.Match(Convert.ToString(value), "\\d+");
            return int.Parse(match.Value);
        }
    }
}
