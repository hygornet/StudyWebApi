using Microsoft.EntityFrameworkCore;
using StudyWebApi.Models;

namespace StudyWebApi.Context
{
    public class CursoContext : DbContext
    {
        public CursoContext(DbContextOptions<CursoContext> options) : base(options) { }

        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
    }
}
