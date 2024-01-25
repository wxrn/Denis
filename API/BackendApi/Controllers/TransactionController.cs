using BackendApi.Contracts.Transaction;
using BackendApi.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        public Расходы_ДоходыContext Context { get; }

        public TransactionController(Расходы_ДоходыContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Transaction> Transaction = Context.Transactions.ToList();
            return Ok(Transaction);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Transaction? Transaction = Context.Transactions.Where(x => x.Id == id).FirstOrDefault();
            if (Transaction == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(Transaction);
        }

        /// <summary>
        /// Создание Транзакции 
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     {
        ///        "User_id" : 4326,
        ///        "Income" : 3443,
        ///        "Expenses" : -12345,
        ///        "Date_time" : 2024-01-19T08:57:13.353Z,
        ///        "Categories_id" : 438054
        ///     }
        ///
        /// </remarks>
        /// <param name="model">Триназакция</param>
        /// <returns></returns>

        // POST api/<UsersController>

        [HttpPost]
        public IActionResult Add(CreateTransactionRequest transaction)
        {
            var transactionDto = transaction.Adapt<Transaction>();
            Context.Transactions.Add(transactionDto);
            Context.SaveChanges();
            return Ok(transactionDto);
        }

        [HttpPut]
        public IActionResult Update(Transaction transaction)
        {
            var transactionDto = transaction.Adapt<Transaction>();
            Context.Transactions.Update(transactionDto);
            Context.SaveChanges();
            return Ok(transactionDto);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            Transaction? Transaction = Context.Transactions.Where(x => x.Id == id).FirstOrDefault();
            if (Transaction == null)
            {
                return BadRequest("Not Found");
            }
            Context.Transactions.Remove(Transaction);
            Context.SaveChanges();
            return Ok(Transaction);
        }
    }
}
