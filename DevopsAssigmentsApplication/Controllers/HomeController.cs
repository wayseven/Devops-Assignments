using DevopsAssigmentsApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;

namespace DevopsAssigmentsApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ConvertorContext _context;
        public HomeController(ConvertorContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(new ConversionViewModel());
        }

        [HttpPost]
        public IActionResult Index(string json)
        {
            var conversion = new ConversionViewModel { Input = json };
            try
            {
                XNode node = JsonConvert.DeserializeXNode(json, "Root");
                conversion.Output = node.ToString();
                _context.Conversions.Add(new ConversionModel
                {
                    Id = Guid.NewGuid(),
                    Input = conversion.Input,
                    Output = conversion.Output,
                    Success = true,
                    CreatedAt = DateTime.Now
                });
                _context.SaveChanges();
            }
            catch (Exception)
            {
                conversion.Output = "Invalid JSON";

                _context.Conversions.Add(new ConversionModel
                {
                    Id = Guid.NewGuid(),
                    Input = conversion.Input,
                    Output = conversion.Output,
                    Success = false,
                    CreatedAt = DateTime.Now
                });
                _context.SaveChanges();

                return View(conversion);
            }            

            return View(conversion);
        }

        public IActionResult Results()
        {
            var conversionModels = new List<ConversionViewModel>();

            foreach (var conversion in _context.Conversions) 
            {
                conversionModels.Add(new ConversionViewModel { 
                    Id = conversion.Id,
                    Input = conversion.Input,
                    Output = conversion.Output,
                    CreatedAt = conversion.CreatedAt.ToString("dd.MM.yyyy HH:mm"),
                    Success = conversion.Success
                });
            }

            return View(conversionModels);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
