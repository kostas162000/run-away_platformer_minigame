
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class LockPickingMinigame : MonoBehaviour
{

    [SerializeField] private playerTestMovement playerMovement; //used for disabling player movement //καινουριο
    [SerializeField] private playerInventory player; //καινουριο

    public KeyCode[] keySequence;
    public float timeLimit = 10f;
    public GameObject Chest; // The chest object
    public GameObject lockPickingUI; // The UI for the minigame
    public GameObject successPanel; // Panel to show success message
    public GameObject failPanel; // Panel to show fail message
    public float timeBetweenKeys = 0.5f; // Time allowed between key presses
    public Transform sequenceTextParent; // Correct: Transform for the parent
    public TextMeshProUGUI timerText;

    private int currentKeyIndex;
    private float timer;
    private bool isMinigameActive;
    private List<KeyCode> allowedKeys = new List<KeyCode>();
    private List<TextMeshProUGUI> sequenceTextComponents = new List<TextMeshProUGUI>();

    public static bool pickLockSuccessfull = false; //used to see if minigame was succesful //καινουριο

    void Start()
    {
        lockPickingUI.SetActive(false);
        successPanel.SetActive(false);
        failPanel.SetActive(false);

        for (int i = (int)KeyCode.A; i <= (int)KeyCode.Z; i++)
        {
            KeyCode key = (KeyCode)i;
            /*if (key != KeyCode.A && key != KeyCode.S && key != KeyCode.D && key != KeyCode.W && key != KeyCode.F && key != KeyCode.E)
            {
                allowedKeys.Add(key);
            }*/
        }

        if (sequenceTextParent != null)
        {
            foreach (Transform child in sequenceTextParent)
            {
                TextMeshProUGUI textComponent = child.GetComponent<TextMeshProUGUI>();
                if (textComponent != null)
                {
                    sequenceTextComponents.Add(textComponent);
                }
            }
        }
        else
        {
            Debug.LogError("sequenceTextParent not assigned in the Inspector!");
        }
    }

    public void StartMinigame()
    {
        playerMovement.enabled = false; //καινουριο

        isMinigameActive = true;
        lockPickingUI.SetActive(true);
        currentKeyIndex = 0;
        timer = timeLimit;

        keySequence = new KeyCode[5];
        for (int i = 0; i < 5; i++)
        {
            int randomIndex = Random.Range(0, allowedKeys.Count);
            keySequence[i] = allowedKeys[randomIndex];
        }


        for (int i = 0; i < sequenceTextComponents.Count; i++)
        {
            sequenceTextComponents[i].color = Color.white;
        }

        // Display the sequence (Optional - for testing/player hints)
        string sequenceString = "";
        foreach (KeyCode key in keySequence)
        {
            sequenceString += key.ToString() + " ";
        }
        Debug.Log(sequenceString);
        // Update the individual TextMeshPro components:
        for (int i = 0; i < sequenceTextComponents.Count; i++)
        {
            if (i < keySequence.Length) // Make sure we don't go out of bounds
            {
                sequenceTextComponents[i].text = keySequence[i].ToString();
            }
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
                timerText.text = "Time: " + timer.ToString("F1");
            }

            if (Input.anyKeyDown)
            {
                foreach (KeyCode key in keySequence)
                {
                    if (Input.GetKeyDown(key))
                    {
                        if (key == keySequence[currentKeyIndex])
                        {
                            if (currentKeyIndex < sequenceTextComponents.Count)
                            {
                                sequenceTextComponents[currentKeyIndex].color = Color.green;
                            }

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
        pickLockSuccessfull = true; //καινουριο
        lockPickingUI.SetActive(false);
        //successPanel.SetActive(true);
        Debug.Log("Player is in collider");
        // Open the chest
        // chest.GetComponent<Chest>().Open(); // Assuming you have a "Chest" script with an "Open()" method.
        StartCoroutine(HidePanelAfterDelay(successPanel, 2f));
    }

    void FailMinigame()
    {
        isMinigameActive = false;
        lockPickingUI.SetActive(false);
        failPanel.SetActive(true);

        //remove one lockpick after failed attempt //καινουριο
        for (int i = 0; i < player.inventory.slots.Count; i++)
        {
            Inventory.Slot slot = player.inventory.slots[i];
            if (slot.type == collectableType.LOCKPICK)
            {
                slot.removeItem();
            }
        }
        //StartCoroutine(HidePanelAfterDelay(failPanel, 2f));
    }

    private IEnumerator HidePanelAfterDelay(GameObject panel, float delay)
    {
        yield return new WaitForSeconds(delay);
        panel.SetActive(false);
    }
}