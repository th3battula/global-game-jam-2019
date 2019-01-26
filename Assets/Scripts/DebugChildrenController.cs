using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DebugChildrenController : MonoBehaviour {
    [SerializeField] bool disableDebugChildren;

    void Update() {
        if (disableDebugChildren) {
            DisableDebugChildren();
            disableDebugChildren = false;
        }
    }

    void DisableDebugChildren() {
        IEnumerable<Transform> debugChildren = transform.GetComponentsInChildren<Transform>().Where(child => child.gameObject.tag == "Debug");
        foreach (Transform child in debugChildren) {
            child.gameObject.SetActive(false);
        }
    }
}
