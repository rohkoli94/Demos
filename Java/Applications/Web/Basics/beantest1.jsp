<jsp:useBean id="now" class="java.util.Date"/>
<jsp:useBean id="uctr" class="basicwebapp.CounterBean" scope="session"/>
<jsp:useBean id="gctr" class="basicwebapp.CounterBean" scope="application"/>
<jsp:setProperty name="gctr" property="step" value="3"/>
<html>
	<head>
		<title>BasicWebApp</title>
	</head>
	<body>
		<h1>Welcome Visitor ${param.visitor}</h1>
		<b>Time on server: </b>${now}
		<p>
			<i>Number of request = </i>${uctr.nextCount} / ${gctr.nextCount}
		</p>
	</body>
</html>

