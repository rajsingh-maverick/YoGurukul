using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoGurukul.Entities.Models;

namespace YoGurukul.Repository
{

    public class GuruRepository : RepositoryBase<Teacher>, IGuruRepository
    {
        public GuruRepository(YoGurukulContext context) : base(context)
        {

        }

        public override IEnumerable<Teacher> GetAll()
        {
            return _entities.Set<Teacher>().AsEnumerable();
        }

        public Teacher GetById(long id)
        {
            return _dbset.Where(x => x.TeacherId == id).FirstOrDefault();
        }
    }
}
