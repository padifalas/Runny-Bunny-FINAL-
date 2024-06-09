using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxStat = 10;
    public int currentHealth;
    public int currentMental;
    public int currentStamina;

    public StatBar healthBar;
    public StatBar mentalBar;
    public StatBar staminaBar;

    void Start()
    {
        currentHealth = maxStat / 2;
        currentMental = maxStat / 2;
        currentStamina = maxStat / 2;

        healthBar.SetMaxStat(maxStat);
        healthBar.SetStat(currentHealth);

        mentalBar.SetMaxStat(maxStat);
        mentalBar.SetStat(currentMental);

        staminaBar.SetMaxStat(maxStat);
        staminaBar.SetStat(currentStamina);
    }

    public void UpdateHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxStat);
        healthBar.SetStat(currentHealth);
    }

    public void UpdateMental(int amount)
    {
        currentMental = Mathf.Clamp(currentMental + amount, 0, maxStat);
        mentalBar.SetStat(currentMental);
    }

    public void UpdateStamina(int amount)
    {
        currentStamina = Mathf.Clamp(currentStamina + amount, 0, maxStat);
        staminaBar.SetStat(currentStamina);
    }
}