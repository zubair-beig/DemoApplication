using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace BAL
{
    public class SecurityBAL
    {
        public bool IsTokenValid(string Token)
        {
           string str =  StringCipher.Decrypt(Token, Constants.Constants.PassPhrase);
            return true;
        }
        public string GenerateToken()
        {
            return GenerateHash(Guid.NewGuid().ToString());
        }
        public string GenerateHash(string Input)
        {
            return HashGen.GetHashString(Input);
        }

    }
}
