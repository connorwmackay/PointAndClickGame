using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/*
 * A UseableObject is an object that the player can put into
 * their inventory, and then use. Typically the object would
 * be used on another InteractableObject.
 */
public class UseableObject : InteractableObject
{
    public UnityEngine.UI.Image image;

    private MeshRenderer meshRenderer;

    protected override void Start()
    {
        base.Start();
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
    }

    protected override void Update()
    {
        base.Update();

        if (hasPerformedAction)
        {
            // Hide the game object
            if (meshRenderer.enabled == true)
            {
                playerInventory.AddItem(this);
            }

            meshRenderer.enabled = false;
        }
    }
}
