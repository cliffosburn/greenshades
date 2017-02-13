using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SQLite;

namespace Greenshades
{
    public class EmployeeDB
    {
        
        public static EmployeeDetails GetEmployeeDetails(int Employee_ID)
        {
            EmployeeDetails myEmployee = new EmployeeDetails();

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr-Employee1"].ConnectionString))

                {
                    conn.Open();
                    string sql = "select Employee.Employee_ID, Employee.Employee_FName, Employee.Employee_LName, Employee.Employee_JobTitle, Employeecontact.EmployeeContact_ID, Employeecontact.EmployeeContact_Email, Employeecontact.EmployeeContact_HomePhone, Employeecontact.EmployeeContact_CellPhone, Employeecontact.EmployeeContact_Fax from Employee INNER JOIN EmployeeContact on Employee.Employee_ID = EmployeeContact.EmployeeContact_Employee_ID Where Employee.Employee_ID = " + Employee_ID;

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //EmployeeDetails myEmployee = new EmployeeDetails();
                                myEmployee.ID = Int32.Parse(reader["Employee_ID"].ToString());
                                myEmployee.FirstName = reader["Employee_FName"].ToString();
                                myEmployee.LastName = reader["Employee_LName"].ToString();
                                myEmployee.JobTitle = reader["Employee_JobTitle"].ToString();
                                myEmployee.ContactID = Int32.Parse(reader["EmployeeContact_ID"].ToString());
                                myEmployee.ContactEmail = reader["EmployeeContact_Email"].ToString();
                                myEmployee.ContactHomePhone = reader["EmployeeContact_HomePhone"].ToString();
                                myEmployee.ContactCellPhone = reader["EmployeeContact_CellPhone"].ToString();
                                myEmployee.ContactFax = reader["EmployeeContact_Fax"].ToString();
                            }

                        }
                    }
                    conn.Close();

                    return myEmployee;
                }
            }
            catch (SQLiteException ex)
            {

                return myEmployee;
            }
        }

    }
}