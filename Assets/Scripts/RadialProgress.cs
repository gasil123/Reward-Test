using UnityEngine;
using UnityEngine.UI;

public class RadialProgress : MonoBehaviour
{
    public float initialCooldownMinutes { set; get; } // Initial cooldown time in minutes
    private float cooldownSeconds; // Current cooldown time in seconds
    private Image image;

    private void Start()
    {
        // Get the Image component once in the Start method to avoid multiple calls
        image = GetComponent<Image>();

        // Set the initial fill amount to 100% (1.0)
        image.fillAmount = 1.0f;

        // Convert initialCooldownMinutes to seconds
        cooldownSeconds = initialCooldownMinutes * 60.0f;
    }

    private void Update()
    {
        // Ensure the cooldownSeconds is positive
        if (cooldownSeconds > 0f)
        {
            // Decrease the cooldownSeconds each frame by deltaTime (time elapsed since the last frame)
            cooldownSeconds -= Time.deltaTime;

            // Calculate the fill amount based on the remaining cooldown time
            float fillAmount = cooldownSeconds / (initialCooldownMinutes * 60.0f);

            // Ensure fillAmount doesn't go below 0
            fillAmount = Mathf.Clamp01(fillAmount);

            // Update the fill amount of the Image component
            image.fillAmount = fillAmount;
        }
    }
}
