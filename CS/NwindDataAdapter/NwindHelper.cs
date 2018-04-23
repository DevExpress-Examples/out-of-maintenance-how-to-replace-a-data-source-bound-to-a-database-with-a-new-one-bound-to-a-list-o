using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

namespace NwindDataAdapter
{
    public class NwindHelper
    {
        public static DataTable GetInvoices( string fileName )
        {
            DataTable dataTableInvoices = new DataTable();
            using (OleDbConnection connection = GetConnection(fileName))
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter(string.Empty, connection);
                adapter.SelectCommand.CommandText = "SELECT * FROM [Invoices] WHERE OrderDate < #06/06/1995# ";
                adapter.Fill(dataTableInvoices);
            }
            return dataTableInvoices;
        }

        static OleDbConnection GetConnection(string fileName)
        {
            OleDbConnection connection = new OleDbConnection();
            //Jet 4
            //connection.ConnectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}", fileName));
            //OLEDB 12
            connection.ConnectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}", fileName);
            return connection;
        }

        
    }


}