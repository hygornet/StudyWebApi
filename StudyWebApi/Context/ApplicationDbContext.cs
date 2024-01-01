using Microsoft.EntityFrameworkCore;
using StudyWebApi.Models;

namespace StudyWebApi.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
