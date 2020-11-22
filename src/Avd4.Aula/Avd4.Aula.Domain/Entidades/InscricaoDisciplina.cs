using System;
using System.Collections.Generic;
using System.Text;

namespace Avd4.Aula.Domain.Entidades
{
    public class InscricaoDisciplina
    {
        public int Id { get; set; }

        public int IdDisciplina { get; set; }
        public Disciplina Disciplinas { get; set; }

        public int IdInscricao { get; set; }
        public Inscricao Inscricoes { get; set; }
    }
}
