// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace AkademiPlusMicroServiceProject.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource ("resource_catalog"){Scopes={"catalog_fullpermission"}},
                new ApiResource ("resource_photostock"){Scopes={"photostock_fullpermission"}},
                    new ApiResource ("resource_basket"){Scopes={"basket_fullpermission"}},
                        new ApiResource ("resource_discount"){Scopes={"discount_fullpermission"}},
                            new ApiResource ("resource_order"){Scopes={"order_fullpermission"}},
                                new ApiResource ("resource_payment"){Scopes={"payment_fullpermission"}},
                                    new ApiResource ("resource_gateway"){Scopes={"gateway_fullpermission"}},
                                        new ApiResource (IdentityServerConstants.LocalApi.ScopeName)
    };
        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("catalog_fullpermission","Katalog Api için Tam Yetkili Erişim."),
                  new ApiScope("photostock_fullpermission","PhotoStock Api için Tam Yetkili Erişim."),
                      new ApiScope("basket_fullpermission","Sepet Api için Tam Yetkili Erişim."),
                           new ApiScope("discount_fullpermission","İndirim Api için Tam Yetkili Erişim."),
                                new ApiScope("order_fullpermission","Sipariş Api için Tam Yetkili Erişim."),
                                     new ApiScope("payment_fullpermission","Ödeme Api için Tam Yetkili Erişim."),
                                          new ApiScope("gateway_fullpermission","GateWay Api için Tam Yetkili Erişim."),
                                                new ApiScope(IdentityServerConstants.LocalApi.ScopeName),
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
              new Client
              {
                  ClientName="AkademiPlus",
                  ClientId="AkademiPlusClient",
                  ClientSecrets={new Secret ("secret".Sha256())},
                  AllowedGrantTypes=GrantTypes.ClientCredentials,
                  AllowedScopes={ "catalog_fullpermission", "photostock_fullpermission",IdentityServerConstants.LocalApi.ScopeName }
              },
              new Client
              {
                  ClientName="AkademiPlus",
                  ClientId="AkademiPlusClientForUser",
                  AllowOfflineAccess=true,
                 ClientSecrets={new Secret ("secret".Sha256())},
                 AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                 AllowedScopes={ "catalog_fullpermission", "photostock_fullpermission",IdentityServerConstants.StandardScopes.Email, IdentityServerConstants.StandardScopes.OpenId, IdentityServerConstants.StandardScopes.Profile,IdentityServerConstants.StandardScopes.OfflineAccess,IdentityServerConstants.LocalApi.ScopeName },
                 AccessTokenLifetime=300
              },
            };
    }
}