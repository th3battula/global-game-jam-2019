using UnityEngine;
using System.Timers;

public class PlayerController : MonoBehaviour {

    [SerializeField] GameController gameController;
    [SerializeField] Animator eyeAnimator;
    [SerializeField] float teleportTimerLength = 2000; // in ms
    Timer timer;

    bool didTeleport;

    void Start() {
        timer = new Timer(teleportTimerLength);
        timer.AutoReset = false;
        timer.Elapsed += OnTeleportTimerElapsed;
    }

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

        if (Input.GetButtonDown("Teleport")) {
            eyeAnimator.SetBool("IsEyeClosing", true);
            timer.Start();
        }

        if (Input.GetButtonUp("Teleport") && !didTeleport) {
            eyeAnimator.SetBool("IsEyeClosing", false);
            timer.Stop();
        }
    }

    void OnTeleportTimerElapsed(System.Object source, ElapsedEventArgs e) {
        didTeleport = true;
        gameController.GoHome();
        timer.Stop();
    }
}