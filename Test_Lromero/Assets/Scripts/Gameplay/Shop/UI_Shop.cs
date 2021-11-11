using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class UI_Shop : MonoBehaviour
{

    private Transform container;
    private Transform shopItemTemplate;
    private IShopCustomer shopCustomer;

    private static int shop1, shop2, shop3, shop4;


    private void Awake()
    {
        container = transform.Find("Container");
        shopItemTemplate = container.Find("ShopItemTemplate");
        shopItemTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        shop1 = 0; shop2 = 0; shop3 = 0; shop4 = 0;
        //Estos crearlos dependiendo con quien yo colisione, hacerlo en el otro script
        //CreateItemButton(Items.ItemType.HealthPotion,   Items.GetSprite(Items.ItemType.HealthPotion), "Health Potion", Items.GetCost(Items.ItemType.HealthPotion), 0);
        //CreateItemButton(Items.ItemType.EnergyPotion,   Items.GetSprite(Items.ItemType.EnergyPotion), "Energy Potion", Items.GetCost(Items.ItemType.EnergyPotion), 1);
        //CreateItemButton(Items.ItemType.ManaPotion, Items.GetSprite(Items.ItemType.ManaPotion), "Mana Potion", Items.GetCost(Items.ItemType.ManaPotion), 2);
        //CreateItemButton(Items.ItemType.PoisonPotion, Items.GetSprite(Items.ItemType.PoisonPotion), "Poison Potion", Items.GetCost(Items.ItemType.PoisonPotion), 3);
        //CreateItemButton(Items.ItemType.StrengthPotion, Items.GetSprite(Items.ItemType.StrengthPotion), "Strength Potion", Items.GetCost(Items.ItemType.StrengthPotion), 4);
        //CreateItemButton(Items.ItemType.SoulPotion, Items.GetSprite(Items.ItemType.SoulPotion), "Soul Potion", Items.GetCost(Items.ItemType.SoulPotion), 5);


        HideShop();
    }

    private void CreateItemButton(Items.ItemType itemType, Sprite itemSprite, string itemName, int itemCost, int positionIndex)
    {

        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        float shopItemHeight = 70f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

        shopItemTransform.Find("NameItem").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("PriceItem").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());

        shopItemTransform.Find("ItemImage").GetComponent<Image>().sprite = itemSprite;
        shopItemTransform.gameObject.SetActive(true);

        shopItemTransform.GetComponent<Button_UI>().ClickFunc = () =>
        {
            TryBuyItem(itemType);
        };

    }

    private void TryBuyItem(Items.ItemType itemType)
    {
        if (shopCustomer.TrySpendGoldAmount(Items.GetCost(itemType)))
        {
            shopCustomer.BoughtItem(itemType);
        }
        
    }

    public void ShowShop(IShopCustomer shopCustomer, string nameShop)
    {
        this.shopCustomer = shopCustomer;
        switch (nameShop)
        {
            case "Shop1":
                if (shop1 < 1)
                {
                    CreateItemButton(Items.ItemType.Food, Items.GetSprite(Items.ItemType.Food), "Food", Items.GetCost(Items.ItemType.Food), 0);
                    CreateItemButton(Items.ItemType.Water, Items.GetSprite(Items.ItemType.Water), "Water", Items.GetCost(Items.ItemType.Water), 1);
                    shop1++;
                }
                break;
            case "Shop2":
                if (shop2 < 1)
                {
                    CreateItemButton(Items.ItemType.WoodAxe, Items.GetSprite(Items.ItemType.WoodAxe), "Wood Axe", Items.GetCost(Items.ItemType.WoodAxe), 0);
                    CreateItemButton(Items.ItemType.StoneAxe, Items.GetSprite(Items.ItemType.StoneAxe), "Stone Axe", Items.GetCost(Items.ItemType.StoneAxe), 1);
                    shop2++;
                }
                break;
            case "Shop3":
                if (shop3 < 1)
                {
                    CreateItemButton(Items.ItemType.BronzePick, Items.GetSprite(Items.ItemType.BronzePick), "Bronze Pick", Items.GetCost(Items.ItemType.BronzePick), 0);
                    CreateItemButton(Items.ItemType.MetalPick, Items.GetSprite(Items.ItemType.MetalPick), "Metal Pick", Items.GetCost(Items.ItemType.MetalPick), 1);
                    shop3++;
                }
                break;
            case "Shop4":
                if (shop4 < 1)
                {
                    CreateItemButton(Items.ItemType.BasicArrow, Items.GetSprite(Items.ItemType.BasicArrow), "Basic Arrow", Items.GetCost(Items.ItemType.BasicArrow), 0);
                    CreateItemButton(Items.ItemType.MediumArrow, Items.GetSprite(Items.ItemType.MediumArrow), "Medium Arrow", Items.GetCost(Items.ItemType.MediumArrow), 1);
                    shop4++;
                }
                break;
        }
        gameObject.SetActive(true);
    }

    public void HideShop()
    {
        gameObject.SetActive(false);

        //Destroy(gameObject, 1f);
        shop1 = 0;
        shop2 = 0;
        shop3 = 0;
        shop4 = 0;

    }

}
