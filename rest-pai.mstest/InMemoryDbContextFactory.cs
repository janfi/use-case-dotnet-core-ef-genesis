using Microsoft.EntityFrameworkCore;
using rest_api;
using rest_api.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace rest_pai.mstest
{
    public class InMemoryDbContextFactory
    {
        public DbCtx GetDbContext()
        {
            var options = new DbContextOptionsBuilder<DbCtx>()
                            .UseInMemoryDatabase(databaseName: "DbCtx_Test")
                            .Options;
            var dbContext = new DbCtx(options);

            return dbContext;
        }
    }
}
