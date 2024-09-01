using AuthentictUserBL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLib.Model;
using MySqlX.XDevAPI.Common;
using Mysqlx;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AuthentictUserBL.Service
{
    public class AuthenticteUserService
    {
        AuthenticteUserRepository _authenticteUserRepository;

        public AuthenticteUserService(AuthenticteUserRepository authenticteUserRepository)
        {
            _authenticteUserRepository = authenticteUserRepository;
        }
    
        public UserModel  Authenticte(UserModel usermodel)
        {

            UserModel usersdetails =  _authenticteUserRepository.GetUserDetils(usermodel.UserName);
            if (usersdetails == null) {
                return null; 
            }

            if (usersdetails.Password == usermodel.Password) {
                return usersdetails;
            }
            else
            {
                return null;
            }
        }

        public int RegisterUser(Registerusermodel model)
        {
            int regmodel = _authenticteUserRepository.RegisterUser(model);
            if (regmodel == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
