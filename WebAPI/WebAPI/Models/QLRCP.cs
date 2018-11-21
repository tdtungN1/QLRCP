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
            modelBuilder.Entity<Chair>()
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.Chair)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Film>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Film>()
                .HasMany(e => e.Film_GenreFilm)
                .WithRequired(e => e.Film)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Film>()
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.Film)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Genre_chair>()
                .HasMany(e => e.Chairs)
                .WithRequired(e => e.Genre_chair)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Genre_film>()
                .HasMany(e => e.Film_GenreFilm)
                .WithRequired(e => e.Genre_film)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Genre_room>()
                .HasMany(e => e.Rooms)
                .WithRequired(e => e.Genre_room)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Room>()
                .HasMany(e => e.Chairs)
                .WithRequired(e => e.Room)
                .WillCascadeOnDelete(false);

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
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
