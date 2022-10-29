using Amrida.Notery.Presentation.Core.Models;
using Armida.Notery.Common.DTOs;

namespace Amrida.Notery.Presentation.Core.Services
{
    public interface INotebookService
    {
        Task<IEnumerable<Notebook>> GetAll();
        Task<Notebook> GetById(Guid id);
        Task<Notebook> GetByName(string Name);
        Task<NotebookCreationResultDto> Create(Notebook Model);
        Task<NotebookCreationResultDto> Edit(Notebook Model);
        Task Remove(Guid Id);
    }
}
