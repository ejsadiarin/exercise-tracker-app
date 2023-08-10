using API.Models;

namespace API.Services;

public interface IExerciseService
{
    // CRUD Operations
    Task<List<Exercise>> GetAllExercises();
    Task<Exercise>? GetSingleExercise(int id);
    Task<List<Exercise>?> AddExercise(Exercise exercise);
    Task<List<Exercise>?> UpdateExercise(int id, Exercise exercise);
    Task<List<Exercise>?> DeleteExercise(int id);
}