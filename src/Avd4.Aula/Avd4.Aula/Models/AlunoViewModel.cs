using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avd4.Aula.Models
{
    public class AlunoViewModel
    {
        public AlunoViewModel()
        {
            this.Endereco = new List<EnderecoViewModel>();
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public int IdEndereco { get; set; }

        public ICollection<EnderecoViewModel> Endereco { get; set; }
    }
}
