using Armida.Notery.Common.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/notebooks")]
    public class NotebooksController : Controller
    {
        private static List<NotebookDto> Notebooks = new List<NotebookDto>()
        {
            new NotebookDto()
            {
                Id = Guid.NewGuid(),
                Description = "Notebook Description 1",
                Name = "Notebook Name 1",
                Removed = false,
            },

            new NotebookDto()
            {
                Id = Guid.NewGuid(),
                Description = "Notebook Description 2",
                Name = "Notebook Name 2",
                Removed = false,
            },

            new NotebookDto()
            {
                Id = Guid.NewGuid(),
                Description = "Notebook Description 3",
                Name = "Notebook Name 3",
                Removed = true,
            },

            new NotebookDto()
            {
                Id = Guid.NewGuid(),
                Description = "Notebook Description 4",
                Name = "Notebook Name 4",
                Removed = false,
            },
        };

        [HttpGet]
        public ActionResult<IEnumerable<NotebookDto>> Get()
        {
            //return NotFound();

            return Ok(Notebooks);
        }
    }
}
