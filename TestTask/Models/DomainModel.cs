using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTask.Models
{
    public class DomainModel
    {
        public int ID { get; set; }
        public string Domain { get; set; }
        public DateTime RecordTime { get; set; }
        public virtual ICollection<UrlMeasurement> UrlsMeasurements { get; set; }
        public DomainModel()
        {
            UrlsMeasurements = new List<UrlMeasurement>();
        }
    }
}