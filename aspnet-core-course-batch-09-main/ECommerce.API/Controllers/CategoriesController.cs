using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryViewModelProvider _provider;

        public CategoriesController(ICategoryViewModelProvider provider)
        {
            _provider = provider;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _provider.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var category = await _provider.GetByIdAsync(id);

            if (category == null)
                return NotFound();

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            CategoryCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _provider.AddAsync(model);

            return Created("", model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            CategoryEditViewModel model)
        {
            if (id != model.Id)
                return BadRequest();

            await _provider.UpdateAsync(model);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _provider.DeleteAsync(id);

            if (!result)
                return NotFound();

            return Ok();
        }
    }
}
