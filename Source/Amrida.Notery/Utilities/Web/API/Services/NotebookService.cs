using Amrida.Notery.Presentation.Core.Models;
using Amrida.Notery.Presentation.Core.Repositories;
using Amrida.Notery.Presentation.Core.Services;
using Armida.Notery.Common.DTOs;

namespace API.Services
{
    public class NotebookService : INotebookService
    {
        private readonly INotebookRepository _notebookRepository;

        public NotebookService(INotebookRepository notebookRepository)
        {
            _notebookRepository = notebookRepository;
        }

        public async Task<NotebookCreationResultDto> Create(Notebook Model) 
            => await _notebookRepository.Create(Model);

        public async Task<NotebookCreationResultDto> Edit(Notebook Model)
            => await _notebookRepository.Edit(Model);

        public async Task<IEnumerable<Notebook>> GetAll()
        {
            return await _notebookRepository.GetAll();
        }

        public Task<Notebook> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Notebook> GetByName(string Name)
        {
            throw new NotImplementedException();
        } 

        public Task Remove(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
