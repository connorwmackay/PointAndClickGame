using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PointAndClick : MonoBehaviour
{
    [SerializeField]
    private UIManager uiManager;

    [SerializeField]
    private PlayerInventory playerInventory;

    [SerializeField]
    private GameObject player;

    [SerializeField, Min(0)]
    private float interactionDistance;

    private RaycastHit mouseHit;

    void Awake()
    {
        interactionDistance = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        mouseHit = PerformRaycastFromMouse();

        // Handle clicking
        if (Input.GetMouseButtonUp(0) && !uiManager.GetIsGameInputDisabled())
        {
            GameObject hitGameObject = mouseHit.collider.gameObject;

            // Get player to start moving towards mouseHit.point
            if (mouseHit.collider.CompareTag("Floor"))
            {
                PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
                playerMovement.MoveToPoint(mouseHit.point);
            }
            else if (hitGameObject.GetComponent<InteractableObject>() != null)
            {
                // Handle interaction with the interactable object
                if (Vector3.Distance(mouseHit.point, player.transform.position) < interactionDistance)
                {
                    // TODO: Make the player go to the interactable object when clicked, then perform the action

                    InteractableObject interactableObject = hitGameObject.GetComponent<InteractableObject>();

                    interactableObject.PerformInteractAction();
                }
            }
        }
    }

    RaycastHit PerformRaycastFromMouse()
    {
        Camera mainCamera = Camera.main;

        Ray mouseRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit mouseHit;

        if (Physics.Raycast(mouseRay, out mouseHit))
        {
            return mouseHit;
        }

        return new RaycastHit();
    }

    public RaycastHit getLatestHit()
    {
        return mouseHit;
    }
}
