namespace Armida.Notery.Common.Dtos
{
    public class NotebookDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Removed { get; set; }
    }
}
