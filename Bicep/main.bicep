param name string
param location string = resourceGroup().location
param sku string
param skucode string
param repositoryUrl string
param branch string

@secure()
param spClientId string

@secure()
param repositoryToken string
param appLocation string
param apiLocation string
param appArtifactLocation string
param resourceTags object
// param appSettings object

resource keyVault 'Microsoft.KeyVault/vaults@2019-09-01' = {
  name: '${name}-kv'
  location: location
  properties: {
    sku: {
      family: 'A'
      name: 'standard'
    }
    tenantId: subscription().tenantId

    enableRbacAuthorization: false      // Using Access Policies model
    accessPolicies: [
      {
        objectId: spClientId
        tenantId: subscription().tenantId
        permissions: {
          secrets: [
            'all'
          ]
          certificates: [
            'all'
          ]
          keys: [
            'all'
          ]
        }
      }
    ]
    enabledForDeployment: true          // VMs can retrieve certificates
    enabledForTemplateDeployment: true  // ARM can retrieve values

    enablePurgeProtection: true         // Not allowing to purge key vault or its objects after deletion
    enableSoftDelete: true
    softDeleteRetentionInDays: 7
    createMode: 'default'               // Creating or updating the key vault (not recovering)
  }
}

resource staticWebApp 'Microsoft.Web/staticSites@2021-01-15' = {
  name: '${name}-swa'
  location: location
  tags: resourceTags
  properties: {
    repositoryUrl: repositoryUrl
    branch: branch
    repositoryToken: repositoryToken
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
