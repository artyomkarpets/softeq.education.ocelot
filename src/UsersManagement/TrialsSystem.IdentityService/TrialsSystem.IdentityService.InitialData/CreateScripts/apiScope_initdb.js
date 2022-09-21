var identityServerDb = db.getSiblingDB('TS_IdentityServer');
var collection = identityServerDb.getCollection("ApiScopes");

if(collection.countDocuments({}) === 0) {
  collection.insertMany([{
    "Name": "trial",
    "DisplayName": "Trial API as Api gateway",
    "Description": null,
    "Required": false,
    "Emphasize": false,
    "ShowInDiscoveryDocument": true,
    "UserClaims": []
  },{
    "Name": "identity",
    "DisplayName": "Identity API",
    "Description": null,
    "Required": false,
    "Emphasize": false,
    "ShowInDiscoveryDocument": true,
    "UserClaims": []
  }]);
}
