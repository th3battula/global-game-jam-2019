using UnityEngine;

public class DistanceTester : MonoBehaviour {
    [SerializeField] float distanceToCheck;

    bool isTiming;

    float timer;

    void Start() {
        StartTimer();
    }

    void Update() {
        if (isTiming) {
            timer += Time.deltaTime;
        }

        if (new Vector2(transform.position.x, transform.position.z).magnitude > distanceToCheck) {
            Debug.Log("Distance Reached in " + timer + " seconds");
            StopTimer();
        }
    }

    void StartTimer() {
        isTiming = true;
    }

    void StopTimer() {
        isTiming = false;
    }
}