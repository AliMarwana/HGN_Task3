using HGN_Task3.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace HGN_Task3.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
       
        public DbSet<Flashcard> Flashcards { get; set; }
        public DbSet<FlashcardsListModel> FlashcardsListModels { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserFullResponse> UserFullResponses { get; set; }
        public DbSet<UserItemResponse> UserItemResponses { get; set; }
        public DbSet<UserRequest> UserRequests { get; set; }
    }
}
