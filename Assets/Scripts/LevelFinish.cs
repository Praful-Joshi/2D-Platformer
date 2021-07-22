using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinish : MonoBehaviour
{
    public static LevelFinish instance;

    public Transform RespawnPoint;
    public GameObject playerPrefab;

    private void Awake() {
        instance = this;
    }

    public void Respawn() {
        Instantiate(playerPrefab, RespawnPoint.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.GetComponent<PlayerController>() != null) {
            Debug.Log("Level Completed");
    }
    }
}
