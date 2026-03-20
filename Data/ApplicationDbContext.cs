using GestaoEventos.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GestaoEventos.Data;

public class ApplicationDbContext : IdentityDbContext
{
    //Passo 2 : Após criar Model, declarar ela no Context
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // Aqui nós declaramos a Model que você acabou de criar!
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Evento> Eventos { get; set; }

    public DbSet<GestaoEventos.Models.Local> Local { get; set; } = default!;

    // Passo 3: 
    // Criar a migration que será responsável por
    // fazer uma estrutura em SQL baseada nas Models
    // Comandos:
    // 1.  add-migration AddCategorias 
    // 2 . Update-database
}
