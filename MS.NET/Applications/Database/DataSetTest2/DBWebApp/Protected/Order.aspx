<%@ Page Title="DBWebApp" Language="C#" MasterPageFile="~/ShopSite.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="DBWebApp.Protected.Order" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        Welcome Customer <asp:Label ID="CustomerIdLabel" runat="server" />
    </h2>
    <p>
        <b>Product No</b><br />
        <asp:DropDownList ID="ProductNoDropDownList" runat="server" DataSourceID="ProductDataSource" DataTextField="ProductNo" DataValueField="ProductNo">

        </asp:DropDownList>
        <asp:ObjectDataSource ID="ProductDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="DBWebApp.Models.ShopDataSetTableAdapters.ProductTableAdapter"></asp:ObjectDataSource>
    </p>
    <p>
        <b>Quantity</b><br />
        <asp:TextBox ID="QuantityTextBox" runat="server" />
        <asp:RequiredFieldValidator ControlToValidate="QuantityTextBox" Display="Dynamic" ErrorMessage="*" runat="server" />
        <asp:RegularExpressionValidator ControlToValidate="QuantityTextBox" ValidationExpression="[1-9][0-9]*" ErrorMessage="Number expected!" runat="server" />
    </p>
    <p>
        <asp:Button ID="OrderButton" Text="Order" OnClick="OrderButton_Click" runat="server" />
    </p>
    <p>
        <asp:Label ID="ResultLabel" runat="server" />
    </p>
    <p>
        <asp:HyperLink Text="View Invoice" NavigateUrl="~/Protected/Invoice.aspx" runat="server" />
    </p>
</asp:Content>
