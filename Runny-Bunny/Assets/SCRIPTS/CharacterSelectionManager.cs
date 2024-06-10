using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelectionManager : MonoBehaviour
{
    public Button player1ConfirmButton;
    public Button player2ConfirmButton;
    public Button startButton;
    public GameObject player1BunnyCharacterPrefab;
    public GameObject player2BunnyCharacterPrefab;

    private static GameObject selectedPlayer1Character;
    private static GameObject selectedPlayer2Character;

    public void Start()
    {
        
        player1ConfirmButton.onClick.AddListener(Player1Confirm);
        player2ConfirmButton.onClick.AddListener(Player2Confirm);

        
        startButton.onClick.AddListener(StartGame);

        
        startButton.interactable = false;
    }

    public void Player1Confirm()
    {
        selectedPlayer1Character = Instantiate(player1BunnyCharacterPrefab);
        CheckIfBothPlayersConfirmed();
    }

    public void Player2Confirm()
    {
        selectedPlayer2Character = Instantiate(player2BunnyCharacterPrefab);
        CheckIfBothPlayersConfirmed();
    }

    private void CheckIfBothPlayersConfirmed()
    {
    
        if (selectedPlayer1Character != null && selectedPlayer2Character != null)
        {
            startButton.interactable = true;
        }
        else
        {
            startButton.interactable = false;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public static GameObject GetSelectedPlayer1Character()
    {
        return selectedPlayer1Character;
    }

    public static GameObject GetSelectedPlayer2Character()
    {
        return selectedPlayer2Character;
    }
}