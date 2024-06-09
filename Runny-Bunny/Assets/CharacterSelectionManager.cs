using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelectionManager : MonoBehaviour
{
    public GameObject[] bunnyPrefabs; // Assign bunny prefabs in the inspector
    private int selectedAvatarIndexPlayer1 = -1; // No selection initially
    private int selectedAvatarIndexPlayer2 = -1; // No selection initially
    public Button startGameButton; 

    void Start()
    {
        startGameButton.interactable = false; // Disable start button initially
    }

    public void SelectAvatarPlayer1(int index)
    {
        selectedAvatarIndexPlayer1 = index;
        CheckSelections();
    }

    public void SelectAvatarPlayer2(int index)
    {
        selectedAvatarIndexPlayer2 = index;
        CheckSelections();
    }

    private void CheckSelections()
    {
        // Enable the start button only if both players have selected an avatar
        if (selectedAvatarIndexPlayer1 != -1 && selectedAvatarIndexPlayer2 != -1)
        {
            startGameButton.interactable = true;
        }
    }

    public void StartGame()
    {
        if (selectedAvatarIndexPlayer1 != -1 && selectedAvatarIndexPlayer2 != -1)
        {
            PlayerPrefs.SetInt("SelectedAvatarIndexPlayer1", selectedAvatarIndexPlayer1);
            PlayerPrefs.SetInt("SelectedAvatarIndexPlayer2", selectedAvatarIndexPlayer2);
            SceneManager.LoadScene("GameScene");
        }
    }
}