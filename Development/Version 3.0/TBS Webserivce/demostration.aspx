<%@ Page Language="vb" AutoEventWireup="false" Codebehind="demostration.aspx.vb" Inherits="tbs.infinishops.com.Demo"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>SearchPage</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:panel id="PnlSearch" style="Z-INDEX: 101; LEFT: 40px; POSITION: absolute; TOP: 48px" runat="server"
				Width="896px" Height="424px">
				<TABLE id="TableMsg" style="WIDTH: 656px; HEIGHT: 75px" cellSpacing="1" cellPadding="1"
					width="656" align="center" border="0">
					<TR align="left">
						<TD style="WIDTH: 100%" align="left">
							<asp:Literal id="LiteralMsg" runat="server" Text="You can't access more than 3 times in a session"
								Visible="False"></asp:Literal></TD>
					</TR>
				</TABLE>
				<TABLE id="Table1" style="WIDTH: 656px; HEIGHT: 75px" cellSpacing="1" cellPadding="1" width="656"
					border="0">
					<TR>
						<TD></TD>
						<TD></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 174px">
							<asp:Label id="Label1" runat="server" Width="176px" BorderStyle="None" Font-Bold="True">Enter Number To Search</asp:Label></TD>
						<TD style="WIDTH: 113px">
							<asp:TextBox id="txtSearch" runat="server" Width="224px"></asp:TextBox></TD>
						<TD>
							<asp:Button id="btnSearch" runat="server" Text="Verify..."></asp:Button></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 174px; HEIGHT: 20px">
							<asp:Label id="Label2" runat="server" Width="176px" BorderStyle="None" Font-Bold="True">Result</asp:Label></TD>
						<TD style="WIDTH: 113px; HEIGHT: 20px">
							<asp:TextBox id="txtVerified" runat="server" Width="224px" Visible="False" Font-Bold="True" Enabled="False"></asp:TextBox></TD>
						<TD style="HEIGHT: 20px"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 174px; HEIGHT: 20px"></TD>
						<TD style="WIDTH: 113px; HEIGHT: 20px"></TD>
						<TD style="HEIGHT: 20px"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 174px; HEIGHT: 20px"></TD>
						<TD style="WIDTH: 113px; HEIGHT: 20px"></TD>
						<TD style="HEIGHT: 20px"></TD>
					</TR>
				</TABLE>
				<TABLE>
					<TR>
						<TD>
							<asp:Label id="ColA" Width="360px" Runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD></TD>
					</TR>
					<TR>
						<TD>
							<asp:Label id="ColB" Width="360px" Runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD></TD>
					</TR>
					<TR>
						<TD>
							<asp:Label id="ColC" Width="360px" Runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD></TD>
					</TR>
					<TR>
						<TD>
							<asp:Label id="ColD" Width="360px" Runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD></TD>
					</TR>
					<TR>
						<TD>
							<asp:Label id="ColE" Width="360px" Runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD></TD>
					</TR>
					<TR>
						<TD>
							<asp:Label id="ColF" Width="360px" Runat="server"></asp:Label></TD>
					</TR>
					<TR>
						<TD></TD>
					</TR>
				</TABLE>
			</asp:panel></form>
	</body>
</HTML>
