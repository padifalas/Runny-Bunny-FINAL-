using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelectionManager : MonoBehaviour
{
    public GameObject[] bunnyPrefabs; 
    public Image displayImagePlayer1; 
    public Image displayImagePlayer2; 
    public Button confirmButtonPlayer1;
    public Button confirmButtonPlayer2; 
    public Button startGameButton; 
    public Button backButtonPlayer1;
    public Button nextButtonPlayer1; 
    public Button backButtonPlayer2; 
    public Button nextButtonPlayer2; 

    private int currentAvatarIndexPlayer1 = 0;
    private int currentAvatarIndexPlayer2 = 0;
    private bool player1Confirmed = false;
    private bool player2Confirmed = false;

    void Start()
    {
        startGameButton.interactable = false; 
        confirmButtonPlayer1.interactable = false;
        confirmButtonPlayer2.interactable = false;
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        displayImagePlayer1.sprite = bunnyPrefabs[currentAvatarIndexPlayer1].GetComponent<SpriteRenderer>().sprite;
        displayImagePlayer2.sprite = bunnyPrefabs[currentAvatarIndexPlayer2].GetComponent<SpriteRenderer>().sprite;
    }

    public void NextAvatarPlayer1()
    {
        currentAvatarIndexPlayer1 = (currentAvatarIndexPlayer1 + 1) % bunnyPrefabs.Length;
        UpdateDisplay();
        confirmButtonPlayer1.interactable = true;
    }

    public void PreviousAvatarPlayer1()
    {
        currentAvatarIndexPlayer1 = (currentAvatarIndexPlayer1 - 1 + bunnyPrefabs.Length) % bunnyPrefabs.Length;
        UpdateDisplay();
        confirmButtonPlayer1.interactable = true;
    }

    public void NextAvatarPlayer2()
    {
        currentAvatarIndexPlayer2 = (currentAvatarIndexPlayer2 + 1) % bunnyPrefabs.Length;
        UpdateDisplay();
        confirmButtonPlayer2.interactable = true;
    }

    public void PreviousAvatarPlayer2()
    {
        currentAvatarIndexPlayer2 = (currentAvatarIndexPlayer2 - 1 + bunnyPrefabs.Length) % bunnyPrefabs.Length;
        UpdateDisplay();
        confirmButtonPlayer2.interactable = true;
    }

    public void ConfirmSelectionPlayer1()
    {
        player1Confirmed = true;
        CheckSelections();
    }

    public void ConfirmSelectionPlayer2()
    {
        player2Confirmed = true;
        CheckSelections();
    }

    private void CheckSelections()
    {
        // Enable the start button only if both players have confirmed their selection
        if (player1Confirmed && player2Confirmed)
        {
            startGameButton.interactable = true;
        }
    }

    public void StartGame()
    {
        if (player1Confirmed && player2Confirmed)
        {
            PlayerPrefs.SetInt("SelectedAvatarIndexPlayer1", currentAvatarIndexPlayer1);
            PlayerPrefs.SetInt("SelectedAvatarIndexPlayer2", currentAvatarIndexPlayer2);
            SceneManager.LoadScene("GameScene");
        }
    }
}
