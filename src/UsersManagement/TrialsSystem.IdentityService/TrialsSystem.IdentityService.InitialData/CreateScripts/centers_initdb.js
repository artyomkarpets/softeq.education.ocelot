//Centers
var randomizationsCollectionName = "Centers";
var identityDb = db.getSiblingDB('TS-IdentityServer');
var identityCollections = identityDb.getCollectionNames();

var randomizationsCollection;
if (!identityCollections.find(x => x === randomizationsCollectionName)) {
    identityDb.createCollection(randomizationsCollectionName, { collation: { locale: 'en', strength: 2 } });

    randomizationsCollection = identityDb.getCollection(randomizationsCollectionName);
    randomizationsCollection.createIndex(
        {
            "Id": 1,
            "CenterName": 1
        },
        { unique: true },
        {
            name: "id_centerName_index"
        }
    );
}
else {
    randomizationsCollection = identityDb.getCollection(randomizationsCollectionName);
}