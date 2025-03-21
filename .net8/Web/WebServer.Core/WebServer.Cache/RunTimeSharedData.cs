using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Cache
{
    public class RunTimeSharedData
    {
        /// <summary>
        /// websocket连接
        /// </summary>
        public static ConcurrentDictionary<string, WebSocket> WebSocketConnections = new();




    }
}
