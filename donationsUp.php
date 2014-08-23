<?php
        // Create the mysqli object

	$mysqli = new mysqli("sulley.cah.ucf.edu", 'jo076048', 
			'Chapsocc3!', 'jo076048');;
            
// Check for any errors. 

	$errnum=mysqli_connect_errno();
	if ($errnum) 
	{
     	$errmsg=mysqli_connect_error();
		print "Connect failed. error number=$errnum<br />
        		error message=$errmsg";    
		exit();
	}
?>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<title>Ziggurat - Thanks</title>
		<link href='http://fonts.googleapis.com/css?family=Alegreya+Sans+SC' rel='stylesheet' type='text/css'>
		<link rel="stylesheet" type="text/css" href="css/reset.css">
		<link rel="stylesheet" type="text/css" href="css/styles.css">
	</head>
	<body>
		<h1>Ziggurat</h1>
		<div id="nav">
			<ul>
				<li><a href="index.html">Home</a></li>
				<li><a href="about.html">About</a></li>
				<li><a href="donate.php">Donate</a></li>
			</ul>
		</div>
        
        <div class="content">

<?php
function addDonation($mysqli)
	{
		 //date variable
		$fnameX=$_POST['first'];
		$lnameX=$_POST['last'];
		$emailX=$_POST['email'];
		$donationX=$_POST['donation'];
		
		// ESSENTIAL cleaning to avoid SQL Injection Attack
		$first=$mysqli->real_escape_string($fnameX);
		$last=$mysqli->real_escape_string($lnameX);
		$email=$mysqli->real_escape_string($emailX);
		$donation=$mysqli->real_escape_string($donationX);
		
		// The 'null' in the VALUES list allows the auto-incrementing idnumber to work
		$query="INSERT INTO donations VALUES (null,'$first', '$last', '$email', '$donation')";

		$result=$mysqli->query($query)
			or die ($mysqli->error); 
	} #adddonation

print "Thank You ".$_POST['first']." ".$_POST['last']." for your donation of $".$_POST['donation'].".
<p>Check Back soon and see your generous Donation in action!
	<br>
	-Ziggurat Team</p>";
	addDonation($mysqli);
?> 
            <img src="img/thumbsup.png" alt="thumb" id="thumb"/>
		</div>
        <div id="bottom">
            This is an educational assignment prepared for the UCF SVAD course DIG4104C: Web Design Workshop with Dr. Moshell, Spring 2014. Not a commercial product
        </div>
        <div id="page">
            </div>    
	</body>
</html>