using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using TestTask.Models;

namespace TestTask.Services
{
    public class RequestTime:IRequestTime
    {
        public List<UrlMeasurement> SendRequest(SortedSet<string> linkList, int countRequest)
        {
           List<UrlMeasurement> list = new List<UrlMeasurement>();
            Parallel.ForEach(linkList, (page) =>
            {
                HttpWebResponse response;
                Stopwatch timer = new Stopwatch();
                List<int> timeRequest = new List<int>();
                for (int i = 0; i < countRequest; i++)
                {
                    try
                    {
                        Thread.Sleep(100);
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(page);
                        timer.Start();
                        response = (HttpWebResponse)request.GetResponse();
                    }
                    catch (WebException ex)
                    {
                        response = ex.Response as HttpWebResponse;
                    }
                    finally
                    {
                        timer.Stop();
                        TimeSpan timeTaken = timer.Elapsed;
                        timeRequest.Add(timeTaken.Milliseconds);
                    }
                }
                list.Add(new UrlMeasurement { Url = page, MaxTime = timeRequest.Max(), MinTime = timeRequest.Min() });
            });
            return list.OrderByDescending(x=>x.MaxTime).ToList<UrlMeasurement>();
        }
    }
}