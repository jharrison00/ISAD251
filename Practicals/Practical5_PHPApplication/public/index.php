<?php
$header = include_once 'header.php';
$footer = include_once 'footer.php';
?>

<body class ="bg-info">
<div class="container-fluid col-md-10 offset-md-1">
    <div class="row">
        <div class="card mt-3 px-2 py-2">
            <h1> Stationery Application</h1>
            <p>Welcome to this fictional stationery application page created for ISAD 251.
                To continue please accept our terms and conditions</p>
        </div>
<div class="container-fluid col-md-10 offset-md-0">
    <div class="row">
        <div class="card mt-3 px-2 py-2">
            <form action=agreement.php method="get">
                <input type="radio" id = "agree" name="choice" value=true>I Agree<br>
                <input type="radio" id = "disagree" name="choice" value=false>I Disagree<br>
                <input type="submit" value="Submit">
            </form>
        </div>
