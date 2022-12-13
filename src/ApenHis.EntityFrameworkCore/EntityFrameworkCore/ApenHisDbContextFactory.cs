using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ApenHis.EntityFrameworkCore;

public class ApenHisDbContextFactory : DbContextFactory<ApenHisDbContext>
{
    public override ApenHisDbContext CreateDbContext(DbContextOptions<ApenHisDbContext> options)
    {
        return new ApenHisDbContext(options);
    }
}
