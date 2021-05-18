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

function rand(min, max) {
    return Math.floor(Math.random() * (max - min + 1) ) + min; // Musel som implementovať Random, lebo JS je má divný random
}
