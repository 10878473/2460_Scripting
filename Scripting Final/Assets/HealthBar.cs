using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] public PlayerStats playerStats; // Reference to the PlayerStats ScriptableObject
    [SerializeField] public Image healthBarFill; // Reference to the UI Image for the health bar

    private void Update()
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        if (playerStats != null && healthBarFill != null)
        {
            // Calculate the fill amount based on current HP and max HP
            float fillAmount = (float)playerStats.GetHP() / playerStats.maxhp;
            healthBarFill.fillAmount = Mathf.Clamp01(fillAmount); // Ensure value is between 0 and 1
        }
    }
}
