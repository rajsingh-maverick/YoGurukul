using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoGurukul.Entities.Models;
using YoGurukul.Repository;

namespace YoGurukul.Services
{

    public class GuruService : EntityService<Teacher>, IGuruService 
    {
        IUnitOfWork _unitOfWork;
        IGuruRepository _guruRepository;

        public GuruService(IUnitOfWork unitOfWork, IGuruRepository guruRepository)
          : base(unitOfWork, guruRepository)
      {
            _unitOfWork = unitOfWork;
            _guruRepository = guruRepository;
        }


        public Teacher GetById(long Id)
        {
            return _guruRepository.GetById(Id);
        }
    }
}
