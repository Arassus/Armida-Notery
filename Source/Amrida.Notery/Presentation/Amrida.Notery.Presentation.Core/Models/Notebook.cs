namespace Amrida.Notery.Presentation.Core.Models
{
    public class Notebook
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Removed { get; set; }

        public Notebook Copy() =>
            new() 
            { 
                Id = this.Id, 
                Name = this.Name, 
                Description = this.Description
            };
    }
}
