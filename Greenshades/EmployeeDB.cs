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
                    string sql = "select Employee.Employee_ID, Employee.Employee_FName, Employee.Employee_LName, Employee.Employee_JobTitle, " 
                        + "Employeecontact.EmployeeContact_ID, Employeecontact.EmployeeContact_Email, Employeecontact.EmployeeContact_HomePhone, Employeecontact.EmployeeContact_CellPhone, Employeecontact.EmployeeContact_Fax, "
                        + "EmployeeAddress.EmployeeAddress_ID, EmployeeAddress.EmployeeAddress_Employee_ID, EmployeeAddress.EmployeeAddress_Line, EmployeeAddress.EmployeeAddress_Line2, EmployeeAddress.EmployeeAddress_City, EmployeeAddress.EmployeeAddress_State_ID, EmployeeAddress.EmployeeAddress_Zip "
                        + "from Employee "
                        + "LEFT JOIN EmployeeContact on Employee.Employee_ID = EmployeeContact.EmployeeContact_Employee_ID "
                        + "LEFT JOIN EmployeeAddress on Employee.Employee_ID = EmployeeAddress.EmployeeAddress_Employee_ID "
                        + "LEFT JOIN State on EmployeeAddress.EmployeeAddress_State_ID = state.State_ID "
                        + "Where Employee.Employee_ID = " + Employee_ID;

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
                                myEmployee.Employee_AddressID = Int32.Parse(reader["EmployeeAddress_ID"].ToString());
                                myEmployee.Employee_AddressLine = reader["EmployeeAddress_Line"].ToString();
                                myEmployee.Employee_AddressLine2 = reader["EmployeeAddress_Line2"].ToString();
                                myEmployee.Employee_AddressCity = reader["EmployeeAddress_City"].ToString();
                                myEmployee.Employee_Address_StateID = Int32.Parse(reader["EmployeeAddress_State_ID"].ToString());
                                myEmployee.Employee_AddressZip = reader["EmployeeAddress_Zip"].ToString();
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


        public static int UpdateEmployeeDetails(EmployeeDetails myEmployee)
        {
            int result = -1;
            using (SQLiteConnection conn = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr-Employee1"].ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "UPDATE Employee "
                    + "SET Employee_FName = @FN, Employee_LName = @LN, Employee_JobTitle = @JT "
                    + "WHERE  Employee_ID = @ID";
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@ID", myEmployee.ID);
                    cmd.Parameters.AddWithValue("@FN", myEmployee.FirstName);
                    cmd.Parameters.AddWithValue("@LN", myEmployee.LastName);
                    cmd.Parameters.AddWithValue("@JT", myEmployee.JobTitle);
                    try
                    {
                        result = cmd.ExecuteNonQuery();
                    }
                    catch (SQLiteException ex)
                    {

                    }
                }
                conn.Close();
                if (result == 1)
                {
                    UpdateEmployeeContact(myEmployee);
                    UpdateEmployeeAddress(myEmployee);

                }
            }
            return result;
        }

        public static int UpdateEmployeeContact(EmployeeDetails myEmployee)
        {
            int result = -1;
            using (SQLiteConnection conn = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr-Employee1"].ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "UPDATE EmployeeContact "
                        + "SET EmployeeContact_Email = @E, EmployeeContact_HomePhone = @HP, EmployeeContact_CellPhone = @CP, EmployeeContact_Fax = @F "
                        + "WHERE EmployeeContact_ID = @ID AND EmployeeContact_Employee_ID = @CID";
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@ID", myEmployee.ID);
                    cmd.Parameters.AddWithValue("@CID", myEmployee.ContactID);
                    cmd.Parameters.AddWithValue("@E", myEmployee.ContactEmail);
                    cmd.Parameters.AddWithValue("@HP", myEmployee.ContactHomePhone);
                    cmd.Parameters.AddWithValue("@CP", myEmployee.ContactCellPhone);
                    cmd.Parameters.AddWithValue("@F", myEmployee.ContactFax);
                    try
                    {
                        result = cmd.ExecuteNonQuery();
                    }
                    catch (SQLiteException ex)
                    {
               
                    }
                }
                conn.Close();
            }
            return result;
        }

        public static int UpdateEmployeeAddress(EmployeeDetails myEmployee)
        {
            int result = -1;
            using (SQLiteConnection conn = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr-Employee1"].ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "UPDATE EmployeeAddress "
                        + "SET EmployeeAddress_Line = @L1, EmployeeAddress_Line2 = @L2, EmployeeAddress_City = @C, EmployeeAddress_State_ID = @S, EmployeeAddress_Zip = @Z "
                        + "WHERE EmployeeAddress_ID = @ID AND EmployeeAddress_Employee_ID = @AID";
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@ID", myEmployee.ID);
                    cmd.Parameters.AddWithValue("@AID", myEmployee.Employee_AddressID);
                    cmd.Parameters.AddWithValue("@L1", myEmployee.Employee_AddressLine);
                    cmd.Parameters.AddWithValue("@L2", myEmployee.Employee_AddressLine2);
                    cmd.Parameters.AddWithValue("@C", myEmployee.Employee_AddressCity);
                    cmd.Parameters.AddWithValue("@S", myEmployee.Employee_Address_StateID);
                    cmd.Parameters.AddWithValue("@Z", myEmployee.Employee_AddressZip);
                    try
                    {
                        result = cmd.ExecuteNonQuery();
                    }
                    catch (SQLiteException ex)
                    {

                    }
                }
                conn.Close();
            }
            return result;
        }

        public static int DeleteEmployee(int intEmployee_ID)
        {
            int result = -1;
            using (SQLiteConnection conn = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr-Employee1"].ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "DELETE FROM Employee WHERE Employee_ID = @ID";
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@ID", intEmployee_ID);
                    try
                    {
                        result = cmd.ExecuteNonQuery();
                    }
                    catch (SQLiteException ex)
                    {
                        return 0;
                
                    }
                }
                conn.Close();
                if (result == 1)
                {
                    DeleteEmployeeContact(intEmployee_ID);
                    DeleteEmployeeAddress(intEmployee_ID);
                }

            }
            return result;
        }

        public static int DeleteEmployeeContact(int intEmployee_ID, int intEmployeeContact_ID = 0)
        {
            int result = -1;
            using (SQLiteConnection conn = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr-Employee1"].ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {

                    string strWhereEmployeeContact_ID = (intEmployeeContact_ID > 0) ? " and EmployeeContact_Employee_ID = @IDC;" : ";";
                    cmd.CommandText = "DELETE FROM EmployeeContact WHERE EmployeeContact_Employee_ID = @ID" + strWhereEmployeeContact_ID;
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@ID", intEmployee_ID);
                    if (intEmployeeContact_ID > 0)
                    {
                        cmd.Parameters.AddWithValue("@IDC", intEmployeeContact_ID);
                    }
                        
                    try
                    {
                        result = cmd.ExecuteNonQuery();
                    }
                    catch (SQLiteException ex)
                    {
                        return 0;

                    }
                }
                conn.Close();
            }
            return result;
        }

        public static int DeleteEmployeeAddress(int intEmployee_ID, int intEmployeeAddress_ID = 0)
        {
            int result = -1;
            using (SQLiteConnection conn = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr-Employee1"].ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    string strWhereEmployeeAddress_ID = (intEmployeeAddress_ID > 0) ? " and EmployeeAddress_Employee_ID = @IDA;" : ";";
                    cmd.CommandText = "DELETE FROM EmployeeAddress WHERE EmployeeAddress_Employee_ID = @ID" + strWhereEmployeeAddress_ID;
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@ID", intEmployee_ID);
                    if (intEmployeeAddress_ID > 0)
                    {
                        cmd.Parameters.AddWithValue("@IDA", intEmployeeAddress_ID);
                    }
                        
                    try
                    {
                        result = cmd.ExecuteNonQuery();
                    }
                    catch (SQLiteException ex)
                    {
                        return 0;

                    }
                }
                conn.Close();
            }
            return result;
        }


        public static EmployeeDetails InsertEmployeeDetails(EmployeeDetails myEmployee)
        {
            long id = -1;

            using (SQLiteConnection conn = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr-Employee1"].ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "INSERT INTO Employee "
                    + "(Employee_FName, Employee_LName, Employee_JobTitle) "
                    + "VALUES (@FN, @LN, @JT); "
                    + "SELECT last_insert_rowid()";
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@FN", myEmployee.FirstName);
                    cmd.Parameters.AddWithValue("@LN", myEmployee.LastName);
                    cmd.Parameters.AddWithValue("@JT", myEmployee.JobTitle);
                    try
                    {
                        //result = cmd.ExecuteNonQuery();
                        object obj = cmd.ExecuteScalar();
                        id = (long)obj;
                        myEmployee.ID = Convert.ToInt32(id);
                    }
                    catch (SQLiteException ex)
                    {

                    }
                }
                conn.Close();

                if (id > 0)
                {
                    myEmployee.Employee_AddressID = InsertEmployeeAddress(myEmployee);
                    myEmployee.ContactID = InsertEmployeeContact(myEmployee);

                }
            }
            return myEmployee;
        }

        public static int InsertEmployeeContact(EmployeeDetails myEmployee)
        {
            long id = -1;

            using (SQLiteConnection conn = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr-Employee1"].ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "INSERT INTO EmployeeContact "
                    + "(EmployeeContact_Employee_ID, EmployeeContact_Email, EmployeeContact_HomePhone, EmployeeContact_CellPhone, EmployeeContact_Fax) "
                    + "VALUES (@EI, @E, @HP, @CP, @F); "
                    + "SELECT last_insert_rowid()";
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@EI", myEmployee.ID);
                    cmd.Parameters.AddWithValue("@E", myEmployee.ContactEmail);
                    cmd.Parameters.AddWithValue("@HP", myEmployee.ContactHomePhone);
                    cmd.Parameters.AddWithValue("@CP", myEmployee.ContactCellPhone);
                    cmd.Parameters.AddWithValue("@F", myEmployee.ContactFax);
                    try
                    {
                        object obj = cmd.ExecuteScalar();
                        id = (long)obj;
                        myEmployee.ContactID = Convert.ToInt32(id);
                    }
                    catch (SQLiteException ex)
                    {

                    }
                }
                conn.Close();

            }
            return myEmployee.ContactID;
        }

        public static int InsertEmployeeAddress(EmployeeDetails myEmployee)
        {
            long id = -1;

            using (SQLiteConnection conn = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr-Employee1"].ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "INSERT INTO EmployeeAddress "
                    + "(EmployeeAddress_Employee_ID, EmployeeAddress_Line, EmployeeAddress_Line2, EmployeeAddress_City, EmployeeAddress_State_ID, EmployeeAddress_Zip) "
                    + "VALUES (@EI, @L1, @L2, @C, @S, @Z); "
                    + "SELECT last_insert_rowid()";
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@EI", myEmployee.ID);
                    cmd.Parameters.AddWithValue("@L1", myEmployee.Employee_AddressLine);
                    cmd.Parameters.AddWithValue("@L2", myEmployee.Employee_AddressLine2);
                    cmd.Parameters.AddWithValue("@C", myEmployee.Employee_AddressCity);
                    cmd.Parameters.AddWithValue("@S", myEmployee.Employee_Address_StateID);
                    cmd.Parameters.AddWithValue("@Z", myEmployee.Employee_AddressZip);
                    try
                    {
                        object obj = cmd.ExecuteScalar();
                        id = (long)obj;
                        myEmployee.Employee_AddressID = Convert.ToInt32(id);
                    }
                    catch (SQLiteException ex)
                    {

                    }
                }
                conn.Close();

            }
            return myEmployee.Employee_AddressID;
        }

    }
}