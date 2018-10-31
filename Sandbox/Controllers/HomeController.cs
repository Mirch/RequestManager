using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sandbox.Models;
using SWriter.RequestManager;

namespace Sandbox.Controllers
{
    public class HomeController : Controller
    {
        private RequestSender _requestSender;

        public HomeController()
        {
            _requestSender = new RequestSender("http://localhost:9453/");
        }


        public async Task<IActionResult> Index()
        {
            var getJsonResponse = (await _requestSender.GetAsync("/api/test/json")).ResultAs<Person>(ContentType.JSON);
            ViewData["getJsonResponse"] = getJsonResponse;

            var getXmlResponse = (await _requestSender.GetAsync("/api/test/xml")).ResultAs<Person>(ContentType.XML);
            ViewData["getXmlResponse"] = getXmlResponse;

            var postAndGetJson = (await _requestSender.PostAsync("/api/test/json", new Person() { Id = 2, Name = "John" }))
                                    .ResultAs<Person>(ContentType.JSON);
            ViewData["postAndGetJson"] = postAndGetJson;

            var postAndGetXml = (await _requestSender.PostAsync("/api/test/xml", new Person() { Id=2, Name="John"})).ResultAs<Person>(ContentType.XML);
            ViewData["postAndGetXml"] = postAndGetXml;

            var postFormGetJson = (await _requestSender.PostAsync("/api/test/form", new Person() { Id = 2, Name = "John" }, ContentType.FORM)).ResultAs<Person>();
            ViewData["postFormGetJson"] = postFormGetJson;


            return View();
        }
    }
}
