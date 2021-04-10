<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ProjectByWeb.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>
                User: <asp:Label ID="LabelUserName" runat="server" Text="Label"></asp:Label>
            </h1>
            <h2>
                Lop Hoc: <br/>
                <asp:DropDownList ID="DropDownListClass" AutoPostBack="true" OnSelectedIndexChanged="DropDownListClass_SelectedIndexChanged" runat="server"></asp:DropDownList>
                <asp:GridView ID="GridViewSinhVien" runat="server"></asp:GridView>     
            </h2>

            <h2>
               Ten Khoa:<br/>
                <asp:DropDownList ID="DropDownListKhoa" AutoPostBack="true" OnSelectedIndexChanged="DropDownListKhoa_SelectedIndexChanged" runat="server"></asp:DropDownList>
                <asp:GridView ID="GridViewKhoa" runat="server"></asp:GridView>
            </h2>
        </div>
    </form>
</body>
</html>
