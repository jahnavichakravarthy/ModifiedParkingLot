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
    public class Slots
    {
        Functions Functions = new Functions();
        public void Insert(Slot slot)
        {
            Functions.CommonQuery(slot, "INSERT INTO SLOTS (Type, Availability) Values (@Type, @Availability);");
            //using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["ParkingLotDataBase"].ConnectionString))
            ////ConfigurationManager.ConnectionStrings["ParkingLotDataBase"].ConnectionString))
            //{
            //    string sqlQuery = "INSERT INTO SLOTS (Type, Availability) Values (@Type, @Availability);";
            //    int rowsAffected = db.Execute(sqlQuery, slot);
            //}

        }

        public void ReInitialize()
        {
            Functions.ReInitialize("DELETE FROM SLOTS");
            //using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["ParkingLotDataBase"].ConnectionString))
            //{
            //    string sqlQuery = "DELETE FROM SLOTS";
            //    int rowsAffected = db.Execute(sqlQuery);
            //    //return rowsAffected;//returns number opf rows updated
            //}

        }
        public List<Slot> GetSlots()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["ParkingLotDataBase"].ConnectionString))
            {
                return db.Query<Slot>("Select * From SLOTS").ToList();

            }

        }
        public void  Update(Slot slot)
        {
            Functions.CommonQuery(slot, "UPDATE SLOTS SET Availability = @Availability, " +
                   " VehicleNumber = @VehicleNumber " + " WHERE Id = @Id ");
            //using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["ParkingLotDataBase"].ConnectionString))
            //{
            //    string sqlQuery = "UPDATE SLOTS SET Availability = @Availability, " +
            //    " VehicleNumber = @VehicleNumber " + " WHERE Id = @Id ";
            //    int rowsAffected = db.Execute(sqlQuery, slot);
            //    //return rowsAffected;//returns number opf rows updated
            //}
        }
    }
}
