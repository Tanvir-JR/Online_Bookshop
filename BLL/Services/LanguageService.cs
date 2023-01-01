using AutoMapper;
using BLL.DTOs;
using DAL.EF;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class LanguageService
    {
        public static List<LanguageDTO> Get()
        {
            var dbdata = DataAccessFactory.LanguageDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Language, LanguageDTO>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<LanguageDTO>>(dbdata);
            return data;
        }
        public static LanguageDTO Get(int id)
        {
            var dbdata = DataAccessFactory.LanguageDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Language, LanguageDTO>());
            var mapper = new Mapper(config);
            var data = mapper.Map<LanguageDTO>(dbdata);
            return data;
        }
        public static bool Add(LanguageDTO dto)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<LanguageDTO, Language>();
                cfg.CreateMap<Language, LanguageDTO>();
                
            });
            var mapper = new Mapper(config);
            var group = mapper.Map<Language>(dto);
            var result = DataAccessFactory.LanguageDataAccess().Add(group);
            return result;
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.LanguageDataAccess().Delete(id);
        }
        public static void Update(Language dto)
        {

            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<LanguageDTO, Language>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Language>(dto);
            DataAccessFactory.LanguageDataAccess().Update(data);
        }
    }
}
