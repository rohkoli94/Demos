<%@Page Inherits="BasicWebApp.WebCtrlTestPage" CodeFile="webctrltest.aspx.cs"%>
<html>
	<head>
		<title>BasicWebApp</title>
	</head>
	<body>
		<h1>Welcome Visitor <asp:Label ID="VisitorLabel" runat="server"/></h1>
		<b>Time on server: </b><asp:Label ID="TimeLabel" runat="server"/>		
	</body>
</html>