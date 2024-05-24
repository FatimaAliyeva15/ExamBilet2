using HeroBiz_Business.Exceptions;
using HeroBiz_Business.Services.Abstracts;
using HeroBiz_Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FileNotFoundException = HeroBiz_Business.Exceptions.FileNotFoundException;

namespace Exam_HeroBiz.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OurServController : Controller
    {
        private readonly IOurService _service;

        public OurServController(IOurService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            List<OurService> ourServices = _service.GetAllServices();
            return View(ourServices);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(OurService service)
        {
            if(!ModelState.IsValid) 
                return View();

            try
            {
                _service.AddService(service);
            }
            catch (NullReferenceException ex)
            {
                return NotFound();
            }
            catch(ImageRequireException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch(FileContentTypeException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch(FileSizeException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var existService = _service.GetService(x  => x.Id == id);
            if(existService == null)
                return NotFound();

            try
            {
                _service.DeleteService(id);
            }
            catch(EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch(FileNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }


            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var existService = _service.GetService(x => x.Id == id);
            if (existService == null)
                return NotFound();

            return View();
        }

        [HttpPost]
        public IActionResult Update(int id, OurService service)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                _service.UpdateService(id, service);
            }
            catch (NullReferenceException ex)
            {
                return NotFound();
            }
            catch (ImageRequireException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch (FileContentTypeException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch (FileSizeException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction("Index");
        }
    }
}
