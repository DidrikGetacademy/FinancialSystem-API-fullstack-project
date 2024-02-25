using Microsoft.AspNetCore.Mvc;

namespace FinancialSystemBackend_api_database
{

    [ApiController]// markerer klassen som et api
    [Route("api/[Controller]")] // angir ruten ( alle HTTP-forespørsler til dette API-et må starte med /api/User)
    public class UserController : ControllerBase // del av ASP.NET Core-rammeverket og gir funksjonalitet for å håndtere HTTP-forespørsler i en ASP.NET Core-applikasjon.
    {
        private readonly DbConnection _Context; //privat referanse til dbconnection klassen

        public UserController(DbConnection context)
        {
            _Context = context; // instanse 
        }







        [HttpPost("register")]   // en HttpPost som registerer ny bruker i database
        public IActionResult RegisterUser([FromBody] User user)
        {
            // sjekker om det finnes en bruker i databasen med dette navnet, vis det gjør det så returnerer den en conflict, vis ikke så legger den brukeren til i databasen
            if (_Context.Users.Any(u => u.Username == user.Username))
            {
                return Conflict("User with this username already exsist. please choose a different username");
            }

            _Context.Users.Add(user);//legger til bruker i database
            _Context.SaveChanges();// lagrer endringer
            return Ok();// sender en ok status til frontend
        }





        [HttpPost("Login")]
        public IActionResult LoginUser([FromBody] UserloginDTO Logindata)
        {
            try
            {
                var exsistingUser = _Context.Users.FirstOrDefault(x => x.Username == Logindata.Username && x.Password == Logindata.Password); //variabel som sjekker om data fra frontend matcher data i databasen
                if (exsistingUser != null)// vis data er lik og password og username stemmer så kjøres en ok (godkjent)
                {
                    return Ok(new { _username = exsistingUser.Username });
                }
                else// vis ikke så kjører en unatorized feil brukernavn eller password 
                {
                    return Unauthorized("Invalid username or password");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"failed to log in: {ex.Message}");
            }
        }
    }

    public class UserloginDTO // en klasse som representerer brukerdata fra frontend 
    {
        public string Username { get; set; }

        public string Password { get; set; }    
    }
}
