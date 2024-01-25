using BackendApi.Contracts.Budget;
using BackendApi.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        public Расходы_ДоходыContext Context { get; }

        public BudgetController(Расходы_ДоходыContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Budget> Budget = Context.Budgets.ToList();
            return Ok(Budget);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Budget? Budget = Context.Budgets.Where(x => x.Id == id).FirstOrDefault();
            if (Budget == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(Budget);
        }

        /// <summary>
        /// Создание бюджета 
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     {
        ///        "Start_date" : 22.09.2003,
        ///        "End_date" : 24.10.2003,
        ///        "User_id" : 5549,
        ///        "Size" : 78342
        ///     }
        ///
        /// </remarks>
        /// <param name="model">Бюджет</param>
        /// <returns></returns>

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Add(CreateBudgetRequest budget)
        {
            var budgetsDto = budget.Adapt<Budget>();
            Context.Budgets.Add(budgetsDto);
            Context.SaveChanges();
            return Ok(budgetsDto);
        }

        [HttpPut]
        public IActionResult Update(Budget budget)
        {
            var budgetsDto = budget.Adapt<Budget>();
            Context.Budgets.Update(budgetsDto);
            Context.SaveChanges();
            return Ok(budgetsDto);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            Budget? Budget = Context.Budgets.Where(x => x.Id == id).FirstOrDefault();
            if (Budget == null)
            {
                return BadRequest("Not Found");
            }
            Context.Budgets.Remove(Budget);
            Context.SaveChanges();
            return Ok(Budget);
        }
    }
}
