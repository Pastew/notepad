using Microsoft.EntityFrameworkCore;
using Notepad.Shared;

namespace Notepad.Server.Repositories
{
    public class NotepadContext : DbContext
    {

        public NotepadContext()
        {
        }
        
        public NotepadContext(DbContextOptions<NotepadContext> options) : base (options)
        {
        }
        
        public DbSet<NotepadFile> NotepadFiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NotepadFile>()
                .HasKey(n => n.Id);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}