using Microsoft.EntityFrameworkCore;
using System;
using Users.Service.Managment.Domain.Entities;
using Users.Service.Managment.Persistence;

namespace Application.UnitTests.Common
{
    public class ContextFactory
    {
        public static UserDBContext Create()
        {
            var options = new DbContextOptionsBuilder<UserDBContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            var context = new UserDBContext(options);

            context.Database.EnsureCreated();

            context.SaveChanges();

            return context;
        }

        public static void Destroy(UserDBContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}