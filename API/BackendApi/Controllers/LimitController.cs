using BackendApi.Contracts.Limit;
using BackendApi.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LimitController : ControllerBase
    {
        public Расходы_ДоходыContext Context { get; }

        public LimitController(Расходы_ДоходыContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Limit> Limit = Context.Limits.ToList();
            return Ok(Limit);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Limit? Limit = Context.Limits.Where(x => x.Id == id).FirstOrDefault();
            if (Limit == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(Limit);
        }

        /// <summary>
        /// Создание Лимита
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     {
        ///        "Type" : "",
        ///        "User_id" : 43983,
        ///        "Name" : "Вацок",
        ///        "Starting_balance" : 4576345,
        ///        "Date_opened" : 07.11.2013,
        ///        "Categories_id" : 43859
        ///     }
        ///
        /// </remarks>
        /// <param name="model">Лимит</param>
        /// <returns></returns>

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Add(CreateLimitRequest limit)
        {
            var limitDto = limit.Adapt<Limit>();
            Context.Limits.Add(limitDto);
            Context.SaveChanges();
            return Ok(limitDto);
        }

        [HttpPut]
        public IActionResult Update(Limit limit)
        {
            var limitDto = limit.Adapt<Limit>();
            Context.Limits.Update(limit);
            Context.SaveChanges();
            return Ok(limit);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            Limit? Limit = Context.Limits.Where(x => x.Id == id).FirstOrDefault();
            if (Limit == null)
            {
                return BadRequest("Not Found");
            }
            Context.Limits.Remove(Limit);
            Context.SaveChanges();
            return Ok(Limit);
        }
    }
}
