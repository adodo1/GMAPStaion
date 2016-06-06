using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GMAPStaion
{
    /// <summary>
    /// OSD控制
    /// </summary>
    public class OSDControl
    {
        /// <summary>
        /// 
        /// </summary>
        private List<OSDData> _datas = new List<OSDData>();

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="text"></param>
        public OSDControl(string text)
        {
            text = text.Replace("\r\n", "\n");
            string[] lines = text.Split('\n');
            for (int i = 0; i < lines.Length; i++) {
                string line = lines[i];
                if (line.ToUpper().StartsWith("#DATA1")) {
                    OSDData1 osdData = new OSDData1(line);
                    _datas.Add(osdData);
                }
                else if (line.ToUpper().StartsWith("#DATA2")) {
                    OSDData2 osdData = new OSDData2(line);
                    _datas.Add(osdData);
                }
                else if (line.ToUpper().StartsWith("#DATA3")) {
                    OSDData3 osdData = new OSDData3(line);
                    _datas.Add(osdData);
                }
            }
        }
        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public OSDData this[int index]
        {
            get { return _datas[index]; }
        }
        /// <summary>
        /// 数据量
        /// </summary>
        public int Count
        {
            get { return _datas.Count; }
        }

    }
    /// <summary>
    /// OSD单条数据
    /// </summary>
    public abstract class OSDData
    {
        /// <summary>
        /// 字符串转整形数组
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        protected int[] ToInts(string data)
        {
            // #DATA1,29,241,249,0,255,5,184,0,204,25,164,31,164,119,251,0,4,3,124,0,0,0,1,0,0,0,0,242,235
            string[] datas = data.Split(',');
            if (datas[0].StartsWith("#DATA", StringComparison.OrdinalIgnoreCase) == false || datas.Length < 2)
                return new int[0];
            int[] result = new int[datas.Length - 1];
            for (int i = 1; i < datas.Length; i++)
            {
                int num = 0;
                if (int.TryParse(datas[i], out num) == false) return new int[0];
                else result[i - 1] = num;
            }
            // 进行信息校验
            if (result[0] != result.Length) return new int[0];
            return result;
        }
        /// <summary>
        /// 转整形
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        /// <returns></returns>
        public int ToInt(int val1, int val2)
        {
            return val1 * 256 + val2;
        }
        /// <summary>
        /// 转小数 十分之一 1/10.0
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        /// <returns></returns>
        public double ToDoubleOneTenth(int val1, int val2)
        {
            return (val1 * 256.0 + val2) / 10.0;
        }
        /// <summary>
        /// 转小数 百分之一 1/100.0
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        /// <returns></returns>
        public double ToDoubleOnePercent(int val1, int val2)
        {
            return (val1 * 256.0 + val2) / 100.0;
        }
        /// <summary>
        /// 计算高度 -500 ~ 9999
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        /// <returns>单位米</returns>
        public double ToDoubleLimit6000(int val1, int val2)
        {
            double val = val1 * 256.0 + val2;
            if (val >= 6000) return 6000 - val;
            else return val;
        }
        /// <summary>
        /// 转经纬度值 单位°例如: 22.1234567°
        /// </summary>
        /// <param name="val1">经纬度整数位1</param>
        /// <param name="val2">经纬度整数位2</param>
        /// <param name="val3">经纬度小数位1</param>
        /// <param name="val4">经纬度小数位2</param>
        /// <returns>经纬度值</returns>
        public double ToCoordinate(int val1, int val2, int val3, int val4)
        {
            //测试数据
            //#DATA1,29,241,249,0,255,5,184,0,204,25,164,31,164,119,251,0,4,3,124,0,0,0,1,0,0,0,0,242,235
            //#DATA2,44,242,1,0,0,0,0,0,190,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,168,51,6,7,42,8,10,15,41,0,1,0,1,10,50,0,128,235
            //#DATA3,53,243,0,35,128,36,11,250,11,126,8,172,11,224,0,0,56,0,0,0,0,0,0,120,9,254,255,253,255,255,255,0,0,242,255,20,0,238,255,222,5,2,0,0,9,254,255,255,255,255,255,82,235
            //24.40033913
            //109.4134979

            // 包含2个字段：5,236表示的意思是：5*256+236=1516分 = 北纬25度16分
            // 如果data5的数值大于128，则当前纬度为南纬
            // 例如137,236表示的意思则为：(137*256+236) - 32768=2540分 =南纬42度20分)
            int fen1 = val1 * 256 + val2;
            int fen2 = val3 * 256 + val4;
            if (val1 > 128) fen1 = fen1 - 32768;    // 超过128说明是 南纬 或者是 西经
            // 包含2个字段：36,79表示的意思是：36*256 + 79=9295分(小数位的分) 需要除以10000.0
            int du = fen1 / 60;
            int fen_int = fen1 % 60;
            double fen_dobule = fen2 / 10000.0;
            // 合并起来
            double result = du + (fen_int + fen_dobule) / 60;
            return result;
        }
        /// <summary>
        /// 转时间
        /// </summary>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public DateTime? ToTime(int hour, int minute, int second, int year = 0, int month = 1, int day = 1)
        {
            if (hour < 0 || hour > 23) return null;
            if (minute < 0 || minute > 59) return null;
            if (second < 0 || second > 59) return null;
            if (year < 0 || year > 100) return null;
            if (month < 1 || month > 12) return null;
            if (day < 1 || day > 31) return null;

            DateTime time = new DateTime(year + 2000, month, day, hour, minute, second);
            return time;
        }
    }

    /// <summary>
    /// OSD单条数据1
    /// </summary>
    public class OSDData1 : OSDData
	{
        //#DATA1,29,241,249,0,255,5,184,0,204,25,164,31,164,119,251,0,4,3,124,0,0,0,1,0,0,0,0,242,235
        //#DATA2,44,242,1,0,0,0,0,0,190,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,168,51,6,7,42,8,10,15,41,0,1,0,1,10,50,0,128,235
        //#DATA3,53,243,0,35,128,36,11,250,11,126,8,172,11,224,0,0,56,0,0,0,0,0,0,120,9,254,255,253,255,255,255,0,0,242,255,20,0,238,255,222,5,2,0,0,9,254,255,255,255,255,255,82,235
        // 说明文件
        // http://www.feiyu-tech.com/download.php?id=42
		public int data1_00_len;                // 数据长度 29
        public int data1_01_start;              // 指令标识
        public int data1_02_fly_statu_info;     // 飞控状态信息
        public int data1_03_fly_statu_flag;     // 飞行状态指示
        public int data1_04_dir_statu_flag;     // 导航状态指示
        public int[] data1_0506_lat1;           // 当前纬度整数位(单位分)
        public int[] data1_0708_lat2;           // 当前纬度小数位
        public int[] data1_0910_lng1;           // 当前经度整数位(单位分)
        public int[] data1_1112_lng2;           // 当前经度小数位
        public int[] data1_1314_gps_course;     // GPS 当前航向(单位百分之一度)
        public int[] data1_1516_gps_speed;      // GPS 当前速度(单位十分之一米/秒)
        public int[] data1_1718_gps_heigh;      // GPS 当前高度(单位米)
        public int[] data1_1920_sky_speed;      // 空速
        public int[] data1_2122_sky_heigh;      // 当前气压高度(单位十分之一米)
        public int[] data1_2324_distance;       // 到当前目标航点距离(单位米)
        public int[] data1_2526_offset;         // 到当前航线侧偏距距离(单位米)
        public int data1_27_mod;                // 所有数据累加和取余
        public int data1_28_end;                // 结束标识符

        public double lat = 0;                  // 纬度
        public double lng = 0;                  // 经度
        public double gps_course = 0;           // GPS航向
        public double gps_speed = 0;            // GPS速度
        public double gps_heigh = 0;            // GPS高度
        public double sky_heigh = 0;            // 气压高度
        public double distance = 0;             // 到目标航点距离
        public double offset = 0;               // 当前航线侧偏距离

        /// <summary>
        /// OSD单条数据1
        /// </summary>
        /// <param name="data1"></param>
        public OSDData1(string data1)
        {
            #region 初始化
            data1_00_len = 0;
            data1_01_start = 0;
            data1_02_fly_statu_info = 0;
            data1_03_fly_statu_flag = 0;
            data1_04_dir_statu_flag = 0;
            data1_0506_lat1 = new int[2] { 0, 0 };
            data1_0708_lat2 = new int[2] { 0, 0 };
            data1_0910_lng1 = new int[2] { 0, 0 };
            data1_1112_lng2 = new int[2] { 0, 0 };
            data1_1314_gps_course = new int[2] { 0, 0 };
            data1_1516_gps_speed = new int[2] { 0, 0 };
            data1_1718_gps_heigh = new int[2] { 0, 0 };
            data1_1920_sky_speed = new int[2] { 0, 0 };
            data1_2122_sky_heigh = new int[2] { 0, 0 };
            data1_2324_distance = new int[2] { 0, 0 };
            data1_2526_offset = new int[2] { 0, 0 };
            data1_27_mod = 0;
            data1_28_end = 0;

            lat = 0;
            lng = 0;
            #endregion

            int[] data1_ints = ToInts(data1);

            if (data1_ints.Length >= 29) {
                data1_00_len = data1_ints[0];
                data1_01_start = data1_ints[1];
                data1_02_fly_statu_info = data1_ints[2];
                data1_03_fly_statu_flag = data1_ints[3];
                data1_04_dir_statu_flag = data1_ints[4];
                data1_0506_lat1 = new int[2] { data1_ints[5], data1_ints[6] };
                data1_0708_lat2 = new int[2] { data1_ints[7], data1_ints[8] };
                data1_0910_lng1 = new int[2] { data1_ints[9], data1_ints[10] };
                data1_1112_lng2 = new int[2] { data1_ints[11], data1_ints[12] };
                data1_1314_gps_course = new int[2] { data1_ints[13], data1_ints[14] };
                data1_1516_gps_speed = new int[2] { data1_ints[15], data1_ints[16] };
                data1_1718_gps_heigh = new int[2] { data1_ints[17], data1_ints[18] };
                data1_1920_sky_speed = new int[2] { data1_ints[19], data1_ints[20] };
                data1_2122_sky_heigh = new int[2] { data1_ints[21], data1_ints[22] };
                data1_2324_distance = new int[2] { data1_ints[23], data1_ints[24] };
                data1_2526_offset = new int[2] { data1_ints[25], data1_ints[26] };
                data1_27_mod = data1_ints[27];
                data1_28_end = data1_ints[28];

                // 经纬度
                lat = ToCoordinate(data1_0506_lat1[0], data1_0506_lat1[1], data1_0708_lat2[0], data1_0708_lat2[1]);
                lng = ToCoordinate(data1_0910_lng1[0], data1_0910_lng1[1], data1_1112_lng2[0], data1_1112_lng2[1]);
                gps_course = ToDoubleOnePercent(data1_1314_gps_course[0], data1_1314_gps_course[1]);    // GPS航向
                gps_speed = ToDoubleOneTenth(data1_1516_gps_speed[0], data1_1516_gps_speed[1]);         // GPS速度
                gps_heigh = ToDoubleLimit6000(data1_1718_gps_heigh[0], data1_1718_gps_heigh[1]);        // GPS高度
                sky_heigh = ToDoubleLimit6000(data1_2122_sky_heigh[0], data1_2122_sky_heigh[1]) / 10.0; // 气压高度
                distance = ToInt(data1_2324_distance[0], data1_2324_distance[1]);                       // 到目标航点的距离
                offset = ToInt(data1_2526_offset[0], data1_2526_offset[1]);                             // 当前航线侧偏距离
            }
        }
	}
    /// <summary>
    /// OSD单条数据2
    /// </summary>
    public class OSDData2 : OSDData
    {
        //#DATA1,29,241,249,0,255,5,184,0,204,25,164,31,164,119,251,0,4,3,124,0,0,0,1,0,0,0,0,242,235
        //#DATA2,44,242,1,0,0,0,0,0,190,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,168,51,6,7,42,8,10,15,41,0,1,0,1,10,50,0,128,235
        //#DATA3,53,243,0,35,128,36,11,250,11,126,8,172,11,224,0,0,56,0,0,0,0,0,0,120,9,254,255,253,255,255,255,0,0,242,255,20,0,238,255,222,5,2,0,0,9,254,255,255,255,255,255,82,235
        // 说明文件
        // http://www.feiyu-tech.com/download.php?id=42

        public int data2_00_len;                // 数据长度 44
        public int data2_01_start;              // 指令标识
        public int data2_02_to_num;             // 当前目标航点编号
        public int[] data2_0304_to_course;      // 当前目标航向(单位：度)
        public int[] data2_0506_to_heigh;       // 当前目标高度(单位：米)
        public int[] data2_0708_to_speed;       // 当前目标速度(单位：十分之一米/秒)
        public int[] data2_0910_s_lat1;         // 当前航线起点纬度整数位(单位分)
        public int[] data2_1112_s_lat2;         // 当前航线起点纬度小数位(单位分)
        public int[] data2_1314_s_lng1;         // 当前航线起点经度整数位(单位分)
        public int[] data2_1516_s_lng2;         // 当前航线起点经度小数位(单位分)
        public int[] data2_1718_e_lat1;         // 当前航线终点纬度整数位(单位分)
        public int[] data2_1920_e_lat2;         // 当前航线终点纬度小数位(单位分)
        public int[] data2_2122_e_lng1;         // 当前航线终点经度整数位(单位分)
        public int[] data2_2324_e_lng2;         // 当前航线终点经度小数位(单位分)
        public int[] data2_2526_power_v;        // 动力电池电压(单位十分之一伏)
        public int data2_27_control_v;          // 控制电池电压(单位十分之一伏)
        public int data2_28_hour;               // 时间 小时
        public int data2_29_min;                // 时间 分钟
        public int data2_30_sec;                // 时间 秒
        public int data2_31_mon;                // 日期 月
        public int data2_32_day;                // 日期 日
        public int data2_33_year;               // 日期 年
        public int data2_34_tmp;                // 当前窗内温度
        public int[] data2_3536_power_a;        // 动力电流 单位A
        public int[] data2_3738_power_w;        // 动力电量 单位毫安时 耗电量
        public int data2_39_gps_hz;             // GPS刷新率
        public int data2_40_stance_hz;          // 姿态数据刷新率
        public int data2_41_fm_hz;              // 数传电台刷新率
        public int data2_42_mod;                // 所有数据累加和取余
        public int data2_43_end;                // 结束标识符

        public int to_num = 0;                  // 当前目标航点编号
        public int to_course = 0;               // 当前目标航向(单位：度)
        public int to_heigh = 0;                // 当前目标高度(单位：米)
        public double to_speed = 0;             // 当前目标速度(单位：十分之一米/秒)
        public double s_lat = 0;                // 当前航线起点纬度
        public double s_lng = 0;                // 当前航线起点经度
        public double e_lat = 0;                // 当前航线终点纬度
        public double e_lng = 0;                // 当前航线终点经度
        public double power_v = 0;              // 动力电池电压
        public double control_v = 0;            // 控制电池电压
        public DateTime? time = null;           // 时间
        public double power_a = 0;              // 动力电流 A
        public double power_w = 0;              // 动力电量

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data2"></param>
        public OSDData2(string data2)
        {
            #region 初始化
            data2_00_len = 0;
            data2_01_start = 0;
            data2_02_to_num = 0;
            data2_0304_to_course = new int[2] { 0, 0 };
            data2_0506_to_heigh = new int[2] { 0, 0 };
            data2_0708_to_speed = new int[2] { 0, 0 };
            data2_0910_s_lat1 = new int[2] { 0, 0 };
            data2_1112_s_lat2 = new int[2] { 0, 0 };
            data2_1314_s_lng1 = new int[2] { 0, 0 };
            data2_1516_s_lng2 = new int[2] { 0, 0 };
            data2_1718_e_lat1 = new int[2] { 0, 0 };
            data2_1920_e_lat2 = new int[2] { 0, 0 };
            data2_2122_e_lng1 = new int[2] { 0, 0 };
            data2_2324_e_lng2 = new int[2] { 0, 0 };
            data2_2526_power_v = new int[2] { 0, 0 };
            data2_27_control_v = 0;
            data2_28_hour = 0;
            data2_29_min = 0;
            data2_30_sec = 0;
            data2_31_mon = 0;
            data2_32_day = 0;
            data2_33_year = 0;
            data2_34_tmp = 0;
            data2_3536_power_a = new int[2] { 0, 0 };
            data2_3738_power_w = new int[2] { 0, 0 };
            data2_39_gps_hz = 0;
            data2_40_stance_hz = 0;
            data2_41_fm_hz = 0;
            data2_42_mod = 0;
            data2_43_end = 0;

            #endregion

            int[] data2_ints = ToInts(data2);

            if (data2_ints.Length >= 44) {
                data2_00_len = data2_ints[0];
                data2_01_start = data2_ints[1];
                data2_02_to_num = data2_ints[2];
                data2_0304_to_course = new int[2] { data2_ints[3], data2_ints[4] };
                data2_0506_to_heigh = new int[2] { data2_ints[5], data2_ints[6] };
                data2_0708_to_speed = new int[2] { data2_ints[7], data2_ints[8] };
                data2_0910_s_lat1 = new int[2] { data2_ints[9], data2_ints[10] };
                data2_1112_s_lat2 = new int[2] { data2_ints[11], data2_ints[12] };
                data2_1314_s_lng1 = new int[2] { data2_ints[13], data2_ints[14] };
                data2_1516_s_lng2 = new int[2] { data2_ints[15], data2_ints[16] };
                data2_1718_e_lat1 = new int[2] { data2_ints[17], data2_ints[18] };
                data2_1920_e_lat2 = new int[2] { data2_ints[19], data2_ints[20] };
                data2_2122_e_lng1 = new int[2] { data2_ints[21], data2_ints[22] };
                data2_2324_e_lng2 = new int[2] { data2_ints[23], data2_ints[24] };
                data2_2526_power_v = new int[2] { data2_ints[25], data2_ints[26] };
                data2_27_control_v = data2_ints[27];
                data2_28_hour = data2_ints[28];
                data2_29_min = data2_ints[29];
                data2_30_sec = data2_ints[30];
                data2_31_mon = data2_ints[31];
                data2_32_day = data2_ints[32];
                data2_33_year = data2_ints[33];
                data2_34_tmp = data2_ints[34];
                data2_3536_power_a = new int[2] { data2_ints[35], data2_ints[36] };
                data2_3738_power_w = new int[2] { data2_ints[37], data2_ints[38] };
                data2_39_gps_hz = data2_ints[39];
                data2_40_stance_hz = data2_ints[40];
                data2_41_fm_hz = data2_ints[41];
                data2_42_mod = data2_ints[42];
                data2_43_end = data2_ints[43];
            }

            to_num = data2_02_to_num;
            to_course = ToInt(data2_0304_to_course[0], data2_0304_to_course[1]);
            to_heigh = ToInt(data2_0506_to_heigh[0], data2_0506_to_heigh[1]);
            to_speed = ToDoubleOneTenth(data2_0708_to_speed[0], data2_0708_to_speed[1]);

            s_lat = ToCoordinate(data2_0910_s_lat1[0], data2_0910_s_lat1[1], data2_1112_s_lat2[0], data2_1112_s_lat2[1]);
            s_lng = ToCoordinate(data2_1314_s_lng1[0], data2_1314_s_lng1[1], data2_1516_s_lng2[0], data2_1516_s_lng2[1]);
            e_lat = ToCoordinate(data2_1718_e_lat1[0], data2_1718_e_lat1[1], data2_1920_e_lat2[0], data2_1920_e_lat2[1]);
            e_lng = ToCoordinate(data2_2122_e_lng1[0], data2_2122_e_lng1[1], data2_2324_e_lng2[1], data2_2324_e_lng2[1]);

            power_v = ToDoubleOneTenth(data2_2526_power_v[0], data2_2526_power_v[1]);
            control_v = data2_27_control_v / 10.0;
            time = ToTime(data2_28_hour, data2_29_min, data2_30_sec, data2_33_year, data2_31_mon, data2_32_day);

            power_a = ToDoubleOneTenth(data2_3536_power_a[0], data2_3536_power_a[1]);
            power_w = ToInt(data2_3738_power_w[0], data2_3738_power_w[1]);
        }



    }
    /// <summary>
    /// OSD单条数据3
    /// </summary>
    public class OSDData3 : OSDData
    {
        //#DATA1,29,241,249,0,255,5,184,0,204,25,164,31,164,119,251,0,4,3,124,0,0,0,1,0,0,0,0,242,235
        //#DATA2,44,242,1,0,0,0,0,0,190,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,168,51,6,7,42,8,10,15,41,0,1,0,1,10,50,0,128,235
        //#DATA3,53,243,0,35,128,36,11,250,11,126,8,172,11,224,0,0,56,0,0,0,0,0,0,120,9,254,255,253,255,255,255,0,0,242,255,20,0,238,255,222,5,2,0,0,9,254,255,255,255,255,255,82,235

        // 说明文件
        // http://www.feiyu-tech.com/download.php?id=42
        public int data3_00_len;                // 数据长度 18
        public int data3_01_start;              // 指令标识
        public int[] data3_0203_pitch;          // 俯仰姿态 单位十分之一度
        public int[] data3_0405_roll;           // 横滚姿态 单位十分之一度
        public int[] data3_0607_aileron;        // 副翼舵量 1000~2000
        public int[] data3_0809_elevator;       // 升降舵舵量 1000~2000
        public int[] data3_1011_throttle;       // 油门舵量 1000~2000
        public int[] data3_1213_rudder;         // 方向舵舵量 1000~2000
        public int[] data3_1415_att_err;        // 姿态误差 0~1000
        public int data3_16_sky_hz;             // 空速刷新
        public int[] data3_1718_sum_distance;   // 飞行距离
        public int[] data3_1920_home_distance;  // 回家距离
        public int[] data3_2122_time;           // 飞行时间

        public int data3_51_mod;                // 所有数据累加和取余
        public int data3_52_end;                // 结束标识符


        /// <summary>
        /// 
        /// </summary>
        /// <param name="data3"></param>
        public OSDData3(string data3)
        {
            #region 初始化
            data3_00_len = 0;
            data3_01_start = 0;
            data3_0203_pitch = new int[2] { 0, 0 };
            data3_0405_roll = new int[2] { 0, 0 };
            data3_0607_aileron = new int[2] { 0, 0 };
            data3_0809_elevator = new int[2] { 0, 0 };
            data3_1011_throttle = new int[2] { 0, 0 };
            data3_1213_rudder = new int[2] { 0, 0 };
            data3_1415_att_err = new int[2] { 0, 0 };
            data3_16_sky_hz = 0;
            data3_1718_sum_distance = new int[2] { 0, 0 };
            data3_1920_home_distance = new int[2] { 0, 0 };
            data3_2122_time = new int[2] { 0, 0 };

            data3_51_mod = 0;
            data3_52_end = 0;
            #endregion

            int[] data3_ints = ToInts(data3);

            if (data3_ints.Length >= 53) {
                data3_00_len = data3_ints[0];
                data3_01_start = data3_ints[1];
                data3_0203_pitch = new int[2] { data3_ints[2], data3_ints[3] };
                data3_0405_roll = new int[2] { data3_ints[4], data3_ints[5] };
                data3_0607_aileron = new int[2] { data3_ints[6], data3_ints[7] };
                data3_0809_elevator = new int[2] { data3_ints[8], data3_ints[9] };
                data3_1011_throttle = new int[2] { data3_ints[10], data3_ints[11] };
                data3_1213_rudder = new int[2] { data3_ints[12], data3_ints[13] };
                data3_1415_att_err = new int[2] { data3_ints[14], data3_ints[15] };
                data3_16_sky_hz = data3_ints[16];
                data3_1718_sum_distance = new int[2] { data3_ints[17], data3_ints[18] };
                data3_1920_home_distance = new int[2] { data3_ints[19], data3_ints[20] };
                data3_2122_time = new int[2] { data3_ints[21], data3_ints[22] };

                data3_51_mod = data3_ints[51];
                data3_52_end = data3_ints[52];
            }
        }

    }
}
