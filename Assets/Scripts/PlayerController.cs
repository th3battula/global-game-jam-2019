using UnityEngine;
using System.Timers;

public class PlayerController : MonoBehaviour {
    [SerializeField] Animator eyeAnimator;
    [SerializeField] float teleportTimerLength = 2000; // in ms
    [SerializeField] ToolList equippedToolId;
    ToolInfoStruct equippedTool;
    Timer timer;

    bool didTeleport;

    void Start() {
    	equippedTool = ToolInformation.ToolInfo[equippedToolId];
        timer = new Timer(teleportTimerLength);
        timer.AutoReset = false;
        timer.Elapsed += OnTeleportTimerElapsed;
    }

    void Update() {
    	if(Input.GetKeyDown(KeyCode.Alpha1)) {
    		ChangeEquippedTool(ToolList.Unarmed);
    	};
    	if(Input.GetKeyDown(KeyCode.Alpha2)) {
    		ChangeEquippedTool(ToolList.Rock);
    	};
    	if(Input.GetKeyDown(KeyCode.Alpha3)) {
    		ChangeEquippedTool(ToolList.SimpleKnife);
    	};
    	if(Input.GetKeyDown(KeyCode.Alpha4)) {
    		ChangeEquippedTool(ToolList.SimpleAxe);
    	};
    	if(Input.GetKeyDown(KeyCode.Alpha5)) {
    		ChangeEquippedTool(ToolList.SimplePickaxe);
    	};
    	if(Input.GetKeyDown(KeyCode.Alpha6)) {
    		ChangeEquippedTool(ToolList.SimpleSpear);
    	};
    	if(Input.GetKeyDown(KeyCode.Alpha7)) {
    		ChangeEquippedTool(ToolList.Torch);
    	};

        if (Input.GetButtonDown("Interact")) {
            Debug.Log("Interact");
        	LayerMask resourceMask = LayerMask.GetMask("Resource");
        	LayerMask waterMask = LayerMask.GetMask("Water");
        	RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward), out hit, 3, resourceMask)) {
                ResourceController resourceScript = hit.collider.gameObject.GetComponent<ResourceController>();
                ResourceStruct resourceIncome = resourceScript.Interact(equippedTool);
                Debug.Log("Received " + resourceIncome.count + " " + resourceIncome.type);
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
        GameController.instance.GoHome();
        timer.Stop();
    }

    void ChangeEquippedTool(ToolList id) {
    	equippedToolId = id;
    	equippedTool = ToolInformation.ToolInfo[id];
    }
}