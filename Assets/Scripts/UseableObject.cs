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
    [SerializeField]
    private PlayerInventory playerInventory;

    private UnityEngine.UI.Image image;

    private MeshRenderer meshRenderer;

    void Awake()
    {
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if (hasPerformedAction)
        {
            // Hide the game object
            meshRenderer.enabled = false;
        }
    }
}