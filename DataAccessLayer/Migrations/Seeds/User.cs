using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Migrations.Seeds
{
    using Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    public class User 
    {
        public static void Seed(DataAccessLayer.DBContext context)
        {
           
            if (context.Users.Count() <= 0)
            {
                context.Users.Add(new Entities.User { UserName = "User1", FirstName = "User1", Password = "ꕻ膔内贯Ý왕㞸씾潻义燥쾙푌�KPI", Region = 1, Email = "Sample@emai.com", ContactNumber = "09000000", IsDeleted = false, UniqueId = Guid.NewGuid() });
                context.Users.Add(new Entities.User { UserName = "User2", FirstName = "User2", Password = "ꕻ膔内贯Ý왕㞸씾潻义燥쾙푌�KPI", Region = 2, Email = "Sample@emai.com", ContactNumber = "09000000", IsDeleted = false, UniqueId = Guid.NewGuid() });
                context.Users.Add(new Entities.User { UserName = "User3", FirstName = "User3", Password = "ꕻ膔内贯Ý왕㞸씾潻义燥쾙푌�KPI", Region = 3, Email = "Sample@emai.com", ContactNumber = "09000000", IsDeleted = false, UniqueId = Guid.NewGuid() });
                context.Users.Add(new Entities.User { UserName = "User4", FirstName = "User4", Password = "ꕻ膔内贯Ý왕㞸씾潻义燥쾙푌�KPI", Region = 4, Email = "Sample@emai.com", ContactNumber = "09000000", IsDeleted = false, UniqueId = Guid.NewGuid() });
                context.Users.Add(new Entities.User { UserName = "User5", FirstName = "User5", Password = "ꕻ膔内贯Ý왕㞸씾潻义燥쾙푌�KPI", Region = 5, Email = "Sample@emai.com", ContactNumber = "09000000", IsDeleted = false, UniqueId = Guid.NewGuid() });
                context.Users.Add(new Entities.User { UserName = "User6", FirstName = "User6", Password = "ꕻ膔内贯Ý왕㞸씾潻义燥쾙푌�KPI", Region = 6, Email = "Sample@emai.com", ContactNumber = "09000000", IsDeleted = false, UniqueId = Guid.NewGuid() });
                context.Users.Add(new Entities.User { UserName = "User7", FirstName = "User7", Password = "ꕻ膔内贯Ý왕㞸씾潻义燥쾙푌�KPI", Region = 7, Email = "Sample@emai.com", ContactNumber = "09000000", IsDeleted = false, UniqueId = Guid.NewGuid() });
                context.Users.Add(new Entities.User { UserName = "User8", FirstName = "User8", Password = "ꕻ膔内贯Ý왕㞸씾潻义燥쾙푌�KPI", Region = 8, Email = "Sample@emai.com", ContactNumber = "09000000", IsDeleted = false, UniqueId = Guid.NewGuid() });
                context.Users.Add(new Entities.User { UserName = "User9", FirstName = "User9", Password = "ꕻ膔内贯Ý왕㞸씾潻义燥쾙푌�KPI", Region = 9, Email = "Sample@emai.com", ContactNumber = "09000000", IsDeleted = false, UniqueId = Guid.NewGuid() });
                context.Users.Add(new Entities.User { UserName = "User10", FirstName = "User10", Password = "ꕻ膔内贯Ý왕㞸씾潻义燥쾙푌�KPI", Region = 10, Email = "Sample@emai.com", ContactNumber = "09000000", IsDeleted = false, UniqueId = Guid.NewGuid() });
                context.Users.Add(new Entities.User { UserName = "User11", FirstName = "User11", Password = "ꕻ膔内贯Ý왕㞸씾潻义燥쾙푌�KPI", Region = 11, Email = "Sample@emai.com", ContactNumber = "09000000", IsDeleted = false, UniqueId = Guid.NewGuid() });
                context.Users.Add(new Entities.User { UserName = "User12", FirstName = "User12", Password = "ꕻ膔内贯Ý왕㞸씾潻义燥쾙푌�KPI", Region = 12, Email = "Sample@emai.com", ContactNumber = "09000000", IsDeleted = false, UniqueId = Guid.NewGuid() });
                context.Users.Add(new Entities.User { UserName = "User13", FirstName = "User13", Password = "ꕻ膔内贯Ý왕㞸씾潻义燥쾙푌�KPI", Region = 13, Email = "Sample@emai.com", ContactNumber = "09000000", IsDeleted = false, UniqueId = Guid.NewGuid() });
                context.Users.Add(new Entities.User { UserName = "User14", FirstName = "User14", Password = "ꕻ膔内贯Ý왕㞸씾潻义燥쾙푌�KPI", Region = 14, Email = "Sample@emai.com", ContactNumber = "09000000", IsDeleted = false, UniqueId = Guid.NewGuid() });
                context.Users.Add(new Entities.User { UserName = "User15", FirstName = "User15", Password = "ꕻ膔内贯Ý왕㞸씾潻义燥쾙푌�KPI", Region = 15, Email = "Sample@emai.com", ContactNumber = "09000000", IsDeleted = false, UniqueId = Guid.NewGuid() });
                context.Users.Add(new Entities.User { UserName = "User16", FirstName = "User16", Password = "ꕻ膔内贯Ý왕㞸씾潻义燥쾙푌�KPI", Region = 16, Email = "Sample@emai.com", ContactNumber = "09000000", IsDeleted = false, UniqueId = Guid.NewGuid() });
                context.Users.Add(new Entities.User { UserName = "User17", FirstName = "User17", Password = "ꕻ膔内贯Ý왕㞸씾潻义燥쾙푌�KPI", Region = 17, Email = "Sample@emai.com", ContactNumber = "09000000", IsDeleted = false, UniqueId = Guid.NewGuid() });
                context.Users.Add(new Entities.User { UserName = "Admin", FirstName = "Admin", Password = "ꕻ膔内贯Ý왕㞸씾潻义燥쾙푌�KPI", Region = 1, Email = "Sample@emai.com", ContactNumber = "09000000", IsDeleted = false, UniqueId = Guid.NewGuid() });

            }
            context.SaveChanges();
        }
    }
}
