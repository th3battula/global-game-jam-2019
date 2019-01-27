using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class CraftingController : MonoBehaviour {

    [SerializeField] GameObject knifeButton, torchButton, axeButton, pickaxeButton, spearButton, bowButton, arrowButton;
    [SerializeField] TextMeshProUGUI knifeButtonRecipeText, torchButtonRecipeText, axeButtonRecipeText, pickaxeButtonRecipeText, spearButtonRecipeText, bowButtonRecipeText, arrowButtonRecipeText;

    void Start() {
        knifeButtonRecipeText.text = ToolInformation.ToolInfo[ToolList.SimpleKnife].GetRecipeString();
        torchButtonRecipeText.text = ToolInformation.ToolInfo[ToolList.Torch].GetRecipeString();
        axeButtonRecipeText.text = ToolInformation.ToolInfo[ToolList.SimpleAxe].GetRecipeString();
        pickaxeButtonRecipeText.text = ToolInformation.ToolInfo[ToolList.SimplePickaxe].GetRecipeString();
        spearButtonRecipeText.text = ToolInformation.ToolInfo[ToolList.SimpleSpear].GetRecipeString();
        bowButtonRecipeText.text = ToolInformation.ToolInfo[ToolList.SimpleBow].GetRecipeString();
        // arrowButtonRecipeText.text = ToolInformation.ToolInfo[ToolList.].GetRecipeString();

        knifeButton.GetComponentInChildren<Button>().onClick.AddListener(() => CraftTool(ToolList.SimpleKnife));
        torchButton.GetComponentInChildren<Button>().onClick.AddListener(() => CraftTool(ToolList.Torch));
        axeButton.GetComponentInChildren<Button>().onClick.AddListener(() => CraftTool(ToolList.SimpleAxe));
        pickaxeButton.GetComponentInChildren<Button>().onClick.AddListener(() => CraftTool(ToolList.SimplePickaxe));
        spearButton.GetComponentInChildren<Button>().onClick.AddListener(() => CraftTool(ToolList.SimpleSpear));
        bowButton.GetComponentInChildren<Button>().onClick.AddListener(() => CraftTool(ToolList.SimpleBow));
    }

    public void CraftTool(ToolList type) {
        ToolInfoStruct info = ToolInformation.ToolInfo[type];
        Dictionary<ResourceList, int> recipe = info.recipe;
        foreach (KeyValuePair<ResourceList, int> kvp in recipe) {
            int value;
            InventoryController.instance.Inventory.resources.TryGetValue(kvp.Key, out value);
            if (value >= kvp.Value) {
                InventoryController.instance.CraftItem(ToolInformation.ToolInfo[type].type, 1);
            } else {
                break;
            }
        }
    }
}