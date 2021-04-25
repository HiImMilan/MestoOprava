<?php
    class PostManager{

        public $db;
        function __construct($database){
            $this->db = $database;
        }
        function getData(){
            $data = json_decode(file_get_contents('php://input'),true);
            $lat = $data["lat"]; 
            $longitude = $data["longy"];

            return $data;
        }
        function fetchData(){
            $data = $this->getData();
            $lat = $data["lat"];
            $longitude = $data["longy"];
            $sql = "SELECT * FROM problems ORDER BY ((post_latitude-$lat)*(post_latitude-$lat)) + ((post_longitude - $longitude)*(post_longitude - $longitude)) ASC LIMIT 10"; 
            $result = $this->db->conn->query($sql);
            return $result;
        }
        function getPostData(){
            $result = $this->fetchData();
            $response = array();
            if($result){
                return json_encode($response);
            }
            else{
                return "";
            }
            
        }
    }
?>