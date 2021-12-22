using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebAppDemo.DAL
{

    public class crud
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TodoDB"].ToString());

        public DataTable GetTodos()
        {
            SqlDataAdapter da = new SqlDataAdapter("spGetTodo", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void InsertTodo(string todo)
        {
            SqlCommand cmd = new SqlCommand("spInsertTodo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@todo", todo);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string message = "App error: " + e.Message + " DB Error: " + e.InnerException;
                Console.WriteLine(message);
            }
            finally
            {
                con.Close();
            }
        }

        public void DeleteRow(int id)
        {
            SqlCommand cmd = new SqlCommand("spTodoDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string message = "App error: " + e.Message + " DB Error: " + e.InnerException;
                Console.WriteLine(message);
            }
            finally
            {
                con.Close();
            }
        }
        public void UpdateRow(int todoid, string todoNew)
        {
            SqlCommand cmd = new SqlCommand("spTodoUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@todoNew", todoNew);
            cmd.Parameters.AddWithValue("@id", todoid);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string message = "app error: " + e.Message + " db error: " + e.InnerException;
                Console.WriteLine(message);
            }
            finally
            {
                con.Close();
            }
        }
    }

}