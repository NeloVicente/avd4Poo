using System;
using System.Collections.Generic;
using System.Text;

namespace Avd4.Aula.Domain.Entidades
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Matricula { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public ICollection<Inscricao> Inscricoes { get; set; }

        public void ValidarCamposObrigatorios(Aluno aluno)
        {
            if (string.IsNullOrWhiteSpace(aluno.Nome))
            {
                throw new Exception("O campo nome é obrigatório e não foi informado, verifique.");
            }

            if (string.IsNullOrWhiteSpace(aluno.Email))
            {
                throw new Exception("O campo e-mail é obrigatório e não foi informado, verifique.");
            }
            if (string.IsNullOrWhiteSpace(aluno.Nome))
            {
                throw new Exception("O campo nome é obrigatório e não foi informado, verifique.");
            }
            if (string.IsNullOrWhiteSpace(aluno.Endereco))
            {
                throw new Exception("O campo Endereço é obrigatório e não foi informado, verifique.");
            }
            if (string.IsNullOrWhiteSpace(aluno.Numero))
            {
                throw new Exception("O campo Número é obrigatório e não foi informado, verifique.");
            }
            if (string.IsNullOrWhiteSpace(aluno.Bairro))
            {
                throw new Exception("O campo Bairro é obrigatório e não foi informado, verifique.");
            }
            if (string.IsNullOrWhiteSpace(aluno.Cidade))
            {
                throw new Exception("O campo Cidade é obrigatório e não foi informado, verifique.");
            }
            if (string.IsNullOrWhiteSpace(aluno.Estado))
            {
                throw new Exception("O campo Estado é obrigatório e não foi informado, verifique.");
            }
        }
    }
}
