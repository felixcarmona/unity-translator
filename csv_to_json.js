const csv=require('csvtojson');

const csvFilePath='i18n.csv';

var json = [];

csv()
.fromFile(csvFilePath)
.on('json',function (jsonObj){
    var key = jsonObj.key;
    delete jsonObj.key;

    var translations = [];
    for (var k in jsonObj){
        if (jsonObj.hasOwnProperty(k)) {
            translations.push({"lang": k, "translation": jsonObj[k]});
        }
    }
    json.push({"key": key, "target": translations});
})
.on('done',function(error){
    var result = JSON.stringify({"target": json});

    console.log(result);
});
