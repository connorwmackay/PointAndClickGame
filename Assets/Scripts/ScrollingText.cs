using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScrollingText : MonoBehaviour
{
    [SerializeField]
    private UIManager uiManager;

    [SerializeField]
    private GameObject equippedItem;

    [SerializeField]
    private UnityEngine.UI.Image panel;

    [SerializeField]
    private TMP_Text tmpText;

    [SerializeField, Min(0.0001f)]
    private float scrollSpeed = 0.2f;

    private string textToDisplay;
    private int startInd;
    private int endInd;
    private bool shouldContinue;

    private bool wasOverflowing;

    void Start()
    {
        textToDisplay = "";
        tmpText.enabled = false;
        panel.enabled = false;

        tmpText.overflowMode = TextOverflowModes.Page;
        tmpText.pageToDisplay = 0;
        shouldContinue = false;
    }

    public void ShowScrollingText(string text)
    {
        uiManager.DisableGameInput();
        tmpText.enabled = true;
        panel.enabled = true;
        textToDisplay = text;
        startInd = 0;
        endInd = 0;
        shouldContinue = true;
        StartCoroutine(HandleScrollingText());
        equippedItem.SetActive(false);
    }

    IEnumerator HandleScrollingText()
    {
        yield return new WaitForSeconds(scrollSpeed);

        if (!tmpText.isTextOverflowing)
        {
            if (endInd < textToDisplay.Length-1)
            {
                endInd++;
                DisplayCurrentText();
                StartCoroutine(HandleScrollingText());
            }
        }
    }

    void DisplayCurrentText()
    {
        string text = "";

        for (int i = startInd; i <= endInd; i++)
        {
            text += textToDisplay[i];
        }

        tmpText.SetText(text);

        uiManager.DisableGameInput();
    }

    void Update()
    {
        if ((Input.GetKeyUp(KeyCode.Return) || Input.GetMouseButtonUp(0)) && textToDisplay != "")
        {
            if (endInd >= textToDisplay.Length - 1)
            {
                textToDisplay = "";
                startInd = 0;
                endInd = 0;
                panel.enabled = false;
                tmpText.enabled = false;
                shouldContinue = false;
                uiManager.EnableGameInput();
                equippedItem.SetActive(true);
            }
            else if (tmpText.isTextOverflowing)
            {
                bool spaceFound = false;
                while (!spaceFound && endInd > 0)
                {
                    if (textToDisplay[endInd] == ' ')
                    {
                        spaceFound = true;
                    }
                    else
                    {
                        endInd--;
                    }
                }

                startInd = endInd;
                endInd = startInd + 1;
                DisplayCurrentText();
                StartCoroutine(HandleScrollingText());
            }
        }
    }
}
