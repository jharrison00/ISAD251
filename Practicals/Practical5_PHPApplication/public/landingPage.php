<?php
$header = include_once 'header.php';
$footer = include_once 'footer.php';
?>

<?php
$cName = $_POST["cName"];
$postcode = $_POST["postcode"];
$email = $_POST["email"];
?>

<body class ="bg-info">
<div class="container-fluid col-md-10 offset-md-1">
    <div class="row">
        <div class="card mt-3 px-2 py-2">
            <h1> Stationery Application</h1>
            <p>Welcome to this fictional stationery application page created for ISAD 251.</p>
        </div>
<div class="container-fluid col-md-10 offset-md-1">
    <div class="row">
        <div class="card mt-3 px-2 py-2">
            <p>
                <?php echo "Greetings $cName."?>
            </p>
            <p>
                <?php echo "Your postcode is: $postcode"?>
            </p>
            <p>
                <?php echo "Your E-mail is: $email"?>
            </p>
        </div>


