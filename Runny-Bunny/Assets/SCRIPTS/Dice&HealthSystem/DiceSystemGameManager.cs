using System.Collections;
using UnityEngine;

public class DiceSystemGameManager : MonoBehaviour
{
    private int currentLevel = 0;
    private readonly int[] diceCountPerLevel = { 3, 1, 1, 3, 2, 1, 1, 1, 0 };
    private int[] player1DiceValues;
    private int[] player2DiceValues;
    private int player1DiceClicked = 0;
    private int player2DiceClicked = 0;

    public Player player1;
    public Player player2;

    private void Start()
    {
        StartLevel();
    }

    private void StartLevel()
    {
        int diceCount = diceCountPerLevel[currentLevel];
        player1DiceClicked = 0;
        player2DiceClicked = 0;
        player1DiceValues = new int[diceCount];
        player2DiceValues = new int[diceCount];

        for (int i = 1; i <= 3; i++)
        {
            GameObject player1Dice = GameObject.Find("Player1Dice/Dice1." + i);
            GameObject player2Dice = GameObject.Find("Player2Dice/Dice2." + i);

            if (player1Dice != null)
            {
                player1Dice.SetActive(i <= diceCount);
            }

            if (player2Dice != null)
            {
                player2Dice.SetActive(i <= diceCount);
            }
        }
    }

    public void DiceRolled(int playerNumber, int diceNumber, int diceValue)
    {
        if (playerNumber == 1)
        {
            player1DiceValues[diceNumber - 1] = diceValue;
            player1DiceClicked++;
        }
        else if (playerNumber == 2)
        {
            player2DiceValues[diceNumber - 1] = diceValue;
            player2DiceClicked++;
        }

        if (player1DiceClicked == diceCountPerLevel[currentLevel] && player2DiceClicked == diceCountPerLevel[currentLevel])
        {
            EvaluateLevel();
            currentLevel++;
            if (currentLevel < diceCountPerLevel.Length)
            {
                StartLevel();
            }
            else
            {
                Debug.Log("Game Over. Determine Winner.");
                DetermineWinner();
            }
        }
    }

    private void EvaluateLevel()
    {
        int player1Sum = 0;
        int player2Sum = 0;

        foreach (int value in player1DiceValues)
        {
            player1Sum += value;
        }

        foreach (int value in player2DiceValues)
        {
            player2Sum += value;
        }

        Debug.Log($"Player 1 rolled: {string.Join(", ", player1DiceValues)} (Sum: {player1Sum})");
        Debug.Log($"Player 2 rolled: {string.Join(", ", player2DiceValues)} (Sum: {player2Sum})");

        switch (currentLevel)
        {
            case 0:
                Level1Conditions(player1Sum, player2Sum);
                break;
            case 1:
                Level2Conditions(player1DiceValues[0], player2DiceValues[0]);
                break;
            case 2:
                Level3Conditions(player1DiceValues[0], player2DiceValues[0]);
                break;
            case 3:
                Level4Conditions(player1Sum, player2Sum);
                break;
            case 4:
                Level5Conditions(player1Sum, player2Sum);
                break;
            case 5:
                Level6Conditions(player1DiceValues[0], player2DiceValues[0]);
                break;
            case 6:
                Level7Conditions(player1DiceValues[0], player2DiceValues[0]);
                break;
            case 7:
                Level8Conditions(player1DiceValues[0], player2DiceValues[0]);
                break;
            case 8:
                DetermineWinner();
                break;
            default:
                Debug.LogError("Invalid level");
                break;
        }
    }

    private void Level1Conditions(int player1Sum, int player2Sum)
    {
        UpdatePlayerStats(player1, player1Sum > 10 ? 1 : -1);
        UpdatePlayerStats(player2, player2Sum > 10 ? 1 : -1);
    }

    private void Level2Conditions(int player1Dice, int player2Dice)
    {
        UpdateJumpHeight(player1, player1Dice >= 4 ? 1.5f : 0.5f);
        UpdateJumpHeight(player2, player2Dice >= 4 ? 1.5f : 0.5f);
    }

    private void Level3Conditions(int player1Dice, int player2Dice)
    {
        UpdateBlackjackThorns(player1, player1Dice == 1 || player1Dice == 6 ? 3 : -1);
        UpdateBlackjackThorns(player2, player2Dice == 1 || player2Dice == 6 ? 3 : -1);
    }

    private void Level4Conditions(int player1Sum, int player2Sum)
    {
        UpdateEagleStats(player1, player1Sum > 12);
        UpdateEagleStats(player2, player2Sum > 12);
    }

    private void Level5Conditions(int player1Sum, int player2Sum)
    {
        UpdateMushroomWall(player1, player1Sum > 6);
        UpdateMushroomWall(player2, player2Sum > 6);
    }

    private void Level6Conditions(int player1Dice, int player2Dice)
    {
        UpdateTomatoes(player1, player1Dice > 4);
        UpdateTomatoes(player2, player2Dice > 4);
    }

    private void Level7Conditions(int player1Dice, int player2Dice)
    {
        UpdateStats(player1, player1Dice > 3 ? -2 : 1);
        UpdateStats(player2, player2Dice > 3 ? -2 : 1);
    }

    private void Level8Conditions(int player1Dice, int player2Dice)
    {
        UpdateGnomes(player1, player1Dice % 2 == 0);
        UpdateGnomes(player2, player2Dice % 2 == 0);
    }

    private void UpdatePlayerStats(Player player, int amount)
    {
        player.UpdateHealth(amount);
        player.UpdateMental(amount);
        player.UpdateStamina(amount);
    }

    private void UpdateJumpHeight(Player player, float multiplier)
    {
        Debug.Log($"{player.name}'s jump height is now {multiplier}x the original height for the entire level.");
    }

    private void UpdateBlackjackThorns(Player player, int duration)
    {
        if (duration > 0)
        {
            Debug.Log($"{player.name} is immune to blackjack thorns for {duration} seconds.");
        }
        else
        {
            Debug.Log($"{player.name} faces increased thorns damage by 0.75x.");
        }
    }

    private void UpdateEagleStats(Player player, bool isImmune)
    {
        if (isImmune)
        {
            Debug.Log($"{player.name} is immune to eagles for 10 seconds.");
        }
        else
        {
            Debug.Log($"{player.name} faces eagles that are 0.5x faster.");
        }
    }

    private void UpdateMushroomWall(Player player, bool revealAll)
    {
        if (revealAll)
        {
            Debug.Log($"{player.name} reveals all poisonous mushrooms.");
        }
        else
        {
            Debug.Log($"{player.name} reveals half of the poisonous mushrooms.");
        }
    }

    private void UpdateTomatoes(Player player, bool disappear)
    {
        if (disappear)
        {
            Debug.Log($"{player.name} sees 25% of tomatoes disappear.");
        }
        else
        {
            Debug.Log($"{player.name}'s speed decreases by 25%.");
        }
    }

    private void UpdateStats(Player player, int amount)
    {
        if (amount > 0)
        {
            player.UpdateHealth(amount);
        }
        else
        {
            player.UpdateHealth(amount);
            player.UpdateMental(amount);
            player.UpdateStamina(amount);
        }
    }

    private void UpdateGnomes(Player player, bool disappear)
    {
        if (disappear)
        {
            Debug.Log($"{player.name} makes 50% of gnomes disappear.");
        }
        else
        {
            Debug.Log($"{player.name} faces gnomes that deal 25% more damage.");
        }
    }

    private void DetermineWinner()
    {
        Debug.Log("Game Over. Determine Winner.");
        // Implement your winner determination logic here
    }
}
