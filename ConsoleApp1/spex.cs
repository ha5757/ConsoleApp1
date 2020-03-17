using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ConsoleApp1
{
    class spex
    {
        private static CommandType command;

        static void Main(string[] args)
        {
            int i = int.Parse(Console.ReadLine());
            int j = int.Parse(Console.ReadLine());
            SqlConnection con = new SqlConnection("Password=Admin@123;Persist Security Info=True;User ID=sa;Initial Catalog=Demo;Data Source=DESKTOP-I8O23UC");
            SqlDataAdapter adp = new SqlDataAdapter("Example1", con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            //input parameter of stored procedure
            adp.SelectCommand.Parameters.AddWithValue("@a",i);
          
            adp.SelectCommand.Parameters.AddWithValue("@b",j);
            //output parameter of stored procedure
            SqlParameter p = new SqlParameter("@c",SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            adp.SelectCommand.Parameters.Add(p);
            SqlParameter p1 = new SqlParameter("@d", SqlDbType.Int);
            p1.Direction = ParameterDirection.Output;
            adp.SelectCommand.Parameters.Add(p1);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            Console.WriteLine(p.Value);
            Console.WriteLine(p1.Value);
            Console.Read();

        }
    }
}
