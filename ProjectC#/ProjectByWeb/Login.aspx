<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProjectByWeb.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>
                Login
            </h1>
            <h2>
                UserName: <asp:TextBox ID="TextBoxUserName" runat="server"></asp:TextBox><br/>
                PassWord:<asp:TextBox ID="TextBoxPass" runat="server"></asp:TextBox><br/>
                <asp:Label ID="LabelLogin" runat="server" Text=""></asp:Label>
                <asp:Button ID="ButtonLogin" runat="server" Text="Login" OnClick="ButtonLogin_Click" />
            </h2>
        </div>
    </form>
</body>
</html>
