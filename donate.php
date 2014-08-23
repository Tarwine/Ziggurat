<?php
        // Create the mysqli object

	$mysqli = new mysqli("sulley.cah.ucf.edu", 'jo076048', 
			'Chapsocc3!', 'jo076048');
            
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
		<title>Donate  | Ziggurat</title>
		<link href='http://fonts.googleapis.com/css?family=Alegreya+Sans+SC' rel='stylesheet' type='text/css'>
		<link rel="stylesheet" type="text/css" href="css/reset.css">
		<link rel="stylesheet" type="text/css" href="css/styles.css">
		<link rel="image_src" type="image/jpeg" href="img/panel.jpg" />
		<script type='text/javascript' language='javascript' src='js/validate.js'>
    </script>
	</head>
	<body>
		<h1>Ziggurat</h1>
		<div id="nav">
			<ul>
				<li><a href="index.html">Home</a></li>
				<li><a href="about.html">About</a></li>
				<li class="active"><a href="#">Donate</a></li>
            </ul>
		</div>
		
        <div class="content">
			<div id="donations">
				<img src="img/donate.png" alt="thumb" id="thumb"/>
                <p>If You love Ziggurat and want to help it's development, while also recieving great inside deals, info, and perks then please make a donation to fund our progress.</p>
				<form action="donationsUp.php" method="post" name="input_form">
				<input type="text" id="first" placeholder="First Name" name="first" onblur="validateData(this.form,this.id)" onfocus="hint(this.form,this.id)">
				<div id="fnamemsg"></div>
				<input type="text" id="last" placeholder="Last Name" name="last" onblur="validateData(this.form,this.id)" onfocus="hint(this.form,this.id)">
				<div id="lnamemsg"></div>
				<input type="text" id="email" placeholder="Email" name="email" onblur="validateData(this.form,this.id)" onfocus="hint(this.form,this.id)">
				<div id="emailmsg"></div>
				<input type="text" id="donation" placeholder="Donation ex: '500.00'" name="donation" onblur="validateData(this.form,this.id)" onfocus="hint(this.form,this.id)" maxlength="6">
				<div id="donatemsg"></div>
				<input type="submit" value="Donate">
				</form>
			</div>
			<?php
			$total =$mysqli->query('SELECT SUM(donation) as TotalDonation FROM donations');
            print "<h3>TOTAL SO FAR: $".$total->fetch_object()->TotalDonation."</h3>";
            ?>
            <div>
            <span id='visitor'>
                <img src="img/visitor.png" alt="visitor">
                <h2>Visitor</h2>
                <p class="money">$20.00 - $50.00</p>
                <ul>
                    <li>Name on Contibuters List</li>
                    <li>Collector's Postcard</li>
                    <li>Game Download and Disc</li>
                </ul>
            </span>
            <span id='digger'>
                <img src="img/digger.png" alt="visitor">
                <h2>Digger</h2>
                <p class="money">$50.00 - $100.00</p>
                <ul>
                    <li>Name on Honorary Contibuters List</li>
                    <li>Collector's Postcard</li>
                    <li>Collector's Poster</li>
                    <li>I &lt;3 Ziggurat T-Shirt</li>
                    <li>Game Download and Disc</li>
                </ul>
            </span>
            <span id='raider'>
                <img src="img/raider.png" alt="visitor">
                <h2>Raider</h2>
                <p class="money">$100.00+</p>
                <ul>
                    <li>Name on Platinum Contibuters List</li>
                    <li>Collector's Postcard</li>
                    <li>Collector's Poster</li>
                    <li>I &lt;3 Ziggurat T-Shirt</li>
                    <li>Game Download and Disc</li>
                    <li>Woodhouse Studios Store Credit/ Promotional codes</li>
                    <li>Our Sincerest Thanks!</li>
                </ul>
            </span>
            </div>
           <p id="discl">*All amounts of money are not asked for until game is at our goal of about $800,000. When this goal is reached we will email you and inform you on how you can put your actual money towards the game. If you are a company and would like to sponsor our game please email us at ziggame@gmail.com</p>
        
        </div>
        <div id="bottom">
            This is an educational assignment prepared for the UCF SVAD course DIG4104C: Web Design Workshop with Dr. Moshell, Spring 2014. Not a commercial product
        </div>
        <div id="page">
            </div>    
	</body>
</html>