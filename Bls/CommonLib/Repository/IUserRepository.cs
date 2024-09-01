using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLib.Model;


namespace CommonLib.Repository
{
    public interface IUserRepository
    {
        UserModel Authenticte(UserModel usermodel);
    }
}
