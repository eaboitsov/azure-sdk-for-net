# Example: Managing the network interfaces

>Note: Before getting started with the samples, go through the [prerequisites](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager#prerequisites).

Namespaces for this example:

```C# Snippet:Manage_Networks_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
```

When you first create your ARM client, choose the subscription you're going to work in. There's a convenient `DefaultSubscription` property that returns the default subscription configured for your user:

```C# Snippet:Readme_DefaultSubscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = armClient.DefaultSubscription;
```

This is a scoped operations object, and any operations you perform will be done under that subscription. From this object, you have access to all children via container objects. Or you can access individual children by ID.

```C# Snippet:Readme_GetResourceGroupContainer
ResourceGroupContainer rgContainer = subscription.GetResourceGroups();
// With the container, we can create a new resource group with an specific name
string rgName = "myRgName";
Location location = Location.WestUS2;
ResourceGroup resourceGroup = await rgContainer.CreateOrUpdate(rgName, new ResourceGroupData(location)).WaitForCompletionAsync();
```

Now that we have the resource group created, we can manage the network interfaces inside this resource group.

***Create a network interface***

```C# Snippet:Managing_Networks_CreateANetworkInterface
PublicIPAddressContainer publicIPAddressContainer = resourceGroup.GetPublicIPAddresses();
string publicIPAddressName = "myIPAddress";
PublicIPAddressData publicIPInput = new PublicIPAddressData()
{
    Location = resourceGroup.Data.Location,
    PublicIPAllocationMethod = IPAllocationMethod.Dynamic,
    DnsSettings = new PublicIPAddressDnsSettings()
    {
        DomainNameLabel = "myDomain"
    }
};
PublicIPAddress publicIPAddress = await publicIPAddressContainer.CreateOrUpdate(publicIPAddressName, publicIPInput).WaitForCompletionAsync();

NetworkInterfaceContainer networkInterfaceContainer = resourceGroup.GetNetworkInterfaces();
string networkInterfaceName = "myNetworkInterface";
NetworkInterfaceData networkInterfaceInput = new NetworkInterfaceData()
{
    Location = resourceGroup.Data.Location,
    IpConfigurations = {
        new NetworkInterfaceIPConfiguration()
        {
            Name = "ipConfig",
            PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
            PublicIPAddress = new PublicIPAddressData()
            {
                Id = publicIPAddress.Id
            },
            Subnet = new SubnetData()
            {
                // use the virtual network just created
                Id = virtualNetwork.Data.Subnets[0].Id
            }
        }
    }
};
NetworkInterface networkInterface = await networkInterfaceContainer.CreateOrUpdate(networkInterfaceName, networkInterfaceInput).WaitForCompletionAsync();
```

***List all network interfaces***

```C# Snippet:Managing_Networks_ListAllNetworkInterfaces
NetworkInterfaceContainer networkInterfaceContainer = resourceGroup.GetNetworkInterfaces();

AsyncPageable<NetworkInterface> response = networkInterfaceContainer.GetAllAsync();
await foreach (NetworkInterface virtualNetwork in response)
{
    Console.WriteLine(virtualNetwork.Data.Name);
}
```

***Get a network interface***

```C# Snippet:Managing_Networks_GetANetworkInterface
NetworkInterfaceContainer networkInterfaceContainer = resourceGroup.GetNetworkInterfaces();

NetworkInterface virtualNetwork = await networkInterfaceContainer.GetAsync("myVnet");
Console.WriteLine(virtualNetwork.Data.Name);
```

***Try to get a network interface if it exists***

```C# Snippet:Managing_Networks_GetANetworkInterfaceIfExists
NetworkInterfaceContainer networkInterfaceContainer = resourceGroup.GetNetworkInterfaces();

NetworkInterface virtualNetwork = await networkInterfaceContainer.GetIfExistsAsync("foo");
if (virtualNetwork != null)
{
    Console.WriteLine(virtualNetwork.Data.Name);
}

if (await networkInterfaceContainer.CheckIfExistsAsync("bar"))
{
    Console.WriteLine("Network interface 'bar' exists.");
}
```

***Delete a network interface***

```C# Snippet:Managing_Networks_DeleteANetworkInterface
NetworkInterfaceContainer networkInterfaceContainer = resourceGroup.GetNetworkInterfaces();

NetworkInterface virtualNetwork = await networkInterfaceContainer.GetAsync("myVnet");
await virtualNetwork.DeleteAsync();
```
