using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;


namespace DAL
{
    public class TokenDAL
    {
        Database database = DBConnect.DbstringConnection();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        public bool SaveToken(string token)
        {
            try
            {
                DbCommand storedProcCommand = database.GetStoredProcCommand("usp_SaveToken");
                database.AddInParameter(storedProcCommand, "@p_Token", DbType.String, token);
                database.ExecuteScalar(storedProcCommand);
                return true;
            }
            catch (Exception ex)
            {
            }
            return false;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool ValidateToken(string token)
        {
            try
            {
                User _applicationUser = new User();
                DataSet ds = new DataSet();
                DbCommand storedProcCommand = database.GetStoredProcCommand("usp_ValidateToken");
                database.AddInParameter(storedProcCommand, "@p_Token", DbType.String, token);
                return Convert.ToBoolean(database.ExecuteScalar(storedProcCommand).ToString());
            }
            catch (Exception ex)
            {
            }
            return false;
        }


    }
}

