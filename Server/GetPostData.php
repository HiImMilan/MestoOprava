<?php 
   require("./includes/dbManager.php");
   require("./includes/PostManager.php");
   $db = new DBManager();
   
   $post = new PostManager($db);
   $json = $post->getPostData();
   echo($json);
?>