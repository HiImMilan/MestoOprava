const app = require('express')();
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
console.log("[Starting CityApka Server Nightly]");
connection.connect();
});

app.get('/makemeacofee', (req,res) => {
        res.status(418).send({
            status: 'Brewing coffee...'
            }
        )
    }
);

app.get('/testObject', (req,res) => {
    res.status(418).send({
            randomURL: dt.generateURL()
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
    /*  connection.query(`` , function (error, results, fields) { // DOROBIT ODOSIELANIE DAT!
    if (error){
        res.status(500).send(
            {
                error: error
            }
        );  
        throw error;
    }
    res.status(200).send(
    )})*/

    res.status(500).send(
        {
            status: "debug"
        }
    );
    console.log(req);
});

app.get('/api/v1/getUserData/:userID', (req,res) => {
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

 app.post('/api/v1/regiserAccount', (req,res) => {
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

 app.delete('/api/v1/deleteAccount/:userID', (req,res) => {
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