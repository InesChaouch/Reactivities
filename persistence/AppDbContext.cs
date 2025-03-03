using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace persistence;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public required DbSet<Activity> Activities{ get; set; }
}
