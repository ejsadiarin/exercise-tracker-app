using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class ExerciseController : ControllerBase
{
    private readonly ExerciseService _exerciseService;
    public ExerciseController(ExerciseService exerciseService) 
    {
        _exerciseService = exerciseService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Exercise>>> GetExerciseList()
    {
        return await _exerciseService.GetAllExercises();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Exercise>> GetExercise(int id)
    {
        // further refactor: type should be of DTO not the model Exercise itself --> to exclude id
        Exercise? result = await _exerciseService.GetSingleExercise(id);
        
        if (result is null)
        {
            return NotFound("Specified exercise doesn't exist");
        }

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<List<Exercise>>> Add(Exercise exercise)
    {
        var result = await _exerciseService.AddExercise(exercise);

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<List<Exercise>>> Update(int id, Exercise exercise)
    {
        var result = await _exerciseService.UpdateExercise(id, exercise);

        if (result is null)
        {
            return NotFound($"Id {id} is not found.");
        }

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Exercise>>> Delete(int id)
    {
        var result = await _exerciseService.DeleteExercise(id);

        if (result is null)
        {
            return NotFound($"Id {id} is not found.");
        }

        return Ok(result);
    }

}