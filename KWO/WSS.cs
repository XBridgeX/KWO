using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fleck;
using XBridge.Utils;
using XBridge.WSPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace KWO
{
    public class WSS
    {
        private WebSocketServer wss;
        private string k;
        private string iv;
        static Dictionary<IWebSocketConnection, string> sockets;
        public string tmpid;
        public WSS(int port,string key)
        {
            k = MD5.MD5Encrypt(key).Substring(0, 16);
            iv = MD5.MD5Encrypt(key).Substring(16);
            sockets = new Dictionary<IWebSocketConnection, string>();
            wss = new WebSocketServer($"ws://0.0.0.0:{port}");
            wss.Start(socket =>
            {
                socket.OnOpen = () =>
                {
                    if (!sockets.ContainsKey(socket))
                    {
                        addLine($"[WS] connect with [{socket.ConnectionInfo.ClientIpAddress}:{socket.ConnectionInfo.ClientPort}]");
                        sockets.Add(socket, string.Empty);
                    }
                    else
                    {
                    }
                };
                socket.OnMessage = (m) =>
                {
                    try
                    {
                        Onmessage(socket,m);
                    }
                    catch { }

                };
                socket.OnClose = () =>
                {
                    if (sockets.ContainsKey(socket))
                    {
                        addLine($"[WS] connect lost [{socket.ConnectionInfo.ClientIpAddress}:{socket.ConnectionInfo.ClientPort}]");
                        sockets.Remove(socket);
                    }
                };
                socket.OnError = (e) =>
                {
                    if (sockets.ContainsKey(socket))
                    {
                        addLine($"[WS] connect error whit [{socket.ConnectionInfo.ClientIpAddress}:{socket.ConnectionInfo.ClientPort}]:{e.Message}");
                        //sockets.Remove(socket); 
                        socket.Close();
                    }
                };
            });
        }
        private void addLine(string t)
        {
            Form1.console.AppendText(t+Environment.NewLine);
        }
        public void sendClose()
        {
            foreach (var o in sockets)
            {
                var p = new
                {
                    type = "pack",
                    cause = "stop",
                    @params = new { }
                };
                o.Key.Send(Encrypt.Encrypted(JsonConvert.SerializeObject(p), k, iv));
            }
        }
        public void sendStart()
        {
            foreach (var o in sockets)
            {
                var p = new
                {
                    type = "pack",
                    cause = "start",
                    @params = new { }
                };
                o.Key.Send(Encrypt.Encrypted(JsonConvert.SerializeObject(p), k, iv));
            }
        }
        public void sendPlanText(string t)
        {
            foreach (var o in sockets)
            {
                var p = new
                {
                    type = "pack",
                    cause = "plantext",
                    @params = new @params
                    {
                        text = t
                    }
                };
                o.Key.Send(Encrypt.Encrypted(JsonConvert.SerializeObject(p), k, iv));
            }
        }
        public void sendCMD(string output)
        {
            foreach(var o in sockets)
            {
                if(o.Value == tmpid)
                {
                    var p = new Result()
                    {
                        @params = new @params()
                        {
                            id = tmpid,
                            result = output
                        }
                    };
                    o.Key.Send(Encrypt.Encrypted(JsonConvert.SerializeObject(p),k,iv));
                }
            }
        }
        public void sendChat(string sender, string text)
        {
            foreach(var i in sockets)
            {
                var p = new
                {
                    type = "pack",
                    cause = "chat",
                    @params = new @params()
                    {
                        sender = sender,
                        text = text
                    }
                };
                i.Key.Send(Encrypt.Encrypted(JsonConvert.SerializeObject(p), k, iv));
            }
        }
        public string sendError(string msg)
        {
            var p = new
            {
                type = "pack",
                cause = "decodefailed",
                @params = new @params
                {
                    msg = msg
                }
            };
            return JsonConvert.SerializeObject(p);
        }
        public void sendEvent(string ev,string sender)
        {
            foreach (var i in sockets)
            {
                var p = new
                {
                    type = "pack",
                    cause = ev,
                    @params = new @params()
                    {
                        sender = sender
                    }
                };
                i.Key.Send(Encrypt.Encrypted(JsonConvert.SerializeObject(p), k, iv));
            }
        }
        public string GetDebugPack(string m)
        {
            var p = new
            {
                type = "pack",
                cause = "debug",
                @params = new @params()
                {
                    msg = m
                }
            };
            return Encrypt.Encrypted(JsonConvert.SerializeObject(p), k, iv);
        }
        public void runcmd(string cmd)
        {
            addLine($"runcmd >> {cmd}");
            Form1.rt = true;
            Form1.bds.StandardInput.WriteLine(Form1.bds.StandardInput.Encoding.GetString(Encoding.UTF8.GetBytes(cmd)));
        }
        private void Onmessage(IWebSocketConnection socket, string m)
        {
            var raw = JObject.Parse(m);
            if(raw["type"].ToString() == "pack")
            {
                socket.Send(Encrypt.Encrypted(sendError("服务端请求使用加密数据包"), k, iv));
                return;
            }
            string rawtext = AES.AesDecrypt(raw["params"]["raw"].ToString(), k, iv);
            JObject jj = JObject.Parse(rawtext);
            var j = JsonConvert.DeserializeObject<@params>(jj["params"].ToString());
            switch (jj["action"].ToString())
            {
                case "runcmdrequest":
                    try
                    {
                        if (Form1.bds.HasExited)
                        {
                            socket.Send(Encrypt.Encrypted(sendError("服务器未开启"),k,iv));
                            return;
                        }
                        sockets[socket] = j.id;
                        tmpid = j.id;
                        runcmd(j.cmd);
                    }
                    catch (Exception e) { Form1.console.AppendText($"[WS][ERROR] error when runcmd >>{e.Message}<<" + Environment.NewLine); }
                    break;
                case "sendtext":
                    try
                    {
                        SendAllText(j.text);
                    }
                    catch (Exception e) { Form1.console.AppendText($"[WS][ERROR] error when sendText >>{e.Message}<<" + Environment.NewLine); }
                    break;
                case "stop":
                    if(Form1.bds.HasExited == false)
                    {
                        Form1.bds.StandardInput.WriteLine(Encoding.UTF8.GetBytes("stop"));
                        socket.Send(GetDebugPack("正在请求关闭服务器"));
                    }
                    else
                    {
                        socket.Send(GetDebugPack("请求失败：服务器已关闭"));
                    }
                    break;
                case "start":
                    if (Form1.bds.HasExited)
                    {
                        Form1.MainForm.start_bds();
                        socket.Send(GetDebugPack("正在请求开启服务器"));
                    }
                    else
                    {
                        socket.Send(GetDebugPack("请求失败：服务器已开启"));
                    }
                    break;
                default:
                    break;
            }
        }
        private void SendAllText(string t)
        {
            try
            {
                Form1.bds.StandardInput.WriteLine(Encoding.UTF8.GetBytes("tellraw @a {\"rawtext\":[{\"text\":\"" + StringToUnicode(t) + "\"}]}"));
            }
            catch { }

        }
        /// <summary>
        /// 字符串转Unicode 直接Byte的方式，单字节操作
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <returns>Unicode编码后的字符串</returns>
        public static string StringToUnicode(string source)
        {
            var bytes = Encoding.Unicode.GetBytes(source);
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < bytes.Length; i += 2)
            {
                stringBuilder.AppendFormat("\\u{0:x2}{1:x2}", bytes[i + 1], bytes[i]);
            }
            return stringBuilder.ToString();
        }
    }
}
