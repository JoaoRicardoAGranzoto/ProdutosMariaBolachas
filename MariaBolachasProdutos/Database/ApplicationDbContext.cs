using System;
using Microsoft.EntityFrameworkCore;

namespace MariaBolachasProdutos.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Bolachas> Alimentos { get; set; }
    public DbSet<RoscasEPaes> Roscas { get; set; }
}