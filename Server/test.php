<?php
$file = "file.txt";
$test = file_get_contents('php://input');
$json = json_decode($test);
file_put_contents($file, $test);
$imageData = base64_decode($json->{'ImageBase64'});
$source = imagecreatefromstring($imageData);
//$rotate = imagerotate($source, $angle, 0); // if want to rotate the image

$imgid = rand (1,999999999);
while(file_exists("userdata/$imgid.jpg")) {
    $imgid = rand (1,999999999); 
} 


$imageSave = imagejpeg($rotate,"userdata/$imgid.jpg",100);
imagedestroy($source);
echo("OK");
?>