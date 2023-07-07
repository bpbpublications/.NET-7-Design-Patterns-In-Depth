<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuthorsList.aspx.cs" Inherits="AuthorsList" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            <span>Best Author:</span>
            <asp:Label runat="server" ID="bestAuthorFirstName" Text="<%# BestAuthor.FirstName%>" />
            <asp:Label runat="server" ID="bestAuthorLastName" Text="<%# BestAuthor.LastName%>" />
        </p>
        <asp:DataGrid runat="server" ID="authorsGrid" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundColumn DataField="FirstName" HeaderText="FirstName"></asp:BoundColumn>
                <asp:BoundColumn DataField="LastName" HeaderText="LastName"></asp:BoundColumn>
                <asp:BoundColumn DataField="BooksCount" HeaderText="Books Count"></asp:BoundColumn>
            </Columns>
        </asp:DataGrid>

    </form>
</body>
</html>
