<?php

// ZMENIT NA _POST NAMIESTO _GET!!!!
require_once __DIR__ . '/vendor/autoload.php';
use OTPHP\TOTP;
$UUID = $_GET["UUID"];
$name = $_GET["post_title"];
$description = $_GET["post_description"];
$lat = $_GET["post_latitude"];
$longitude = $_GET["post_longitude"];
$img = $_GET["post_imageURL"];
$OTP = $_GET["auth"];
$ip = $_SERVER['REMOTE_ADDR'];
$TOTPToken;
$encodedImage = ""; // Po nahratí bude URL

if(empty($UUID)){
    die("400: Bad Request: You are missing UUID");
}

$db = mysqli_connect("localhost", "root", "", "city"); // DB beží na localhoste len!!!!!

$TokenCheckSQL = "SELECT OTPtoken  FROM `users` WHERE `UUID` = '$UUID'";
$TokenCheckRes = $db->query($TokenCheckSQL);
if ($TokenCheckRes->num_rows > 0) {
    while($row = $TokenCheckRes->fetch_assoc()) {
        $TOTPToken = $row["OTPtoken"];
    }
  } else {
     die("400: Bad Request: Corrupted or non-existant UUID");
  }
  
$otp2 = TOTP::create($TOTPToken, 30);
$IPCheck = "SELECT * FROM `bannedip` WHERE `ip` = '$ip' OR `uuid` = '$UUID'";
$IPResoult = $db->query($IPCheck);
// https://www.w3schools.com/php/php_mysql_select.asp
if (($IPResoult->num_rows > 0)) {
    while ($row = $IPResoult->fetch_assoc() )
    {
        die("403: You are banned fron using our application.");  // AK JE IP/UUID ZABANOVANE
    }  
}
if(!($otp2->verify($OTP))){
    die("401: OTP Error");
}


$sql = "INSERT INTO `problems` (`creatorUUID`, `name`, `latitude`, `longitude`, `descript`, `imageURL`) VALUES ('$UUID', '$name', '$lat', '$longitude', '$description', '$imgurl');";

if ($result = $db->query($sql) === TRUE) {
    echo "200: OK";
  } else {
    echo "500 Interial Server Error: <br><br>" . $conn->error;
  }

$db->close(); 
?>