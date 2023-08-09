using API.Data;
using API.Models;

namespace API.Services;

public class ExerciseService : IExerciseService
{
    // Constructor Injection
    private readonly ExerciseDbContext _exerciseDbContext;

    public ExerciseService(ExerciseDbContext exerciseDbContext) 
    {
        _exerciseDbContext = exerciseDbContext;
    }


    public async Task<List<Exercise>> GetAllExercises()
    {
        // from Database, query all exercises data
        var exercises = await _exerciseDbContext.Exercises.ToListAsync();   
        return exercises;
    }
    
    public async Task<Exercise>? GetSingleExercise()
    {
        
    }

    public async Task<List<Exercise>>? AddExercise()
    {

    }

    public async Task<List<Exercise>?> UpdateExercise();
    {

    }

    public async Task<List<Exercise>?> DeleteExercise();
    {

    }

}