using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialsSystem.IdentityService.Domain.Entities
{
    public class ClientEntity : Entity
    {
        public bool Enabled { get; set; } = true;
        public string ClientId { get; set; }
        public string ProtocolType { get; set; } = "oidc";
        public List<SecretEntity> ClientSecrets { get; set; }
        public bool RequireClientSecret { get; set; } = true;
        public string ClientName { get; set; }
        public string Description { get; set; }
        public string ClientUri { get; set; }
        public string LogoUri { get; set; }
        public bool RequireConsent { get; set; } = false;
        public bool AllowRememberConsent { get; set; } = true;
        public bool AlwaysIncludeUserClaimsInIdToken { get; set; }
        public List<string> AllowedGrantTypes { get; set; }
        public bool RequirePkce { get; set; } = true;
        public bool AllowPlainTextPkce { get; set; }
        public bool RequireRequestObject { get; set; }
        public bool AllowAccessTokensViaBrowser { get; set; }
        public List<string> RedirectUris { get; set; }
        public List<string> PostLogoutRedirectUris { get; set; }
        public string FrontChannelLogoutUri { get; set; }
        public bool FrontChannelLogoutSessionRequired { get; set; } = true;
        public string BackChannelLogoutUri { get; set; }
        public bool BackChannelLogoutSessionRequired { get; set; } = true;
        public bool AllowOfflineAccess { get; set; } = false;
        public List<string> AllowedScopes { get; set; }
        public int IdentityTokenLifetime { get; set; } = 300;
        public List<string> AllowedIdentityTokenSigningAlgorithms { get; set; }
        public int AccessTokenLifetime { get; set; } = 3600;
        public int AuthorizationCodeLifetime { get; set; } = 300;
        public int AbsoluteRefreshTokenLifetime { get; set; } = 2592000;
        public int SlidingRefreshTokenLifetime { get; set; } = 1296000;
        public int? ConsentLifetime { get; set; } = null;
        public int RefreshTokenUsage { get; set; } = (int)IdentityServer4.Models.TokenUsage.OneTimeOnly;
        public bool UpdateAccessTokenClaimsOnRefresh { get; set; }
        public int RefreshTokenExpiration { get; set; } = (int)IdentityServer4.Models.TokenExpiration.Sliding;
        public int AccessTokenType { get; set; } = 0; // AccessTokenType.Jwt;
        public bool EnableLocalLogin { get; set; } = true;
        public List<string> IdentityProviderRestrictions { get; set; }
        public bool IncludeJwtId { get; set; }
        public List<Claim> Claims { get; set; }
        public bool AlwaysSendClientClaims { get; set; }
        public string ClientClaimsPrefix { get; set; } = "client_";
        public string PairWiseSubjectSalt { get; set; }
        public int? UserSsoLifetime { get; set; }
        public string UserCodeType { get; set; }
        public int DeviceCodeLifetime { get; set; } = 300;
        public List<string> AllowedCorsOrigins { get; set; }
        public List<Property> Properties { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime? Updated { get; set; }
        public DateTime? LastAccessed { get; set; }
    }
}
