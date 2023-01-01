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
    public class ReportService
    {
        public static List<ReportDTO> Get()
        {
            var dbdata = DataAccessFactory.ReportDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Report, ReportDTO>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<ReportDTO>>(dbdata);
            return data;
        }
        public static ReportDTO Get(int id)
        {
            var dbdata = DataAccessFactory.ReportDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Report, ReportDTO>());
            var mapper = new Mapper(config);
            var data = mapper.Map<ReportDTO>(dbdata);
            return data;
        }
        public static bool Add(ReportDTO dto)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ReportDTO, Report>();
                cfg.CreateMap<Report, ReportDTO>();
                
            });
            var mapper = new Mapper(config);
            var group = mapper.Map<Report>(dto);
            var result = DataAccessFactory.ReportDataAccess().Add(group);
            return result;
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.ReportDataAccess().Delete(id);
        }
        public static void Update(Report dto)
        {

            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<ReportDTO, Report>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Report>(dto);
            DataAccessFactory.ReportDataAccess().Update(data);
        }
    }
}
