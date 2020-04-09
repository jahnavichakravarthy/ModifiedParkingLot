using System;
using ParkingLot.DBMethods;
using System.Collections.Generic;
using ParkingLot.Models;
using System.Linq;

namespace ParkingLot.Services
{
    interface IParkingService
    {
        List<Slot> GetAvailableSlots(VehicleModel type);
        void InitializeParkingLot(int twoWheeler, int fourWheeler, int heavyVehicles);
        void Park(int slotId, string vehicleNumber);
        void UnPark(int number);
        List<Slot> GetSlots();
        Slot GetSlot(int Number);
       bool CheckSimialarVehicleNo(string newVehicleNo);
    }
    public class ParkingSevice : IParkingService
    {
        TicketService TicketService = new TicketService();
        Slots slots = new Slots();
        Tickets Tickets = new Tickets();
        Vehicles Vehicles = new Vehicles();
        public List<Slot> Slots = new List<Slot>();
        
        public List<Slot> GetAvailableSlots(VehicleModel type)
        {
            Slots =slots.GetSlots();
                 //this is to get the slots which are available for parking
                 var slotsAvailable = from slot in Slots
                             where slot.Type == type && slot.Availability ==Status.AVAILABLE
                             select slot;
                 List<Slot> AvailableSlots = slotsAvailable.ToList();
                 return (AvailableSlots.Count == 0) ? null : AvailableSlots;
            
        }
        public void InitializeParkingLot(int twoWheeler, int fourWheeler, int heavyVehicles)
        {
            //Intialize slots for various types of vehicles
            CreateSlot(twoWheeler, VehicleModel.TwoWheeler);
            CreateSlot(fourWheeler, VehicleModel.FourWheeler);
            CreateSlot(heavyVehicles, VehicleModel.HeavyVehicle);
        }
        public void CreateSlot(int NumberofVehicles, VehicleModel vehicleType)
        { 
            //create slots for each type of  vehicle
            for (int index = 1; index <=NumberofVehicles; index++)
            { 
                
                Slot slot = new Slot(vehicleType);
                slots.Insert(slot);
               // Slots.Add(slot);
            }
        }
        public void Park(int slotId, string vehicleNumber)
        {
            //park a vehicle ,generate a tickeT,change status to "OCCUPIED"
            Vehicle vehicle = new Vehicle();
            
            Slot SelectedSlot = Slots.Find(slot => slot.Id == slotId);
            SelectedSlot.Availability = Status.OCCUPIED;
            SelectedSlot.VehicleNumber= vehicleNumber;

            vehicle.VehicleNumber = vehicleNumber;
            vehicle.Type = SelectedSlot.Type;
            slots.Update(SelectedSlot);
            Vehicles.Insert(vehicle);

        }
        public void UnPark(int number)
        {
            Slots = slots.GetSlots();
            //unpark a vehicle ,change the status to available
            Slot ThisSlot = Slots.Find(slot => slot.Id == number);
            ThisSlot.VehicleNumber = null ;
            ThisSlot.Availability = Status.AVAILABLE;
            Ticket ticket = TicketService.GetTicket(number);
            ticket.OutTime = DateTime.Now;
            Tickets.Update(ticket);
            slots.Update(ThisSlot);
            Vehicles.Delete(ticket.VehicleNumber);
            
            

        }
        public List<Slot> GetSlots()
        {
            Slots = slots.GetSlots();
            return Slots;
        }
        public Slot GetSlot(int Number)
        {
            Slots = slots.GetSlots();
            Slot SelectedSlot = Slots.Find(slot => slot.Id == Number);
            return SelectedSlot;
        }
        public bool CheckSimialarVehicleNo(string newVehicleNo)
        {
            Slots = slots.GetSlots();
            try
            {
                //Slot slot = Slots.Find(item => item.ParkedVehicle.VehicleNumber == newVehicleNo);
                Slot slot = Slots.Find(item => item.VehicleNumber == newVehicleNo);
                return true;
            }
            catch (NullReferenceException)
            {
                return false;
            }


        }

    }
}