using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                Email = "chrk@kea.dk",
                EmailConfirmed = true,
                UserName = "chrk@kea.dk",
            };

            var user2 = new IdentityUser
            {
                Id = "2",
                Email = "test@kea.dk",
                EmailConfirmed = true,
                UserName = "test@kea.dk",
            };

            PasswordHasher<IdentityUser> passHash = new PasswordHasher<IdentityUser>();
                user1.PasswordHash = passHash.HashPassword(user1, "aA123456!");
                user2.PasswordHash = passHash.HashPassword(user2, "aA123456!");

                builder.Entity<IdentityUser>().HasData(
                    user1, user2
                );
            }

        private void SeedMovies(ModelBuilder builder)  
        {  
  
                //Tilføj UserIds og lav
            builder.Entity<Movie>().HasData(
                new Movie() {Id = 1, CreatedDate = DateTime.Now, Title = "Movie 1", Text = "Movie no. 1", Status = MovieStatus.PUBLISHED},
                new Movie() {Id = 2, CreatedDate = DateTime.Now, Title = "Movie 2", Text = "Movie no. 2", Status = MovieStatus.DRAFT},
                new Movie() {Id = 3, CreatedDate = DateTime.Now, Title = "Movie 3", Text = "Movie no. 3", Status = MovieStatus.PUBLISHED}
            );  
        }

        private void SeedComments(ModelBuilder builder){
            builder.Entity<Comment>().HasData(
                new Comment() {CommentId = 1, Content = "Comment 1 content", MovieId = 1}
            );
        }
    }
}