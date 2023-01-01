using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RoleService
    {
        public static List<RoleDTO> Get()
        {
            var dbdata = DataAccessFactory.RoleDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Role, RoleDTO>());
            var mapper = new Mapper(config);
            var data = mapper.Map<List<RoleDTO>>(dbdata);
            return data;
        }
        public static RoleDTO Get(int id)
        {
            var dbdata = DataAccessFactory.RoleDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Role, RoleDTO>());
            var mapper = new Mapper(config);
            var data = mapper.Map<RoleDTO>(dbdata);
            return data;
        }
        public static bool Add(RoleDTO dto)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<RoleDTO, Role>();
                cfg.CreateMap<Role, RoleDTO>();
            });
            var mapper = new Mapper(config);
            var group = mapper.Map<Role>(dto);
            var result = DataAccessFactory.RoleDataAccess().Add(group);
            return result;
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.RoleDataAccess().Delete(id);
        }

        public static void Update(Role dto)
        {

            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<RoleDTO, Role>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Role>(dto);
            DataAccessFactory.RoleDataAccess().Update(data);
        }
    }
}
