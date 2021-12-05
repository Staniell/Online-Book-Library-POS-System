<%@ Page Title="" Language="C#" MasterPageFile="~/backend_master.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="mp.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <br />
        <br />
    <br />
    <br />
    <br />

        <br />
    <br />
    <br />
    <br />
        <br />
    <br />
    <br />
    <br />
    <div class="formlogin">
        <div class="loginbox">
        <img src="images/UserAdmin.png"alt="Alternate Text" class="user"/>
        <h2>Employee Control Panel</h2>
        <asp:Label ID="signInError" runat="server" CssClass="errorMessage"></asp:Label>
        <br />
        <asp:Label text="Employee ID" CssClass="lblemail" runat="server" ID="EmployeeID" />
        <asp:TextBox runat="server" CssClass="txtemail" ID="EmployeeIDTextBox" CausesValidation="True" />
        <br />
        <asp:RequiredFieldValidator ID="employeeIDRFV" runat="server" ControlToValidate="EmployeeIDTextBox" CssClass="errorMessage" ErrorMessage="*Employee ID is required" Display="Dynamic"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label Text="Password" CssClass="lblpass" runat="server" ID="PassLabel" />
        <asp:TextBox runat="server" CssClass="txtpass" ID="passwordTextBox" TextMode="Password" CausesValidation="True" />
        <br />
        <asp:RequiredFieldValidator ID="passwordRFV" runat="server" ControlToValidate="passwordTextBox" CssClass="errorMessage" ErrorMessage="*Password is required" Display="Dynamic"></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
        <asp:Button Text="Sign In" CssClass="btnsubmit" runat="server" ID="signInBtn" OnClick="signInBtn_Click" CausesValidation="true"/>
        </div>
    </div>
</asp:Content>
