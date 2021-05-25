// Milošov ultimátny URL Generátor
// Rewritten from PHP to JS

exports.generateURL = function(){
    var url = "";
    var urlLength = 0;
    var alphabet = ['A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'];
        while(urlLength < 30){
            url += alphabet[rand(0,25)];
            urlLength++;
        }
    return url;
}

exports.generateToken = function(){
    var token = "";
    var tokenLength = 0;
    var alphabet = ['A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z','1','2','3','4','5','6','7','8','9','0','a','b','c','d','e','f','g','h'];
    while(tokenLength < 64){
        token += alphabet[rand(0,43)];
        tokenLength++;
    }
    return token;
}

exports.generateID = function(){
    var token = "";
    var tokenLength = 0;
    var alphabet = ['A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z','1','2','3','4','5','6','7','8','9','0','a','b','c','d','e','f','g','h'];
    while(tokenLength < 16){
        token += alphabet[rand(0,43)];
        tokenLength++;
    }
    return token;
}

function rand(min, max) {
    return Math.floor(Math.random() * (max - min + 1) ) + min; // Musel som implementovať Random, lebo JS je má divný random
}
