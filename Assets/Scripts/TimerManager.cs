using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI text;
    public float timeInMinutes { set; get; } // Use a variable for time in minutes

    private void Update()
    {
        timeInMinutes = Mathf.Clamp(timeInMinutes, 0f , timeInMinutes);
        if (timeInMinutes > 0)
        {
            int hours = Mathf.FloorToInt(timeInMinutes / 60); // Get the whole hours
            int minutes = Mathf.FloorToInt(timeInMinutes % 60); // Get the remaining minutes
            int seconds = Mathf.FloorToInt((timeInMinutes * 60) % 60); // Get the remaining seconds

            // Display the time as hours, minutes, and seconds
            text.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);

            // Decrease timeInMinutes
            timeInMinutes -= Time.deltaTime / 60.0f; // Convert deltaTime to minutes
        }
    }
}
