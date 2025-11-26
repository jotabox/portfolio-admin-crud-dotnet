using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    /// <summary>
    /// Representa um projeto do seu portfólio profissional.
    /// Este modelo será gerenciado através do Admin Panel.
    /// </summary>
    public class Project
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O título é obrigatório.")]
        [StringLength(100, ErrorMessage = "O título deve ter no máximo 100 caracteres.")]

        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Imagem (URL)")]
        public string? ImageUrl { get; set; }

        public string? Technologies { get; set; }

        [Display(Name = "GitHub (URL)")]
        public string? GitHubUrl { get; set; }

        [Display(Name = "Demo (URL)")]
        public string? DemoUrl { get; set; }

        [Range(0, 9999)]
        public int Order { get; set; } = 0;

        public bool IsPublished { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
