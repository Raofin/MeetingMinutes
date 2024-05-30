using MeetingMinutes.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeetingMinutes.Infrastructure.Persistence;

public static class SeedData
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        // Individual_Customer_Tbl
        modelBuilder.Entity<IndividualCustomer>()
           .HasData(
                new IndividualCustomer { CustomerId = 1, CustomerName = "John Doe" },
                new IndividualCustomer { CustomerId = 2, CustomerName = "Jane Smith" },
                new IndividualCustomer { CustomerId = 3, CustomerName = "Alice Johnson" },
                new IndividualCustomer { CustomerId = 4, CustomerName = "Bob Brown" },
                new IndividualCustomer { CustomerId = 5, CustomerName = "Charlie White" },
                new IndividualCustomer { CustomerId = 6, CustomerName = "Diana Green" },
                new IndividualCustomer { CustomerId = 7, CustomerName = "Ethan Black" },
                new IndividualCustomer { CustomerId = 8, CustomerName = "Fiona Red" },
                new IndividualCustomer { CustomerId = 9, CustomerName = "George Blue" },
                new IndividualCustomer { CustomerId = 10, CustomerName = "Hannah Yellow" }
            );

        // Corporate_Customer_Tbl
        modelBuilder.Entity<CorporateCustomer>()
           .HasData(
                new CorporateCustomer { CustomerId = 1, CustomerName = "Tech Corp" },
                new CorporateCustomer { CustomerId = 2, CustomerName = "Finance Inc" },
                new CorporateCustomer { CustomerId = 3, CustomerName = "Healthcare LLC" },
                new CorporateCustomer { CustomerId = 4, CustomerName = "Education Group" },
                new CorporateCustomer { CustomerId = 5, CustomerName = "Retail Co" },
                new CorporateCustomer { CustomerId = 6, CustomerName = "Manufacturing Ltd" },
                new CorporateCustomer { CustomerId = 7, CustomerName = "Agriculture Farm" },
                new CorporateCustomer { CustomerId = 8, CustomerName = "Construction Co" },
                new CorporateCustomer { CustomerId = 9, CustomerName = "Real Estate LLC" },
                new CorporateCustomer { CustomerId = 10, CustomerName = "Media Group" }
            );

        // Products_Service_Tbl
        modelBuilder.Entity<ProductsService>()
           .HasData(
                new ProductsService { ProductServiceId = 1, Name = "Cloud-Based CRM Software", Type = "service" },
                new ProductsService { ProductServiceId = 2, Name = "AI-Powered Analytics Suite", Type = "service" },
                new ProductsService { ProductServiceId = 3, Name = "E-Commerce Platform", Type = "service" },
                new ProductsService { ProductServiceId = 4, Name = "Blockchain Technology Solutions", Type = "service" },
                new ProductsService { ProductServiceId = 5, Name = "Cybersecurity Services", Type = "service" },
                new ProductsService { ProductServiceId = 6, Name = "Wireless Earbuds", Type = "product" },
                new ProductsService { ProductServiceId = 7, Name = "Smart Home Hub", Type = "product" },
                new ProductsService { ProductServiceId = 8, Name = "Electric Scooter", Type = "product" },
                new ProductsService { ProductServiceId = 9, Name = "Solar Energy Panels", Type = "product" },
                new ProductsService { ProductServiceId = 10, Name = "Portable Power Bank", Type = "product" }
            );
    }
}