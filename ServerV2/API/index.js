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

       connection.query(`SELECT * FROM problems ORDER BY ((post_latitude-${latitude})*(post_latitude-${latitude})) + ((post_longitude - ${longitude})*(post_longitude - ${longitude})) ASC LIMIT 10` , function (error, results, fields) {
        res.status(200).send(
            results
        )})

    }
);