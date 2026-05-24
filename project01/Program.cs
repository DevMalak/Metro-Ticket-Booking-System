using Microsoft.EntityFrameworkCore;
using project01.Data;
using project01.Models;

namespace project01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppDbContext context = new AppDbContext();



            
            //======================== Add Stations
            

            if (!context.Stations.Any())
            {
                Station station1 = new Station()
                {
                    Name = "Ramses",
                    Location = "Cairo"
                };

                Station station2 = new Station()
                {
                    Name = "Sadat",
                    Location = "Giza"
                };

                context.Stations.Add(station1);
                context.Stations.Add(station2);

                context.SaveChanges();
            }



            
            //========================= Add Trains
            

            if (!context.Trains.Any())
            {
                Train train1 = new Train()
                {
                    Number = "T1",
                    Capacity = 200
                };

                Train train2 = new Train()
                {
                    Number = "T2",
                    Capacity = 300
                };

                context.Trains.Add(train1);
                context.Trains.Add(train2);

                context.SaveChanges();
            }



            
            //============================= Add Tickets
            

            if (!context.Tickets.Any())
            {
                Train firstTrain = context.Trains.First();
                Train secondTrain = context.Trains
                    .OrderBy(t => t.Id)
                    .Last();

                Station firstStation = context.Stations.First();
                Station secondStation = context.Stations
                    .OrderBy(s => s.Id)
                    .Last();
                List<Ticket> tickets = new List<Ticket>()
                {
                    new Ticket()
                    {
                        PassengerName = "Ahmed",
                        Price = 25,
                        TravelDate = DateTime.Now,
                        TrainId = firstTrain.Id,
                        StationId = firstStation.Id
                    },

                    new Ticket()
                    {
                        PassengerName = "Ali",
                        Price = 15,
                        TravelDate = DateTime.Now,
                        TrainId = firstTrain.Id,
                        StationId = secondStation.Id
                    },

                    new Ticket()
                    {
                        PassengerName = "Sara",
                        Price = 35,
                        TravelDate = DateTime.Now,
                        TrainId = secondTrain.Id,
                        StationId = firstStation.Id
                    },

                    new Ticket()
                    {
                        PassengerName = "Mona",
                        Price = 18,
                        TravelDate = DateTime.Now,
                        TrainId = secondTrain.Id,
                        StationId = secondStation.Id
                    },

                    new Ticket()
                    {
                        PassengerName = "Khalid",
                        Price = 40,
                        TravelDate = DateTime.Now,
                        TrainId = firstTrain.Id,
                        StationId = firstStation.Id
                    }
                };

                context.Tickets.AddRange(tickets);

                context.SaveChanges();
            }



            
            //================================= Get All Tickets
            
            var allTickets = context.Tickets.ToList();

            Console.WriteLine("===== All Tickets =====");

            foreach (var ticket in allTickets)
            {
                Console.WriteLine(
                    $"{ticket.PassengerName} - {ticket.Price}");
            }



            //==================================== Tickets Price > 20
            
            var expensiveTickets = context.Tickets
                .Where(t => t.Price > 20)
                .ToList();

            Console.WriteLine("\n===== Tickets Price > 20 =====");

            foreach (var ticket in expensiveTickets)
            {
                Console.WriteLine(
                    $"{ticket.PassengerName} - {ticket.Price}");
            }



            
            //========================= First Ticket
            
            var firstTicket = context.Tickets
                .FirstOrDefault(t => t.PassengerName == "Ahmed");

            Console.WriteLine("\n===== First Ticket =====");

            Console.WriteLine(
                $"{firstTicket.PassengerName} - {firstTicket.Price}");



           
            //======================= Count Tickets
            

            int countTickets = context.Tickets.Count();

            Console.WriteLine("\n===== Tickets Count =====");

            Console.WriteLine(countTickets);



            
            //============================== Order By Price Desc
            
            var orderedTickets = context.Tickets
                .OrderByDescending(t => t.Price)
                .ToList();

            Console.WriteLine("\n===== Ordered Tickets =====");

            foreach (var ticket in orderedTickets)
            {
                Console.WriteLine(
                    $"{ticket.PassengerName} - {ticket.Price}");
            }



            // ======================================Include Train + Station
            
            var ticketsWithRelations = context.Tickets
                .Include(t => t.Train)
                .Include(t => t.Station)
                .ToList();

            Console.WriteLine("\n===== Tickets With Relations =====");

            foreach (var ticket in ticketsWithRelations)
            {
                Console.WriteLine(
                    $"Passenger: {ticket.PassengerName} " +
                    $"| Train: {ticket.Train.Number} " +
                    $"| Station: {ticket.Station.Name} " +
                    $"| Price: {ticket.Price}");
            }




            // Number Of Tickets Per Train

            var ticketsPerTrain = context.Tickets
                .GroupBy(t => t.Train.Number)
                .Select(g => new
                {
                    TrainNumber = g.Key,
                    TicketsCount = g.Count()
                })
                .ToList();

            Console.WriteLine("\n===== Tickets Per Train =====");

            foreach (var item in ticketsPerTrain)
            {
                Console.WriteLine(
                    $"{item.TrainNumber} : {item.TicketsCount}");
            }



            // Cheapest Ticket

            var cheapestTicket = context.Tickets
                .OrderBy(t => t.Price)
                .FirstOrDefault();

            Console.WriteLine("\n===== Cheapest Ticket =====");

            Console.WriteLine(
                $"{cheapestTicket.PassengerName} - {cheapestTicket.Price}");



            // Most Expensive Ticket

            var expensiveTicket = context.Tickets
                .OrderByDescending(t => t.Price)
                .FirstOrDefault();

            Console.WriteLine("\n===== Most Expensive Ticket =====");

            Console.WriteLine(
                $"{expensiveTicket.PassengerName} - {expensiveTicket.Price}");
        }
    }
}