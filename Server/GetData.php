<?php 
$lat = $_GET["lat"]; 
$longitude = $_GET["long"];
$db = mysqli_connect("localhost", "root", "", "city"); // DB beží na localhoste len!!!!!
$sql = "SELECT * FROM problems ORDER BY ((latitude-$lat)*(latitude-$lat)) + ((longitude - $longitude)*(longitude - $longitude)) ASC LIMIT 10"; //https://gist.github.com/statickidz/8a2f0ce3bca9badbf34970b958ef8479
$result = $db->query($sql);

// https://www.w3schools.com/php/php_mysql_select_orderby.asp
// https://stackoverflow.com/questions/3563389/php-json-encode-mysql-result

while($row = mysqli_fetch_array($result))
{
   $results[] = array(
      'creator' => $row['creatorUUID'],
      'name' => $row['name'],
      'description' => $row['descript'],
      'latitude' => $row['latitude'],
      'longitude' => $row['longitude'],
      'URL' => $row['imageURL'],
   );
}
$db->close(); // Uzavre pripojenie na JSON
$json = json_encode($results);
echo($json);
?>