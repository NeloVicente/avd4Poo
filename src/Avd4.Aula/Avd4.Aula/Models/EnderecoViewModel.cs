using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avd4.Aula.Models
{
    public class EnderecoViewModel
    {
        public int Id { get; set; }

        public string Endereco { get; set; }

        public string Numero { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }
    }
}
