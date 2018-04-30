namespace WebCrawler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class WebCrawlerProgram
    {
        public static void Main()
        {
            var crawler = new WebCrawler();

            for (var i = 0; i < 1000; i++)
            {
                crawler.AddPendingUrl("https://www.zerohedge.com/?page=" + i);
            }

            crawler.Run("https://www.zerohedge.com/");
        }   
    }
}
