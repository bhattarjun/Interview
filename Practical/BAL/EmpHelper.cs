using Practical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
namespace Practical.BAL
{
    public class EmpHelper : Helper
    {
        public bool Create(EmpModel data)
        {
            NpgsqlCommand com = new NpgsqlCommand(@"INSERT INTO t_employee(c_emp_name, c_joining_date, c_salary, c_dep_id)VALUES (@c_emp_name, @c_joining_date, @c_salary, @c_dep_id);", conn);

            com.Parameters.AddWithValue("@c_emp_name", data.c_emp_name);
            com.Parameters.AddWithValue("@c_joining_date", data.c_joining_date);
            com.Parameters.AddWithValue("@c_salary", data.c_salary);
            com.Parameters.AddWithValue("@c_dep_id", data.c_dep_id);

            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();

            return true;
        }

        public List<EmpModel> GetAll()
        {
            NpgsqlCommand com = new NpgsqlCommand(@"
	                        select d.c_dep_name,d.c_dep_id,e.c_emp_name,e.c_salary,d.c_dep_location	
	                        from t_employee e,t_departments  d
	                        where d.c_dep_id = e.c_dep_id 
	                        order by d.c_dep_name, e.c_salary desc; ", conn);
            conn.Open();

            List<EmpModel> emplist = new List<EmpModel>();
            NpgsqlDataReader dr = com.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    EmpModel em = new EmpModel();

                    em.c_dep_name = dr["c_dep_name"].ToString();
                    em.c_emp_name = dr["c_emp_name"].ToString();
                    em.c_salary = Convert.ToInt32(dr["c_salary"]);
                    em.c_dep_id = Convert.ToInt32(dr["c_dep_id"]);
                    em.c_dep_location = dr["c_dep_location"].ToString();

                    emplist.Add(em);

                }
                return emplist;
                conn.Close();
            }
            else
            {
                conn.Close();
                return emplist;
            }
        }





        public List<EmpModel> GetOne()
        {
            NpgsqlCommand com = new NpgsqlCommand(@"select * from t_employee where c_joining_date < '2020-01-01'; ", conn);
            conn.Open();

            List<EmpModel> emplist = new List<EmpModel>();
            NpgsqlDataReader dr = com.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    EmpModel em = new EmpModel();

                    em.c_emp_name = dr["c_emp_name"].ToString();
                    em.c_joining_date = Convert.ToDateTime(dr["c_joining_date"]);
                    em.c_salary = Convert.ToInt32(dr["c_salary"]);
                    em.c_dep_id = Convert.ToInt32(dr["c_dep_id"]);

                    emplist.Add(em);

                }
                return emplist;
                conn.Close();
            }
            else
            {
                conn.Close();
                return emplist;
            }

        }

        public List<EmpModel> Gettwo()
        {
            NpgsqlCommand com = new NpgsqlCommand(@"select e.c_emp_name,e.c_joining_date, d.c_dep_id, e.c_salary , 
                            d.c_dep_location from t_employee e , t_departments  d
                    where d.c_dep_id = e.c_dep_id and e.c_salary between 8000 and 12000 and d.c_dep_location ='Ahmedabad';
", conn);
            conn.Open();

            List<EmpModel> emplist = new List<EmpModel>();
            NpgsqlDataReader dr = com.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    EmpModel em = new EmpModel();

                    em.c_emp_name = dr["c_emp_name"].ToString();
                    em.c_joining_date = Convert.ToDateTime(dr["c_joining_date"]);
                    em.c_salary = Convert.ToInt32(dr["c_salary"]);
                    em.c_dep_id = Convert.ToInt32(dr["c_dep_id"]);
                    em.c_dep_location = dr["c_dep_location"].ToString();

                    emplist.Add(em);

                }
                return emplist;
                conn.Close();
            }
            else
            {
                conn.Close();
                return emplist;
            }

        }



    }
}