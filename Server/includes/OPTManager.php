<?php
require_once __DIR__ . '/vendor/autoload.php';
use OTPHP\TOTP;
    class PostManager{

        public $db;
        function __construct($database){
            $this->db = $database;
        }
        
    }
?>