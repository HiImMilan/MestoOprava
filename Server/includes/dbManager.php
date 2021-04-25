<?php
class DBManager{
    private $server = "localhost";
    private $username = "root";
    private $password = "";
    private $dbName = "city";
    public $conn;
    function __construct(){
        $conn = new mysqli($this->server, $this->username, $this->password,$this->dbName);

        if ($conn->connect_error) {
            die("Connection failed: " . $conn->connect_error);
        }
        echo "Connected successfully";
        $this->conn = $conn;
    }
    function __destruct(){
        $this->conn->close();
    }
}
?>