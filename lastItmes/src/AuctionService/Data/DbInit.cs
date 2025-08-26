using System;
using AuctionService.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.Data;

public class DbInit
{
    public static void InitDataBase(WebApplication app)
    {
      using var scope = app.Services.CreateScope();

      SeedData(scope.ServiceProvider.GetService<AuctionDbContext>());
    }

    private static void SeedData(AuctionDbContext context)
    {
        context.Database.Migrate();

        if(context.Auctions.Any()){
            Console.WriteLine("Already have data no need to seed");
            return;
        }

        var auction = new List<Auction>()
        {
          new Auction
        {
        Id = Guid.Parse("d7a12b18-ec79-4e8a-b97f-1d8bc983ee5a"),
        Status = Status.ReservNotMet,
        ReservPrice = 50000,
        Seller = "Tom",
        AuctionEnd = DateTime.UtcNow.AddDays(-10),
        Item = new Item
        {
            Make = "Ford",
            Model = "GT",
            Color = "White",
            Mileage = 55055,
            Year = 2020,
            ImageUrl = "https://www.shutterstock.com/image-photo/cremona-italy-january-15th-2025-silver-2574901755"
        }
    },
    new Auction
    {
        Id = Guid.Parse("0b637ff4-3d99-42d8-ae1e-2b8941e3e0ad"),
        Status = Status.Live,
        ReservPrice = 32000,
        Seller = "Mike",
        AuctionEnd = DateTime.UtcNow.AddDays(5),
        Item = new Item
        {
            Make = "Tesla",
            Model = "Model 3",
            Color = "Red",
            Mileage = 15000,
            Year = 2022,
            ImageUrl = "https://www.shutterstock.com/image-photo/red-tesla-model-3-parked-city-1234567890"
        }
    },
    new Auction
    {
        Id = Guid.Parse("ce5cfbea-28cb-4c0b-8f57-8d78b8c1b5a9"),
        Status = Status.Finished,
        ReservPrice = 27000,
        Seller = "Sarah",
        Winner = "John",
        SoldAmount = 28000,
        CurrentHighBid = 28000,
        AuctionEnd = DateTime.UtcNow.AddDays(-2),
        Item = new Item
        {
            Make = "BMW",
            Model = "M3",
            Color = "Black",
            Mileage = 45000,
            Year = 2019,
            ImageUrl = "https://www.shutterstock.com/image-photo/black-bmw-m3-driving-road-2345678901"
        }
    },
    new Auction
    {
        Id = Guid.Parse("f2353b13-1c4c-4d4e-94e1-6e1eaa8e041a"),
        Status = Status.ReservNotMet,
        ReservPrice = 15000,
        Seller = "Daniel",
        AuctionEnd = DateTime.UtcNow.AddDays(7),
        Item = new Item
        {
            Make = "Toyota",
            Model = "Corolla",
            Color = "Blue",
            Mileage = 60000,
            Year = 2018,
            ImageUrl = "https://www.shutterstock.com/image-photo/blue-toyota-corolla-parked-driveway-3456789012"
        }
    },
    new Auction
    {
        Id = Guid.Parse("a6db9c09-4b5e-4e5b-833a-9f22cb38c0f1"),
        Status = Status.Live,
        ReservPrice = 42000,
        Seller = "Emma",
        AuctionEnd = DateTime.UtcNow.AddDays(3),
        Item = new Item
        {
            Make = "Audi",
            Model = "A6",
            Color = "Silver",
            Mileage = 35000,
            Year = 2021,
            ImageUrl = "https://www.shutterstock.com/image-photo/silver-audi-a6-modern-city-4567890123"
        }
    },
    new Auction
    {
        Id = Guid.Parse("e83dcb84-2910-4aef-a5e3-4f7f0c9ab1a2"),
        Status = Status.ReservNotMet,
        ReservPrice = 8000,
        Seller = "Liam",
        AuctionEnd = DateTime.UtcNow.AddDays(-1),
        Item = new Item
        {
            Make = "Honda",
            Model = "Civic",
            Color = "Grey",
            Mileage = 85000,
            Year = 2016,
            ImageUrl = "https://www.shutterstock.com/image-photo/grey-honda-civic-street-parked-5678901234"
        }
    },
    new Auction
    {
        Id = Guid.Parse("f9c3b15a-5d9a-4f5e-8c7a-32c88b4dfed3"),
        Status = Status.Finished,
        ReservPrice = 25000,
        Seller = "Olivia",  
        Winner = "Mark",
        SoldAmount = 26000,
        CurrentHighBid = 26000,
        AuctionEnd = DateTime.UtcNow.AddDays(-5),
        Item = new Item
        {
            Make = "Mercedes",
            Model = "C-Class",
            Color = "White",
            Mileage = 40000,
            Year = 2020,
            ImageUrl = "https://www.shutterstock.com/image-photo/white-mercedes-c-class-parking-lot-6789012345"
        }
    },
    new Auction
    {
        Id = Guid.Parse("b1df3916-9f4a-4bb2-bf47-ffb8395d54a0"),
        Status = Status.Live,
        ReservPrice = 12000,
        Seller = "Sophia",
        AuctionEnd = DateTime.UtcNow.AddDays(4),
        Item = new Item
        {
            Make = "Volkswagen",
            Model = "Golf",
            Color = "Green",
            Mileage = 72000,
            Year = 2017,
            ImageUrl = "https://www.shutterstock.com/image-photo/green-volkswagen-golf-country-road-7890123456"
        }
    },
    new Auction
    {
        Id = Guid.Parse("aa14fca3-b612-4c6d-8df5-40d3e8c2a908"),
        Status = Status.ReservNotMet,
        ReservPrice = 65000,
        Seller = "James",
        AuctionEnd = DateTime.UtcNow.AddDays(-8),
        Item = new Item
        {
            Make = "Porsche",
            Model = "911",
            Color = "Yellow",
            Mileage = 30000,
            Year = 2019,
            ImageUrl = "https://www.shutterstock.com/image-photo/yellow-porsche-911-driving-road-8901234567"
        }
    },
    new Auction
    {
        Id = Guid.Parse("d06e98af-558b-41d3-9b6a-ec41b72ccfaf"),
        Status = Status.Live,
        ReservPrice = 34000,
        Seller = "William",
        AuctionEnd = DateTime.UtcNow.AddDays(6),
        Item = new Item
        {
            Make = "Chevrolet",
            Model = "Camaro",
            Color = "Orange",
            Mileage = 25000,
            Year = 2021,
            ImageUrl = "https://www.shutterstock.com/image-photo/orange-chevrolet-camaro-modern-city-9012345678"
        }
    }
         
        };

        context.AddRange(auction);

        context.SaveChanges();
    }
}
