using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCWeiXin.Common
{
    public class RandomController
    {
         #region Member Variables

        //待随机抽取数据集合
        public List<char> datas ;

        //权值
        public List<int> weights ;

        #endregion

        #region Contructors

        /// <summary>
        /// 构造函数,第二参数为无奖概率,第三参数为有奖概率,tags为有奖，SourceFrom为无奖
        /// </summary>
        /// <param name="count">随机抽取个数</param>
        public RandomController(char[] data,int[] value)
        {


            datas = new List<char>(data);
            weights = new List<int>(value);//new int[] { a, b }
          
        }

        #endregion

        #region Method

        #region 普通随机抽取

        /// <summary>
        /// 随机抽取
        /// </summary>
        /// <param name="rand">随机数生成器</param>
        /// <returns></returns>
        public char[] RandomExtract(Random rand)
        {
            List<char> result = new List<char>();
            if (rand != null)
            {
                for (int i = Count; i > 0; )
                {
                    char item = datas[rand.Next(datas.Count)];
                    if (result.Contains(item))
                        continue;
                    else
                    {
                        result.Add(item);
                        i--;
                    }
                }
            }
            return result.ToArray();
        }

        #endregion

        #region 受控随机抽取

        /// <summary>
        /// 随机抽取
        /// </summary>
        /// <param name="rand">随机数生成器</param>
        /// <returns></returns>
        public char[] ControllerRandomExtract(Random rand)
        {
            List<char> result = new List<char>();
            if (rand != null)
            {
                //临时变量
                Dictionary<char, int> dict = new Dictionary<char, int>(datas.Count + 1);

                //为每个项算一个随机数并乘以相应的权值
                for (int i = datas.Count - 1; i >= 0; i--)
                {
                    
                    int a = rand.Next(4) * weights[i];
                    if (weights[i] != 0)
                    {
                        dict.Add(datas[i], rand.Next(4) * weights[i]);
                    }
                }

                //排序
                List<KeyValuePair<char, int>> listDict = SortByValue(dict);

                //拷贝抽取权值最大的前Count项
                foreach (KeyValuePair<char, int> kvp in listDict.GetRange(0, dict.Count))
                {
                    result.Add(kvp.Key);
                }
            }
            return result.ToArray();
        }

        #endregion

        #region Tools

        /// <summary>
        /// 排序集合
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        private List<KeyValuePair<char, int>> SortByValue(Dictionary<char, int> dict)
        {
            List<KeyValuePair<char, int>> list = new List<KeyValuePair<char, int>>();

            if (dict != null)
            {
                list.AddRange(dict);

                list.Sort(
                  delegate(KeyValuePair<char, int> kvp1, KeyValuePair<char, int> kvp2)
                  {
                      return kvp2.Value - kvp1.Value;
                  });
            }
            return list;
        }


        #endregion

        #endregion

        #region Properties

        private int _Count;
        /// <summary>
        /// 随机抽取个数
        /// </summary>
        public int Count
        {
            get
            {
                return _Count;
            }
            set
            {
                _Count = value;
            }
        }

        #endregion
    }
}
