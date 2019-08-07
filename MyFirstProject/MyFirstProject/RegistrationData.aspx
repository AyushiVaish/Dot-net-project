<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationData.aspx.cs" Inherits="MyFirstProject.RegistrationData" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Data</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
    <h1>Registration data</h1>
        <asp:Button ID="btnInsert" runat="server" Text="Insert" OnClick="btnInsert_Click" />
        <table>
            <tr>
                <td>Id</td>
                <td>First Name</td>
                <td>Last Name</td>
                <td>User Name</td>
                <td>Password</td>
                <td>Email Id</td>
                <td>State</td>
                <td>City</td>
                <td>PinCode</td>
                <td>Gender</td>
                <td>Programming</td>
                <td></td>
                <td></td>
            </tr>
            <%for(int i=0 ; i< regListObj.Count; i++) { %>
            <tr>
                   <td><%=regListObj[i].Id %></td>
                   <td><%=regListObj[i].FirstName %></td>
                   <td><%=regListObj[i].LastName %></td>
                   <td><%=regListObj[i].UserName %></td>
                   <td><%=regListObj[i].Password %></td>
                   <td><%=regListObj[i].EmailId %></td>
                <td><%=regListObj[i].State %></td>
                <td><%=regListObj[i].City %></td>
                <td><%=regListObj[i].Pincode %></td>
                <td><%=regListObj[i].Gender %></td>
                <td><%=regListObj[i].Programming %></td>
                 
                 <td><a href="EditRegistrationData.aspx?Id=<%=regListObj[i].Id %>">Edit</a></td>
                 <td><a href="DeleteRegistrationData.aspx?Id=<%=regListObj[i].Id %>">Delete</a></td>
              
            </tr>
            <% } %>
        </table>
    </div>
    </form>
</body>
</html>
