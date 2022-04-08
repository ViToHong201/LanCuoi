using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace API.Controllers
{
    public class ConnectSever
    {
        string strCon = @"Data Source=LAPTOP-1J12A8QF\MainServer;Initial Catalog=thoi_khoa_bieu;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
        public SqlConnection sqlCon = null;
        public void OpenConnection()
        {
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(strCon);
            }
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
        }
        public void CloseConnection()
        {
            if (sqlCon.State == ConnectionState.Open && sqlCon != null)
            {
                sqlCon.Close();
            }
        }
    }
}