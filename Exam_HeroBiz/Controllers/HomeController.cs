
using HeroBiz_Business.Services.Abstracts;
using HeroBiz_Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Exam_HeroBiz.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOurService _service;

        public HomeController(IOurService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            List<OurService> ourServices = _service.GetAllServices();
            return View(ourServices);
        }

    }
}