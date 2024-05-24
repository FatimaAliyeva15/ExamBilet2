using HeroBiz_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroBiz_Business.Services.Abstracts
{
    public interface IOurService
    {
        void AddService(OurService service);
        void DeleteService(int id);
        void UpdateService(int id, OurService service);
        OurService GetService(Func<OurService, bool>? func = null);
        List<OurService> GetAllServices(Func<OurService, bool>? func = null);
    }
}
