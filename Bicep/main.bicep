param name string
param location string = resourceGroup().location
param sku string
param skucode string
param appLocation string
param apiLocation string
param appArtifactLocation string
param resourceTags object
// param appSettings object

@secure()
param adminLoginName string
@secure()
param adminLoginPassword string

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
  parent: keyVault // Pass key vault symbolic name as parent
  properties: {
    value: listSecrets(staticWebApp.id, staticWebApp.apiVersion).properties.apiKey
  }
}

resource dataBaseServer 'Microsoft.Sql/servers@2021-11-01-preview' = {
  name: '${name}-dbs'
  location: location
  properties: {
    administratorLogin: adminLoginName
    administratorLoginPassword: adminLoginPassword
    version: '12.0'
    minimalTlsVersion: '1.2'
  }
}

resource database 'Microsoft.Sql/servers/databases@2021-11-01-preview' = {
  parent: dataBaseServer
  name: '${name}-db'
  location: location
  sku: {
    name: 'GP_S_Gen5'
    tier: 'GeneralPurpose'
    family: 'Gen5'
    capacity: 2
  }
  properties: {
    collation: 'SQL_Latin1_General_CP1_CI_AS'
    maxSizeBytes: 5368709120
    catalogCollation: 'SQL_Latin1_General_CP1_CI_AS'
    zoneRedundant: false
    readScale: 'Disabled'
    autoPauseDelay: 60
    minCapacity: any('0.5')
  }
}

// resource name_appsettings 'Microsoft.Web/staticSites/config@2021-01-15' = {
//   parent: staticWebApp
//   name: 'appsettings'
//   properties: appSettings
// }
