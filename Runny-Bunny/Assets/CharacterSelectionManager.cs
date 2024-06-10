using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public Button player1ConfirmButton;
    public Button player2ConfirmButton;
    public Button startButton;
    public Transform player1SpawnPoint;
    public Transform player2SpawnPoint;
    public GameObject player1BunnyCharacterPrefab;
    public GameObject player2BunnyCharacterPrefab;

    private GameObject player1SelectedCharacter;
    private GameObject player2SelectedCharacter;

    private bool player1Confirmed = false;
    private bool player2Confirmed = false;

    public void Start()
    {
        // Disable the start button initially
        startButton.interactable = false;

        // Add onClick listeners to the confirm buttons
        player1ConfirmButton.onClick.AddListener(Player1Confirm);
        player2ConfirmButton.onClick.AddListener(Player2Confirm);

        // Add onClick listener to the start button
        startButton.onClick.AddListener(StartGame);
    }

    private void Player1Confirm()
    {
        // Instantiate the selected character for player 1 at the spawn point
        player1SelectedCharacter = Instantiate(player1BunnyCharacterPrefab, player1SpawnPoint.position, Quaternion.identity);

        // Set player 1 confirmed flag
        player1Confirmed = true;

        // Check if both players have confirmed
        CheckIfBothPlayersConfirmed();
    }

    private void Player2Confirm()
    {
        // Instantiate the selected character for player 2 at the spawn point
        player2SelectedCharacter = Instantiate(player2BunnyCharacterPrefab, player2SpawnPoint.position, Quaternion.identity);

        // Set player 2 confirmed flag
        player2Confirmed = true;

        // Check if both players have confirmed
        CheckIfBothPlayersConfirmed();
    }

    private void CheckIfBothPlayersConfirmed()
    {
        // Enable start button if both players have confirmed
        if (player1Confirmed && player2Confirmed)
        {
            startButton.interactable = true;
        }
    }

    private void StartGame()
    {
        // Load the game scene
        SceneManager.LoadScene("GameScene");
    }
}
