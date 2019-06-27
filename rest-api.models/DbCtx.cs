using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace rest_api.models
{
    public class DbCtx: DbContext
    {

        public DbCtx(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Contact> Contact { get; set; }
        public DbSet<Entreprise> Entreprise { get; set; }
        public DbSet<Entity> Entity { get; set; }
        public DbSet<Contract> Contract { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contract>()
                .HasKey(ct => new { ct.ContactId, ct.EntrepriseId });

            modelBuilder.Entity<Contract>()
                .HasOne(ct => ct.Contact)
                .WithMany(c => c.Contracts)
                .HasForeignKey(pt => pt.ContactId);

            modelBuilder.Entity<Contract>()
                .HasOne(ct => ct.Entreprise)
                .WithMany(e => e.Contracts)
                .HasForeignKey(pt => pt.EntrepriseId);

            modelBuilder.Entity<Contact>().OwnsOne(p => p.Address);
            modelBuilder.Entity<Entity>().OwnsOne(p => p.Address);

        }

        public override int SaveChanges()
        {
           
            var entities = from e in ChangeTracker.Entries()
                        where e.State == EntityState.Added
                            || e.State == EntityState.Modified
                        select e.Entity;
            foreach (var entity in entities)
            {
                var validationContext = new ValidationContext(entity);
                Validator.ValidateObject(entity, validationContext);
            }

            var EditedEntities = ChangeTracker.Entries().Where(E => E.Entity is BaseClass && E.State == EntityState.Modified).ToList();

            EditedEntities.ForEach(E =>
            {
                ((BaseClass)E.Entity).UpdatedDate = DateTime.UtcNow;
               
            });

            return base.SaveChanges();
        }


    }
}
