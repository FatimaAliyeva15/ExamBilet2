using HeroBiz_Core.Models;
using HeroBiz_Core.RepositoryAbstracts;
using HeroBiz_Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroBiz_Data.RepositoryConcretes
{
    public class OurServiceRepository : GenericRepository<OurService>, IOurServiceRepository
    {
        public OurServiceRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
