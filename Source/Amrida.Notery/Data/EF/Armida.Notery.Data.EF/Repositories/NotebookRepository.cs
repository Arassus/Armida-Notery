using Amrida.Notery.Presentation.Core.Models;
using Amrida.Notery.Presentation.Core.Repositories;
using Armida.Notery.Common.DTOs;
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

        public async Task<NotebookCreationResultDto> Create(Notebook model)
        {
            var creationResult = new NotebookCreationResultDto();

            var notebook = await _dataContext.Notebooks
               .FirstOrDefaultAsync(n => n.Id == model.Id)
               .ConfigureAwait(false);

            // Entity already exists
            if (notebook != null)
            {
                creationResult.Created = true;
                creationResult.Errors.Add($"The Notebook '{notebook.Id}' already exists in the database");
            }

            // Create new Entity
            notebook = new Data.Notebook
            {
                Id = model.Id != Guid.Empty ? model.Id : Guid.NewGuid()
            };

            var addingResult = await _dataContext.Notebooks
                .AddAsync(notebook)
                .ConfigureAwait(false);

            creationResult.Id = notebook.Id;
            creationResult.Created = addingResult.State == EntityState.Added;

            if (!creationResult.Created)
            {
                creationResult.Errors.Add($"The Notebook '{notebook.Id}' could not be saved to database");
                return creationResult;
            }

            // Finalize
            notebook.Name = model.Name;
            notebook.Description = model.Description;
            notebook.Removed = model.Removed;

            var savingResult = await _dataContext
                .SaveChangesAsync()
                .ConfigureAwait(false);

            creationResult.Finalized = savingResult > 0;
            if (!creationResult.Finalized)
            {
                creationResult.Errors.Add($"The Notebook '{model.Name}':'{model.Id}' could not be saved to database");
            }

            return creationResult;
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

        public async Task<NotebookCreationResultDto> Edit(Notebook model)
        {
            var editResult = new NotebookCreationResultDto();

            var notebook = await _dataContext.Notebooks
                .FirstOrDefaultAsync(n => n.Id == model.Id)
                .ConfigureAwait(false);

            // Entity does not exist
            if (notebook == null)
            {
                editResult.Errors.Add($"The Notebook '{model.Name}' does not exist in the database");
                return editResult;
            }

            editResult.Id = notebook.Id;
            editResult.Created = true;

            // Edit
            if (!string.IsNullOrEmpty(model.Name))
                notebook.Name = model.Name;

            if (!string.IsNullOrEmpty(model.Description))
                notebook.Description = model.Description;
                
            notebook.Removed = model.Removed;

            // Save
            var savingResult = await _dataContext
                .SaveChangesAsync()
                .ConfigureAwait(false);

            editResult.Finalized = savingResult > 0;
            if (!editResult.Finalized)
            {
                editResult.Errors.Add($"The Notebook '{model.Name}':'{model.Id}' could not be saved to database");
            }

            return editResult;
        }
    }
}
