
using BackendApi.Contracts.User;
using BackendApi.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public Расходы_ДоходыContext Context { get; }

        public UserController(Расходы_ДоходыContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Вывод информации о пользователе
        /// </summary
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll() 
        {
            List<User> users = Context.Users.ToList();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            User? user = Context.Users.Where(x => x.Id == id).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(user);
        }

        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     {
        ///        "userName" : "Bacok",
        ///        "age" : 18,
        ///        "passwords" : "12345",
        ///        "email" : "Иванов@gmail.com"
        ///     }
        ///
        /// </remarks>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Add(CreateUserRequest user)
        {
            var userDto = user.Adapt<User>();
            Context.Users.Add(userDto);
            Context.SaveChanges();
            return Ok(userDto);
        }

        [HttpPut]
        public IActionResult Update(GetUserResponse user)
        {
            var userDto = user.Adapt<User>();
            Context.Users.Update(userDto);
            Context.SaveChanges();
            return Ok(userDto);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            User? user = Context.Users.Where(x => x.Id == id).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Not Found");
            }
            Context.Users.Remove(user);
            Context.SaveChanges();
            return Ok(user);
        }
    }
}
