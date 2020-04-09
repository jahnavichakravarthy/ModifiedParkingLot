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
    public class Tickets
    {
        Functions Functions = new Functions();
        public void Insert(Ticket ticket)
        {
            Functions.CommonQuery(ticket, "INSERT INTO TICKETS (Id, InTime, SlotNumber, VehicleNumber) Values (@Id, @InTime, @SlotNumber, @VehicleNumber);");
            //using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["ParkingLotDataBase"].ConnectionString))
            ////ConfigurationManager.ConnectionStrings["ParkingLotDataBase"].ConnectionString))
            //{
            //    string sqlQuery = "INSERT INTO TICKETS (Id, InTime, SlotNumber, VehicleNumber) Values (@Id, @InTime, @SlotNumber, @VehicleNumber);";
            //    int rowsAffected = db.Execute(sqlQuery, ticket);
            //}

        }

        public void ReInitialize()
        {
            Functions.ReInitialize("DELETE FROM TICKETS");
            //using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["ParkingLotDataBase"].ConnectionString))
            //{
            //    string sqlQuery = "DELETE FROM TICKETS";
            //    int rowsAffected = db.Execute(sqlQuery);
            //    //return rowsAffected;//returns number opf rows updated
            //}

        }
        public List<Ticket> GetTickets()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["ParkingLotDataBase"].ConnectionString))
            {
                return db.Query<Ticket>("Select * From TICKETS").ToList();
            }

        }
        public void Update(Ticket ticket)
        {
            Functions.CommonQuery(ticket, "UPDATE TICKETS SET OutTime = @OutTime " +
                  " WHERE Id = @Id ");
            //using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["ParkingLotDataBase"].ConnectionString))
            //{
            //    string sqlQuery = "UPDATE TICKETS SET OutTime = @OutTime " +
            //    " WHERE Id = @Id ";
            //    int rowsAffected = db.Execute(sqlQuery, ticket);
            //   // return rowsAffected;//returns number opf rows updated
            //}
        }
    }
}
