using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public LayerMask layerMask;
    public bool openInventory;

    public static GameManager sharedInstance;


    public List<Item> items = new List<Item>(); //What kind of items we have
    public List<int> itemNumbers = new List<int>(); //How many items we have
    public GameObject[] slots;

    public GameObject water, food;

    private float timer = 10f;

    //public Dictionary<Item, int> itemDict = new Dictionary<Item, int>();

    private void Awake()
    {
        sharedInstance = this;
    }

    private void Start()
    {
        DisplayItems();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            IncreaseHunger();
            IncreaseThirst();
            SpawnFood();
            SpawnWater();
            timer = 10f;
        }
    }

    private void DisplayItems()
    { 
        for (int i = 0; i < slots.Length; i++)
        {
            if(i < items.Count)
            {
                //Update slots Items Image
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemSprite;

                //Update slots count text
                slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 1);
                slots[i].transform.GetChild(1).GetComponent<Text>().text = itemNumbers[i].ToString();

                //Update close/throw button
                slots[i].transform.GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                //Update slots Items Image
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;

                //Update slots count text
                slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 0);
                slots[i].transform.GetChild(1).GetComponent<Text>().text = null;

                //Update close/throw button
                slots[i].transform.GetChild(2).gameObject.SetActive(false);
            }
        }
    }

    public void AddItem(Item _item)
    {
        if (!items.Contains(_item))
        {
            items.Add(_item);
            itemNumbers.Add(1);
        }
        else
        {
            Debug.Log("Already have this item");
            for (int i = 0; i < items.Count; i++)
            {
                if (_item == items[i])
                {
                    itemNumbers[i]++;
                }
            }
            
        }

        DisplayItems();
    }

    public void RemoveItem(Item _item)
    {
        if (items.Contains(_item))
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (_item == items[i])
                {
                    itemNumbers[i]--;
                    //To do sell object
                    if(itemNumbers[i] == 0)
                    {
                        items.Remove(_item);
                        itemNumbers.Remove(itemNumbers[i]);
                    }
                }
            }
        }
        else
        {
            Debug.Log("THERE ISN'T " + _item + " in my Bags");
        }

        DisplayItems();
    }


    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void IncreaseHunger()
    {
        Player.sharedInstance.currentValueHungry -= 5;
        if(Player.sharedInstance.currentValueHungry < 0)
        {
            Player.sharedInstance.currentValueHungry = 0;
        }
        Player.sharedInstance.hungryBar.SetValue(Player.sharedInstance.currentValueHungry);

    }

    public void IncreaseThirst()
    {
        Player.sharedInstance.currentValueThirsty -= 8;
        if (Player.sharedInstance.currentValueThirsty < 0)
        {
            Player.sharedInstance.currentValueThirsty = 0;
        }
        Player.sharedInstance.thirstyBar.SetValue(Player.sharedInstance.currentValueThirsty);
    }

    public void DecreaseHunger()
    {
        Player.sharedInstance.currentValueHungry += 5;
        if (Player.sharedInstance.currentValueHungry > 100)
        {
            Player.sharedInstance.currentValueHungry = 100;
        }
        Player.sharedInstance.hungryBar.SetValue(Player.sharedInstance.currentValueHungry);

    }

    public void DecreaseThirst()
    {
        Player.sharedInstance.currentValueThirsty += 10;
        if(Player.sharedInstance.currentValueThirsty > 100)
        {
            Player.sharedInstance.currentValueThirsty = 100;
        }
        Player.sharedInstance.thirstyBar.SetValue(Player.sharedInstance.currentValueThirsty);
    }

    public void SpawnFood()
    {
        var position = new Vector3(Random.Range(-25.0f, 25.0f), Random.Range(-25.0f, 25.0f), 0);
        Instantiate(food, position, Quaternion.identity);
    }

    public void SpawnWater()
    {
        var position = new Vector3(Random.Range(-25.0f, 25.0f), Random.Range(-25.0f, 25.0f), 0);
        Instantiate(water, position, Quaternion.identity);
    }
}
