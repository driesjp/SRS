# About
Spaced repetition is an evidence-based learning technique that is usually performed with flashcards. Newly introduced and more difficult flashcards are shown more frequently, while older and less difficult flashcards are shown less frequently in order to exploit the psychological spacing effect. The use of spaced repetition has been proven to increase the rate of learning.
(source: https://en.wikipedia.org/wiki/Spaced_repetition)

The purpose behind building this custom SRS platform is to build the foundation to go beyond traditional SRS algorithms.
With, in time, incorporating factors such as user intelligence, interest, and motivation into the scheduling logic.
This personalised approach aims to optimise the learning experience and efficiency for individual users, tailoring the difficulty and review intervals more closely to their unique learning pace and needs.


# Front-end
The front-end was developed using React 18, embodying modern React features and best practices to create a dynamic and interactive user interface.
It leverages the Context API, Fetch API, and React Router, focusing on modularity and separation of concerns.

- Context API for global state management, specifically to handle the state related to learning flashcards.
- Server communication is handled using the Fetch API, abstracted in a service layer (LearnService.js), which interacts with the backend to fetch the flashcards data.
    This abstraction encapsulates the API calls, making the codebase cleaner and more maintainable. Environment variable (.env) is used for the base url.
- React Router is employed to manage navigation within the app, enabling the creation of a single-page application (SPA) with multiple views without the need for page reloads. 
- It also features a welcome page, with a nod to the React 18 default page.
- Ducks.

For explanation, comments are provided in the code. Mainly in LearnService.js, LearnContext.js and Api.js in the components folder and App.js 


# Back-end
Developed using C# in Visual Studio 2022.
Whilst in a production version of this application, I'd most likely use Entity Framework Core, this API uses a helper class for database operations since it enables easy modifcation of the SQL queries.
It uses MySql.Data package to connect to a MySQL database and provides three main asynchronous methods: GetDataAsync<T> for fetching data, ExecuteScalarAsync for executing queries that return a single value, and ExecuteAsync for executing commands that modify data.
These methods utilise async/await for non-blocking database calls.

The GetFlashcards endpoint retrieves a list of flashcards from the database and returns it to the client. 
The CountFlashcards24h endpoint counts how many flashcards need to be reviewed in the next 24 hours.

The DifficultySubmission performs several operations:
- Checks if the submission object is null, returns BadRequest if invalid
- Executes a SELECT query to fetch the current efficiency factor (EF) for the specified flashcard, returns BadRequest if no rows are returned (not found)
- Depending on the submitted difficulty, it calculates a new EF and the next review interval 
- Executes an UPDATE query to set the flashcard's new EF and next review timestamp in the database

Some advantages of the helper class:
Asynchronous:
By utilising asynchronous methods, the application can handle database operations without blocking the main thread. 
Separation of Concerns:
The DatabaseHelper abstracts away the complexity of database interactions, making the controller code cleaner and focused on handling API logic. 
Reusability:
The DatabaseHelper can be used across different controllers within the application

For more info, comments are provided in the code.

When testing, remember to update the 'DefaultConnection' variable in appsettings.json as needed.
The database configuration is injected from the controller into the DatabaseHelper class.


# Database
For testing purposes, MySQL is the selected database due to its generous licensing terms and status as an industry standard.
In my setup, MySQL is deployed within a Docker container and managed using MySQL Workbench or HeidiSQL.


# Excel
An Excel spreadsheet that utilises the SRS algorithm from the API for calculating interval trajectories is provided.
The Quality of Response is adjusted in cell C2 (dropdown listbox) and the initial EF is adjusted in cell B4.
