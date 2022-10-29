using Amrida.Notery.Presentation.Core.Models;
using Amrida.Notery.Presentation.Core.Services;
using Armida.Notery.Common.Dtos;
using Armida.Notery.Common.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/notebooks")]
    public class NotebooksController : Controller
    {
        private readonly INotebookService _notebookService;
        private readonly IMapper _mapper;

        public NotebooksController(INotebookService notebookService, IMapper mapper)
        {
            _notebookService = notebookService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotebookDto>>> GetAll()
        {
            var notebooks = await _notebookService.GetAll();
            return Ok(notebooks);
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<NotebookCreationResultDto>> CreateNotebook(NotebookDto notebookDto)
        {
            var notebook = _mapper.Map<Notebook>(notebookDto);
            var result = await _notebookService.Create(notebook);

            if(result.Finalized)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost]
        [Route("edit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<NotebookCreationResultDto>> EditNotebook(NotebookDto notebookDto)
        {
            var notebook = _mapper.Map<Notebook>(notebookDto);
            var result = await _notebookService.Edit(notebook);

            if (result.Finalized)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
