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
    public class DBConnect
    {
        /// <summary>
        /// Get database object from connection string
        /// </summary>
        /// <returns></returns>
        public static Database DbstringConnection()
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database namedDB = factory.Create("DemoString");
            return namedDB;
        }
    }
    public class UserDAL
    {
        Database database = DBConnect.DbstringConnection();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        public User SaveUser(User _applicationUser)
        {
            try
            {
                DbCommand storedProcCommand = database.GetStoredProcCommand("usp_SaveOrUpdateUser");
                database.AddInParameter(storedProcCommand, "@p_Name", DbType.String, _applicationUser.Name);
                database.AddInParameter(storedProcCommand, "@p_UserName", DbType.String, _applicationUser.UserName);
                database.AddInParameter(storedProcCommand, "@p_Email", DbType.String, _applicationUser.Email);
                database.AddInParameter(storedProcCommand, "@p_Password", DbType.String, _applicationUser.Password);
                database.ExecuteScalar(storedProcCommand);
                return _applicationUser;
            }
            catch (Exception ex)
            {
            }
            return new User();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool ValidateUser(LoginUser loginUser)
        {
            try
            {
                User _applicationUser = new User();
                DataSet ds = new DataSet();
                DbCommand storedProcCommand = database.GetStoredProcCommand("usp_ValidateUser");
                database.AddInParameter(storedProcCommand, "@p_UserName", DbType.String, loginUser.UserName);
                database.AddInParameter(storedProcCommand, "@p_Password", DbType.String, loginUser.Password);
                return Convert.ToBoolean(database.ExecuteScalar(storedProcCommand).ToString());
                
                
            }
            catch (Exception ex)
            {
            }
            return false;
        }
     

    }
}

