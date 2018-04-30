namespace WebCrawler
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;


    public class WebCrawler
    {
        private int workerCount = Environment.ProcessorCount;
        private Task[] workerTasks; 
        private ConcurrentQueue<string> pendingUrls;
        private string host;
        private HashSet<string> downloadedImages;

        public WebCrawler()
        {
            downloadedImages = new HashSet<string>();
            pendingUrls = new ConcurrentQueue<string>();
        }

        public void AddPendingUrl(string url)
        {
            this.pendingUrls.Enqueue(url);
        }

        public void Run(string host)
        {
            if (!Directory.Exists("Files"))
            {
                Directory.CreateDirectory("Files");
            }

            this.host = host;
            workerTasks = new Task[workerCount];

            for (var i = 0; i < workerCount; i++)
            {
                var completed = ExecuteWithTimeLimit(TimeSpan.FromMilliseconds(10000), () =>
                {
                    var task = new Task(RunWorker);
                    workerTasks[i] = task;
                    task.Start();
                });
            }

            //for (var i = 0; i < workerCount; i++)
            //{
            //    workerTasks[i].Wait();
            //}

            Task.WaitAll(workerTasks);
        }

        public void RunWorker()
        {
            while (pendingUrls.Count > 0)
            {
                var url = string.Empty;

                if (!pendingUrls.TryDequeue(out url))
                {
                    break;
                }

                using (var webclient = new WebClient())
                {
                    //Download html
                    var html = webclient.DownloadString(url);

                    //Parse img tags
                    var relativeImageUrls = HtmlParser.ParseImgTags(html);

                    //Download images
                    foreach (var imgUrl in relativeImageUrls)
                    {
                        if (downloadedImages.Contains(imgUrl))
                        {
                            continue;
                        }

                        var fullUrl = host + imgUrl;

                        //if (!fullUrl.Contains("https://softuni.bg//users/profile/showavatar/"))
                        //{
                        //    continue;
                        //}

                        downloadedImages.Add(imgUrl);
                        
                        var filename = imgUrl.Substring(imgUrl.LastIndexOf('/') + 1);
                        var lastIndex = filename.LastIndexOf('?') >= 0 ? filename.LastIndexOf('?') : 0;
                        filename = filename.Substring(0, lastIndex);

                        using (var downloader = new WebClient())
                        {
                            Console.WriteLine($"Downloading: {Task.CurrentId} - {fullUrl}");

                            downloader.DownloadFile(fullUrl, "Files/" + filename + ".jpg");
                            //var contentType = downloader.ResponseHeaders["Content-Type"]
                            //    .Split('/')
                            //    [1];
                        }

                    }
                }
            }
        }

        public static bool ExecuteWithTimeLimit(TimeSpan timeSpan, Action codeBlock)
        {
            try
            {
                Task task = Task.Factory.StartNew(() => codeBlock());
                task.Wait(timeSpan);
                return task.IsCompleted;
            }
            catch (AggregateException ae)
            {
                throw ae.InnerExceptions[0];
            }
        }
    }
}
    