using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    protected bool hasPerformedAction;

    [SerializeField]
    private ScrollingText scrollingText;

    [SerializeField]
    protected List<UseableObject> useableObjects;

    [SerializeField]
    protected PlayerInventory playerInventory;

    private string copypastaTest;

    void Start()
    {
        hasPerformedAction = false;
        copypastaTest =
            "\"Who’s joe?\" a distant voice asks. Instantly everyone nearby hears the sound of 1,000s of bricks rapidly shuffling towards his location. The earth itself seemed to cry out in agony, until finally the ground itself split open and a horrific creature crawled from the ground, covered in mucus and tar. \"Joe Momma…\" the creature whispered. The man cried out in pain as he disintegrated into dust, and the whole world fell silent in fear. \"I did a little trolling.\" the wretched creature remarked before burrowing back into the earth.";
    }

    public void PerformInteractAction()
    {
        Debug.Log("Performing interact action");

        bool hasSetText = false;

        foreach (UseableObject uo in useableObjects)
        {
            if (playerInventory.GetEquippedItemID() == uo.GetInstanceID())
            {
                scrollingText.ShowScrollingText(
                    "You used " + playerInventory.GetEquippedItemID() + " on " + name);
                hasPerformedAction = true;
                hasSetText = true;
            }
        }

        if (!hasSetText && playerInventory.GetEquippedItemID() == -1)
        {
            scrollingText.ShowScrollingText("Interacting with " + name + ".");
            hasPerformedAction = true;
            hasSetText = true;
        }
        else if (!hasSetText)
        {
            scrollingText.ShowScrollingText("I can't use " + playerInventory.GetEquippedItemID() + " with " + name + ".");
            hasPerformedAction = true;
            hasSetText = true;
        }
    }
}
