<%@ Page Title="Basic Controls" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="BasicControls.aspx.cs" 
    Inherits="WebApp.SamplePages.BasicControls" %>
<asp:Content ID="Content1" 
    ContentPlaceHolderID="MainContent" runat="server">
    <table align="center" style="width: 80%; border-style: solid; border-width: 1px; background-color: #99FF66">
        <tr>
            <td align="right">Enter Your Choice(1-4)</td>
            <td>
                <asp:TextBox ID="TextBoxNumericChoice" ToolTip="Enter a Number from 1 - 4 representing the Course choice" runat="server"></asp:TextBox>
                 &nbsp;&nbsp;
                <asp:Button ID="SubmitChoice" runat="server" Text="Submit Choice" OnClick="SubmitChoice_Click" />
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label1" runat="server" Text="Course Choice" Font-Size="Medium" ForeColor="#56b2e5" Font-Bold="true" ></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="RadioButtonListChoice" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Value="1">COMP1008</asp:ListItem>
                    <asp:ListItem Value="2">CPSC1517</asp:ListItem>
                    <asp:ListItem Value="4">DMIT1508</asp:ListItem>
                    <asp:ListItem Value="3">DMIT2018</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Literal ID="Literal1" runat="server" Text="Programming Choice" ></asp:Literal>
            </td>
            <td>
                <asp:CheckBox ID="CheckBoxChoice" runat="server" Text="(Active if Checked)"/>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label2" runat="server" Text="ReadOnly Label Display"></asp:Label>
            </td>
            <td>
                <asp:Label ID="DisplayDataReadOnly" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label4" runat="server" Text="Choice Collection"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="CollectionList" runat="server">
                </asp:DropDownList>
                &nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit Choice" Width="146px" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Label ID="OutputMessage" runat="server"></asp:Label>

            </td>
        </tr>
    </table>
</asp:Content>
