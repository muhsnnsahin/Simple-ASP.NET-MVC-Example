using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace MyFirstWebSite.Models
{
    public class Customers
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }

        public List<Customers> GenerateCustomers()
        {
            var usersList = new List<Customers>
            {
                new Customers
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Sinan",
                    Surname = "Şahin",
                    Phone = "05555555555"
                },
                new Customers
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Ahmet",
                    Surname = "Jelibon",
                    Phone = "05444444444"
                },
                new Customers
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Mehmet",
                    Surname = "Bonibon",
                    Phone = "05333333333"
                }
            };

            return usersList;
        }
    }
}