using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DockerAndMongoSampleWebApp.Models;
using DockerAndMongoSampleWebApp.Infra.MongoDb.Interfaces;
using DockerAndMongoSampleWebApp.Infra.MongoDb.Repository;
using DockerAndMongoSampleWebApp.Domain;
using MongoDB.Driver;

namespace DockerAndMongoSampleWebApp.Controllers
{
    public class HomeController : Controller
    {
        BusinessRepository _businessRepository;
        public HomeController(IConnectionMongo connectionMongo)
        {
            _businessRepository = new BusinessRepository(connectionMongo);
        }

        public IActionResult Index()
        {
            Console.WriteLine("Hello World!");

            var bizConnection = _businessRepository.GetAll();

            return View(new List<Business>());
        }

        public async Task<IActionResult> InsertSampleBusinessAsync()
        {
            try
            {
                for (var i = 1; i < 4; i++)
                {
                    var biz = new Business
                    {
                        Name = "Empresa " + i.ToString(),
                        Cnpj = Guid.NewGuid().ToString("N")
                    };

                    await _businessRepository.InsertAsync(biz);
                }

                return Content("Success!");
            }
            catch (Exception ex)
            {
                return Content("Fail: " + ex.ToString());
            }
        }



        private void testeConn()
        {
            var client = new MongoClient("mongodb://mongodockersample:27099/test");
            var db = client.GetDatabase("test");
            db.CreateCollection("client");
        }

    }
}
