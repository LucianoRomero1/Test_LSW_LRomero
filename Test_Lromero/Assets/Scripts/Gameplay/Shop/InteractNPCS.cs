using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractNPCS : MonoBehaviour
{

    private bool talkNpc = false;

    public GameObject dialogue;
    public GameObject tradeWindow;

    public float rayLenght;
    public LayerMask layerMask;


    // Update is called once per frame
    void Update()
    {
        if (talkNpc)
        {
            
            if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, layerMask);

                if (hit.collider.gameObject.CompareTag("Shop"))
                {

                    tradeWindow.SetActive(true);
                    dialogue.SetActive(false);
                    GameManager.sharedInstance.PauseGame();
                }
                
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            dialogue.SetActive(true);
            talkNpc = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            dialogue.SetActive(false);
            talkNpc = false;
        }
    }

}
