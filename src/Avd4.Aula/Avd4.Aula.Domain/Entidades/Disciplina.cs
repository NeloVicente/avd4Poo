using System;
using System.Collections.Generic;
using System.Text;

namespace Avd4.Aula.Domain.Entidades
{
    public class Disciplina
    {
        public Disciplina()
        {
            Cursos = new Curso();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int CargaHoraria { get; set; }
        public string Descricao { get; set; }

        public int IdCurso { get; set; }
        public Curso Cursos { get; set; }

        public ICollection<InscricaoDisciplina> Inscricoes { get; set; }

        public void ValidarCamposObrigatorios(Disciplina disciplina)
        {
            if (string.IsNullOrWhiteSpace(disciplina.Nome))
            {
                throw new Exception("O campo nome é obrigatório e não foi informado, verifique.");
            }

            if (disciplina.IdCurso == 0)
            {
                throw new Exception("Informe o Id do curso.");
            }
        }
    }
}
