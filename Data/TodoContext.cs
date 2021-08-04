using Microsoft.EntityFrameworkCore;
using todo_aspnetcore.Models;
using System;

namespace todo_aspnetcore.Data 
{
    public class TodoContext: DbContext 
    {
        // 
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
        }

        // these propertiesmap to tables in the database
        public DbSet<Todo> Todos { get; set; }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            BeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }


        private void BeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            DateTime now = DateTime.UtcNow;

            foreach (var entry in entries) 
            { 
                if (entry.Entity is ITrackable trackable)
                {
                    if (entry.State == EntityState.Added)
                    {
                        trackable.CreatedAt = now;
                        trackable.LastUpdatedAt = now;
                    }

                    if (entry.State == EntityState.Modified) 
                    {
                        trackable.LastUpdatedAt = now;
                    }
                }
            }
        }
    }
}


