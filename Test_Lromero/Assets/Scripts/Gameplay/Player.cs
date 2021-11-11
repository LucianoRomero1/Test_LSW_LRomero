using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Player : MonoBehaviour, IShopCustomer
{

    public static Player sharedInstance;

    public Rigidbody2D rigidBody;

    public Item[] itemData;
    public Animator animator;

    public GameObject panelSettings;
    public GameObject deadSettings;

    private Vector2 movement;

    public HudBars hungryBar;
    public HudBars thirstyBar;


    public Text goldAmountText;

    [SerializeField] private float moveSpeed = 5f;

    private int goldAmount = 900;

    public int maxValueBars = 100;

    public int currentValueHungry;
    public int currentValueThirsty;


    private void Awake()
    {
        sharedInstance = this;

    }

    private void Start()
    {
        GameManager.sharedInstance.ResumeGame();

        goldAmountText.text = goldAmount.ToString();

        currentValueHungry = maxValueBars;
        currentValueThirsty = maxValueBars;

        hungryBar.SetMaxValueBars(maxValueBars);
        thirstyBar.SetMaxValueBars(maxValueBars);
    }

    void Update()
    {
        CheckBars();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panelSettings.SetActive(true);
            GameManager.sharedInstance.PauseGame();
        } 

        //Inputs inside update
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        goldAmountText.text = goldAmount.ToString();

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Water")
        {
            GameManager.sharedInstance.DecreaseThirst();
        }

        if (collision.tag == "Food")
        {
            GameManager.sharedInstance.DecreaseHunger();
        }
    }

    private void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + movement * moveSpeed * Time.fixedDeltaTime);
    }


    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public int GetGoldAmount()
    {
        return goldAmount;
    }

    public void CollectObjects()
    {
        goldAmount += 200;

    }

    public void CheckBars()
    {
        if(currentValueThirsty <= 0 && currentValueHungry <= 0)
        {
            GameManager.sharedInstance.PauseGame();
            deadSettings.SetActive(true);
        }
    }

    //Here buy the item
    public void BoughtItem(Items.ItemType itemType)
    {

        switch (itemType)
        {
            default:
            //Here put the price of the enum
            case Items.ItemType.Food:
                GameManager.sharedInstance.AddItem(itemData[0]);
                break;
            case Items.ItemType.Water:
                GameManager.sharedInstance.AddItem(itemData[1]);
                break;
            case Items.ItemType.WoodAxe:
                GameManager.sharedInstance.AddItem(itemData[2]);
                break;
            case Items.ItemType.StoneAxe:
                GameManager.sharedInstance.AddItem(itemData[3]);
                break;
            case Items.ItemType.BronzePick:
                GameManager.sharedInstance.AddItem(itemData[4]);
                break;
            case Items.ItemType.MetalPick:
                GameManager.sharedInstance.AddItem(itemData[5]);
                break;
            case Items.ItemType.BasicArrow:
                GameManager.sharedInstance.AddItem(itemData[6]);
                break;
            case Items.ItemType.MediumArrow:
                GameManager.sharedInstance.AddItem(itemData[7]);
                break;

        }
        //Debug.Log("Bought item: " + itemType);
    }

    public void SellItems() { 

    }


    //Here discount total gold
    public bool TrySpendGoldAmount(int spendGoldAmount)
    {
        if (GetGoldAmount() >= spendGoldAmount)
        {
            goldAmount -= spendGoldAmount;
            return true;
        }
        else
        {
            Debug.Log("No tenes mas plata mijo");
            return false;
        }
    }

}
