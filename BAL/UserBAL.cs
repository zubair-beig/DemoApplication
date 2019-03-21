using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace BAL
{
    public class UserBAL
    {
        UserDAL _userBAL = new UserDAL();
        public bool SaveUser(User user)
        {
            string HashedPassword = HashGen.GetHashString(user.Password);
            user.Password = HashedPassword;
           return _userBAL.SaveUser(user)!= null ?true:false;
        }
        public string LoginUser(LoginUser user)
        {
            string HashedPassword = HashGen.GetHashString(user.Password);
            user.Password = HashedPassword;
            if (_userBAL.ValidateUser(user))
            {
                string Token = new SecurityBAL().GenerateToken();
                SaveToken(Token);
                return Token;
            }
            return string.Empty;
        }
        public bool SaveToken(string token)
        {
            return new TokenDAL().SaveToken(token);
        }

        public bool IsTokenValid(string Token)
        {
           return new TokenDAL().ValidateToken(Token);
        }

    }
}
