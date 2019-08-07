<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteRegistrationData.aspx.cs" Inherits="MyFirstProject.DeleteRegistrationData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Delete Registration Data</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Delete Registration Data</h1>
        <h3>Are you sure you want to dekete data </h3>
        <table>
            <tr>
                <td>First Name:</td>
                <td>
                    <asp:Label ID="lblFirstName" runat="server" Text=""></asp:Label></td>
              
            </tr>
             <tr>
                <td>Last Name:</td>
                <td>
                    <asp:Label ID="lblLastName" runat="server" Text=""></asp:Label></td>
              
            </tr>
             <tr>
                <td>User Name:</td>
                <td>
                    <asp:Label ID="lblUserName" runat="server" Text=""></asp:Label></td>
              
            </tr>
             <tr>
                <td>Password:</td>
                <td>
                    <asp:Label ID="lblPassword" runat="server" Text=""></asp:Label></td>
              
            </tr>
             <tr>
                <td>Email Id:</td>
                <td>
                    <asp:Label ID="lblEmailId" runat="server" Text=""></asp:Label></td>
              
            </tr>
 <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </td>
              
            </tr>

        </table>
    </div>
    </form>
</body>
</html>
