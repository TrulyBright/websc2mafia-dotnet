using System;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Example
{
    public class Chat : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            Sessions.Broadcast(e.Data);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var wssv = new WebSocketServer("ws://localhost:8000");

            wssv.AddWebSocketService<Chat>("/");
            wssv.Start();
            Console.ReadKey(true);
            wssv.Stop();
        }
    }
}