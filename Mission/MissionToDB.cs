using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace GMAPStaion
{
    /// <summary>
    /// 任务保存到db文件
    /// </summary>
    public class MissionToDB
    {
        private string _name = "";              // 任务名称
        private List<utmpos> _points = null;    // 航点
        private double _toward = 0;             // 机头朝向
        private double _height = 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">任务名称</param>
        /// <param name="points">所有航点</param>
        /// <param name="height">高度</param>
        /// <param name="toward">机头朝向 小于0表示下一个航点 或 0-360</param>
        public MissionToDB(string name, List<utmpos> points, double height, double toward)
        {
            _name = name;
            _points = points;
            _toward = toward;
            _height = height;
        }
        /// <summary>
        /// 保存到文件
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public bool SaveTo(string file)
        {
            // 初始化数据库
            SQLiteHelper.SetConnectionString = string.Format("Data Source=\"{0}\"", file);

            List<utmpos> datas = new List<utmpos>();    // 一个航段的所有点
            for (int i = 0; i < _points.Count; i++) {
                if (_points[i].x == 0 || _points[i].y == 0) {
                    SaveTo(datas);      // 提交本次航段点
                    datas.Clear();      // 清除航段数据
                    continue;
                }
                datas.Add(_points[i]);
            }
            SaveTo(datas);              // 提交最后一个航段的数据


            return true;
        }
        private int num = 1;
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="datas"></param>
        /// <returns></returns>
        private bool SaveTo(List<utmpos> datas)
        {
            //"gimbalYaw": 0,
            //"height": 60,
            //"gimbalPitch": 0,
            //"lat": "24.306648871473",
            //"lng": "109.428814606948",
            //"craftYaw": 0

            double distance = 0;                    // 航段长度
            List<object> items = new List<object>();
            for (int i = 0; i < datas.Count; i++) {

                int toward = 0;
                if (i < datas.Count - 1) {
                    if (_toward < 0) {
                        // 计算机头朝向
                        if (datas[i + 1].y == datas[i].y) {
                            // 垂直
                            if (datas[i + 1].x >= datas[i].x) toward = 0;
                            else toward = 180;
                        }
                        else {
                            double dx = datas[i + 1].x - datas[i].x;
                            double dy = datas[i + 1].y - datas[i].y;
                            double hudu = Math.Atan(dx / dy);
                            double du = hudu * 180 / 3.14159265358;
                            // 反正切函数取值范围 -90°:90°
                            if (dy >= 0) toward = (int)du;
                            else toward = (int)du + 180;
                        }
                    }

                    distance += datas[i].GetDistance(datas[i + 1]);     // 航程累加
                }

                items.Add(new Dictionary<string, object>() {
                     {"lat", datas[i].ToLLA().Lat.ToString("0.000000000000")},      // 纬度
                     {"lng", datas[i].ToLLA().Lng.ToString("0.000000000000")},      // 经度
                     {"height", _height},           // 航高
                     {"craftYaw", toward},          // 机头朝向
                     {"gimbalYaw", 0},              // ??
                     {"gimbalPitch", 0}             // ??
                });
            }
            if (items.Count == 0) return true;
            Dictionary<string, object> result = new Dictionary<string, object>() {
                {"points", items}
            };
            string jsontxt = Json.JsonSerialize(result);

            // 插入数据库
            string tablename = "dji_pilot_groundStation_db_DJIWPCollectionItem";
            string sql = string.Format("INSERT INTO {0} (distance, pointsJsonStr, location, autoAddFlag, createdDate)" +
                                       "VALUES(@DISTANCE, @JSONTXT, @LOCATION, @FLAG, @DATE)", tablename);
            SQLiteParameter[] args = new SQLiteParameter[5];
            args[0] = new SQLiteParameter("@DISTANCE", distance);
            args[1] = new SQLiteParameter("@JSONTXT", jsontxt);
            args[2] = new SQLiteParameter("@LOCATION", _name + Convert.ToString(num++));
            args[3] = new SQLiteParameter("@FLAG", 0);
            args[4] = new SQLiteParameter("@DATE", (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000);
            int count = SQLiteHelper.ExecuteNonQuery(CommandType.Text, sql, args);
            return count > 0;
        }

    }
}
