using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerInventory : MonoBehaviour
{
    private bool isShowingInventory;

    [SerializeField]
    private UIManager uiManager;

    [SerializeField]
    private UnityEngine.UI.Image panel;

    [SerializeField]
    private GameObject inventoryUI;

    private List<UseableObject> inventoryItems;

    private UseableObject equippedItem;

    // Start is called before the first frame update
    void Start()
    {
        inventoryItems = new List<UseableObject>();
        equippedItem = null;
        isShowingInventory = false;
        inventoryUI.SetActive(isShowingInventory);
    }

    public void SetEquippedItem(UseableObject item)
    {
        equippedItem = item;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isShowingInventory = !isShowingInventory;

            if (isShowingInventory)
            {
                inventoryUI.SetActive(true);
                uiManager.DisableGameInput();
            }
            else
            {
                inventoryUI.SetActive(false);
                uiManager.EnableGameInput();
            }
        }
    }

    // Update the items that have been rendered as UI
    void UpdateRenderedItems()
    {
        foreach (UseableObject item in inventoryItems)
        {
            
        }
    }

    public void AddItem(UseableObject item)
    {
        inventoryItems.Add(item);
    }

    public void RemoveItem(UseableObject item)
    {
        inventoryItems.Remove(item);
    }
}
