using UnityEngine;

public enum ResourceTypes {
    Wood,
    Hardwood,
    PetrifiedWood,
    Rock,
    Flint,
    Stone,
    Metal,
    Fiber,
    AdvancedFiber,
    ReinforcedFiber,
}

public class ResourceController : MonoBehaviour {

    [SerializeField] int durability;

    [SerializeField] GameObject depletedState;
    [SerializeField] ResourceStruct resource;

    public ResourceTypes getResourceType() {
        return this.resource.type;
    }

    public ResourceStruct Interact(int damage) {
        Debug.Log("hit for " + damage + " damage");
        this.durability -= damage;
        if (this.durability <= 0) {
            Debug.Log("is depleted");
            DestroyThis();
            return resource;
        }
        Debug.Log("is not depleted");
        return new ResourceStruct(resource.type, 0);
    }

    public void DestroyThis() {
        DestroyImmediate(this.gameObject);
    }

    public string TestHit() {
        return "Hit the object";
    }
}

[System.Serializable] public struct ResourceStruct {
    public ResourceTypes type;
    public int count;

    public ResourceStruct(ResourceTypes newType, int newCount) {
        type = newType;
        count = newCount;
    }
}