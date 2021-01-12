using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WpfApp2
{
    public class LocalDataAccess
    {
        private static LocalDataAccess instance;
        private LocalDataAccess()
        {

        }
        public static LocalDataAccess GetInstance()
        {
            return instance ?? (instance = new LocalDataAccess());
        }

        MySqlConnection conn;
        MySqlCommand comm;
        MySqlDataAdapter adapter;

        private void Dispose()
        {
            if (adapter != null)
            {
                adapter.Dispose();
                adapter = null;
            }
            if (comm != null)
            {
                comm.Dispose();
                comm = null;
            }
            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }
        }
        private bool DBConnection()
        {
            if (conn == null)
                conn = new MySqlConnection("server=rm-uf6a477d150fh94852o.mysql.rds.aliyuncs.com;port=3306;user=zhangyi;password=Goodluck2020!; database=homeassistant;Allow User Variables=True");
            try
            {
                conn.Open();
                return true;
            }
            catch
            {

                return false;
            }

        }
        public List<string> GetTeachers()
        {
            try
            {
                List<string> result = new List<string>();
                if (this.DBConnection())
                {
                    string sql = "select data from temperature ";
                    adapter = new MySqlDataAdapter(sql, conn);


                    DataTable table = new DataTable();
                    int count = adapter.Fill(table);
                    if (count > 0)
                    {
                        result = table.AsEnumerable().Select(c => c.Field<string>("data")).ToList();

                        
                    }
                }

                return result;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                this.Dispose();
            }

            
        }

       

    }
}
