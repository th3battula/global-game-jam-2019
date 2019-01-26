using UnityEngine;

public class PlayerController : MonoBehaviour {
    void Update() {
        if (Input.GetButtonDown("Interact")) {
            Debug.Log("Interact");
        }
    }
}