using System.ComponentModel.DataAnnotations;

namespace Sebrae.UI.Model
{
    public class ContaViewModel
    {
        [Required(ErrorMessage = "O campo Id é obrigatório.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        public string Descricao { get; set; }
    }
}
