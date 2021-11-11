using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemButton : MonoBehaviour
{
    public int buttonID;
    private Item thisItem;

    private Item GetThisItem()
    {
        for(int i = 0; i < GameManager.sharedInstance.items.Count; i++)
        {
            if(buttonID == i)
            {
                thisItem = GameManager.sharedInstance.items[i];
            }
        }

        return thisItem;
    }

    public void CloseButton()
    {
        GameManager.sharedInstance.RemoveItem(GetThisItem());
    }

}
