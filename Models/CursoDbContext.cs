using Microsoft.EntityFrameworkCore;

namespace ExemploWEB_API.Models
{
    public class CursoDbContext: DbContext
    {
        public CursoDbContext(DbContextOptions<CursoDbContext> options)
         : base(options)
        { }
        
        public DbSet<Curso> Cursos {get; set;}
    }
}
