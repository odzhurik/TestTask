using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestTask.Models;

namespace TestTask.DAL
{
    public class PageMeasurementContext:DbContext 
    {
        public PageMeasurementContext():base("PageMeasurementConnection")
        {

        }
        public DbSet<UrlMeasurement> UrlsMeasurement { get; set; }
        public DbSet<DomainModel> Domains { get; set; }
    }
}