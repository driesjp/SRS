using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ProcessController : ControllerBase
{
    // Field to hold the DatabaseHelper instance for database operations
    private readonly DatabaseHelper _databaseHelper;

    // Constructor that configures the DatabaseHelper with the connection string (DefaultConnection) from appsettings.json
    public ProcessController(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        _databaseHelper = new DatabaseHelper(connectionString);
    }

    // Retrieve a list of flashcards
    [HttpPost("GetFlashcards")]
    public async Task<IActionResult> GetFlashcards()
    {
        var query = "SELECT ID, question, answer FROM flashcards";
        // Executes the query asynchronously and maps the results to an anonymous type
        var flashcards = await _databaseHelper.GetDataAsync(query, null, reader => new
        {
            ID = reader.GetInt32("ID"),
            Question = reader.GetString("question"),
            Answer = reader.GetString("answer")
        });

        // Returns the list of flashcards to the client (our React app)
        return Ok(flashcards);
    }

    // Retrieve a list of flashcards that are either NULL or next review time is <= current time
    [HttpPost("GetFlashcardsReview")]
    public async Task<IActionResult> GetFlashcardsReview()
    {
        var query = "SELECT ID, question, answer FROM flashcards WHERE next_review IS NULL OR next_review <= NOW()";
        var flashcards = await _databaseHelper.GetDataAsync(query, null, reader => new
        {
            ID = reader.GetInt32("ID"),
            Question = reader.GetString("question"),
            Answer = reader.GetString("answer")
        });


        return Ok(flashcards);
    }

    // Count number of review that are coming up in 24 hours
    [HttpPost("CountFlashcards24h")]
    public async Task<IActionResult> CountFlashcards24h()
    {
        var query = @"SELECT COUNT(*) FROM flashcards WHERE next_review < DATE_ADD(NOW(), INTERVAL 24 HOUR)";

        var count = await _databaseHelper.ExecuteScalarAsync(query, null);

        return Ok(new { number = count });
    }
}
