using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace CozyThings.Services.Identity
{
    public static class StaticDetails
    {
        public const string ADMIN = "Admin";
        public const string CUSTOMER = "Customer";

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope> 
            { 
                new ApiScope("cozythings", "cozythings server"), 
                new ApiScope(name: "read", displayName: "Read your date"),
                new ApiScope(name: "write", displayName: "Write your date"),
                new ApiScope(name: "delete", displayName: "Delete your date")
            };

        public static IEnumerable<Client> CLients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = { new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "read", "write", "profile" }
                },
                new Client
                {
                    ClientId = "cozythings",
                    ClientSecrets = { new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = { "https://localhost:44379/signin-oidc" },
                    PostLogoutRedirectUris = { "https://localhost:44379/signout-callback-oidc" },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Profile,
                        "cozythings"
                    }
                }
            };
    }
}
