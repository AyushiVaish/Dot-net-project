<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyFirstWebForm.aspx.cs" Inherits="MyFirstProject.MyFirstWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Form</title>
    <style type="text/css">
        .auto-style1 {
            width: 104px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <center>
    <div>
        <h1>Registration Form</h1>
    </div>
        <div>
            <table>
                <tr>
                    <td class="auto-style1">First Name</td>
                    <td>
                        <asp:TextBox ID="firstName"  runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RfFirstName" runat="server" ErrorMessage="please insert first name" ControlToValidate="firstName" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                
                </tr>
                 <tr>
                    <td class="auto-style1">Last Name</td>
                    <td><asp:TextBox ID="lastName"    runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFLastName" runat="server" ErrorMessage="please insert last name" ControlToValidate="lastName" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                
                 <tr>
                    <td class="auto-style1">User Name</td>
                    <td>
                        <asp:TextBox ID="userName"  runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFUserName" runat="server" ErrorMessage="please insert user name" ControlToValidate="userName" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr>
                    <td class="auto-style1">Password</td>
                    <td>
                        <asp:TextBox ID="password" MaxLength="10"  TextMode="Password" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFPassword" runat="server" ErrorMessage="please insert password" ControlToValidate="password" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr>
                    <td class="auto-style1">Email Id</td>
                    <td>
                        <asp:TextBox ID="emailId" TextMode="Email" MaxLength="50" runat="server"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RFEmail" runat="server" ErrorMessage="please insert email" ControlToValidate="emailId" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>State</td>
                    <td><asp:DropDownList ID="ddlState" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlState_SelectedIndexChanged"></asp:DropDownList></td>
                </tr>
                  <tr>
                    <td>City</td>
                    <td><asp:DropDownList ID="ddlCity" runat="server" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>
                </tr>
                  <tr>
                    <td>Pincode</td>
                    <td> 
                        <asp:TextBox ID="txtPinCode" runat="server" AutoPostBack="True"></asp:TextBox>
                      </td> </tr>
                 <tr>
                     <td>Gender</td>
                     <td><asp:RadioButton ID="rdMale" runat="server" GroupName="gender" Text="Male"></asp:RadioButton>
                         <asp:RadioButton ID="rdFemale" runat="server" GroupName="gender" Text="Female" ></asp:RadioButton></td>
                 </tr>
                <tr>
                    <td>Programming</td>
                    <td><asp:CheckBox ID="chkJava" runat="server" Text="Java"></asp:CheckBox>
                        <asp:CheckBox ID="chkdotNet" runat="server" Text="Dot Net"></asp:CheckBox>
                        <asp:CheckBox ID="chkPython" runat="server" Text="Python"></asp:CheckBox>
                        <asp:CheckBox ID="chkCPlus" runat="server" Text="C++"></asp:CheckBox>
                    </td>
                </tr>
                 <tr>   
                     <td></td>
                    <td ><asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                        <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                     </td>
                     
                </tr>
            </table>
        </div>
        </center>
    </form>
</body>
</html>
