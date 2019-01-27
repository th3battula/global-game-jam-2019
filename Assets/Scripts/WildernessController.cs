using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WildernessController : MonoBehaviour {
    [SerializeField] GameObject loadingScreenCamera;
    [SerializeField] TextMeshProUGUI loadingPercentage;

    [SerializeField] float mapSize = 2000;
    [SerializeField] GameObject playerPrefab;

    [SerializeField] int baseRockCount;
    [SerializeField] GameObject baseRock;
    [SerializeField] int flintRockCount;
    [SerializeField] GameObject flintRock;
    [SerializeField] int boulderStoneCount;
    [SerializeField] GameObject boulderStone;
    [SerializeField] int saplingCount;
    [SerializeField] GameObject sapling;

    Vector3 playerSpawnPosition;

    Coroutine worldPopulationCoroutine;
    void Start() {
        GameObject playerSpawnMarker = GameObject.FindGameObjectWithTag("Respawn");
        if (playerSpawnMarker == null) {
            Debug.LogError("No spawn marker found");
        } else {
            playerSpawnPosition = playerSpawnMarker.transform.position;
            worldPopulationCoroutine = StartCoroutine(PopulateWorldWithObjects());
        }
    }

    IEnumerator PopulateWorldWithObjects() {
        Debug.Log("Placing Saplings");
        float percentage = 0;
        for (int i = 0; i < saplingCount; i++) {
            percentage = ((float)i / (float)saplingCount) * 25;
            loadingPercentage.text = string.Format("{0}%", Mathf.FloorToInt(percentage));
            Vector2 randomPos = Random.insideUnitCircle * mapSize;
            GameObject saplingObj = GameObject.Instantiate(sapling, new Vector3(randomPos.x, 0, randomPos.y), Quaternion.identity) as GameObject;
            saplingObj.transform.parent = transform;
            yield return null;
        }
        Debug.Log("Finished placing saplings");
        Debug.Log("Placing Base Rocks");
        for (int i = 0; i < baseRockCount; i++) {
            percentage = 25 + ((float)i / (float)baseRockCount) * 25;
            loadingPercentage.text = string.Format("{0}%", Mathf.FloorToInt(percentage));
            Vector2 randomPos = Random.insideUnitCircle * mapSize;
            GameObject baseRockObj = GameObject.Instantiate(baseRock, new Vector3(randomPos.x, 0, randomPos.y), Quaternion.identity) as GameObject;
            baseRockObj.transform.parent = transform;
            yield return null;
        }
        Debug.Log("Placed Base Rocks");
        Debug.Log("Placing Flint Rocks");
        for (int i = 0; i < flintRockCount; i++) {
            percentage = 50 + ((float)i / (float)flintRockCount) * 25;
            loadingPercentage.text = string.Format("{0}%", Mathf.FloorToInt(percentage));
            Vector2 randomPos = Random.insideUnitCircle * mapSize;
            GameObject flintRockObj = GameObject.Instantiate(flintRock, new Vector3(randomPos.x, 0, randomPos.y), Quaternion.identity) as GameObject;
            flintRockObj.transform.parent = transform;
            yield return null;
        }
        Debug.Log("Finished placing Flint Rocks");
        Debug.Log("Placing Boulder Stone");
        for (int i = 0; i < boulderStoneCount; i++) {
            percentage = 75 + ((float)i / (float)boulderStoneCount) * 25;
            loadingPercentage.text = string.Format("{0}%", Mathf.FloorToInt(percentage));
            Vector2 randomPos = Random.insideUnitCircle * mapSize;
            GameObject boulderStoneObj = GameObject.Instantiate(boulderStone, new Vector3(randomPos.x, 0, randomPos.y), Quaternion.identity) as GameObject;
            boulderStoneObj.transform.parent = transform;
            yield return null;
        }
        Debug.Log("Finished placing Boulder Stone");
        loadingScreenCamera.SetActive(false);
        yield return null;
        Debug.Log("Placing player object");
        GameObject.Instantiate(playerPrefab, playerSpawnPosition, Quaternion.identity);
    }
}
