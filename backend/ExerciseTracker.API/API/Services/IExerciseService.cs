using API.Models;

namespace API.Services;

public interface IExerciseService
{
    // CRUD Operations
    Task<List<Exercise>> GetAllExercises();
    Task<Exercise>? GetSingleExercise();
    Task<List<Exercise>?> AddExercise();
    Task<List<Exercise>?> UpdateExercise();
    Task<List<Exercise>?> DeleteExercise();
}