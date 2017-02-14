<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="Greenshades.Employee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Greenshades Employee Management</title>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="Content/bootstrap.min.css"/>
    <script src="Content/bootstrap.min.js"></script>
    <link rel="stylesheet" href="Content/bootstrap-theme.min.css"/>
    <link href="StyleSheet1.css" rel="stylesheet" />
    <script src="http://code.jquery.com/jquery-1.11.0.min.js"></script>
    <script src="http://digitalbush.com/wp-content/uploads/2013/01/jquery.maskedinput-1.3.1.min_.js"></script>
      <script type='text/javascript'>
    $( document ).ready(function() {
        $('#txtEmployeeContact_HomePhone').mask('(999) 999-9999');
        $('#txtEmployeeContact_CellPhone').mask('(999) 999-9999');
        $('#txtEmployeeContact_Fax').mask('(999) 999-9999');
    });
  </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12" >
                    <img src="images/greenshades-logo.png" />       
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12" style="color: #008a00">
                    <h2>Employee Details</h2>     
                </div>
            </div>
             <div class="row">
                <div class="col-md-12" style="background-color:darkseagreen;">
                   
                </div>
             </div>
            <div class="row">
                <div class="col-md-4" >
                    <label for="lblEmployee_ID">Employee ID</label>
                    <asp:Label ID="lblEmployee_ID" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4" >
                    <label for="txtEmployee_FName">First Name</label>
                    <asp:TextBox ID="txtEmployee_FName" runat="server"  class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Required information" ControlToValidate="txtEmployee_FName" runat="server" Text="Required information" Font-Bold="true" ForeColor="Crimson"  Display="Dynamic" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-4" >
                    <label for="txtEmployee_LName">Last Name</label>
                    <asp:TextBox ID="txtEmployee_LName" runat="server"  class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ErrorMessage="Required information" ControlToValidate="txtEmployee_LName" runat="server" Text="Required information" Font-Bold="true" ForeColor="Crimson" Display="Dynamic" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-4" >
                    <label for="txtEmployee_JobTitle">Job Title</label>
                    <asp:TextBox ID="txtEmployee_JobTitle" runat="server"  class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ErrorMessage="Required information" ControlToValidate="txtEmployee_JobTitle" runat="server" Text="Required information" Font-Bold="true" ForeColor="Crimson" Display="Dynamic" />

                </div>
            </div>
            <div class="row">
                <div class="col-md-4" >
                    <label for="txtEmployeeContact_Email">Email</label>
                    <asp:TextBox ID="txtEmployeeContact_Email" runat="server"  class="form-control"></asp:TextBox>
                    <asp:RegularExpressionValidator runat="server" ControlToValidate="txtEmployeeContact_Email"  ErrorMessage="Enter a valid email address." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Font-Bold="true" ForeColor="Crimson" ></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4" >
                    <label for="txtEmployeeContact_HomePhone">Home Phone</label>
                    <asp:TextBox ID="txtEmployeeContact_HomePhone" runat="server"  class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4" >
                    <label for="txtEmployeeContact_CellPhone">Cell Phone</label>
                    <asp:TextBox ID="txtEmployeeContact_CellPhone" runat="server"  class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4" >
                    <label for="txtEmployeeContact_Fax">Fax</label>
                    <asp:TextBox ID="txtEmployeeContact_Fax" runat="server"  class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4" >
                    <label for="txtEmployeeAddress_Line">Address Line 1</label>
                    <asp:TextBox ID="txtEmployeeAddress_Line" runat="server"  class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ErrorMessage="Required information" ControlToValidate="txtEmployeeAddress_Line" runat="server" Text="Required information" Font-Bold="true" ForeColor="Crimson" Display="Dynamic" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-4" >
                    <label for="txtEmployeeAddress_Line2">Address Line 2</label>
                    <asp:TextBox ID="txtEmployeeAddress_Line2" runat="server"  class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4" >
                    <label for="txtEmployeeAddress_City">City</label>
                    <asp:TextBox ID="txtEmployeeAddress_City" runat="server"  class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ErrorMessage="Required information" ControlToValidate="txtEmployeeAddress_City" runat="server" Text="Required information" Font-Bold="true" ForeColor="Crimson" Display="Dynamic" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-4" >
                    <label for="ddlState">State</label>
                    <asp:DropDownList ID = "ddlState" runat="server" class="form-control">
                    </asp:DropDownList>
                    <asp:CompareValidator ControlToValidate="ddlState" ID="CompareValidator1" Font-Bold="true" ForeColor="Crimson" ErrorMessage="Please select a State" runat="server" Display="Dynamic" Operator="NotEqual" ValueToCompare="0" Type="Integer" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-4" >
                    <label for="txtEmployeeAddress_Zip">Zip</label>
                    <asp:TextBox ID="txtEmployeeAddress_Zip" runat="server"  class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ErrorMessage="Required information" ControlToValidate="txtEmployeeAddress_Zip" runat="server" Text="Required information" Font-Bold="true" ForeColor="Crimson" Display="Dynamic" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-12" style="background-color:darkseagreen; height:25px;">
                   <asp:Label ID="lblStatus" runat="server" Text="" ForeColor="White" Font-Bold="true"></asp:Label>
                </div>
            </div>
            
           <div class="row">
                <div class="col-sm-1" >
                    <asp:LinkButton ID="lnkBtnBack" runat="server" CssClass="btn btn-default btn-md" OnClick="lnkBtnBack_Click" CausesValidation="false">
                        <span aria-hidden="true" class="glyphicon glyphicon-menu-left"></span>Back
                    </asp:LinkButton>
                </div>
                <div class="col-sm-1" >
                    <asp:LinkButton ID="lnkBtnEditEmployee" runat="server" CssClass="btn btn-default btn-md" OnClick="lnkBtnEditEmployee_Click">
                        <span aria-hidden="true" class="glyphicon glyphicon-pencil"></span>Edit Employee
                    </asp:LinkButton>
                    <asp:LinkButton ID="lnkBtnAddEmployee" runat="server" CssClass="btn btn-default btn-md" OnClick="lnkBtnAddEmployee_Click">
                        <span aria-hidden="true" class="glyphicon glyphicon-pencil"></span>Add Employee
                    </asp:LinkButton>
                </div>
                <div class="col-sm-1" >
                    <asp:LinkButton ID="lnkBtnDeleteEmployee" runat="server" CssClass="btn btn-default btn-md" OnClick="lnkBtnDeleteEmployee_Click" CausesValidation="false">
                        <span aria-hidden="true" class="glyphicon glyphicon-remove"></span>Delete Employee
                    </asp:LinkButton>
                </div>
            </div>  

        </div>
    </form>
</body>
</html>

