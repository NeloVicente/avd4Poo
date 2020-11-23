using System;
using System.Collections.Generic;
using System.Text;

namespace Avd4.Aula.Domain.Entidades
{
    public class Inscricao
    {
        public Inscricao()
        {
            Alunos = new Aluno();
            Cursos = new Curso();
        }

        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataConclusao { get; set; }
        public string Status { get; set; }

        public int IdAluno { get; set; }
        public Aluno Alunos { get; set; }

        public int IdCurso { get; set; }
        public Curso Cursos { get; set; }

        public ICollection<InscricaoDisciplina> Inscricoes { get; set; }

        public void ValidarDataInicioEConclusao(Inscricao inscricao)
        {
            if (inscricao.DataInicio > inscricao.DataConclusao.Value)
            {
                throw new Exception("A data de início não pode ser maior que a data de conclusão.");
            }

            if (inscricao.IdAluno == 0)
            {
                throw new Exception("Informe o Id do aluno.");
            }
        }
    }
}
