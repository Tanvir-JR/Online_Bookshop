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
    public class PaymentService
    {
        public static List<PaymentDTO> Get()
        {
            var dbdata = DataAccessFactory.PaymentDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Payment, PaymentDTO>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<PaymentDTO>>(dbdata);
            return data;
        }
        public static PaymentDTO Get(int id)
        {
            var dbdata = DataAccessFactory.PaymentDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Payment, PaymentDTO>());
            var mapper = new Mapper(config);
            var data = mapper.Map<PaymentDTO>(dbdata);
            return data;
        }
        public static bool Add(PaymentDTO dto)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<PaymentDTO, Payment>();
                cfg.CreateMap<Payment, PaymentDTO>();
                
            });
            var mapper = new Mapper(config);
            var group = mapper.Map<Payment>(dto);
            var result = DataAccessFactory.PaymentDataAccess().Add(group);
            return result;
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.PaymentDataAccess().Delete(id);
        }
        public static void Update(Payment dto)
        {

            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<PaymentDTO, Payment>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Payment>(dto);
            DataAccessFactory.PaymentDataAccess().Update(data);
        }
    }
}
