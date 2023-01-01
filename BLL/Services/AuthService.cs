using BLL.DTOs;
using DAL.EF;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace BLL.Services
{
    public class AuthService
    {
        public static TokenDTO Authenticate(string username, string password)
        {
            var user = DataAccessFactory.AuthDataAccess().Authenticate(username, password);
            if (user != null)
            {
                Token t = new Token();
                t.creationTime = DateTime.Now;
                t.userId = user.id;
                t.expirationTime = null;
                t.tkey = Guid.NewGuid().ToString();
                var rt = DataAccessFactory.TokenDataAccess().Add(t);
                if (rt != null)
                {
                    var config = new MapperConfiguration(cfg => {
                        cfg.CreateMap<Token, TokenDTO>();
                    });
                    var mapper = new Mapper(config);
                    var data = mapper.Map<TokenDTO>(rt);
                    return data;
                }
            }
            return null;
        }
        public static bool TokenValidity(string tkey)
        {
            var token = DataAccessFactory.TokenDataAccess().Get(tkey);
            if (token != null && token.expirationTime == null)
            {
                return true;
            }
            return false;
        }

        public static TokenDTO Logout(string username, string password)
        {
            var user = DataAccessFactory.AuthDataAccess().Authenticate(username, password);
            if (user != null)
            {
                Token t = new Token();
                
                t.expirationTime = DateTime.Now;
                
                var rt = DataAccessFactory.TokenDataAccess().Add(t);
                if (rt != null)
                {
                    var config = new MapperConfiguration(cfg => {
                        cfg.CreateMap<Token, TokenDTO>();
                    });
                    var mapper = new Mapper(config);
                    var data = mapper.Map<TokenDTO>(rt);
                    return data;
                }
            }
            return null;
        }
    }
}
