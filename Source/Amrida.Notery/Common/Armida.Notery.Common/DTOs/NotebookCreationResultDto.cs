namespace Armida.Notery.Common.DTOs
{
    public class NotebookCreationResultDto
    {
        public Guid Id { get; set; }
        public bool Created { get; set; }
        public bool Finalized { get; set; }
        public ICollection<string> Errors { get; set; }
    }
}
