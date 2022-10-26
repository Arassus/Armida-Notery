using Amrida.Notery.Presentation.Core.Models;
using Amrida.Notery.Presentation.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Armida.Notery.Data.EF.Repositories
{
    public class NotebookRepository : INotebookRepository
    {
        private readonly IApplicationDataContext _dataContext;

        public NotebookRepository(IApplicationDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<Notebook>> GetAll() =>
            await _dataContext.Notebooks
                .AsNoTracking()
                .OrderBy(n => n.Id)
                .Select(n => n.Copy())
                .ToListAsync()
                .ConfigureAwait(false);

        public async Task<Notebook> GetById(Guid id) =>
            await _dataContext.Notebooks
                .AsNoTracking()
                .Where(n => n.Id == id)
                .Select(n => n.Copy())
                .FirstOrDefaultAsync();

        public async Task<Notebook> GetByName(string Name) =>
            await _dataContext.Notebooks
                .AsNoTracking()
                .Where(n => Name == n.Name)
                .Select(n => n.Copy())
                .FirstOrDefaultAsync();

        public async Task Save(Notebook model)
        {
            var notebook = await _dataContext.Notebooks
                .FirstOrDefaultAsync(n => n.Id == model.Id)
                .ConfigureAwait(false);

            if (notebook == null)
            {
                notebook = new Data.Notebook
                {
                    Id = model.Id != Guid.Empty ? model.Id : Guid.NewGuid()
                };

                await _dataContext.Notebooks
                    .AddAsync(notebook)
                    .ConfigureAwait(false);
            }

            notebook.Name = model.Name;
            notebook.Description = model.Description;
            notebook.Removed = model.Removed;

            await _dataContext
                .SaveChangesAsync()
                .ConfigureAwait(false);
        }

        public async Task Remove(Guid id)
        {
            var notebook = await _dataContext.Notebooks
                .FirstOrDefaultAsync(n => n.Id == id)
                .ConfigureAwait(false);

            if (notebook != null && !notebook.Removed)
            {
                notebook.Removed = true;
                await _dataContext
                    .SaveChangesAsync()
                    .ConfigureAwait(false);
            }
        }
    }
}
