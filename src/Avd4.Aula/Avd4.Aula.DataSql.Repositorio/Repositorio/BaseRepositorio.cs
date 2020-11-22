using System;
using System.Collections.Generic;
using System.Text;

namespace Avd4.Aula.DataSql.Repositorio.Repositorio
{
    public class BaseRepositorio
    {
        // String de conexão com o banco de dados (local)
        // protected string _conexaoBancoDeDados = @"Data Source=.\SQLEXPRESS;Initial Catalog=DbAvd4;Integrated Security=True";

        // String de conexão com o banco de dados (produção)
        protected string _conexaoBancoDeDados = @"Data Source=sql-avd4.database.windows.net;Initial Catalog=avd4;Persist Security Info=True;User ID=avd4;Password=UO!g*pOq3xqf;MultipleActiveResultSets=True";
    }
}
