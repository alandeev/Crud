using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.SqlClient;
using Dapper;

namespace CRUD_TI
{
    class Metodos
    {
        public int verify(string nome,string login,string senha, int idade)
        {
            int count = 0;
            if (nome.Length >= 8)
            {
                count += 1;
            }
            if (login.Length >= 8)
            {
                count += 1;
            }
            if (senha.Length >= 8)
            {
                count += 1;
            }
            if (idade >= 18 && idade < 100)
            {
                count += 1;
            }
            return count;
        }
    }
}
