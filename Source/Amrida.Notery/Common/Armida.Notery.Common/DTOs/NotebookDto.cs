using System.ComponentModel.DataAnnotations;

namespace Armida.Notery.Common.Dtos
{
    public class NotebookDto
    {
        public Guid? Id { get; set; }

        [Required, MaxLength(255)]
        [MinLength(3)]
        public string Name { get; set; } = string.Empty;

        [Required, MaxLength(4000)]
        [MinLength(33)]
        public string Description { get; set; } = string.Empty;

        public bool? Removed { get; set; }
    }
}
