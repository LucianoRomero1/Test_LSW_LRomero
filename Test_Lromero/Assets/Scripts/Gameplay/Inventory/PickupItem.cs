using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public Item itemData;
    public GameObject pickupEffect;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (GameManager.sharedInstance.items.Count < GameManager.sharedInstance.slots.Length)
            {
                Instantiate(pickupEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);


                GameManager.sharedInstance.AddItem(itemData);
            }
            else
            {
                Debug.Log("Cant pick this item, bag is full");
            }
            
        }
    }
}
