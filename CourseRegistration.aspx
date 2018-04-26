<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CourseRegistration.aspx.cs" Inherits="CourseRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Course Registration</title>
    <link rel="stylesheet" href="App_Themes/SiteStyles.css"/>
</head>
<body>
    <h1>Algonquin College Course Registration</h1>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="registrationPanel" runat="server">
                <asp:Label ID="lblName" runat="server" Text="Student Name: "></asp:Label>
                <asp:TextBox ID="txtBoxName" runat="server" Width="267px" CssClass="input"></asp:TextBox>     
                &nbsp;&nbsp;     
                <asp:RadioButtonList ID="radioBtnStudentType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Text="Full Time" />
                    <asp:ListItem Text="Part Time" />
                    <asp:ListItem Text="Co-op" />
                </asp:RadioButtonList>
                <p>
                    Following Courses are currently available for registration
                </p>
                <asp:Label ID="lblError" runat="server" CssClass="emphsis" Font-Bold="True"></asp:Label>
                <asp:CheckBoxList ID="chklst" runat="server" />
                <p>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="button" OnClick="btnSubmit_Click" />
                </p>
            </asp:Panel>
            <asp:Panel ID="registeredPanel" runat="server" Visible="False">
                <p>
                    Thank you <asp:Label ID="lblShowName" runat="server" CssClass="emphsis"></asp:Label>,for using our online registration system.
                </p>
                <p>
                    You have been registered as a <asp:Label ID="lblShowStudentType" runat="server" CssClass="distinct"></asp:Label>
                    &nbsp;for the following courses
                </p>
                <asp:Table ID="tblList" runat="server" CssClass="table" HorizontalAlign="Left">
                </asp:Table>
            </asp:Panel>
        </div>
    </form>
</body>
</html>