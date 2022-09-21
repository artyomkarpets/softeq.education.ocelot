var identityServerDb = db.getSiblingDB('TS_IdentityServer');
var collection = identityServerDb.getCollection("IdentityResources");
if(collection.countDocuments({}) === 0) {
  collection.insertMany([{
    "Name": "openid",
    "DisplayName": "Your user identifier",
    "Description": null,
    "Required": true,
    "Emphasize": false,
    "Enabled": true,
    "ShowInDiscoveryDocument": true,
    "UserClaims": [{
      "Type": "sub",
      "Value": null
    },{
      "Type": "role",
      "Value": null
    }]
  }]);
}
