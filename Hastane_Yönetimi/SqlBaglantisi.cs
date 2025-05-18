using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;

namespace Hastane_Yönetimi
{
    public class SQLBaglantim
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source= LAPTOP-0SI016LJ\SQLEXPRESS;Initial Catalog=test;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
