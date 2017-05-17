using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTask.Models
{
    public class UrlMeasurement
    {
        public int ID { get; set; }
        public int? DomainModelID { get; set; }
        public string Url { get; set; }
        public int MaxTime { get; set; }
        public int MinTime { get; set; }
        public virtual DomainModel Domain { get; set; }
    }
}