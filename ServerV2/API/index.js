// Podla miloša je toto zbytočne zabitý čas
// kód WIP, comittujem len kvôli tomuto komentaru kekW
// hours_wasted_on_xamarin = 1
const app = require('express')();
const crypto = require('crypto');
const bodyParser = require('body-parser');
app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());

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

 app.delete('/api/v1/post/:postID/removePost/', (req,res) => {
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

app.get('/api/v1/post/getTopScorePosts/', (req,res) => {
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

 app.get('/api/v1/post/:postID/sendRating/:rating', (req,res) => {
    const {postID, rating} = req.params;
    connection.query(`SELECT rating, totalVotes FROM problems WHERE creationID = ${postID};` , function (error, results, fields) {
     if (error){
         res.status(500).send(
             {
                 error: error
             }
         );  
         throw error;
     }

     var totalVotes = results[0].totalVotes + 1;
     var resoulta = (((results[0].rating * results[0].totalVotes) + parseFloat(rating)) / (totalVotes));
        connection.query(`UPDATE problems SET rating = '${resoulta}', totalVotes = '${totalVotes}' WHERE creationID = ${postID};` , function (error, results, fields) {
            if (error){
                res.status(500).send(
                    {
                        error: error
                    }
                );
                throw error;
            }
        })

     res.status(200).send({
        status: "accepted"
     });
 });})


app.get('/api/v1/post/:postID/getPost/', (req,res) => {
    const {postID} = req.params;
    console.log(`[LOG][getPost][${req.ip}] postID:${postID}`);
    connection.query(`SELECT * FROM problems WHERE creationID = ${postID}` , function (error, results, fields) {
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

     var userID = dt.generateID();
     var token = dt.generateToken();
     var dataHash = crypto.createHash('sha256').update(req.body.password).digest('base64');

     connection.query(`INSERT INTO users (UUID, Name, LoginToken, passwordHash, email) VALUES ('${userID}','${req.body.name}', '${token}', '${dataHash}','${req.body.email}'); ` , function (error, results, fields) { //kekw
     if (error){
         res.status(500).send(
             {
                 error: error
             }
         );
         throw error;
     }

     res.status(200).send(
         {
         status: "accepted",
         userID: userID,
         token: token,
     }

      )})
 });

 app.get('/api/v1/loginAccount', (req,res) => {
     var email = req.body.email;
     var rawPassword = req.body.password;
     var newToken = dt.generateToken();
     var dataHash = crypto.createHash('sha256').update(rawPassword).digest('base64');

     connection.query(`SELECT passwordHash FROM users WHERE email = '${email}'` , function (error, results, fields) {
     if (error){
         res.status(500).send(
             {
                 error: error
             }
         );  
         throw error;
     }

     if(!(results.length > 0)) {
         res.status(401).send(
             {status: "Not Authorised"});
         // TODO: Dorobit nejaky return alebo nieco co stopne kod
     }

     if(results[0].passwordHash === dataHash) {
         connection.query(`UPDATE users SET LoginToken = '${newToken}' WHERE email = '${email}';` , function (error, results, fields) {
             if (error) {
                 res.status(500).send(
                     {
                         error: error
                     }
                 );
                 throw error;
             } else {
                 res.status(200).send(
                    {
                        status: "accepted",
                        token: newToken
                 });
             }
         })
         //TODO: Dorobit nejaky return alebo nieco co stopne kod
         } else {
         res.status(401).send(
             {status: "Not Authorised"});
         }})
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
