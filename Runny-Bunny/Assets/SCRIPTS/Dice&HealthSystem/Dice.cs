using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour
{
    private Sprite[] diceSides;
    private SpriteRenderer rend;
    private DiceSystemGameManager gameManager;
    public int playerNumber;
    public int diceNumber;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        gameManager = FindObjectOfType<DiceSystemGameManager>();
    }

    private void OnMouseDown()
    {
        StartCoroutine(RollTheDice());
    }

    private IEnumerator RollTheDice()
    {
        int randomDiceSide = 0;
        int finalSide = 0;

        for (int i = 0; i <= 15; i++)
        {
            randomDiceSide = Random.Range(0, 6);
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.1f);
        }

        finalSide = randomDiceSide + 1;
        gameManager.DiceRolled(playerNumber, diceNumber, finalSide);
        Debug.Log(finalSide);
    }
}