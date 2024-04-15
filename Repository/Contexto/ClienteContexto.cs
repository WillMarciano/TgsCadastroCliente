using Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Domain.Entity;

namespace Repository.Contexto
{
    public class ClienteContexto(DbContextOptions<ClienteContexto> options) : IdentityDbContext<User, Role, int,
                                                       IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
                                                       IdentityRoleClaim<int>, IdentityUserToken<int>>(options)
    {
        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Logradouro> Logradouros { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                        .WithMany(r => r.UserRoles)
                        .HasForeignKey(ur => ur.RoleId)
                        .IsRequired();

                userRole.HasOne(ur => ur.User)
                        .WithMany(r => r.UserRoles)
                        .HasForeignKey(ur => ur.UserId)
                        .IsRequired();
            });

            builder.Entity<Logradouro>(logradouro =>
            {
                logradouro.HasKey(l => l.Id);
                logradouro.Property(l => l.Endereco).IsRequired();
                logradouro.Property(l => l.ClienteId).IsRequired();
            });

            builder.Entity<Cliente>(cliente =>
            {
                cliente.HasKey(c => c.Id);
                cliente.HasIndex(c => c.Email).IsUnique();
                cliente.Property(c => c.Nome).IsRequired();
                cliente.Property(c => c.Email).IsRequired();
                cliente.HasMany(c => c.Logradouros);
            });

        }
    }

}