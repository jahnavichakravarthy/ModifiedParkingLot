using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using System.Dynamic;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLot.DBMethods
{
    public class Functions
    {
        //public string Connection = ConfigurationManager.ConnectionStrings["ParkingLotDataBase"].ConnectionString;
        public void CommonQuery(object obj,string statement)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["ParkingLotDataBase"].ConnectionString))
            //ConfigurationManager.ConnectionStrings["ParkingLotDataBase"].ConnectionString))
            {
                string sqlQuery = statement;
                int rowsAffected = db.Execute(sqlQuery, obj);
                
            }

        }
        public void ReInitialize(string statement)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["ParkingLotDataBase"].ConnectionString))
            {
                string sqlQuery = statement;
                int rowsAffected = db.Execute(sqlQuery);
                //return rowsAffected;//returns number opf rows updated
            }

        }
        //public List<object> Get(string statement)
        //{
        //    using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["ParkingLotDataBase"].ConnectionString))
        //    {
        //        return db.Query<object>(statement).ToList();

        //    }

        //}

    }
}
