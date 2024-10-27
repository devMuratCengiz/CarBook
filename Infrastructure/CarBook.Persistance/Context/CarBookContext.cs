using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistance.Context
{
    public class CarBookContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-S2VR96V;Database=CarBookDb;integrated Security=true;trustServerCertificate=true");
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarDescription> CarDescriptions { get; set; }
        public DbSet<CarPricing> CarPricings { get; set; }
        public DbSet<CarFeature> CarFeatures { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<FooterAddress> FooterAddresses { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Pricing> Pricings { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comment> Comments{ get; set; }
        public DbSet<RentACar> RentACars{ get; set; }
        public DbSet<Rezervation> Rezervations { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rezervation>()
                .HasOne(x => x.PickUp)
                .WithMany(y => y.PickUpRezervation)
                .HasForeignKey(x => x.PickUpId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Rezervation>()
                .HasOne(x => x.DropOff)
                .WithMany(y => y.DropOffRezervation)
                .HasForeignKey(z => z.DropOffId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
