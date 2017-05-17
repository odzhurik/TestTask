using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Windows.Forms;
using System.Xml;
using TestTask.DAL;
using TestTask.Models;
using TestTask.Services;

namespace TestTask.Controllers
{
    public class TestController : Controller
    {
        private IPageMeasurementRepository _repository;
        private IRequestTime _requestTime;
        private IUrlParser _urlParser;
        public TestController(IPageMeasurementRepository repository, IRequestTime requestTime, IUrlParser urlParser)
        {
            _repository = repository;
            _requestTime = requestTime;
            _urlParser = urlParser;
        }
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Measure(string Url)
        {
            DomainModel domainModel = new DomainModel();
            domainModel.RecordTime = DateTime.Now;
            Uri myUri = new Uri(Url);
            string domain = myUri.GetLeftPart(UriPartial.Authority);
            domainModel.Domain = domain;
            _urlParser.Domain = domain;
            _urlParser.Depth = 1;
            List<UrlMeasurement> sortedList = _requestTime.SendRequest(_urlParser.GetAllUrls(), 4);
            sortedList.ForEach(x => _repository.SaveMeasurements(x));
            foreach(var url in sortedList)
            {
                domainModel.UrlsMeasurements.Add(url);
            }
            _repository.SaveDomain(domainModel);
            return View(sortedList);
        }
        [HttpGet]
        public JsonResult GetDataToChart(int? domainId)
        {
            List<UrlMeasurement> listPages = _repository.GetMeasurements().Where(x => x.DomainModelID == domainId).ToList<UrlMeasurement>();
            var result = listPages.Select(x => new
            {
                Url = x.Url,
                MaxTime = x.MaxTime
            }
            );

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetSavedMeasurements(int id)
        {
            List<UrlMeasurement> list = _repository.GetMeasurements().Select(x => x).Where(x => x.DomainModelID == id).ToList<UrlMeasurement>();
            return View("Measure", _repository.GetMeasurements().Select(x => x).Where(x => x.DomainModelID == id));
        }
        public ActionResult GetSavedDomains()
        {
            return View(_repository.GetDomains());
        }
    }
}