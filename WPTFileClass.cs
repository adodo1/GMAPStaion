using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace GMAPStaion
{
    /// <summary>
    /// 解析WPT文件的类
    /// </summary>
    public class WPTFileClass
    {
        private DataTable _data = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        public WPTFileClass(string file)
        {
            _data = new DataTable();
            _data.Columns.Add("NO", typeof(string));        // 编号
            _data.Columns.Add("LAT", typeof(double));       // 纬度
            _data.Columns.Add("LNG", typeof(double));       // 经度
            _data.Columns.Add("ATT", typeof(double));       // 高程

            string text = "";
            using (StreamReader reader = new StreamReader(file)) {
                text = reader.ReadToEnd();
                reader.Close();
            }
            Init(text);
        }
        /// <summary>
        /// 初始化
        /// </summary>
        private void Init(string text)
        {
            //[Way Point]
            //Total Num=4
            //01=01,24.432674,109.492624,250
            //02=02,24.430195,109.483461,250
            //03=03,24.405586,109.483461,250
            //04=04,24.405586,109.484251,250
            text = text.Replace("\r", "");
            string[] lines = text.Split('\n');
            foreach (string line in lines) {
                if (line.Contains("=") == false) continue;
                string[] datas = line.Split('=')[1].Split(',');
                if (datas.Length != 4) continue;
                string no = datas[0];
                double lat = double.Parse(datas[1]);
                double lng = double.Parse(datas[2]);
                double att = double.Parse(datas[3]);
                _data.Rows.Add(no, lat, lng, att);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public DataTable GetData
        {
            get { return _data; }
        }
    }
}
