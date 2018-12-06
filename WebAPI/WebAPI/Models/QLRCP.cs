namespace WebAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QLRCP : DbContext
    {
        public QLRCP()
            : base("name=QLRCP")
        {
        }

        public virtual DbSet<Chair> Chairs { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<Film_GenreFilm> Film_GenreFilm { get; set; }
        public virtual DbSet<Genre_chair> Genre_chair { get; set; }
        public virtual DbSet<Genre_film> Genre_film { get; set; }
        public virtual DbSet<Genre_room> Genre_room { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Film>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Customers)
                .WithOptional(e => e.User)
                .WillCascadeOnDelete();
        }
    }
}
