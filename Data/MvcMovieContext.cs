using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace MvcMovie.Data
{
    public class MvcMovieContext : IdentityDbContext
    {
        public MvcMovieContext (DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }
        
        public DbSet<Movie> Movie { get; set; } 


        public DbSet<Comment> Comments { get; set; }
    



    protected override void OnModelCreating(ModelBuilder builder)  
        {  
            base.OnModelCreating(builder); 
            this.UsersSeed(builder); 
            this.SeedMovies(builder);  
            this.SeedComments(builder);  
        } 

        private void UsersSeed(ModelBuilder builder)
        {
            var user1 = new IdentityUser
            {
                Id = "1",
                Email = "patricko@gmail.com",
                EmailConfirmed = true,
                UserName = "patricko@gmail.com",
            };


            PasswordHasher<IdentityUser> passHash = new PasswordHasher<IdentityUser>();
                user1.PasswordHash = passHash.HashPassword(user1, "aA123456!");

                builder.Entity<IdentityUser>().HasData(
                    user1
                );
            }

        private void SeedMovies(ModelBuilder builder)  
        {  
  

            builder.Entity<Movie>().HasData(
                new Movie() {Id = 1, CreatedDate = DateTime.Now, Title = "Superman", Description = "A mighty superhero!", UserId = "1"}
            );  
        }

        private void SeedComments(ModelBuilder builder){
            builder.Entity<Comment>().HasData(
                new Comment() {CommentId = 1, TimeStamp = DateTime.Now,
                 Content = "I love the Superman movies so much!", MovieId = 1, UserId = "1"}
            );
        }
    }
}