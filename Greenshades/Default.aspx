<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Greenshades.Default" %>

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
                    <h2>Employee Management</h2>     
                </div>
            </div>
             <div class="row">
                <div class="col-md-12" style="background-color:darkseagreen;">
                   
                </div>
             </div>
            <div class="row">
                <div class="col-lg-12">
                    <asp:SqlDataSource ID="Employee1" 
                        ConnectionString="<%$ ConnectionStrings:ConnStr-Employee1 %>"
                        ProviderName="System.Data.SQLite"
                        SelectCommand="select Employee_ID,Employee_FName,Employee_LName,Employee_JobTitle from Employee"
                        runat="server">
                    </asp:SqlDataSource>

                    <asp:GridView ID="EmployeeView" runat="server" 
                        AutoGenerateColumns="False"
                        DataKeyNames="Employee_ID" 
                        DataSourceID="Employee1" 
                        BorderStyle="None"  
                        AllowSorting="true" 
                        AllowPaging="True"
                        CssClass="gridview"
                        >
                        <AlternatingRowStyle CssClass="altrow" />
                        <Columns>

                            <asp:HyperLinkField HeaderText="Employee ID" DataTextField="Employee_ID" DataNavigateUrlFields="Employee_ID" SortExpression="Employee_ID" 
                                DataNavigateUrlFormatString="Employee.aspx?id={0}">
                            </asp:HyperLinkField>

                            <asp:TemplateField HeaderText="Name"   SortExpression="Employee_LName">
                                <ItemTemplate>
                                    <asp:HyperLink runat="server" ID="HyperLink1" NavigateUrl='<%# "Employee.aspx?id=" + Eval("Employee_ID")%>' Text='<%#Eval("Employee_FName")+ " " + Eval("Employee_LName")%>'></asp:HyperLink>

                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Employee_JobTitle" HeaderText="Job Title" SortExpression="Employee_JobTitle" />
                        </Columns>

                    </asp:GridView>
                </div>
            </div>
 

           <div class="row">
                <div class="col-sm-8" >
                    <button type="button" class="btn btn-default btn-md" id="btnAddEmployee" runat="server" onserverclick="btnAddEmployee_serverClick"> 
                       <span class="glyphicon glyphicon-user" aria-hidden="true"></span> Add Employee</button>
                </div>
            </div>  




        </div>
    </form>
</body>
</html>
