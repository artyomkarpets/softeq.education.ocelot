var identityServerDb = db.getSiblingDB('TS-IdentityServer');
var collection = identityServerDb.getCollection("ApiScopes");

if(collection.countDocuments({}) === 0) {
  collection.insertMany([{
    "Name": "treatment",
    "DisplayName": "Treatment API as Api gateway for Mobile app",
    "Description": null,
    "Required": false,
    "Emphasize": false,
    "ShowInDiscoveryDocument": true,
    "UserClaims": []
  },{
    "Name": "identity",
    "DisplayName": "Identity API for Mobile app",
    "Description": null,
    "Required": false,
    "Emphasize": false,
    "ShowInDiscoveryDocument": true,
    "UserClaims": []
  }]);
}
