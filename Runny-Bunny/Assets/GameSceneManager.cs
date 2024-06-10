using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    public GameObject player1CharacterPrefab;
    public GameObject player2CharacterPrefab;
    public Transform player1SpawnPoint;
    public Transform player2SpawnPoint;

    void Start()
    {
        // Retrieve selected characters from PlayerPrefs
        string player1CharacterName = PlayerPrefs.GetString("Player1Character");
        string player2CharacterName = PlayerPrefs.GetString("Player2Character");

        // Spawn characters at specified spawn points
        GameObject player1Character = Instantiate(player1CharacterPrefab, player1SpawnPoint.position, Quaternion.identity);
        GameObject player2Character = Instantiate(player2CharacterPrefab, player2SpawnPoint.position, Quaternion.identity);
    }
}
