using System;
using Quobject.SocketIoClientDotNet.Client;
using System.Threading;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Linq;
namespace csharp
{
    public static class SocketIOExample
    {
        private static readonly String USER_ID = "HypW9sEVE";
        private static readonly String USER_KEY = "463e501e5f66b72987d13770406b7b3f8e11f98f0add9ff1";
        private static readonly string TOPIC_ID = "rkxsfcsVN4";

        public static void ExampleMain()
        {
            Console.WriteLine("Connecting...");

            var url = "https://socket.ubsub.io";
            var manager = new Manager(new Uri(url));
            var sock = manager.Socket("/socket");

            sock.On(Socket.EVENT_CONNECT, () =>
            {
                Console.WriteLine("Connected!");
                var data = JObject.FromObject(new
                {
                    userId = USER_ID,
                    userKey = USER_KEY,
                    topicId = TOPIC_ID,
                });
                sock.Emit("subscribe", data);
            });

            sock.On(Socket.EVENT_ERROR, err =>
            {
                Console.WriteLine(err);
            });

            sock.On("event", data =>
            {
                Console.WriteLine(data);
            });

            while(true)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }
    }
}
