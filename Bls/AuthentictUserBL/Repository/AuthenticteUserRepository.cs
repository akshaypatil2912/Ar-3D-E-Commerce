using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseforDbConncetion;
using Microsoft.EntityFrameworkCore;
using CommonLib.Repository;
using CommonLib.Model;



namespace AuthentictUserBL.Repository
{
    public class AuthenticteUserRepository : IUserRepository
    {
        MyDbContext _myDbContext;
        public AuthenticteUserRepository(MyDbContext myDbContext) 
        {
            _myDbContext=myDbContext;
        }

        public int RegisterUser(Registerusermodel model)
        {
            int  result = _myDbContext.Database.ExecuteSqlInterpolated
                ($"CALL RegisterUserDetails({model.UserName}, {model.Password}, {model.Email})");
             
            return result;
        }

        public UserModel GetUserDetils(string username)
        {
            var user = _myDbContext.Users
                .FromSqlInterpolated($"CALL GetUserDetailsByUserName({username})")
                .AsEnumerable()
                .FirstOrDefault();
            return user;
        }

        public UserModel Authenticte(UserModel usermodel)
        {
            var user = _myDbContext.Users
                .FromSqlInterpolated($"CALL AuthenticateUser({usermodel.UserName}, {usermodel.Password})")
                .AsEnumerable()
                .FirstOrDefault();

            return user;
            
        }
    }
}
