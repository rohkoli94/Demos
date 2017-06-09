<%@Page Inherits="BasicWebApp.PostBackTestPage"%>
<html>
	<head>
		<title>BasicWebApp</title>
	</head>
	<body>
		<h1><asp:Label ID="OutputLabel" Text="Welcome Visitor" runat="server"/></h1>
		<form runat="server">
			<b>Name: </b>
			<asp:TextBox ID="NameTextBox" runat="server"/>
			<asp:Button ID="GreetButton" Text="Greet" OnClick="GreetButton_Click" runat="server"/>
		</form>		
		<p>
			<b><asp:Label ID="GreetCountLabel" runat="server"/></b>
		</p>
	</body>
</html>