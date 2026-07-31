using System;

namespace assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            DeliveryCenter center = new DeliveryCenter();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Enter Shipment {i + 1} Data");

                Console.Write("Tracking Code: ");
                string trackingCode = Console.ReadLine() ?? "";

                Console.Write("Description: ");
                string description = Console.ReadLine() ?? "";

                Console.Write("Weight: ");
                double weight = double.Parse(Console.ReadLine() ?? "0");

                Console.Write("Delivery Fee: ");
                decimal fee = decimal.Parse(Console.ReadLine() ?? "0");
                Console.Write("City: ");
                string city = Console.ReadLine() ?? "";

                Console.Write("Street: ");
                string street = Console.ReadLine() ?? "";

                Console.Write("Building Number: ");
                int building = int.Parse(Console.ReadLine() ?? "0");
                DeliveryAddress address = new DeliveryAddress(city, street, building);

                Shipment shipment = new Shipment(trackingCode, description, weight, fee, address);

                if (center.AddShipment(shipment))
                {
                    Console.WriteLine("Shipment added successfully.");
                }
                else
                {
                    Console.WriteLine("Delivery center is full.");
                }
            }
            Console.WriteLine("--- All Shipments ---");

            for (int i = 0; i < 3; i++)
            {
                center[i].PrintShipment();
                Console.WriteLine();
            }
            Console.Write("Enter a tracking code to search: ");
            string searchCode = Console.ReadLine() ?? "";

            Shipment foundShipment = center[searchCode];

            if (foundShipment.TrackingCode != null)
            {
                Console.WriteLine("Shipment found:");
                Console.WriteLine(foundShipment.TrackingCode + " - " + foundShipment.Description);
            }
            else
            {
                Console.WriteLine("Shipment not found.");
            }
            Console.WriteLine("--- Struct Copy Test ---");

            DeliveryAddress originalAddress = new DeliveryAddress("Cairo", "Tahrir Street", 15);

            DeliveryAddress copiedAddress = originalAddress;

            copiedAddress.Street = "Makram Ebeid Street";
            copiedAddress.BuildingNumber = 20;

            Console.WriteLine("Original Address: " + originalAddress.GetFullAddress());
            Console.WriteLine("Copied Address: " + copiedAddress.GetFullAddress());
        }
        






}


    }