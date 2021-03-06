﻿using System;
using ParkingLot.Models;
using System.Collections.Generic;
using ParkingLot.DBMethods;

namespace ParkingLot.Services
{
    interface ITicketService
    {
        string GenerateID();
        Ticket GenerateTicket(int slotId, string vehiclenumber);
        //void UpdateTicketList(Ticket ticket);
        Ticket GetTicket(int id);
        int GetTicketCount();

    }
    public class TicketService : ITicketService
    {
        Tickets tickets = new Tickets();
        List<Ticket> Tickets = new List<Ticket>();

        public string GenerateID()
        {
            string Id;
            Id = "TKT" + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;//
            return Id;
        }
        public Ticket GenerateTicket(int slotId, string vehiclenumber)
        {
            //generate a ticket
            Ticket ticket = new Ticket(slotId, vehiclenumber)
            {
                Id = GenerateID(),
                InTime = DateTime.Now,
               
            };
          //  ticket.OutTime = DateTime.Parse(null);
            tickets.Insert(ticket);
            return ticket;
        }
        //public void UpdateTicketList(Ticket ticket)
        //{
        //    tickets.Add(ticket);
        //}
        public Ticket GetTicket(int id)
        {
            Tickets = tickets.GetTickets();
            Ticket SelectedTicket = Tickets.Find(ticket => ticket.SlotNumber == id);
            return SelectedTicket;
        }
        public int GetTicketCount()
        {
            Tickets = tickets.GetTickets();
            return Tickets.Count;
        }
    }
}
