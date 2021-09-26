using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldItem : MonoBehaviour
{
    public Item Item;
    public SpriteRenderer image;

    public void SetItem(Item _Item){
        Item.itemName =_Item.itemName;
        Item.itemImage =_Item.itemImage;
        Item.itemType =_Item.itemType;

        image.sprite = Item.itemImage;
    }
    public Item GetItem(){
        return Item;
    }
    public void DestroyItem(){
        Destroy(gameObject);
    }

}
