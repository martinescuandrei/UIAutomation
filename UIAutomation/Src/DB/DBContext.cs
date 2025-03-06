using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIAutomation.Src.DB
{
    public class DBContext
    {

        public DBContext() {
            SqlDataReaders = new DataTable();
        }
        public DataTable SqlDataReaders { get; set; }
    }
}
