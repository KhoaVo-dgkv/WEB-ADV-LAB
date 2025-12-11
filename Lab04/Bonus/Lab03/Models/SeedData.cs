using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Lab03.Data;
using System;
using System.Linq;

namespace Lab03.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                // Seed Categories if empty
                if (!context.Category.Any())
                {
                    var categories = new Category[]
                    {
                        new Category
                        {
                            Name = "Action",
                            Description = "Action-packed movies with thrilling sequences"
                        },
                        new Category
                        {
                            Name = "Comedy",
                            Description = "Funny and entertaining movies"
                        },
                        new Category
                        {
                            Name = "Romance",
                            Description = "Romantic and love stories"
                        },
                        new Category
                        {
                            Name = "Drama",
                            Description = "Serious and emotional movies"
                        }
                    };
                    context.Category.AddRange(categories);
                    context.SaveChanges();
                }

                // Seed Customers if empty
                if (!context.Customer.Any())
                {
                    var customers = new Customer[]
                    {
                        new Customer
                        {
                            Name = "John Doe",
                            Email = "john.doe@example.com",
                            Phone = "123-456-7890",
                            Address = "123 Main St, City"
                        },
                        new Customer
                        {
                            Name = "Jane Smith",
                            Email = "jane.smith@example.com",
                            Phone = "098-765-4321",
                            Address = "456 Oak Ave, Town"
                        },
                        new Customer
                        {
                            Name = "Bob Johnson",
                            Email = "bob.johnson@example.com",
                            Phone = "555-123-4567",
                            Address = "789 Pine Rd, Village"
                        }
                    };
                    context.Customer.AddRange(customers);
                    context.SaveChanges();
                }

                // Seed Movies if empty
                if (!context.Movie.Any())
                {
                    var categories = context.Category.ToList();
                    var movies = new Movie[]
                    {
                        new Movie
                        {
                            Title = "When Harry Met Sally",
                            ReleaseDate = DateTime.Parse("1989-2-12"),
                            Genre = "Romantic Comedy",
                            Price = 7.99M,
                            Rating = "R",
                            CategoryId = categories.FirstOrDefault(c => c.Name == "Romance")?.Id
                        },
                        new Movie
                        {
                            Title = "Ghostbusters ",
                            ReleaseDate = DateTime.Parse("1984-3-13"),
                            Genre = "Comedy",
                            Price = 8.99M,
                            Rating = "PG",
                            CategoryId = categories.FirstOrDefault(c => c.Name == "Comedy")?.Id
                        },
                        new Movie
                        {
                            Title = "Ghostbusters 2",
                            ReleaseDate = DateTime.Parse("1986-2-23"),
                            Genre = "Comedy",
                            Price = 9.99M,
                            Rating = "PG",
                            CategoryId = categories.FirstOrDefault(c => c.Name == "Comedy")?.Id
                        },
                        new Movie
                        {
                            Title = "Rio Bravo",
                            ReleaseDate = DateTime.Parse("1959-4-15"),
                            Genre = "Western",
                            Price = 3.99M,
                            Rating = "PG-13",
                            CategoryId = categories.FirstOrDefault(c => c.Name == "Action")?.Id
                        }
                    };
                    context.Movie.AddRange(movies);
                    context.SaveChanges();
                }

                // Seed Tickets if empty
                if (!context.Ticket.Any())
                {
                    var movies = context.Movie.ToList();
                    var customers = context.Customer.ToList();
                    
                    if (movies.Any() && customers.Any())
                    {
                        context.Ticket.AddRange(
                            new Ticket
                            {
                                MovieId = movies[0].Id,
                                CustomerId = customers[0].Id,
                                PurchaseDate = DateTime.Parse("2024-1-15"),
                                Price = 12.50M,
                                SeatNumber = "A12"
                            },
                            new Ticket
                            {
                                MovieId = movies[1].Id,
                                CustomerId = customers[1].Id,
                                PurchaseDate = DateTime.Parse("2024-1-16"),
                                Price = 10.00M,
                                SeatNumber = "B5"
                            },
                            new Ticket
                            {
                                MovieId = movies[2].Id,
                                CustomerId = customers[2].Id,
                                PurchaseDate = DateTime.Parse("2024-1-17"),
                                Price = 11.00M,
                                SeatNumber = "C8"
                            },
                            new Ticket
                            {
                                MovieId = movies[0].Id,
                                CustomerId = customers[1].Id,
                                PurchaseDate = DateTime.Parse("2024-1-18"),
                                Price = 12.50M,
                                SeatNumber = "D15"
                            }
                        );
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
