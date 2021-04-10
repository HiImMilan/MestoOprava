<?php

// ZMENIT NA _POST NAMIESTO _GET!!!!
require_once __DIR__ . '/vendor/autoload.php';
use OTPHP\TOTP;
$data = file_get_contents('php://input');
$json = json_decode($data);

$UUID = $json->{'UUID'};
$name = $json->{'PostTitle'};
$description = $json->{'PostDescription'};
$lat = $json->{'PostLatitude'};
$longitude = $json->{'PostLongitude'};
$OTP = $json->{'OTPToken'};

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

$imageData = base64_decode($json->{'ImageBase64'});
$source = imagecreatefromstring($imageData);


$url = "";
$urlLength = 0;
$alphabet = array('A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z');
while($urlLength < 30){
  $url .= $alphabet[rand(0,25)];
  $urlLength++;
}

while(file_exists("userdata/$url.jpg")) {
  $urlLength = 0;
  while($urlLength < 30){
   $url .= $alphabet[rand(0,25)];
    $urlLength++;
  }
} 

$imageSave = imagejpeg($source,"userdata/$url.jpg",100);
$urlFinal = "http://192.168.50.34/Server/userdata/$url.jpg";



$sql = "INSERT INTO `problems` (`creatorUUID`, `post_title`, `post_latitude`, `post_longitude`, `post_description`, `post_imageURL`) VALUES ('$UUID', '$name', '$lat', '$longitude', '$description', '$urlFinal');";

if ($result = $db->query($sql) === TRUE) {
    echo "200: OK";
  } else {
    echo "500 Interial Server Error: <br><br>" . $db->error;
  }

$db->close(); 
?>