using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class ExerciseDbContext : DbContext
{
    public ExerciseDbContext(DbContextOptions<ExerciseDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Exercise> Exercises { get; set; }
}