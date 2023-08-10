using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;

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
    
    public async Task<Exercise>? GetSingleExercise(int id)
    {
        var exercise = await _exerciseDbContext.Exercises.FindAsync(id);

        if (exercise is null) return null;

        return exercise;
    }

    public async Task<List<Exercise>>? AddExercise(Exercise exercise)
    {
        if (exercise is null)
        {
            throw new ArgumentNullException(nameof(exercise));
        }

        // id will be automatically incremented
        _exerciseDbContext.Exercises.Add(exercise);
        await _exerciseDbContext.SaveChangesAsync();

        // output new list with new additions
        return await _exerciseDbContext.Exercises.ToListAsync();
    }

    public async Task<List<Exercise>?> UpdateExercise(int id, Exercise request)
    {
        // go to db and find id
        var exercise = await _exerciseDbContext.Exercises.FindAsync(id);

        if (exercise is null) return null;

        exercise.Name = request.Name;
        exercise.Category = request.Category;

        await _exerciseDbContext.SaveChangesAsync();

        return await _exerciseDbContext.Exercises.ToListAsync();
    }

    public async Task<List<Exercise>?> DeleteExercise(int id)
    {
        var exercise = await _exerciseDbContext.Exercises.FindAsync(id);

        if (exercise is null) return null;

        _exerciseDbContext.Exercises.Remove(exercise);

        // save changes to database
        await _exerciseDbContext.SaveChangesAsync();

        return await _exerciseDbContext.Exercises.ToListAsync();

    }
    
}