Example: Creating a Virtual Network
--------------------------------------

In this example, we'll create a virtual network. Since the SDK follows the resource hierarchy in Azure, we'll need to do this inside of a resource group.

## Import the namespaces
These are the namespaces needed for this project:
```C#
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Network;
using System;
using System.Threading.Tasks;
```

## Create a Resource Group
Start by creating a new resource group, like we did above:

```C# Snippet:Creating_A_Virtual_Network_CreateResourceGroup
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
ResourceGroupContainer rgContainer = armClient.DefaultSubscription.GetResourceGroups();

string rgName = "myResourceGroup";
ResourceGroupData rgData = new ResourceGroupData(Location.WestUS2);
ResourceGroupCreateOrUpdateOperation operation = await rgContainer.CreateOrUpdateAsync(rgName, rgData);
ResourceGroup resourceGroup = operation.Value;
```
## Create a Virtual Network
Now that we have a resource group, we'll create our virtual network. To do this, we will create a `VirtualNetworkData` object for the parameters that we want our Virtual Network to have, then we will get the Virtual Network container and from there we call `CreateOrUpdateAsync()`.

```csharp
string vnetName = "myVnetName";
VirtualNetworkData vnetData = new VirtualNetworkData()
{
    // You can specify many options for the Virtual Network in here
    Location = "WestUS2",
    AddressSpace = new AddressSpace()
    {
        AddressPrefixes = { "10.0.0.0/16", }
    }
};

VirtualNetwork vnet = await resourceGroup.GetVirtualNetworks().CreateOrUpdateAsync(vnetName, vnetData);
```

## Create a Subnet 
Now that we have a virtual network, we must create at least one subnet in order to add any virtual machines.
Following the hierarchy in Azure, subnets belong to a virtual network, so that's where we'll get our `SubnetContainer` instance. Before that, a `SubnetData` object must be created to specify the parameters for the Subnet.

```csharp
string subnetName = vnetName + "_Subnet1";
SubnetData subnetData = new SubnetData()
{
    Name = subnetName,
    AddressPrefix = "10.0.1.0/24"
};

Subnet subnet = await vnet.GetSubnets().CreateOrUpdateAsync(subnetName, subnetData);
```

## Another way to create a Virtual Network with a Subnet
It is possible to define an create a virtual network with its subnets in a single step. This is achieved by defining the subnets in the `VirtualNetworkData` object that is given as a parameter.

```csharp
string vnetName = "myVnetName";
string subnet1Name = vnetName + "_Subnet1";

var vnetData = new VirtualNetworkData()
{
    Location = "WestUS2",
    AddressSpace = new AddressSpace()
    {
        AddressPrefixes = { "10.0.0.0/16", }
    },
    Subnets = { new SubnetData() { Name = subnet1Name, AddressPrefix = "10.0.0.0/24", } }
};

VirtualNetwork vnet = await resourceGroup.GetVirtualNetworks().CreateOrUpdateAsync(vnetName, vnetData);
```
### Modifying the Subnets of an existing Virtual Network
Using the SubnetContainer it is possible to add a subnet into the virtual network we created above.
```csharp
string subnet2Name = vnetName + "_Subnet2";
SubnetData subnetData = new SubnetData()
{
    Name = subnet2Name,
    AddressPrefix = "10.0.1.0/24"
};

Subnet subnet = await vnet.GetSubnets().CreateOrUpdateAsync(subnet2Name, subnetData);
```

You can verify that your virtual network now has 2 subnets by doing the following: 
```csharp
VirtualNetwork myVNet = await resourceGroup.GetVirtualNetworks().GetAsync(vnetName);
Console.WriteLine(myVNet.Data.Subnets.Count);
```
