using System.ComponentModel.DataAnnotations;

namespace AgendaPro.Api.ViewModels
{
    public class EditorViewModels
    {
        [StringLength(160, MinimumLength = 3, ErrorMessage = "A quantidade de números deve ser entre 3 e 160 caracteres")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "O e-mail não é válido")]
        public string Email { get; set; }

        [StringLength(20, MinimumLength = 11, ErrorMessage = "A quantidade de números deve ser entre 11 e 20 caracteres")]
        public string Phone { get; set; }
    }
}
