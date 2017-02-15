using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SQLite;



namespace Greenshades
{
    public partial class Employee : System.Web.UI.Page
    {

        EmployeeDetails myEmployee = new EmployeeDetails();
        public int intEmployee_ID;

        protected void Page_Load(object sender, EventArgs e)
        {


            if (Request.QueryString["id"] != null)
            {
                //Employee ID provided
                intEmployee_ID = Convert.ToInt32(Request.QueryString["id"]);

                if (Request.QueryString["new"] == "true")
                {
                    lblStatus.Text = "Employee Information Added";
                }
                else
                {
                    lblStatus.Text = "";
                }

                

                this.lnkBtnAddEmployee.Visible = false;

                if (!IsPostBack)
                {
                    GetStates();
                    DisplayEmployeeDetails(intEmployee_ID);
                }
                
            }
            else
            {
                // No ID provided, new entry
                if (!IsPostBack)
                {
                    GetStates();
                    this.lnkBtnAddEmployee.Visible = true;
                    this.lnkBtnEditEmployee.Visible = false;
                    this.lnkBtnDeleteEmployee.Visible = false;
                }
                else
                {
                    this.lnkBtnAddEmployee.Visible = false;
                    this.lnkBtnEditEmployee.Visible = true;
                    this.lnkBtnDeleteEmployee.Visible = true;
                }



            }

        }



        public void GetStates()
        {


            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr-Employee1"].ConnectionString))

                {
                    conn.Open();
                    string sql = "select State_ID, State_Name, State_Abbr From State";
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            ddlState.Items.Clear();
                            ddlState.DataTextField = "State_Name";
                            ddlState.DataValueField = "State_ID";

                            while (reader.Read())
                            {
                                ListItem newItem = new ListItem();
                                newItem.Text = reader["State_Name"].ToString();
                                newItem.Value = reader["State_ID"].ToString();
                                ddlState.Items.Add(newItem);

                            }

                            ddlState.Items.Insert(0, new ListItem("<Select State>", "0"));

                        }
                    }
                    conn.Close();
                }
            }
            catch (SQLiteException ex)
            {

            }
        }




        public void DisplayEmployeeDetails(int EmployeeID)
        {
            

            //EmployeeDetails myEmployee = new EmployeeDetails(intEmployee_ID, "John", "JOnes", "Janitor", 1, "jjones@gmail.com", "8001234567", "8009876543", "8007771111");

            try
            {
                myEmployee = EmployeeDB.GetEmployeeDetails(EmployeeID);
            }
            catch (SQLiteException ex)
            {

                Response.Write("<script>alert('Exception: " + ex.Message + "')</script>");
            }

            lblEmployee_ID.Text = myEmployee.ID.ToString();
            txtEmployee_FName.Text = myEmployee.FirstName.ToString();
            txtEmployee_LName.Text = myEmployee.LastName.ToString();
            txtEmployee_JobTitle.Text = myEmployee.JobTitle.ToString();
            txtEmployeeContact_Email.Text = myEmployee.ContactEmail.ToString();
            txtEmployeeContact_HomePhone.Text = myEmployee.ContactHomePhone.ToString();
            txtEmployeeContact_CellPhone.Text = myEmployee.ContactCellPhone.ToString();
            txtEmployeeContact_Fax.Text = myEmployee.ContactFax.ToString();
            txtEmployeeAddress_Line.Text = myEmployee.Employee_AddressLine.ToString();
            txtEmployeeAddress_Line2.Text = myEmployee.Employee_AddressLine2.ToString();
            txtEmployeeAddress_City.Text = myEmployee.Employee_AddressCity.ToString();
            txtEmployeeAddress_Zip.Text = myEmployee.Employee_AddressZip.ToString();

            ddlState.SelectedValue = myEmployee.Employee_Address_StateID.ToString();

        }



        protected void lnkBtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void lnkBtnEditEmployee_Click(object sender, EventArgs e)
        {
            myEmployee = EmployeeDB.GetEmployeeDetails(intEmployee_ID);

            myEmployee.FirstName = txtEmployee_FName.Text.ToString();
            myEmployee.LastName = txtEmployee_LName.Text.ToString();
            myEmployee.JobTitle = txtEmployee_JobTitle.Text.ToString();
            myEmployee.ContactEmail = txtEmployeeContact_Email.Text.ToString();
            myEmployee.ContactHomePhone = txtEmployeeContact_HomePhone.Text.ToString();
            myEmployee.ContactCellPhone = txtEmployeeContact_CellPhone.Text.ToString();
            myEmployee.ContactFax = txtEmployeeContact_Fax.Text.ToString();
            myEmployee.Employee_AddressLine = txtEmployeeAddress_Line.Text.ToString();
            myEmployee.Employee_AddressLine2 = txtEmployeeAddress_Line2.Text.ToString();
            myEmployee.Employee_AddressCity = txtEmployeeAddress_City.Text.ToString();
            myEmployee.Employee_Address_StateID = Convert.ToInt32(ddlState.SelectedValue.ToString());
            myEmployee.Employee_AddressZip = txtEmployeeAddress_Zip.Text.ToString();

            bool NewEntry = false;
            if (ValidateInput.ValidateEmployeeDetails(myEmployee, NewEntry))
            {
                EmployeeDB.UpdateEmployeeDetails(myEmployee);
                DisplayEmployeeDetails(myEmployee.ID);
                lblStatus.Text = "Employee Information Updated";
            }
            else
            {
                lblStatus.Text = "Invalid input, please check entries.";
            }
        }

        protected void lnkBtnDeleteEmployee_Click(object sender, EventArgs e)
        {
            myEmployee = EmployeeDB.GetEmployeeDetails(intEmployee_ID);
            EmployeeDB.DeleteEmployee(myEmployee.ID);
            Response.Redirect("Default.aspx");
        }

        protected void lnkBtnAddEmployee_Click(object sender, EventArgs e)
        {
            myEmployee.FirstName = txtEmployee_FName.Text.ToString();
            myEmployee.LastName = txtEmployee_LName.Text.ToString();
            myEmployee.JobTitle = txtEmployee_JobTitle.Text.ToString();
            myEmployee.ContactEmail = txtEmployeeContact_Email.Text.ToString();
            myEmployee.ContactHomePhone = txtEmployeeContact_HomePhone.Text.ToString();
            myEmployee.ContactCellPhone = txtEmployeeContact_CellPhone.Text.ToString();
            myEmployee.ContactFax = txtEmployeeContact_Fax.Text.ToString();
            myEmployee.Employee_AddressLine = txtEmployeeAddress_Line.Text.ToString();
            myEmployee.Employee_AddressLine2 = txtEmployeeAddress_Line2.Text.ToString();
            myEmployee.Employee_AddressCity = txtEmployeeAddress_City.Text.ToString();
            myEmployee.Employee_Address_StateID = Convert.ToInt32(ddlState.SelectedValue.ToString());
            myEmployee.Employee_AddressZip = txtEmployeeAddress_Zip.Text.ToString();

            bool NewEntry = true;
            if (ValidateInput.ValidateEmployeeDetails(myEmployee, NewEntry))
            {
                myEmployee = EmployeeDB.InsertEmployeeDetails(myEmployee);
                //DisplayEmployeeDetails(myEmployee.ID);
                //lblStatus.Text = "Employee Information Added";
                Response.Redirect("Employee.aspx?new=true&id=" + myEmployee.ID.ToString());
            }
            else
            {
                lblStatus.Text = "Invalid input, please check entries.";
            }

        }
    }
}