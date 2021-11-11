using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory.gameObject.SetActive(false);
        GameManager.sharedInstance.openInventory = true;
    }

    // Update is called once per frame
    void Update()
    {
        InventoryControl();    
    }

    private void InventoryControl()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (GameManager.sharedInstance.openInventory)
            {
                ShowInventory();
            }
            else
            {
                HideInventory();
            }
        }
    }

    private void ShowInventory()
    {
        inventory.gameObject.SetActive(true);
        GameManager.sharedInstance.openInventory = false;
    }

    private void HideInventory()
    {
        inventory.gameObject.SetActive(false);
        GameManager.sharedInstance.openInventory = true;
    }


    
}
