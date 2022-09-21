var db = db.getSiblingDB('TS-Users');
var collectionName = "Roles";
var collections = db.getCollectionNames();

var collection;
if (!collections.find(x => x === collectionName)) {
    db.createCollection(collectionName, { collation: { locale: 'en', strength: 2 } });

    collection = db.getCollection(collectionName);
    collection.createIndex(
        {
            "NormalizedName": 1
        },
        {
            name: "normalizedName_index"
        }
    );
}
else {
    collection = db.getCollection(collectionName);
}

if(collection.countDocuments({}) === 0) {
  collection.insertMany([{
    "Name": "Patient",
    "NormalizedName": "PATIENT",
    "ConcurrencyStamp": "e34f9ad0-eb46-47f2-b5ff-3a06b1914cee",
    "Claims" : []
  },
  {
    "Name" : "Volunteer",
    "NormalizedName" : "VOLUNTEER",
    "ConcurrencyStamp" : "d4a69485-e2bd-4133-b15d-632d9839aeb0",
    "Claims" : []
  }]);
}