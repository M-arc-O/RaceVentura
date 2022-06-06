param name string
param location string = resourceGroup().location
param sku string
param skucode string
param appLocation string
param apiLocation string
param appArtifactLocation string
param resourceTags object
// param appSettings object

resource keyVault 'Microsoft.KeyVault/vaults@2019-09-01' existing = {
  name: 'raceventura-kv'
}

resource staticWebApp 'Microsoft.Web/staticSites@2021-01-15' = {
  name: '${name}-swa'
  location: location
  tags: resourceTags
  properties: {
    buildProperties: {
      appLocation: appLocation
      apiLocation: apiLocation
      appArtifactLocation: appArtifactLocation
    }
  }
  sku: {
    tier: sku
    name: skucode
  }
}

resource webAppApiKey 'Microsoft.KeyVault/vaults/secrets@2019-09-01' = {
  name: 'webAppApiKey'
  parent: keyVault  // Pass key vault symbolic name as parent
  properties: {
    value: listSecrets(staticWebApp.id, staticWebApp.apiVersion).properties.apiKey
  }
}

// resource name_appsettings 'Microsoft.Web/staticSites/config@2021-01-15' = {
//   parent: staticWebApp
//   name: 'appsettings'
//   properties: appSettings
// }
