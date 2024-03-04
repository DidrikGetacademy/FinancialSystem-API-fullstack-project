using System.Diagnostics.Eventing.Reader;
using Microsoft.AspNetCore.Mvc;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using ØkonomiSystemet;

namespace FinancialSystemBackend_api_database
{

    [ApiController] // markerer klassen som et api
    [Route("api/[Controller]")] // angir ruten ( alle HTTP-forespørsler til dette API-et må starte med /api/User)
    public class
        UserController : ControllerBase // del av ASP.NET Core-rammeverket og gir funksjonalitet for å håndtere HTTP-forespørsler i en ASP.NET Core-applikasjon.
    {
        private readonly DbConnection _Context; //privat referanse til dbconnection klassen

        public UserController(DbConnection context)
        {
            _Context = context; // instanse 
        }



        [HttpPost("project")]
        public IActionResult CreateProject([FromBody] ProjectCreationRequest project)
        {
            if (project == null || string.IsNullOrEmpty(project.Title) || string.IsNullOrEmpty(project.Username))
            {
                return BadRequest("Invalid Project data");
            }

            string Projectname = project.Title;
            string description = project.Description;

            Savings newProject = new Savings(Projectname, description);
            var CurrentUser = _Context.Users.FirstOrDefault(x => x.Username == project.Username);
            if (CurrentUser == null)
            {
                BadRequest("User not found");
            }

            CurrentUser.UserSavingProjects.Add(newProject);
            _Context.SaveChanges();
            return Ok("Project created sucsessfully");
        }












        [HttpPost("projectList")]
        public IActionResult GetProjectsForUser([FromBody] string Username)
        {
            Console.WriteLine($"Received request for projects for user: {Username}");
            var user = _Context.Users.Include(x => x.UserSavingProjects).FirstOrDefault(x => x.Username == Username);
            if (user == null)
            {
                return BadRequest("User not found");
            }



            if (user.UserSavingProjects != null)
            {
                var projects = user.UserSavingProjects.Select(x => new { x.Title, x.Description });
                return Ok(projects);
            }
            else
            {
                return BadRequest("User has no projects");
            }
        }
        





    [HttpPost("register")] // en HttpPost som registerer ny bruker i database
        public IActionResult RegisterUser([FromBody] User user)
        {
            // sjekker om det finnes en bruker i databasen med dette navnet, vis det gjør det så returnerer den en conflict, vis ikke så legger den brukeren til i databasen
            if (_Context.Users.Any(u => u.Username == user.Username))
            {
                return Conflict("User with this username already exsist. please choose a different username");
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Password = hashedPassword;

            _Context.Users.Add(user); //legger til bruker i database
            _Context.SaveChanges(); // lagrer endringer
            return Ok(); // sender en ok status til frontend
        }




        [HttpPost("Login")]
        public IActionResult LoginUser([FromBody] UserloginDTO Logindata)
        {
            try
            {

                var existingUser = _Context.Users.FirstOrDefault(x => x.Username == Logindata.Username);

                if (existingUser != null)
                {
                    if (BCrypt.Net.BCrypt.Verify(Logindata.Password, existingUser.Password))
                    {
                        Console.WriteLine("Login successful for user: " + existingUser.Username);
                        return Ok(new { _username = existingUser.Username });
                    }
                    else
                    {
                        Console.WriteLine("Invalid username or password");
                        return Unauthorized("Invalid username or password");
                    }
                }
                else
                {
                    Console.WriteLine("User not found");
                    return Unauthorized("user not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occurred: " + ex.Message);
                return StatusCode(500, $"failed to log in: {ex.Message}");
            }
        }
    }
}





//klasse som representerer data fra frontend ihenhold til login
public class UserloginDTO 
{
            public string Username { get; set; }

            public string Password { get; set; }
}






//klasse som representerer data fra frontend ihenhold til opprettelse av prosjekt 
public class ProjectCreationRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Username { get; set; }
}
