<?php
$file = "file.txt";
$test = file_get_contents('php://input');
file_put_contents($file, $test);

?>