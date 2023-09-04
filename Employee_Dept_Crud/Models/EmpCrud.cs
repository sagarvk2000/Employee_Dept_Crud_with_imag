using System.Data.SqlClient;

namespace Employee_Dept_Crud.Models
{
    public class EmpCrud
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;
        public EmpCrud(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConnection"));
        }


        public IEnumerable<Employee> GetEmployees()
        {
            List<Employee> list = new List<Employee>();
            string qry = "select emp.*, dept.dname from Employee emp inner join Department dept on dept.did = emp.did";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Employee emp = new Employee();
                    emp.Id = Convert.ToInt32(dr["id"]);
                    emp.Name = dr["name"].ToString();
                    emp.Salary = Convert.ToDouble(dr["salary"]);
                    emp.Imageurl = dr["imageurl"].ToString();
                    emp.Did = Convert.ToInt32(dr["did"]);
                    emp.Dname = dr["dname"].ToString();
                    list.Add(emp);
                }
            }
            con.Close();
            return list;
        }
        public Employee GetEmployeeById(int id)
        {
            Employee emp = new Employee();
            string qry = "select emp.*, dept.dname from Employee emp inner join Department dept on dept.did = emp.did where emp.id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    emp.Id = Convert.ToInt32(dr["id"]);
                    emp.Name = dr["name"].ToString();
                    emp.Salary = Convert.ToDouble(dr["salary"]);
                    emp.Imageurl = dr["imageurl"].ToString();
                    emp.Did = Convert.ToInt32(dr["did"]);
                    emp.Dname = dr["dname"].ToString();
                }
            }
            con.Close();
            return emp;
        }


        public int AddEmployee(Employee emp)
        {
            int result = 0;
            string qry = "insert into Employee values(@name,@salary,@imageurl,@did)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", emp.Name);
            cmd.Parameters.AddWithValue("@salary", emp.Salary);
            cmd.Parameters.AddWithValue("@imageurl", emp.Imageurl);
            cmd.Parameters.AddWithValue("@did", emp.Did);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;


        }
        public int UpdateEmployee(Employee emp)
        {
            int result = 0;
            string qry = "update Employee set name=@name,salary=@salary,imageurl=@imageurl,did=@did where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", emp.Name);
            cmd.Parameters.AddWithValue("@salary", emp.Salary);
            cmd.Parameters.AddWithValue("@imageurl", emp.Imageurl);
            cmd.Parameters.AddWithValue("@did", emp.Did);
            cmd.Parameters.AddWithValue("@id", emp.Id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteEmployee(int id)
        {
            int result = 0;
            string qry = "delete from Employee where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

    }
}
