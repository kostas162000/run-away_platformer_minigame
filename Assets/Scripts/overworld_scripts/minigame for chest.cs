using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // For UI elements
using TMPro;

public class LockPickingMinigame : MonoBehaviour
{
    public KeyCode[] keySequence;
    public float timeLimit = 10f;
    public GameObject Chest ; // The chest object
    public GameObject lockPickingUI; // The UI for the minigame
    public GameObject successPanel; // Panel to show success message
    public GameObject failPanel; // Panel to show fail message
    public float timeBetweenKeys = 0.5f; // Time allowed between key presses
    public TextMeshProUGUI sequenceText; // Use TextMeshProUGUI for TextMeshPro
    public TextMeshProUGUI timerText;
  //  public Image sequenceBackground;

    private int currentKeyIndex;
    private float timer;
    private bool isMinigameActive;

    void Start()
    {
        lockPickingUI.SetActive(false); // Hide the UI initially
        successPanel.SetActive(false);
        failPanel.SetActive(false);
    }

    public void StartMinigame()
    {
        isMinigameActive = true;
        lockPickingUI.SetActive(true);
        currentKeyIndex = 0;
        timer = timeLimit;

        // Generate a random key sequence of 5 keys
        keySequence = new KeyCode[5];
        for (int i = 0; i < 5; i++)
        {
            keySequence[i] = (KeyCode)Random.Range((int)KeyCode.A, (int)KeyCode.Z + 1); // Or any range you prefer
        }

        // Display the sequence (Optional - for testing/player hints)
        if (sequenceText != null)
        {
            string sequenceString = "";
            foreach (KeyCode key in keySequence)
            {
                sequenceString += key.ToString() + " ";
            }
            sequenceText.text = sequenceString;
        }


    }

    void Update()
    {
        if (isMinigameActive)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                FailMinigame();
                return;
            }

            if (timerText != null)
            {
                timerText.text = "Time: " + timer.ToString("F1"); // Update timer display
            }

            if (Input.anyKeyDown) // Check for any key press
            {
                foreach (KeyCode key in keySequence)
                {
                    if (Input.GetKeyDown(key))
                    {
                        if (key == keySequence[currentKeyIndex])
                        {
                            currentKeyIndex++;

                            if (currentKeyIndex == keySequence.Length)
                            {
                                SuccessMinigame();
                                return;
                            }
                        }
                        else
                        {
                            FailMinigame();
                            return;
                        }
                    }
                }
            }
        }
    }

    void SuccessMinigame()
    {
        isMinigameActive = false;
        lockPickingUI.SetActive(false);
        successPanel.SetActive(true);
        Debug.Log("Player is in collider");
        // Open the chest
        //  chest.GetComponent<Chest>().Open(); // Assuming you have a "Chest" script with an "Open()" method.
        StartCoroutine(HidePanelAfterDelay(successPanel, 2f)); // Hide the panel after 2 seconds
    }

    void FailMinigame()
    {
        isMinigameActive = false;
        lockPickingUI.SetActive(false);
        failPanel.SetActive(true);
        StartCoroutine(HidePanelAfterDelay(failPanel, 2f)); // Hide the panel after 2 seconds
    }

    private IEnumerator HidePanelAfterDelay(GameObject panel, float delay)
    {
        yield return new WaitForSeconds(delay);
        panel.SetActive(false);
    }
}


