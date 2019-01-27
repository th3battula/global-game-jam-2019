using UnityEngine;
using System.Collections.Generic;

public enum ToolTypes {
    Unarmed,
    Rock,
    Torch,
    Knife,
    Axe,
    Pickaxe,
    Spear,
    Bow,
    Any,
};

public enum ToolList {
    Unarmed,
    Rock,
    SimpleAxe,
    AdvancedAxe,
    SuperiorAxe,
    SimplePickaxe,
    AdvancedPickaxe,
    SuperiorPickAxe,
    SimpleSpear,
    AdvancedSpear,
    SuperiorSpear,
    SimpleBow,
    AdvancedBow,
    SuperiorBow,
    SimpleKnife,
    AdvancedKnife,
    SuperiorKnife,
    Torch,
};

public static class ToolInformation {
    private static ToolInfoStruct UnarmedInfo = new ToolInfoStruct(ToolList.Unarmed, ToolTypes.Unarmed, 0, 100, null);
    private static ToolInfoStruct RockInfo = new ToolInfoStruct(ToolList.Rock, ToolTypes.Rock, 0, 200, null);
    private static ToolInfoStruct TorchInfo = new ToolInfoStruct(ToolList.Torch, ToolTypes.Torch, 0, 300, new Dictionary<ResourceList, int>() {
        { ResourceList.Sapling, 1 },
        { ResourceList.SimpleFiber, 1 },
        { ResourceList.Flint, 1 },
    });

    private static ToolInfoStruct SimpleKnifeInfo = new ToolInfoStruct(ToolList.SimpleKnife, ToolTypes.Knife, 0, 100, new Dictionary<ResourceList, int>() {
        { ResourceList.SimpleFiber, 1 },
        { ResourceList.Flint, 1 },
    });
    private static ToolInfoStruct AdvancedKnifeInfo = new ToolInfoStruct(ToolList.AdvancedKnife, ToolTypes.Knife, 1, 200, new Dictionary<ResourceList, int>() {
        { ResourceList.AdvancedFiber, 1 },
        { ResourceList.Stone, 1 },
    });
    private static ToolInfoStruct SuperiorKnifeInfo = new ToolInfoStruct(ToolList.SuperiorKnife, ToolTypes.Knife, 2, 400, new Dictionary<ResourceList, int>() {
        { ResourceList.ReinforcedFiber, 1 },
        { ResourceList.Metal, 1 },
    });

    private static ToolInfoStruct SimpleAxeInfo = new ToolInfoStruct(ToolList.SimpleAxe, ToolTypes.Axe, 0, 100, new Dictionary<ResourceList, int>() {
        { ResourceList.Sapling, 1 },
        { ResourceList.SimpleFiber, 1 },
        { ResourceList.Flint, 1 },
    });
    private static ToolInfoStruct AdvancedAxeInfo = new ToolInfoStruct(ToolList.AdvancedAxe, ToolTypes.Axe, 1, 200, new Dictionary<ResourceList, int>() {
        { ResourceList.Hardwood, 1 },
        { ResourceList.AdvancedFiber, 1 },
        { ResourceList.Stone, 1 },
    });
    private static ToolInfoStruct SuperiorAxeInfo = new ToolInfoStruct(ToolList.SuperiorAxe, ToolTypes.Axe, 2, 400, new Dictionary<ResourceList, int>() {
        { ResourceList.PetrifiedWood, 1 },
        { ResourceList.ReinforcedFiber, 1 },
        { ResourceList.Metal, 1 },
    });

    private static ToolInfoStruct SimplePickaxeInfo = new ToolInfoStruct(ToolList.SimplePickaxe, ToolTypes.Pickaxe, 0, 100, new Dictionary<ResourceList, int>() {
        { ResourceList.Sapling, 1 },
        { ResourceList.SimpleFiber, 1 },
        { ResourceList.Flint, 1 },
    });
    private static ToolInfoStruct AdvancedPickaxeInfo = new ToolInfoStruct(ToolList.AdvancedPickaxe, ToolTypes.Pickaxe, 1, 200, new Dictionary<ResourceList, int>() {
        { ResourceList.Hardwood, 1 },
        { ResourceList.AdvancedFiber, 1 },
        { ResourceList.Stone, 1 },
    });
    private static ToolInfoStruct SuperiorPickAxeInfo = new ToolInfoStruct(ToolList.SuperiorPickAxe, ToolTypes.Pickaxe, 2, 400, new Dictionary<ResourceList, int>() {
        { ResourceList.PetrifiedWood, 1 },
        { ResourceList.ReinforcedFiber, 1 },
        { ResourceList.Metal, 1 },
    });

    private static ToolInfoStruct SimpleSpearInfo = new ToolInfoStruct(ToolList.SimpleSpear, ToolTypes.Spear, 0, 100, new Dictionary<ResourceList, int>() {
        { ResourceList.Sapling, 1 },
        { ResourceList.SimpleFiber, 1 },
        { ResourceList.Flint, 1 },
    });
    private static ToolInfoStruct AdvancedSpearInfo = new ToolInfoStruct(ToolList.AdvancedSpear, ToolTypes.Spear, 1, 200, new Dictionary<ResourceList, int>() {
        { ResourceList.Hardwood, 1 },
        { ResourceList.AdvancedFiber, 1 },
        { ResourceList.Stone, 1 },
    });
    private static ToolInfoStruct SuperiorSpearInfo = new ToolInfoStruct(ToolList.SuperiorSpear, ToolTypes.Spear, 2, 400, new Dictionary<ResourceList, int>() {
        { ResourceList.PetrifiedWood, 1 },
        { ResourceList.ReinforcedFiber, 1 },
        { ResourceList.Metal, 1 },
    });
    private static ToolInfoStruct SimpleBowInfo = new ToolInfoStruct(ToolList.SimpleSpear, ToolTypes.Spear, 0, 100, new Dictionary<ResourceList, int>() {
        { ResourceList.Sapling, 1 },
        { ResourceList.SimpleFiber, 1 },
        { ResourceList.Flint, 1 },
    });
    private static ToolInfoStruct AdvancedBowInfo = new ToolInfoStruct(ToolList.AdvancedSpear, ToolTypes.Spear, 1, 200, new Dictionary<ResourceList, int>() {
        { ResourceList.Hardwood, 1 },
        { ResourceList.AdvancedFiber, 1 },
        { ResourceList.Stone, 1 },
    });
    private static ToolInfoStruct SuperiorBowInfo = new ToolInfoStruct(ToolList.SuperiorSpear, ToolTypes.Spear, 2, 400, new Dictionary<ResourceList, int>() {
        { ResourceList.PetrifiedWood, 1 },
        { ResourceList.ReinforcedFiber, 1 },
        { ResourceList.Metal, 1 },
    });

    public static Dictionary<ToolList, ToolInfoStruct> ToolInfo = new Dictionary<ToolList, ToolInfoStruct>() {
        { ToolList.Unarmed, UnarmedInfo },
        { ToolList.Rock, RockInfo },
        { ToolList.SimpleAxe, SimpleAxeInfo },
        { ToolList.AdvancedAxe, AdvancedAxeInfo },
        { ToolList.SuperiorAxe, SuperiorAxeInfo },
        { ToolList.SimplePickaxe, SimplePickaxeInfo },
        { ToolList.AdvancedPickaxe, AdvancedPickaxeInfo },
        { ToolList.SuperiorPickAxe, SuperiorPickAxeInfo },
        { ToolList.SimpleSpear, SimpleSpearInfo },
        { ToolList.AdvancedSpear, AdvancedSpearInfo },
        { ToolList.SuperiorSpear, SuperiorSpearInfo },
        { ToolList.SimpleBow, SimpleBowInfo },
        { ToolList.AdvancedBow, AdvancedBowInfo },
        { ToolList.SuperiorBow, SuperiorBowInfo },
        { ToolList.SimpleKnife, SimpleKnifeInfo },
        { ToolList.AdvancedKnife, AdvancedKnifeInfo },
        { ToolList.SuperiorKnife, SuperiorKnifeInfo },
        { ToolList.Torch, TorchInfo },
    };
}

public class InventoryController : MonoBehaviour {

    public static InventoryController instance;
    [SerializeField] Inventory inventory;

    void Start() {
        instance = this;
        inventory = new Inventory();
        inventory.resources = new Dictionary<ResourceList, int> {
            { ResourceList.Sapling, 0 },
            { ResourceList.Hardwood, 0 },
            { ResourceList.PetrifiedWood, 0 },
            { ResourceList.Rock, 0 },
            { ResourceList.Flint, 0 },
            { ResourceList.Stone, 0 },
            { ResourceList.Metal, 0 },
            { ResourceList.SimpleFiber, 0 },
            { ResourceList.AdvancedFiber, 0 },
            { ResourceList.ReinforcedFiber, 0 },
        };

        inventory.tools = new Dictionary<ToolTypes, int> {
            { ToolTypes.Axe, 0 },
            { ToolTypes.Pickaxe, 0 },
            { ToolTypes.Spear, 0 },
            { ToolTypes.Bow, 0 },
            { ToolTypes.Knife, 0 },
            { ToolTypes.Torch, 0 },
            { ToolTypes.Unarmed, 0 },
        };

        string inventoryString = inventory.ToString();
        Debug.Log("inventory: " + inventoryString);
    }

    public void IncrementResource(ResourceList resourceId, int amount = 1) {
        int newValue = 0;
        inventory.resources.TryGetValue(resourceId, out newValue);

        inventory.resources[resourceId] = newValue + amount;
        string inventoryString = inventory.ToString();
        Debug.Log("new inventory: " + inventoryString);
    }

    public void CraftItem(ToolTypes toolId, int amount) {
        int newValue = 0;
        inventory.tools.TryGetValue(toolId, out newValue);

        inventory.tools[toolId] = amount;
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
    public Dictionary<ResourceList, int> resources;

    public Dictionary<ToolTypes, int> tools;

    public override string ToString() {
        string stringifiedInventory = "resources: { ";

        foreach (KeyValuePair<ResourceList, int> kvp in resources) {
            ResourceList resourceId = kvp.Key;
            int count = kvp.Value;
            stringifiedInventory += string.Format("{0}: {1}, ", resourceId, count);
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

public struct ToolInfoStruct {
    public ToolList id;
    public ToolTypes type;
    public Dictionary<ResourceList, int> recipe;
    public int tier;
    public int damage;

    public ToolInfoStruct(ToolList newId, ToolTypes newType, int newTier, int newDamage, Dictionary<ResourceList, int> newRecipe) {
        id = newId;
        type = newType;
        tier = newTier;
        damage = newDamage;
        recipe = newRecipe;
    }

    public string GetRecipeString() {
        string recipeString = "";
        foreach (KeyValuePair<ResourceList, int> kvp in recipe) {
            recipeString += string.Format("{0} x {1}\n", kvp.Key, kvp.Value);
        }
        return recipeString;
    }
}
