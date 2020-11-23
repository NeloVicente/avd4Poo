using System;
using System.Collections.Generic;
using System.Text;

namespace Avd4.Aula.Domain.Entidades
{
  public class Curso
    {
        public Curso()
        {
            Disciplinas = new List<Disciplina>();
            Inscricoes = new List<Inscricao>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public ICollection<Disciplina> Disciplinas { get; set; }
        public ICollection<Inscricao> Inscricoes { get; set; }

        public void ValidarCamposObrigatorios(Aluno aluno)
        {
            if (string.IsNullOrWhiteSpace(aluno.Nome))
            {
                throw new Exception("O campo nome é obrigatório e não foi informado, verifique.");
            }
        }
    }
}
