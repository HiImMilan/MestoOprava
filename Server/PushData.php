<?php

// NEODTESTOVANÝ KÓD, NESPÚŠTAT


// ZMENIT NA _POST NAMIESTO _GET!!!!
$UUID = $_GET["UUID"];
$name = $_GET["title"];
$description = $_GET["description"];
$lat = $_GET["lat"];
$longitude = $_GET["long"];
$img = $_GET["img"]; //???
$OTP = $_GET["auth"]; // ???

$imgurl = "url"; // Po nahratí bude URL

$db = mysqli_connect("localhost", "root", "", "city"); // DB beží na localhoste len!!!!!

// Kontrola, či OTP kód súhlasí, ak nie, nech vyhodí chybu
//die("401: OTP Error");

if(empty($UUID)){
    die("400: Bad Request: You are missing UUID");
}

// Pridať check na BAN
//die("403: You are banned fron using our application.);  AK JE IP/UUID ZABANOVANE

$sql = "INSERT INTO `problems` (`creatorUUID`, `name`, `latitude`, `longitude`, `descript`, `imageURL`) VALUES ('$UUID', '$name', '$lat', '$longitude', '$description', '$imgurl');";
$result = $db->query($sql);

// Pridať check na to, či sa úspešne poslalo do DB

echo($sql);
$db->close(); 
?>