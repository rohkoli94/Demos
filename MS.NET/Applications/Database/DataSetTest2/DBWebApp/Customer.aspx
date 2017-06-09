<%@ Page Title="DBWebApp" Language="C#" MasterPageFile="~/ShopSite.Master" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="DBWebApp.Customer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Welcome Customer</h2>
    <asp:Login ID="CustomerLogin" runat="server" BackColor="#F7F7DE" BorderColor="#CCCC99" BorderStyle="Solid" BorderWidth="1px" DestinationPageUrl="~/Protected/Order.aspx" DisplayRememberMe="False" FailureText="Invalid credentials!" Font-Names="Verdana" Font-Size="10pt" OnAuthenticate="CustomerLogin_Authenticate" TitleText="" UserNameLabelText="Customer ID:">
        <TitleTextStyle BackColor="#6B696B" Font-Bold="True" ForeColor="#FFFFFF" />

    </asp:Login>
</asp:Content>
