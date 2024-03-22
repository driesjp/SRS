using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateController : ControllerBase
    {
        // Field to hold the DatabaseHelper instance for database operations
        private readonly DatabaseHelper _databaseHelper;

        // Constructor that configures the DatabaseHelper with the connection string (DefaultConnection) from appsettings.json
        public UpdateController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            _databaseHelper = new DatabaseHelper(connectionString);
        }

        // Submit difficulty rating for a flashcard. 
        [HttpPost("SubmitDifficulty")]
        public async Task<IActionResult> SubmitDifficulty([FromBody] DifficultySubmission submission)
        {
            // Validates the received submission.
            if (submission == null)
            {
                return BadRequest("Invalid submission");
            }

            // Logs the received flashcard ID and difficulty level for debugging.
            Debug.WriteLine($"Received flashcardId: {submission.FlashcardId}, difficulty: {submission.Difficulty}");

            // Fetch the current E-Factor (EF) for the flashcard
            string selectQuery = "SELECT EF FROM flashcards WHERE ID = @FlashcardId";
            var selectParameters = new Dictionary<string, object>
        {
            { "@FlashcardId", submission.FlashcardId }
        };

            var results = await _databaseHelper.GetDataAsync<double>(
                selectQuery, selectParameters, reader => reader.GetDouble(0));

            // Checks if the flashcard exists in the database.
            if (results.Count == 0)
            {
                return NotFound(new { message = "Flashcard not found" });
            }

            double currentEF = results[0];

            // Map submitted difficulty to a quality of response
            double qualityOfResponse = submission.Difficulty switch
            {
                1 => 1, // Hard
                2 => 30, // Medium
                3 => 100, // Easy
                _ => throw new ArgumentOutOfRangeException(nameof(submission.Difficulty), "Invalid difficulty level")
            };

            // Adjust the EF based on the mapped quality of response
            double newEF = CalculateNewEF(currentEF, qualityOfResponse);

             

            // Calculate the next review interval (in hours) based on the new EF
            int newInterval = CalculateNextReviewInterval(newEF);

            Debug.WriteLine("new interval: " + newInterval);

            // Update the flashcard with the new EF and next review interval
            string updateQuery = @"UPDATE flashcards SET next_review = DATE_ADD(NOW(), INTERVAL @NewInterval HOUR), EF = @NewEF WHERE ID = @FlashcardId";

            var updateParameters = new Dictionary<string, object>
        {
            { "@NewInterval", newInterval },
            { "@NewEF", newEF },
            { "@FlashcardId", submission.FlashcardId }
        };

            // Executes the update query and checks if any rows were affected.
            int affectedRows = await _databaseHelper.ExecuteAsync(updateQuery, updateParameters);

            // Returns success message if the update was successful.
            if (affectedRows > 0)
            {
                return Ok(new { message = "Update successful" });
            }
            else
            {
                return NotFound(new { message = "Flashcard not found" });
            }
        }

        // Calculates the next review interval based on the new EF.
        private int CalculateNextReviewInterval(double newEF)
        {
            int hourInterval = 6;
            
            return (int)Math.Round(newEF * hourInterval);
        }

        // Calculates the new EF based on the current EF and the quality of response.
        private double CalculateNewEF(double currentEF, double qualityOfResponse)
        {
            // Adjustment and base for the logarithmic calculation. These constants are chosen based on the algorithm's design
            // to ensure a smooth adjustment of the EF based on the quality of response. However, these will be used for drift values.
            int logAdjustment = 1;
            int logBase = 11;

            // Calculates the new EF using a logarithmic function to adjust the current EF based on the quality of response.
            // The logAdjustment is added to the qualityOfResponse to prevent taking the log of 0, which is undefined.
            // The logBase is used to control the rate of change of the EF.
            double newEF = currentEF * Math.Log(qualityOfResponse + logAdjustment, logBase);

            // Ensures the new EF does not fall below a minimum threshold.
            // 0.0050 is used as the threshold, corresponding to a +- 3-minute interval, ensuring that the EF does not drop too low.
            // This minimum threshold is important to prevent the interval between reviews from becoming impractically short.
            return newEF < 0.0050 ? 0.0050 : newEF;
        }
    }
}