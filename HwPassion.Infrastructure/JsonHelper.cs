using System.Text.RegularExpressions;

namespace HwPassion.Infrastructure
{
    public class JsonHelper
    {
        /// <summary>
        /// 过滤json字符串，去除\\，把HTML中的"替换成'
        /// </summary>
        /// <param name="strJson"></param>
        /// <returns></returns>
        private static string FilterJson(string strJson)
        {
            var filterJson = strJson.Replace("\\", "");
            var listMatch = new Regex("<.*?>").Matches(filterJson);
            foreach (var strMatch in listMatch)
            {
                filterJson = filterJson.Replace(strMatch.ToString(), strMatch.ToString().Replace("\"", "'"));
            }
            return filterJson;
        }
    }
}
