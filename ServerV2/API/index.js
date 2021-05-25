// Podla miloša je toto zbytočne zabitý čas
// kód WIP, comittujem len kvôli tomuto komentaru kekW
// hours_wasted_on_xamarin = 1
const app = require('express')();
const crypto = require('crypto');
const PORT = 8142;
var dt = require('./libCityApka');
var mysql  = require('mysql');
var connection = mysql.createConnection({
    host     : 'localhost',
    user     : 'root',
    password : '',
    database : 'city'
});

app.listen(PORT,() => {
console.log("[Starting CityApka Nightly Server]");
connection.connect();
});

app.get('/makemeacofee', (req,res) => {
        res.status(418).send({
            status: 'Brewing coffee...'
            }
        )
    }
);

app.get('/api/v1/testObject/:data', (req,res) => {
    const {data} = req.params;
    var dataHash = crypto.createHash('sha256').update(data).digest('base64');


    res.status(418).send({
            randomURL: dt.generateURL(),
            token: dt.generateToken(),
            userID: dt.generateID(),
            hash: dataHash
        }
    )
   }
);

app.get('/api/v1/getNearest/:latitude/:longitude', (req,res) => {
        const {latitude, longitude} = req.params;
        console.log(`[LOG][getNearest][${req.ip}] lat:${latitude} long:${longitude}`);
       connection.query(`SELECT * FROM problems ORDER BY ((latitude-${latitude})*(latitude-${latitude})) + ((longitude - ${longitude})*(longitude - ${longitude})) ASC LIMIT 10` , function (error, results, fields) {
        if (error){
            res.status(500).send(
                {
                    error: error
                }
            );  
            throw error;
        }
        res.status(200).send(
            results
        )})
    }
);

app.post('/api/v1/sendData', (req,res) => {
      connection.query(`` , function (error, results, fields) { // DOROBIT ODOSIELANIE DAT!
    if (error){
        res.status(500).send(
            {
                error: error
            }
        );  
        throw error;
    }
    res.status(200).send(
    )})

    res.status(500).send(
        {
            status: "debug"
        }
    );
    console.log(req);
});

app.get('/api/v1/connectivityCheck', (req,res) => {
    res.status(200).send(
        {
            status: "ok",
            mode: "debug"
        }
    );
});

app.get('/api/v1/:userID/getUserData/', (req,res) => {
    const {userID} = req.params;
    connection.query(`` , function (error, results, fields) {  // RETURNE AJ USER POSTY!!!!!
     if (error){
         res.status(500).send(
             {
                 error: error
             }
         );  
         throw error;
     }
     res.status(200).send(
         results
     )})
 });

 app.delete('/api/v1/removePost/:postID', (req,res) => {
    const {postID} = req.params;
    connection.query(`` , function (error, results, fields) { 
     if (error){
         res.status(500).send(
             {
                 error: error
             }
         );  
         throw error;
     }
     res.status(200).send(
         results
     )})
 });

 app.post('/api/v1/registerAccount', (req,res) => {


     var data = "0";
     var dataHash = crypto.createHash('sha256').update(data).digest('base64');


     connection.query(`` , function (error, results, fields) {
     if (error){
         res.status(500).send(
             {
                 error: error
             }
         );  
         throw error;
     }
     res.status(200).send(
         results
     )})
 });

 app.get('/api/v1/loginAccount', (req,res) => {
    connection.query(`` , function (error, results, fields) { 
     if (error){
         res.status(500).send(
             {
                 error: error
             }
         );  
         throw error;
     }
     res.status(200).send(
         results
     )})
 });

 app.delete('/api/v1/:userID/deleteAccount/', (req,res) => {
    const {userID} = req.params;
    connection.query(`` , function (error, results, fields) { 
     if (error){
         res.status(500).send(
             {
                 error: error
             }
         );  
         throw error;
     }
     res.status(200).send(
         results
     )})
 });