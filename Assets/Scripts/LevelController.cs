using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LevelController : MonoBehaviour
{
    public static LevelController instance;
    public Transform RespawnPoint;
    public GameObject playerPrefab;
    public CinemachineVirtualCamera myCinemachine;

    private void Awake() {
        instance = this;
    }

    public void Respawn() {
        var newPlayer = Instantiate(playerPrefab, RespawnPoint.position, Quaternion.identity);
        myCinemachine.m_Follow = newPlayer.transform;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.GetComponent<PlayerController>() != null) {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            if(playerController.hasKey == true) {
                Debug.Log("Level 1 finished");
            }
            else {
                Debug.Log("Find the key to move to the next level!");
            }
            
    }
    }
}
