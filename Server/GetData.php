<?php 
$lat = $_GET["lat"]; 
$longitude = $_GET["longy"];
$db = mysqli_connect("localhost", "root", "", "city"); // DB beží na localhoste len!!!!!
$sql = "SELECT * FROM problems ORDER BY ((post_latitude-$lat)*(post_latitude-$lat)) + ((post_longitude - $longitude)*(post_longitude - $longitude)) ASC LIMIT 10"; 

$result = $db->query($sql);

while($row = mysqli_fetch_array($result))
{
   $results[] = array(
      'creator' => $row['creatorUUID'],
      'name' => $row['post_title'],
      'description' => $row['post_description'],
      'latitude' => $row['post_latitude'],
      'longitude' => $row['post_longitude'],
      'URL' => $row['post_imageURL'],
   );
}
$db->close();
$json = json_encode($results);
echo($json);
?>