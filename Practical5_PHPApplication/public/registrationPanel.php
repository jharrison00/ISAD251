<?php
$header = include_once 'header.php';
$footer = include_once 'footer.php';
?>

<body class ="bg-info">
<div class="container-fluid col-md-10 offset-md-1">
    <div class="row">
        <div class="card mt-3 px-2 py-2">
            <h1> Stationery Application</h1>
            <p>Welcome to this fictional stationery application page created for ISAD 251.</p>
        </div>
<div class="container-fluid col-md-10 offset-md-0">
    <div class="row">
        <div class="card mt-3 px-2 py-2">
            <form action=landingPage.php method="post">
                Name:     <input type = "text" name = "cName" required><br>
                Postcode: <input type = "text" name = "postcode" required><br>
                E-mail:   <input type = "text" name = "email"><br>
                <input type= "submit" name = "Submit">
            </form>
        </div>