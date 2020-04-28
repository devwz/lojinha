using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace lojinha.Core.Data
{
    public class ApplicationDbContext
    {
        public ApplicationDbContext(string strCon)
        {
            SqlConnection = new SqlConnection(strCon);
            SqlConnection.Open();
        }

        public SqlConnection SqlConnection { get; set; }
    }
}
