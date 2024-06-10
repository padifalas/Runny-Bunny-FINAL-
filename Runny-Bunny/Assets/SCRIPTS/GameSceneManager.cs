using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    public Transform player1SpawnPoint;
    public Transform player2SpawnPoint;

    void Start()
    {
        GameObject player1CharacterPrefab = CharacterSelectionManager.GetSelectedPlayer1Character();
        GameObject player2CharacterPrefab = CharacterSelectionManager.GetSelectedPlayer2Character();

        if (player1CharacterPrefab != null)
        {
            Instantiate(player1CharacterPrefab, player1SpawnPoint.position, Quaternion.identity);
        }

        if (player2CharacterPrefab != null)
        {
            Instantiate(player2CharacterPrefab, player2SpawnPoint.position, Quaternion.identity);
        }
    }
}
