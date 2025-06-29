using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public Text timerText;          // Text to display current timer
    public Text bestTimeText;       // Text to display best (minimum) time
    private float startTime;
    private bool timerRunning = true;

    private float bestTime = Mathf.Infinity;  // Start with an infinitely large best time
    private string bestTimeString = "";       // String to store the formatted best time

    void Start()
    {
        // Start the timer at the beginning of the game
        //StopTimer();
        timerRunning = false;
    }

    public void TimeStart()
    {
        LoadBestTime();  // Load the best time from previous runs (if available)
        ResetTimer();
    }
    void Update()
    {
        if (timerRunning)
        {
            // Calculate the elapsed time
            float elapsedTime = Time.time - startTime;

            // Convert elapsed time to minutes and seconds
            int minutes = Mathf.FloorToInt(elapsedTime / 60F);
            int seconds = Mathf.FloorToInt(elapsedTime % 60F);

            // Format the time string as MM:SS
            string timeText = string.Format("{0:00}:{1:00}", minutes, seconds);

            // Display the current time in the UI Text component
            timerText.text = timeText;
        }
    }

    // Method to stop the timer and check if it's the best time
    public void StopTimer()
    {
        timerRunning = false;

        // Calculate the elapsed time
        float elapsedTime = Time.time - startTime;

        // Check if the current elapsed time is less than the best time
        if (elapsedTime < bestTime)
        {
            // Update the best time
            bestTime = elapsedTime;

            // Convert best time to minutes and seconds
            int bestMinutes = Mathf.FloorToInt(bestTime / 60F);
            int bestSeconds = Mathf.FloorToInt(bestTime % 60F);

            // Format the best time string as MM:SS
            bestTimeString = string.Format("{0:00}:{1:00}", bestMinutes, bestSeconds);

            // Display the best time in the UI Text component
            bestTimeText.text = "Best Time:  " + bestTimeString;

            // Save the new best time to PlayerPrefs
            SaveBestTime();
        }
    }

    // Method to reset the timer
    public void ResetTimer()
    {
        startTime = Time.time;  // Reset the start time to the current time
        timerRunning = true;    // Optionally, resume the timer after resetting
    }

    // Optional method to resume the timer
    public void ResumeTimer()
    {
        timerRunning = true;
        startTime = Time.time;
    }

    // Method to save the best time using PlayerPrefs
    private void SaveBestTime()
    {
        PlayerPrefs.SetFloat("BestTime", bestTime);
        PlayerPrefs.SetString("BestTimeString", bestTimeString);
        PlayerPrefs.Save();  // Save the data to disk
    }

    // Method to load the best time from PlayerPrefs
    private void LoadBestTime()
    {
        if (PlayerPrefs.HasKey("BestTime"))
        {
            bestTime = PlayerPrefs.GetFloat("BestTime");
            bestTimeString = PlayerPrefs.GetString("BestTimeString");

            // Display the best time in the UI Text component
            bestTimeText.text = "Best Time: " + bestTimeString;
        }
    }

    // Method to get the best time as a string (optional)
    public string GetBestTimeString()
    {
        return bestTimeString;  // Return the formatted best time as a string
    }
}
