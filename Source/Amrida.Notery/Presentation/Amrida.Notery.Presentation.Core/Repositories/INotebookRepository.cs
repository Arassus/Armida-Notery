using Amrida.Notery.Presentation.Core.Models;

namespace Amrida.Notery.Presentation.Core.Repositories
{
    public interface INotebookRepository
    {
        Task<IEnumerable<Notebook>> GetAll();
        Task<Notebook> GetById(Guid id);
        Task<Notebook> GetByName(string Name);
        Task Save(Notebook Model);
        Task Remove(Guid Id);
    }
}
