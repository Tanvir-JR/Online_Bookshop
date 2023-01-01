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
    public class BuyService
    {
        public static List<BuyDTO> Get()
        {
            var dbdata = DataAccessFactory.BuyDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Buy, BuyDTO>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<BuyDTO>>(dbdata);
            return data;
        }
        public static BuyDTO Get(int id)
        {
            var dbdata = DataAccessFactory.BuyDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Buy, BuyDTO>());
            var mapper = new Mapper(config);
            var data = mapper.Map<BuyDTO>(dbdata);
            return data;
        }
        public static bool Add(BuyDTO dto)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<BuyDTO, Buy>();
                cfg.CreateMap<Buy, BuyDTO>();
                
            });
            var mapper = new Mapper(config);
            var group = mapper.Map<Buy>(dto);
            var result = DataAccessFactory.BuyDataAccess().Add(group);
            return result;
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.BuyDataAccess().Delete(id);
        }
        public static void Update(Buy dto)
        {

            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<BuyDTO, Buy>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Buy>(dto);
            DataAccessFactory.BuyDataAccess().Update(data);
        }
    }
}
