using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GMAPStaion
{
    /// <summary>
    /// 任务分段
    /// </summary>
    public class MissionCut
    {
        /// <summary>
        /// 测试
        /// </summary>
        public void Test()
        {
            List<utmpos> tests = new List<utmpos>();
            tests.Add(new utmpos(340600, 2689000, 49));
            tests.Add(new utmpos(340700, 2689000, 49));
            tests.Add(new utmpos(340750, 2689000, 49));
            tests.Add(new utmpos(340800, 2689000, 49));

            LineCut(tests, 30);
        }

        /// <summary>
        /// 任务分段
        /// </summary>
        /// <param name="points">任务航点</param>
        /// <param name="distance">每一段任务长度</param>
        /// <returns></returns>
        public List<utmpos> LineCut(List<utmpos> points, double distance)
        {
            // 1. 航点坐标转墨卡托
            // 2. 任务分段
            // 3. 墨卡托转经纬度
            // 4. 写数据库

            // 结果
            List<utmpos> result = new List<utmpos>();
            // 创建一个堆栈
            Stack<utmpos> stacks = new Stack<utmpos>();
            for (int i = points.Count -1; i >= 0; i--) {
                stacks.Push(points[i]);
            }
            // 
            double total = 0;
            utmpos frompoint = stacks.Pop();
            result.Add(frompoint);              // 添加第一个节点
            for (; stacks.Count > 0; ) {
                utmpos topoint = stacks.Pop();
                // 
                double len = frompoint.GetDistance(topoint);
                if (len + total < distance) {
                    // 还没有达到极限
                    result.Add(topoint);        // 加到结果
                    frompoint = topoint;        // 记录最后一个点
                    total = total + len;        // 线段累加
                    continue;
                }
                else if (len + total > distance) {
                    // 剩下长度不够达到下一个节点
                    double x = 0;
                    double y = 0;
                    double dis = distance - total;
                    GetCutPoint(frompoint.x, frompoint.y, topoint.x, topoint.y, dis, out x, out y);     // 计算中间节点
                    utmpos cutpoint = new utmpos(x, y, frompoint.zone);     // 中间节点
                    result.Add(cutpoint);                                   // 加到结果
                    result.Add(new utmpos(0, 0, 0));                        // 添加分隔 ##
                    frompoint = cutpoint;                                   // 起始点定义到中间节点
                    result.Add(frompoint);                                  // 添加起始点
                    stacks.Push(topoint);                                   // 结束点重新压回堆栈
                    total = 0;                                              // 总长度归零
                    continue;
                }
                else {
                    // 刚刚好
                    result.Add(topoint);                    // 添加结果
                    if (stacks.Count > 0) {
                        // 如果后面还有数据就继续处理
                        result.Add(new utmpos(0, 0, 0));    // 添加分隔 ##
                        frompoint = topoint;                // 记录最后一个点
                        result.Add(frompoint);              // 结果添加新的起始点
                        total = 0;                          // 总长度归零
                    }
                    continue;
                }
            }

            return result;
        }
        /// <summary>
        /// 获取中间点坐标
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="distance"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool GetCutPoint(double x1, double y1, double x2, double y2, double distance, out double x, out double y)
        {
            //直线方程
            //斜截式:y=kx+b
            //截距式:x/a+y/b=1
            //两点式:(x-x1)/(x2-x1)=(y-y1)/(y2-y1)
            //一般式:ax+by+c=0
            //这里用的方法是等比法
            double len = Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));      // 线段长度
            double scale = distance / len;                                              // 比例
            x = x1 + (x2 - x1) * scale;
            y = y1 + (y2 - y1) * scale;
            return true;
        }
    }
}
