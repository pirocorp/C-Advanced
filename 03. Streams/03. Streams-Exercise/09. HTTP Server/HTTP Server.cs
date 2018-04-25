namespace _09.HTTP_Server
{
    using System;
    using System.Text;
    using System.Net;
    using System.Net.Sockets;
    using System.IO;


    public class Program
    {
        private const int PortNumber = 8000;
        private const string HttpOK = "HTTP/1.1 200 OK\nContent-Type:text\n\n";

        public static void Main()
        {
            var tcpListener = new TcpListener(IPAddress.Any, PortNumber);

            tcpListener.Start();
            Console.WriteLine("Listening on port {0}...", PortNumber);

            while (true)
            {
                using (NetworkStream stream = tcpListener.AcceptTcpClient().GetStream())
                {
                    var request = new byte[4096];
                    var readBytes = stream.Read(request, 0, 4096);

                    var requestTokens = Encoding.UTF8.GetString(request, 0, readBytes)
                        .Split(new []{ " " }, StringSplitOptions.RemoveEmptyEntries);

                    var path = requestTokens[1].ToLower();

                    var html = HttpOK;

                    switch (path)
                    {
                        case "/info":
                            html += File.ReadAllText("../../info.html");
                            html = html.Replace("{0}", $"{DateTime.Now}");
                            html = html.Replace("{1}", $"{Environment.ProcessorCount}");
                            break;
                        case "/index":
                        case "/":
                            html += File.ReadAllText("../../index.html");
                            break;
                        default:
                            html += File.ReadAllText("../../error.html");
                            break;
                    }

                    var htmlBytes = Encoding.UTF8.GetBytes(html);

                    stream.Write(htmlBytes, 0, htmlBytes.Length);
                }
            }
        }
    }
}
