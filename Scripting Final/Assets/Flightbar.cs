using UnityEngine;
using UnityEngine.UI;

public class FlightBar : MonoBehaviour
{
    public PlayerStats playerStats; // Reference to the PlayerStats ScriptableObject
    public Image flightBarFill; // Reference to the UI Image for the flight bar

    private void Update()
    {
        UpdateFlightBar();
    }

    private void UpdateFlightBar()
    {
        if (playerStats != null && flightBarFill != null)
        {
            // Calculate the fill amount based on current flight left and max flight
            float fillAmount = (float)playerStats.flightleft / playerStats.maxFlight;
            flightBarFill.fillAmount = Mathf.Clamp01(fillAmount); // Ensure value is between 0 and 1
        }
    }
}