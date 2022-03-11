using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Data;

namespace CURDWITHADO.Models
{
    public class EmployeeDataAccess
    {
        DbConnection Dbconnection;
        public EmployeeDataAccess()
        {
            Dbconnection = new DbConnection();
        }
        public List<Employee> GetEmployee()
        {
            string Sp = "SP_Employee";
            SqlCommand sql = new SqlCommand(Sp, Dbconnection.Connection);
            sql.CommandType = CommandType.StoredProcedure;
            sql.Parameters.AddWithValue("@action", "SELECT_JOIN");
            if (Dbconnection.Connection.State ==System.Data. ConnectionState.Closed)
            {
                Dbconnection.Connection.Open();
            }
            SqlDataReader dr = sql.ExecuteReader();
            List<Employee> employee = new List<Employee>();

            while(dr.Read())
            {
                Employee Emp = new Employee();
                Emp.id = (int)dr["Id"];
                Emp.Name = dr["name"].ToString();
                Emp.Email = dr["email"].ToString();
                Emp.Mobile = dr["mobile"].ToString();
                Emp.Gender = dr["gender"].ToString();
                Emp.DName = dr["Department"].ToString();
                employee.Add(Emp);
            }
            Dbconnection.Connection.Close();
            return employee;
        }

    }
}
