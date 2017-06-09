<%@ Page Title="" Language="C#" MasterPageFile="~/ShopSite.Master" AutoEventWireup="true" CodeBehind="Invoice.aspx.cs" Inherits="DBWebApp.Protected.Invoice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        Welcome Customer <asp:Label ID="CustomerLabel" runat="server" />
    </h2>
    <p>
        <asp:GridView runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" DataSourceID="InvoiceDataSource" ForeColor="Black">
            <Columns>
                <asp:BoundField DataField="OrderDate" DataFormatString="{0:dd-MMM-yyyy}" HeaderText="Order Date" SortExpression="OrderDate" />
                <asp:BoundField DataField="ProductNo" HeaderText="Product No" SortExpression="ProductNo" />
                <asp:BoundField DataField="Amount" HeaderText="Amount" ReadOnly="True" SortExpression="Amount" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />

        </asp:GridView>
        <asp:ObjectDataSource ID="InvoiceDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="DBWebApp.Models.ShopDataSetTableAdapters.InvoiceTableAdapter">
            <SelectParameters>
                <asp:ControlParameter ControlID="CustomerLabel" Name="customerId" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </p>
    <p>
        <asp:LinkButton ID="LogoutLinkButton" Text="Logout" OnClick="LogoutLinkButton_Click" runat="server" />
    </p>
</asp:Content>
