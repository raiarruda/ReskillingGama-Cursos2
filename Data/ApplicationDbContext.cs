using Cursos.Models.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Data
{
    public class ApplicationDbContext : IdentityDbContext

    {

        IConfiguration _configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<Aula> Aula { get; set; }
        public virtual DbSet<Professor> Professor { get; set; }
        public virtual DbSet<PostagemBlog> PostagemBlogs { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connection = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;

                optionsBuilder.UseMySql(connection, Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.27-mysql"));
            }
        }
    }
}