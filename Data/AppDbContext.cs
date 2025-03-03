using Microsoft.EntityFrameworkCore;
using WebApiLivros.Models;

// Context serve para comunicar nosso codigo com o banco de dados

namespace WebApi_Livros.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) // setar conexao do codigo com banco de dados
        {
        } // construtor

        public DbSet<AutorModel> Autores { get; set; } // tabelas a serem criadas e suas models
        public DbSet<LivroModel> Livros { get; set; }
    }
}
