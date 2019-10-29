<?php
$header = include_once 'header.php';
$footer = include_once 'footer.php';
?>

<body class ="bg-info">
<div class="container-fluid col-md-10 offset-md-1">
    <div class="row">
        <div class="card mt-3 px-2 py-2">
            <h1> Stationery Application</h1>
            <p>Welcome to this fictional stationery application page created for ISAD 251 example. To continue please accept our terms and conditions</p>
        </div>
<div class="container-fluid col-md-10 offset-md-0">
    <div class="row">
        <div class="card mt-3 px-2 py-2">
            <input type="radio" name="Agree" value=true>I Agree<br>
            <input type="radio" name="Disagree" value=false>I Disagree<br>
            <button type="button" name ="submit" value=false> Submit
        </div>