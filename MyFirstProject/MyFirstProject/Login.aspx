<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MyFirstProject.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Login</h1>
        <table>
            <tr>
                <td>Email Id</td>
            <td>
                <asp:TextBox ID="txtEmailId" runat="server"></asp:TextBox>
            </td>
            </tr><tr>
            <td>Password</td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
            </td>
                </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="Btnlogin" runat="server" Text="login"  OnClick="Btnlogin_Click"/>
                    <asp:Label ID="Lblmsg" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
