using UnityEngine;

public class PlayerController : MonoBehaviour {
    void Update() {
        if (Input.GetButtonDown("Interact")) {
        	LayerMask resourceMask = LayerMask.GetMask("Resource");
        	LayerMask waterMask = LayerMask.GetMask("Water");
        	RaycastHit hit;
            // Debug.Log("Interact");
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 2, resourceMask)) {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                ResourceController resourceScript = hit.collider.gameObject.GetComponent<ResourceController>();
                ResourceStruct resourceIncome = resourceScript.Interact(100);
                Debug.Log("Received " + resourceIncome.count + " " + resourceIncome.type);
                // Debug.Log("Hit this: " + resourceScript.TestHit());
            }
        }
    }
}