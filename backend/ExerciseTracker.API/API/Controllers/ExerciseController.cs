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
        var result = await _exerciseService.GetSingleExercise(id);
        
        if (result is null)
        {
            return NotFound("Specified exercise doesn't exist");
        }


        return Ok(result);
    }

}