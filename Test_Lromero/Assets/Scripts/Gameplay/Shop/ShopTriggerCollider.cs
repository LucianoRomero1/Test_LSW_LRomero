using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTriggerCollider : MonoBehaviour
{

    [SerializeField] private UI_Shop uiShop;

    private string nameShop;

    private void Start()
    {
        nameShop = this.gameObject.name;
    }
    //Here the player collission with the shops and open tabs
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        IShopCustomer shopCustomer = collision.GetComponent<IShopCustomer>();
        if(shopCustomer != null)
        {
            uiShop.ShowShop(shopCustomer, nameShop);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IShopCustomer shopCustomer = collision.GetComponent<IShopCustomer>();
        
        if (shopCustomer != null)
        {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            uiShop.HideShop();


        }
    }
}
