using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Models;

namespace TestTask.Services
{
    public interface IRequestTime
    {
        List<UrlMeasurement> SendRequest(SortedSet<string> linkList, int countRequest);
    }
}
