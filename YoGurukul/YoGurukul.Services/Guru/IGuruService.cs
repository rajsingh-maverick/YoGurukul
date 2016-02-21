using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoGurukul.Entities.Models;

namespace YoGurukul.Services
{
    interface  IGuruService : IEntityService<Teacher>
    {
        Teacher GetById(long Id);
    }
}
