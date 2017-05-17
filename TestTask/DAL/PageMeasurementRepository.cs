using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestTask.Models;

namespace TestTask.DAL
{
    public class PageMeasurementRepository: IDisposable,IPageMeasurementRepository
    {
        private PageMeasurementContext _db = new PageMeasurementContext();
        public void SaveDomain(DomainModel domainToSave)
        {
            _db.Domains.Add(domainToSave);
            _db.SaveChanges();
        }
        public IEnumerable<DomainModel> GetDomains()
        {
            return _db.Domains;
        }
        public void SaveMeasurements(UrlMeasurement measurement)
        {
            _db.UrlsMeasurement.Add(measurement);
            _db.SaveChanges();
        }
        public IEnumerable<UrlMeasurement> GetMeasurements()
        {
            return _db.UrlsMeasurement;
        }
        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_db != null)
                {
                    _db.Dispose();
                    _db = null;
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}