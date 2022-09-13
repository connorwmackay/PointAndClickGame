using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerInventory : MonoBehaviour
{
    private int imageWidth, imageHeight;

    private bool isShowingInventory;

    [SerializeField]
    private UIManager uiManager;

    [SerializeField]
    private UnityEngine.UI.Image panel;

    [SerializeField]
    private GameObject images;

    [SerializeField]
    private GameObject inventoryUI;

    private List<UseableObject> inventoryItems;
    private List<UnityEngine.UI.Image> inventoryImages;

    private UseableObject equippedItem;

    // Start is called before the first frame update
    void Start()
    {
        inventoryItems = new List<UseableObject>();
        inventoryImages = new List<UnityEngine.UI.Image>();
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

    public void AddItem(UseableObject item)
    {
        inventoryItems.Add(item);
        UnityEngine.UI.Image image = item.image;
        inventoryImages.Add(Instantiate(image, images.transform));
    }

    public void RemoveItem(UseableObject item)
    {
        inventoryItems.Remove(item);
    }
}
