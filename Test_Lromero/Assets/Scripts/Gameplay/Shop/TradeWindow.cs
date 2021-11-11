using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeWindow : MonoBehaviour
{

    public GameObject tradeTab;
    public GameObject shopEnabled;

    public void CloseTab()
    {
        
        GameManager.sharedInstance.ResumeGame();
        shopEnabled.GetComponent<BoxCollider2D>().enabled = false;
        tradeTab.SetActive(false);

    }

    public void BuyObjects()
    {
        GameManager.sharedInstance.ResumeGame();
        shopEnabled.GetComponent<BoxCollider2D>().enabled = true;
        tradeTab.SetActive(false);
        
    }

    public void CloseSettings()
    {
        GameManager.sharedInstance.ResumeGame();
        tradeTab.SetActive(false);
        
    }

}
