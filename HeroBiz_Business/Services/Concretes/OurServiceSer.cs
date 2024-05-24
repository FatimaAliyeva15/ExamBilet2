using HeroBiz_Business.Exceptions;
using HeroBiz_Business.Services.Abstracts;
using HeroBiz_Core.Models;
using HeroBiz_Core.RepositoryAbstracts;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HeroBiz_Business.Services.Concretes
{
    public class OurServiceSer : IOurService
    {
        private readonly IOurServiceRepository _ourServiceRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public OurServiceSer(IOurServiceRepository ourServiceRepository)
        {
            _ourServiceRepository = ourServiceRepository;
        }

        public void AddService(OurService service)
        {
            if (service == null)
                throw new NullReferenceException("Service not found");
            if (service.ImgFile == null) 
                throw new ImageRequireException("ImgFile", "Image is required");

            if (!service.ImgFile.ContentType.Contains("image/"))
                throw new FileContentTypeException("ImgFile", "File content type error");
            if (service.ImgFile.Length > 2097152)
                throw new FileSizeException("ImgFile", "File size error");

            string fileName = service.ImgFile.FileName;
            //string path = _webHostEnvironment.WebRootPath + @"\upload\ourservice\" + fileName;
            string path = @"C:\Users\II novbe\Desktop\Praktika-Codlar\praktika 05.04.24\Exam_HeroBiz\wwwroot\upload\ourservice\" + fileName;
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                service.ImgFile.CopyTo(fileStream);
            }
            service.ImgUrl = fileName;

            _ourServiceRepository.Add(service);
            _ourServiceRepository.Commit();
        }

        public void DeleteService(int id)
        {
            var existService = _ourServiceRepository.Get(x => x.Id == id);
            if (existService == null)
                throw new EntityNotFoundException("", "Entity not found");

            //string path = _webHostEnvironment.WebRootPath + @"\upload\ourservice\" + existService.ImgUrl;
            string path = @"C:\Users\II novbe\Desktop\Praktika-Codlar\praktika 05.04.24\Exam_HeroBiz\wwwroot\upload\ourservice\" + existService.ImgUrl;
            if (!File.Exists(path))
                throw new Exceptions.FileNotFoundException("ImgFile", "File not found");

            File.Delete(path);

            _ourServiceRepository.Delete(existService);
            _ourServiceRepository.Commit();
        }

        public List<OurService> GetAllServices(Func<OurService, bool>? func = null)
        {
            return _ourServiceRepository.GetAll(func);
        }

        public OurService GetService(Func<OurService, bool>? func = null)
        {
            return _ourServiceRepository.Get(func);
        }

        public void UpdateService(int id, OurService service)
        {
            var existService = _ourServiceRepository.Get(x => x.Id == id);
            if (existService == null)
                throw new EntityNotFoundException("", "Entity not found");

            if(service.ImgFile != null)
            {
                if (!service.ImgFile.ContentType.Contains("image/"))
                    throw new FileContentTypeException("ImgFile", "File content type error");
                if (service.ImgFile.Length > 2097152)
                    throw new FileSizeException("ImgFile", "File size error");

                string fileName = service.ImgFile.FileName;
                //string path = _webHostEnvironment.WebRootPath + @"\upload\ourservice\" + fileName;
                string path = @"C:\Users\II novbe\Desktop\Praktika-Codlar\praktika 05.04.24\Exam_HeroBiz\wwwroot\upload\ourservice\" + fileName;
                using (FileStream fileStream = new FileStream(path, FileMode.Create))
                {
                    service.ImgFile.CopyTo(fileStream);
                }
                service.ImgUrl = fileName;
                existService.ImgUrl = service.ImgUrl;
            }

            existService.Title = service.Title;
            existService.Description = service.Description;

            _ourServiceRepository.Commit();
        }
    }
}
