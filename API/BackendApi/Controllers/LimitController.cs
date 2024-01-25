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

        /// <summary>
        /// Вывод информации о лимите
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Limit> Limit = Context.Limits.ToList();
            return Ok(Limit);
        }

        /// <summary>
        /// Вывод лимита по ID
        /// </summary>
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
        /// <param name="limit">Лимит</param>
        /// <returns></returns>
        ///
        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Add(CreateLimitRequest limit)
        {
            var limitDto = limit.Adapt<Limit>();
            Context.Limits.Add(limitDto);
            Context.SaveChanges();
            return Ok(limitDto);
        }

        /// <summary>
        /// Обновление записи о лимите
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     {
        ///        "User_id" : 9843,
        ///        "Type" : "Продукты",
        ///        "Date_time" : 08.03.2017,
        ///        "Sum" : 3274,
        ///        "Comment" : "Операция прошла успешна",
        ///        "Categories_id" : 43857
        ///     }
        ///
        /// </remarks>
        /// <param name="limit">Лимит</param>
        /// <returns></returns>
        ///
        // PUT api/<UsersController>
        [HttpPut]
        public IActionResult Update(Limit limit)
        {
            var limitDto = limit.Adapt<Limit>();
            Context.Limits.Update(limit);
            Context.SaveChanges();
            return Ok(limit);
        }

        /// <summary>
        /// Удаление записи о лимите
        /// </summary>
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
