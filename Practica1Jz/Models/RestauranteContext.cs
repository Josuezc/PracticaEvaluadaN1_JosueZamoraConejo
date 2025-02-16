using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Practica1Jz.Models
{
    public class RestauranteContext : DbContext
    {
        public RestauranteContext(DbContextOptions<RestauranteContext> options)
            : base(options)
        {
        }

        public DbSet<Restaurante> Restaurante { get; set; }
    }
}
