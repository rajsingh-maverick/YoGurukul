using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoGurukul.Entities.Models;

namespace YoGurukul.Repository
{
   public interface IGuruRepository:IRepository<Teacher>
    {
        Teacher GetById(long id);
    }
}
