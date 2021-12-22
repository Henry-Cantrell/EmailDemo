<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodoContent.aspx.cs" Inherits="WebAppDemo.Todo.TodoContent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="pnl1" runat="server">
        <h3>Enter an item to your todo list</h3>
        <asp:TextBox ID="txtTodo" runat="server"></asp:TextBox>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server"></asp:Panel>
    <asp:Panel ID="pnl2" runat="server">
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Create" />
    </asp:Panel>
    <asp:Panel ID="Panel1" runat="server"></asp:Panel>
    <asp:Panel ID="pnl3" runat="server">
        <h3>Your todo list</h3>
        <asp:GridView ID="gdvOne" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowCancelingEdit="gdvOne_OnRowEditCancel" OnRowDeleting="gdvOne_OnRowDelete" OnRowEditing="gdvOne_OnRowEditing" OnRowUpdating="gdvOne_OnRowUpdating" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal">
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <Columns>
                <asp:BoundField DataField="todo" HeaderText="Name" />
                <asp:CommandField ShowEditButton="true" HeaderText="Edit Row" />
                <asp:CommandField ShowDeleteButton="true" HeaderText="Delete Row" />
                <asp:TemplateField HeaderText="Email Row">
                    <ItemTemplate>
                        <asp:Button ID="btnEmail" runat="server" CommandArgument='<%# Container.DataItemIndex %>' CommandName="Email" Text="Email" OnClick="btnEmail_Click"></asp:Button>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <SortedAscendingCellStyle BackColor="#F4F4FD" />
            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
            <SortedDescendingCellStyle BackColor="#D8D8F0" />
            <SortedDescendingHeaderStyle BackColor="#3E3277" />
        </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="pnl4" runat="server">
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </asp:Panel>
</asp:Content>

