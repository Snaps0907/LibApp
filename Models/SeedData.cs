using System;
using System.Linq;
using LibApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.MembershipTypes.Any())
                {
                    Console.WriteLine("MembershipTypes already seeded");
                    return;
                }
                else
                {
                    context.MembershipTypes.AddRange(

                    new MembershipType
                    {
                        Id = 1,
                        SignUpFee = 0,
                        DurationInMonths = 0,
                        DiscountRate = 0
                    },
                    new MembershipType
                    {
                        Id = 2,
                        SignUpFee = 30,
                        DurationInMonths = 1,
                        DiscountRate = 10

                    });
                }
                // Genres
                if (context.Genre.Any())
                {
                    Console.WriteLine("Genres already seeded");
                }
                else
                {
                    context.Genre.AddRange(
                        new Genre
                        {
                            Id = 1,
                            Name = "Fantasy",
                        },
                        new Genre
                        {
                            Id = 2,
                            Name = "Horror"
                        });
                }

                // Customers
                if (context.Customers.Any())
                {
                    Console.WriteLine("Customers already seeded");
                }
                else
                {
                    context.Customers.AddRange(
                        new Customer
                        {
                            Name = "Piotr Wolny",
                            Birthdate = new DateTime(1993, 2, 11),
                            HasNewsletterSubscribed = true,
                            MembershipTypeId = 1
                        },
                        new Customer
                        {
                            Name = "Michał Kowalski",
                            Birthdate = new DateTime(1987, 4, 27),
                            HasNewsletterSubscribed = false,
                            MembershipTypeId = 1
                        });
                }

                // Books
                if (context.Books.Any())
                {
                    Console.WriteLine("Books already seeded");
                }
                else
                {
                    context.Books.AddRange(
                        new Book
                        {
                            ReleaseDate = new DateTime(2001, 2, 12),
                            AuthorName = "Trudi Canavan",
                            GenreId = 1,
                            Name = "Gildia Magów",
                            NumberInStock = 1,
                        },
                        new Book
                        {
                            ReleaseDate = new DateTime(2002, 7, 10),
                            AuthorName = "Dmitrij Głuchowski",
                            GenreId = 1,
                            Name = "Metro 2033",
                            NumberInStock = 11,
                        },
                        new Book
                        {
                            ReleaseDate = new DateTime(1978, 2, 14),
                            AuthorName = "Stephen King",
                            GenreId = 2,
                            Name = "Bastion",
                            NumberInStock = 12,
                        });
                }
                context.SaveChanges();
            }
        }
    }
}