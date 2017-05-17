using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Models;

namespace TestTask.DAL
{
    public interface IPageMeasurementRepository
    {
        void SaveDomain(DomainModel domainToSave);
        IEnumerable<DomainModel> GetDomains();
        void SaveMeasurements(UrlMeasurement measurement);
        IEnumerable<UrlMeasurement> GetMeasurements();

    }
}
