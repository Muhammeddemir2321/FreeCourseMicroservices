using FreeCourse.Services.Catalog.Dtos;
using FreeCourse.Services.Catalog.Services;
using FreeCourse.Shared.Controller;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : CustomBaseController
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return CreateActionResult(await _courseService.GetByIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResult(await _courseService.GetAllAsync());
        }

        [HttpGet("[action]/{userId}")]
        public async Task<IActionResult> GetAllByUserId(string userId)
        {
            return CreateActionResult(await _courseService.GetAllByUserIdAsync(userId));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CourseCreateDto course)
        {
            return CreateActionResult(await _courseService.CreateAsync(course));
        }

        [HttpPut]
        public async Task<IActionResult> Update(CourseUpdateDto course)
        {
            return CreateActionResult(await _courseService.UpdateAsync(course));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return CreateActionResult(await _courseService.DeleteAsync(id));
        }
    }
}
