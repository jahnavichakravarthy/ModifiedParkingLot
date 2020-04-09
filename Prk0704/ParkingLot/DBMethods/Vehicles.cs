using ParkingLot.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections.Generic;

namespace ParkingLot.DBMethods
{
    public class Vehicles
    {
        Functions Functions = new Functions();
        public void Insert(Vehicle vehicle)
        {
            Functions.CommonQuery(vehicle, "INSERT INTO VEHICLES (VehicleNumber, Type) Values (@VehicleNumber, @Type);");
            //using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["ParkingLotDataBase"].ConnectionString))
            ////ConfigurationManager.ConnectionStrings["ParkingLotDataBase"].ConnectionString))
            //{
            //    string sqlQuery = "INSERT INTO VEHICLES (VehicleNumber, Type) Values (@VehicleNumber, @Type);";
            //    int rowsAffected = db.Execute(sqlQuery, vehicle);
            //}

        }
        public void ReInitialize()
        {
            Functions.ReInitialize("DELETE FROM VEHICLES");
            //using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["ParkingLotDataBase"].ConnectionString))
            //{
            //    string sqlQuery = "DELETE FROM VEHICLES";
            //    int rowsAffected = db.Execute(sqlQuery);
            //    //return rowsAffected;//returns number opf rows updated
            //}

        }
        public void Delete(string vehicleNumber)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["ParkingLotDataBase"].ConnectionString))
            {
                //    SqlCommand cmd = new SqlCommand("DELETE FROM VEHICLES " +
                //    " WHERE VehicleNumber = @vehicleNumber ");
                ////    string sqlQuery = "DELETE FROM VEHICLES " +
                ////      " WHERE VehicleNumber = @vehicleNumber ";
                //    SqlParameter sqlParameter = new SqlParameter();
                //    sqlParameter.ParameterName = "@vehicleNumber";
                //   sqlParameter.Value = vehicleNumber;      
                //    cmd.Parameters.Add(sqlParameter);
                //   int rowsAffected = db.Execute((cmd));
                string sql = "DELETE FROM VEHICLES WHERE VehicleNumber = @VehicleNumber";
                var affectedRows = db.Execute(sql, new { VehicleNumber = vehicleNumber });
            }


        }
        public List<Vehicle> GetVehicles()
        {
           // Functions.Get("Select * From VEHICLES");
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["ParkingLotDataBase"].ConnectionString))
            {
                return db.Query<Vehicle>("Select * From VEHICLES").ToList();

            }

        }
    }
}
