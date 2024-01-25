using BackendApi.Contracts.Category;
using BackendApi.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public Расходы_ДоходыContext Context { get; }

        public CategoryController(Расходы_ДоходыContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Вывод информации о категориях
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            List<CategoryType> Category_Types = Context.CategoryTypes.ToList();
            return Ok(Category_Types);
        }

        /// <summary>
        /// Вывод категорий по ID
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            CategoryType? Category_Type = Context.CategoryTypes.Where(x => x.Id == id).FirstOrDefault();
            if (Category_Type == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(Category_Type);
        }

        /// <summary>
        /// Создание новой категории
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     {
        ///        "Name" : "Образование"
        ///     }
        ///
        /// </remarks>
        /// <param name="category">Категории</param>
        /// <returns></returns>

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Add(CreateCategoryRequest categoryType)
        {
            var categoryTypeDto = categoryType.Adapt<CategoryType>();
            Context.CategoryTypes.Add(categoryTypeDto);
            Context.SaveChanges();
            return Ok(categoryTypeDto);
        }

        /// <summary>
        /// Обновление записи категорий
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     {
        ///        "Name" : "Образование"
        ///     }
        ///
        /// </remarks>
        /// <param name="category">Категории</param>
        /// <returns></returns>
        ///
        // PUT api/<UsersController>
        [HttpPut]
        public IActionResult Update(CategoryType categoryType)
        {
            var categoryTypeDto = categoryType.Adapt<CategoryType>();
            Context.CategoryTypes.Update(categoryTypeDto);
            Context.SaveChanges();
            return Ok(categoryTypeDto);
        }

        /// <summary>
        /// Удаление записи о категориях
        /// </summary>
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            CategoryType? Category_Type = Context.CategoryTypes.Where(x => x.Id == id).FirstOrDefault();
            if (Category_Type == null)
            {
                return BadRequest("Not Found");
            }
            Context.CategoryTypes.Remove(Category_Type);
            Context.SaveChanges();
            return Ok(Category_Type);
        }
    }
}
