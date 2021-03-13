<?php 
$lat = $_GET["lat"]; 
$longitude = $_GET["longy"];
$db = mysqli_connect("localhost", "root", "", "city"); // DB beží na localhoste len!!!!!
$sql = "SELECT * FROM problems ORDER BY ((post_latitude-$lat)*(post_latitude-$lat)) + ((post_longitude - $longitude)*(post_longitude - $longitude)) ASC LIMIT 10"; 

//httpsgist.github.com/statickidz/8a2f0ce3bca9badbf34970b958ef8479
$result = $db->query($sql);

// https://www.w3schools.com/php/php_mysql_select_orderby.asp
// https://stackoverflow.com/questions/3563389/php-json-encode-mysql-result

while($row = mysqli_fetch_array($result))
{
   $results[] = array(
      'creator' => $row['creatorUUID'], // NEPOSIELAT!!! BEZPEČNOSTNÁ CHYBA!!!
      'name' => $row['post_title'],
      'description' => $row['post_description'],
      'latitude' => $row['post_latitude'],
      'longitude' => $row['post_longitude'],
      'URL' => $row['post_imageURL'],
   );
}
$db->close(); // Uzavre pripojenie na JSON
$json = json_encode($results);
echo($json);
?>