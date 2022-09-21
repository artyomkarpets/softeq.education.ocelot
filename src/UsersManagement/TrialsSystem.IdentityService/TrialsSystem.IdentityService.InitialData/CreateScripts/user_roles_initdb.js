var db = db.getSiblingDB('TS_IdentityServer');
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
    "Name": "Participant",
    "NormalizedName": "PARTICIPANT",
    "ConcurrencyStamp": "e34f9ad0-eb46-47f2-b5ff-3a06b1914cee",
    "Claims" : []
  },
  {
    "Name" : "Observer",
    "NormalizedName" : "OBSERVER",
    "ConcurrencyStamp" : "d4a69485-e2bd-4133-b15d-632d9839aeb0",
    "Claims" : []
  }, 
  {
    "Name" : "Admin",
    "NormalizedName" : "ADMIN",
    "ConcurrencyStamp" : "e966431d-73d4-4871-b2ce-5e6a372a634a",
    "Claims" : []
  }]);
}