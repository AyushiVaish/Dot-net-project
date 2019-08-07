 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditRegistrationData.aspx.cs" Inherits="MyFirstProject.EditRegistrationData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Registration Data</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Edit Registration Data</h1>
         <table>
                <tr>
                    <td class="auto-style1">First Name</td>
                    <td>
                        <asp:TextBox ID="txtfirstName"  runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RfFirstName" runat="server" ErrorMessage="please insert first name" ControlToValidate="txtfirstName" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                
                </tr>
                 <tr>
                    <td class="auto-style1">Last Name</td>
                    <td><asp:TextBox ID="txtlastName"    runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFLastName" runat="server" ErrorMessage="please insert last name" ControlToValidate="txtlastName" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                
                 <tr>
                    <td class="auto-style1">User Name</td>
                    <td>
                        <asp:TextBox ID="txtuserName"  runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFUserName" runat="server" ErrorMessage="please insert user name" ControlToValidate="txtuserName" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr>
                    <td class="auto-style1">Password</td>
                    <td>
                        <asp:TextBox ID="txtpassword" MaxLength="10" runat="server" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFPassword" runat="server" ErrorMessage="please insert password" ControlToValidate="txtpassword" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr>
                    <td class="auto-style1">Email Id</td>
                    <td>
                        <asp:TextBox ID="txtemailId" TextMode="Email" MaxLength="50" runat="server"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RfEmail" runat="server" ErrorMessage="please insert email" ControlToValidate="txtemailId" ForeColor="Red"></asp:RequiredFieldValidator>
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
    </form>
</body>
</html>
