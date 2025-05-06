using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HelloWorld.WebSocket
{
    public class WebSocketClient
    {
        public async Task StartAsync()
        {
            using var ws = new ClientWebSocket();
            Console.WriteLine("Connecting to server...");
            await ws.ConnectAsync(new Uri("ws://localhost:5123/ws"), CancellationToken.None);
            Console.WriteLine("✅ Connected!");

            // Start receive loop
            var receiveTask = Task.Run(async () =>
            {
                var buffer = new byte[1024];
                while (ws.State == WebSocketState.Open)
                {
                    var result = await ws.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        Console.WriteLine("🚪 Server closed connection.");
                        break;
                    }

                    var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    Console.WriteLine("📥 Received: " + message);
                }
            });

            // Send loop: read from terminal and send to server
            while (ws.State == WebSocketState.Open)
            {
                Console.Write("📤 Send: ");
                var input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                    continue;

                if (input.Equals("exit", StringComparison.CurrentCultureIgnoreCase))
                {
                    await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, "Client closed", CancellationToken.None);
                    break;
                }

                var bytes = Encoding.UTF8.GetBytes(input);
                await ws.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, CancellationToken.None);
            }

            await receiveTask;
        }
    }
}
