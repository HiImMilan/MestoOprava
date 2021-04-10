<?php
  $url = "";
  $urlLength = 0;
  $alphabet = array('A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z');
  while($urlLength < 30){
    $url .= $alphabet[rand(0,25)];
    $urlLength++;
  }
  echo($url);
  ?>