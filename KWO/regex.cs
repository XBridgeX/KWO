using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using XBridge.Config;

namespace KWO
{
    class regex
    {
        public static List<RegexItem> regexs = new List<RegexItem>();
        public static void on_regex(string input)
        {
            foreach (var i in regexs)
            {
                Match mat = Regex.Match(input, i.Regex);
                if (mat.Success)
                {
                    Form1.tmplog.Clear();
                    string o = i.@out.text;
                    for (int io = 1; io < mat.Groups.Count; io++)
                    {
                        o = o.Replace($"${io}", mat.Groups[io].Value);
                    }
                    o = buildString(o);
                    try
                    {
                        on_regex_item(i.@out, o);
                    }
                    catch { }
                    
                }
            }
        }
        private static void on_regex_item(Out it, string o)
        {
            switch (it.type) {
                case "chat":
                    Form1.wss.sendChat(o.Split('|')[0], o.Split('|')[1]);
                    break;
                case "join":
                    Form1.wss.sendEvent("join", o);
                    break;
                case "left":
                    Form1.wss.sendEvent("left", o);
                    break;
                case "log":
                    Form1.console.AppendText(o + Environment.NewLine);
                    break;
                case "plantext":
                    Form1.wss.sendPlanText(o);
                    break;
            }
        }
        private static string buildString(string input)
        {
            StringBuilder builder = new StringBuilder(input);
            builder.Replace("%random%", new Random().Next(1, 100).ToString());
            builder.Replace("%datetime%", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            return builder.ToString();
        }
    }
}
namespace XBridge.Config
{
    public class Out
    {
        /// <summary>
        /// 执行模式
        /// </summary>
#pragma warning disable IDE1006 // 命名样式
        public string type { get; set; }
#pragma warning restore IDE1006 // 命名样式
        /// <summary>
        /// 执行命令
        /// </summary>
        public string text { get; set; }
    }

    public class RegexItem
    {
        /// <summary>
        /// 正则主体
        /// </summary>
        public string Regex { get; set; }
        /// <summary>
        /// 响应组
        /// </summary>
        public Out @out { get; set; }
    }
}