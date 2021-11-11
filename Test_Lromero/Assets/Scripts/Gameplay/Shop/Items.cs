using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class Items : MonoBehaviour
{

    public enum ItemType
    {
        Food,
        Water,
        WoodAxe,
        StoneAxe,
        BronzePick,
        MetalPick,
        BasicArrow,
        MediumArrow
    }

    //Here add to necessary items
    public static int GetCost(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            //Here put the price of the enum
            case ItemType.Food:
                return 15;
            case ItemType.Water:
                return 15;
            case ItemType.WoodAxe:
                return 30;
            case ItemType.StoneAxe:
                return 80;
            case ItemType.BronzePick:
                return 30;
            case ItemType.MetalPick:
                return 80;
            case ItemType.BasicArrow:
                return 30;
            case ItemType.MediumArrow:
                return 80;

        }
    }

    //And then your sprites
    public static Sprite GetSprite(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.Food:
                return GameAssets.i.sprites[0];
            case ItemType.Water:
                return GameAssets.i.sprites[1];
            case ItemType.WoodAxe:
                return GameAssets.i.sprites[2];
            case ItemType.StoneAxe:
                return GameAssets.i.sprites[3];
            case ItemType.BronzePick:
                return GameAssets.i.sprites[4];
            case ItemType.MetalPick:
                return GameAssets.i.sprites[5];
            case ItemType.BasicArrow:
                return GameAssets.i.sprites[6];
            case ItemType.MediumArrow:
                return GameAssets.i.sprites[7];
        }
    }
}
