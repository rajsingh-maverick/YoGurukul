using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoGurukul.DataContract
{
  public class Helper
    {
        Helper()
        {
            Mapper.CreateMap<UserDco, Entities.Models.User>();
        }  
    }
}
