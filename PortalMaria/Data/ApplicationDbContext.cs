using Microsoft.EntityFrameworkCore;
using PortalMaria.Models;

namespace PortalMaria.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<HorarioAluno> HorarioAluno { get; set; }
    }
}
