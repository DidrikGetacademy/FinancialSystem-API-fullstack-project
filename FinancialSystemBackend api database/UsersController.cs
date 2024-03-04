using System.Diagnostics.Eventing.Reader;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Text;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Mysqlx;
using BCrypt.Net;

namespace MovieSpin_Backend_Files
{

    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly Dbconnection _Context;


        public UsersController(Dbconnection context)
        {

            _Context = context;

        }




        [HttpPost("register")]
        public IActionResult RegisterUser([FromBody] Users user)
        {
            try
            {
                string hashedpassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
                user.Password = hashedpassword;
                var existingUsername = _Context.Users.FirstOrDefault(x => x.Username == user.Username);
                var existingEmail = _Context.Users.FirstOrDefault(x => x.Email == user.Email);

                if (existingUsername != null)
                {
                    return Conflict("Existing username already exists");
                }

                if (existingEmail != null)
                {
                    return Conflict("Existing email already exists");
                }
                else
                {
                    _Context.Users.Add(user);
                    _Context.SaveChanges();
                    return Ok("User registered");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to register user: {ex.Message}");
            }
        }





        [HttpPost("Login")]
        public IActionResult LoginUser([FromBody] UserLoginDTO loginData)
        {
            try
            {

                var existingUser = _Context.Users.FirstOrDefault(u => u.Username == loginData.Username);


                if (existingUser != null)
                {
                    if (BCrypt.Net.BCrypt.Verify(loginData.Password, existingUser.Password))
                    {
                        return Ok(new { _Username = existingUser.Username });
                    }
                    else
                    {
                        return Unauthorized("Invalid username or password");
                    }
                }
                else
                {
                    return Unauthorized("Invalid username or password");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to log in: {ex.Message}");
            }
        }
    }

    public class UserLoginDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

}