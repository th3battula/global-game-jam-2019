using UnityEngine;
using System.Collections.Generic;

public enum ToolTypes {
    Axe,
    Pickaxe,
    Spear,
    Bow,
    Knife,
    Torch,
    None,
}

public class InventoryController : MonoBehaviour {

    public static InventoryController instance;
    [SerializeField] Inventory inventory;

    void Start() {
        instance = this;
        inventory = new Inventory();
        inventory.resources = new Dictionary<ResourceTypes, int> {
            { ResourceTypes.Wood, 0 },
            { ResourceTypes.Hardwood, 0 },
            { ResourceTypes.PetrifiedWood, 0 },
            { ResourceTypes.Rock, 0 },
            { ResourceTypes.Flint, 0 },
            { ResourceTypes.Stone, 0 },
            { ResourceTypes.Metal, 0 },
            { ResourceTypes.Fiber, 0 },
            { ResourceTypes.AdvancedFiber, 0 },
            { ResourceTypes.ReinforcedFiber, 0 },
        };

        inventory.tools = new Dictionary<ToolTypes, int> {
            { ToolTypes.Axe, 0 },
            { ToolTypes.Pickaxe, 0 },
            { ToolTypes.Spear, 0 },
            { ToolTypes.Bow, 0 },
            { ToolTypes.Knife, 0 },
            { ToolTypes.Torch, 0 },
            { ToolTypes.None, 0 },
        };

        string inventoryString = inventory.ToString();
        Debug.Log("inventory: " + inventoryString);
    }

    public void IncrementResource(ResourceTypes resourceType, int amount = 1) {
        int newValue = 0;
        inventory.resources.TryGetValue(resourceType, out newValue);

        inventory.resources[resourceType] = newValue + amount;
        //TAB
        string inventoryString = inventory.ToString();
        Debug.Log("new inventory: " + inventoryString);
    }

    public Inventory Inventory {
        get {
            return inventory;
        }
    }
}

[System.Serializable]
public struct Inventory {
    public Dictionary<ResourceTypes, int> resources;

    public Dictionary<ToolTypes, int> tools;

    public override string ToString() {
        string stringifiedInventory = "resources: { ";

        foreach (KeyValuePair<ResourceTypes, int> kvp in resources) {
            ResourceTypes type = kvp.Key;
            int count = kvp.Value;
            stringifiedInventory += string.Format("{0}: {1}, ", type, count);
        }
        stringifiedInventory += "}, tools: { ";

        foreach (KeyValuePair<ToolTypes, int> kvp in tools) {
            ToolTypes type = kvp.Key;
            int count = kvp.Value;
            stringifiedInventory += string.Format("{0}: {1}, ", type, count);
        }
        stringifiedInventory += "}";

        return stringifiedInventory;
    }
}