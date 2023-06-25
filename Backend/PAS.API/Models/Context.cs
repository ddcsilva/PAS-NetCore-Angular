using Microsoft.EntityFrameworkCore;

namespace PAS.API.Models;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {
    }

    public DbSet<Estudante> Estudantes { get; set; }
    public DbSet<Genero> Generos { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
}