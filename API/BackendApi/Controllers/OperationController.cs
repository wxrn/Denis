using BackendApi.Contracts.Operation;
using BackendApi.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        public Расходы_ДоходыContext Context { get; }

        public OperationController(Расходы_ДоходыContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Вывод информации об операции
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Operation> operation = Context.Operations.ToList();
            return Ok(operation);
        }

        /// <summary>
        /// Вывод операции по ID
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Operation? operation = Context.Operations.Where(x => x.Id == id).FirstOrDefault();
            if (operation == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(operation);
        }

        /// <summary>
        /// Создание операции
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
        /// <param name="operation">Операция</param>
        /// <returns></returns>
        ///
        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Add(CreateOperationRequest operation)
        {
            var operationDto = operation.Adapt<Operation>();
            Context.Operations.Add(operationDto);
            Context.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// Обновление записи операции
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
        /// <param name="operation">Операция</param>
        /// <returns></returns>
        ///
        // PUT api/<UsersController>
        [HttpPut]
        public IActionResult Update(CreateOperationRequest operation)
        {
            var operationDto = operation.Adapt<Operation>();
            Context.Operations.Update(operationDto);
            Context.SaveChanges();
            return Ok(operationDto);
        }

        /// <summary>
        /// Удаление записи об операции
        /// </summary>
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            Operation? operation = Context.Operations.Where(x => x.Id == id).FirstOrDefault();
            if (operation == null)
            {
                return BadRequest("Not Found");
            }
            Context.Operations.Remove(operation);
            Context.SaveChanges();
            return Ok(operation);
        }
    }
}
