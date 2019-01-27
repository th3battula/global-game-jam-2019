using UnityEngine;
using System.Collections.Generic;

public enum ResourceList {
    Rock,
    Sapling,
    Hardwood,
    PetrifiedWood,
    Flint,
    Stone,
    Metal,
    SimpleFiber,
    AdvancedFiber,
    ReinforcedFiber,
}

public enum ResourceTypes {
    Rock,
    Wood,
    Ore,
    Fiber,
}

static class ResourceInformation {
    private static ResourceInfoStruct RockResourceInfo = new ResourceInfoStruct(ResourceList.Rock, ToolTypes.Any, ResourceTypes.Rock, 0, 1, 1);

    private static ResourceInfoStruct FlintResourceInfo = new ResourceInfoStruct(ResourceList.Flint, ToolTypes.Rock, ResourceTypes.Ore, 0, 200, 1);
    private static ResourceInfoStruct StoneResourceInfo = new ResourceInfoStruct(ResourceList.Stone, ToolTypes.Pickaxe, ResourceTypes.Ore, 1, 400, 1);
    private static ResourceInfoStruct MetalResourceInfo = new ResourceInfoStruct(ResourceList.Metal, ToolTypes.Pickaxe, ResourceTypes.Ore, 2, 1000, 1);

    private static ResourceInfoStruct SaplingResourceInfo = new ResourceInfoStruct(ResourceList.Sapling, ToolTypes.Knife, ResourceTypes.Wood, 0, 100, 1);
    private static ResourceInfoStruct HardwoodResourceInfo = new ResourceInfoStruct(ResourceList.Hardwood, ToolTypes.Axe, ResourceTypes.Wood, 1, 500, 1);
    private static ResourceInfoStruct PetrifiedWoodInfo = new ResourceInfoStruct(ResourceList.PetrifiedWood, ToolTypes.Axe, ResourceTypes.Wood, 2, 1000, 1);

    private static ResourceInfoStruct SimpleFiberResourceInfo = new ResourceInfoStruct(ResourceList.SimpleFiber, ToolTypes.Knife, ResourceTypes.Fiber, 0, 100, 1);
    private static ResourceInfoStruct AdvancedFiberResourceInfo = new ResourceInfoStruct(ResourceList.AdvancedFiber, ToolTypes.Knife, ResourceTypes.Fiber, 1, 400, 1);
    private static ResourceInfoStruct ReinforcedFiberResourceInfo = new ResourceInfoStruct(ResourceList.ReinforcedFiber, ToolTypes.Knife, ResourceTypes.Fiber, 1, 1000, 1);

    public static Dictionary<ResourceList, ResourceInfoStruct> resourceInfo = new Dictionary<ResourceList, ResourceInfoStruct> {
    { ResourceList.Rock, RockResourceInfo },
    { ResourceList.Sapling, SaplingResourceInfo },
    { ResourceList.Hardwood, HardwoodResourceInfo },
    { ResourceList.PetrifiedWood, PetrifiedWoodInfo },
    { ResourceList.Flint, FlintResourceInfo },
    { ResourceList.Stone, StoneResourceInfo },
    { ResourceList.Metal, MetalResourceInfo },
    { ResourceList.SimpleFiber, SimpleFiberResourceInfo },
    { ResourceList.AdvancedFiber, AdvancedFiberResourceInfo },
    { ResourceList.ReinforcedFiber, ReinforcedFiberResourceInfo },
};
}

public class ResourceController : MonoBehaviour {

    [SerializeField] ResourceList resourceId;

    [SerializeField] GameObject depletedState;

    ResourceInfoStruct resource;
    int durability;

    void Start() {
        resource = getResourceInfo(resourceId);
        durability = resource.durability;
    }

    public static ResourceInfoStruct getResourceInfo(ResourceList id) {
        return ResourceInformation.resourceInfo[id];
    }

    public ResourceTypes getResourceType() {
        return this.resource.resourceType;
    }

    public ResourceStruct Interact(ToolInfoStruct toolInfo) {
        bool canHarvest = getCanHarvest(toolInfo, resource);

        if(canHarvest) {
            this.durability -= toolInfo.damage;
        }
        if (this.durability <= 0) {
            InventoryController.instance.IncrementResource(resource.id, resource.count);
            DestroyThis();
            return new ResourceStruct(resource.id, resource.resourceType, resource.resourceTier, resource.count);
        }
        return new ResourceStruct(resource.id, resource.resourceType, resource.resourceTier, 0);
    }

    public bool getCanHarvest(ToolInfoStruct toolInfo, ResourceInfoStruct resource) {
        if(toolInfo.type == resource.toolType || resource.toolType == ToolTypes.Any) {
            return true;
        };
        return false;
    }

    public void DestroyThis() {
        if (depletedState != null) {
            GameObject.Instantiate(depletedState, transform.position, Quaternion.identity);
        }
        Destroy(this.gameObject);
    }
}

[System.Serializable] public struct ResourceStruct {
    public ResourceList id;
    public ResourceTypes type;
    public int tier;
    public int count;

    public ResourceStruct(ResourceList newId, ResourceTypes newType, int newTier, int newCount) {
        id = newId;
        type = newType;
        tier = newTier;
        count = newCount;
    }
}

[System.Serializable] public struct ResourceInfoStruct {
    public ResourceList id;
    public ToolTypes toolType;
    public ResourceTypes resourceType;
    public int resourceTier;
    public int durability;
    public int count; // setting default to 1 for testing purposes.

    public ResourceInfoStruct(ResourceList newId, ToolTypes newToolType, ResourceTypes newResourceType, int newResourceTier, int newDurability, int newCount) {
        id = newId;
        toolType = newToolType;
        resourceType = newResourceType;
        resourceTier = newResourceTier;
        durability = newDurability;
        count = newCount;
    }
}