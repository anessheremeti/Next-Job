// using System;
// using System.Net.WebSockets;
// using System.Text;
// using System.Threading;
// using System.Threading.Tasks;

// class MultipleClients
// {
//     public static async Task Main(string[] args)
//     {
//         using var ws = new ClientWebSocket();

//         Console.Write("Input name: ");
//         string? name = Console.ReadLine();

//         Console.WriteLine("Connecting to server");
//         await ws.ConnectAsync(new Uri($"ws://localhost:6969/ws?name={name}"), CancellationToken.None);
//         Console.WriteLine("Connected!");

//         var receiveTask = Task.Run(async () =>
//         {
//             var buffer = new byte[1024 * 4];
//             while (ws.State == WebSocketState.Open)
//             {
//                 try
//                 {
//                     var result = await ws.ReceiveAsync(
//                         new ArraySegment<byte>(buffer),
//                         CancellationToken.None);

//                     if (result.MessageType == WebSocketMessageType.Close)
//                         break;

//                     var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
//                     Console.WriteLine(message);
//                 }
//                 catch (Exception ex)
//                 {
//                     Console.WriteLine($"Receive error: {ex.Message}");
//                     break;
//                 }
//             }
//         });

//         var sendTask = Task.Run(async () =>
//         {
//             while (ws.State == WebSocketState.Open)
//             {
//                 string? message = Console.ReadLine();

//                 if (string.IsNullOrWhiteSpace(message))
//                     continue;

//                 if (message.Equals("exit", StringComparison.OrdinalIgnoreCase))
//                     break;

//                 var bytes = Encoding.UTF8.GetBytes(message);
//                 await ws.SendAsync(
//                     new ArraySegment<byte>(bytes),
//                     WebSocketMessageType.Text,
//                     true,
//                     CancellationToken.None
//                 );
//             }
//         });


//         await Task.WhenAny(sendTask, receiveTask);

//         if (ws.State != WebSocketState.Closed)
//         {
//             await ws.CloseAsync(WebSocketCloseStatus.NormalClosure,
//                 "Closing", CancellationToken.None);
//         }

//         await Task.WhenAll(sendTask, receiveTask);
//     }
// }
