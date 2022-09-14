using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    protected bool hasPerformedAction;

    [SerializeField]
    protected string baseInteractionText;

    [SerializeField]
    protected string wrongUseableObjectText;

    [SerializeField]
    protected List<UseableObject> useableObjects;

    [SerializeField]
    protected List<string> useableObjectsText;

    [SerializeField]
    protected PlayerInventory playerInventory;

    [SerializeField]
    private ScrollingText scrollingText;

    private Outline outline;

    private string copypastaTest;

    [SerializeField]
    private PointAndClick pointAndClick;

    protected virtual void Start()
    {
        hasPerformedAction = false;

        Mesh mesh = GetComponent<MeshFilter>().sharedMesh;
        mesh.UploadMeshData(false);

        outline = gameObject.AddComponent<Outline>();

        outline.OutlineMode = Outline.Mode.OutlineAll;
        outline.enabled = false;
        outline.OutlineColor = Color.gray;
        outline.OutlineWidth = 5f;
    }

    public void ShowOutline()
    {
        outline.enabled = true;
    }

    public void HideOutline()
    {
        outline.enabled = false;
    }

    protected virtual void Update()
    {
        bool shouldShowOutline = false;
        RaycastHit hit = pointAndClick.getLatestHit();
        
        if (!hit.IsUnityNull())
        {
            if (hit.colliderInstanceID == GetComponent<Collider>().GetInstanceID())
            {
                shouldShowOutline = true;
            }
        }

        if (!shouldShowOutline)
        {
            HideOutline();
        }
        else
        {
            ShowOutline();
        }
    }

    public void PerformInteractAction()
    {
        bool hasSetText = false;

        for (int i=0; i < useableObjects.Count; i++)
        {
            UseableObject uo = useableObjects[i];

            if (playerInventory.GetEquippedItemID() == uo.GetInstanceID())
            {
                scrollingText.ShowScrollingText(useableObjectsText[i]);
                hasPerformedAction = true;
                hasSetText = true;
            }
        }

        if (!hasSetText && playerInventory.GetEquippedItemID() == -1)
        {
            if (baseInteractionText.Length > 0)
            {
                scrollingText.ShowScrollingText(baseInteractionText);
            }

            hasPerformedAction = true;
            hasSetText = true;
        }
        else if (!hasSetText)
        {
            if (wrongUseableObjectText.Length > 0)
            {
                scrollingText.ShowScrollingText(wrongUseableObjectText);
            }

            hasPerformedAction = true;
            hasSetText = true;
        }
    }
}
