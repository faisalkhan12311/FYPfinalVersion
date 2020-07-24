using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool hovered;
    public bool empty;
    public int itemID;
    public GameObject item;
    public Sprite itemIcon; 
    Image thisSprite;
    public survivalBar sb;
    public Sprite img;
     
    void Start()
    {
        hovered = false;
        empty = true;
    }

    void Update()
    {
        //print(itemID);
        //print(itemIcon);

        if(hovered && Input.GetMouseButtonDown(1))
        {
            if(itemID == 1)
            {
                sb.Health += 50;
                empty = true;
                GetComponent<Image>().sprite.Equals(null); //= null;
                itemID = 0;
                //ItemUsed();
            }
            if(itemID == 2)
            {
                sb.Thirst += 50;
                empty = true;
                GetComponent<Image>().sprite.Equals(null); //= null;
                itemID = 0;
            }
            if (itemID == 3)
            {
                sb.Hunger += 50;
                empty = true;
                GetComponent<Image>().sprite = null;
                itemID = 0;
            }
        }

        if(itemIcon != null)
        {
            GetComponent<Image>().sprite = itemIcon;
        }


        if (item)
        {
            empty = false;
            itemIcon = item.GetComponent<Item>().icon;
            itemID = item.GetComponent<Item>().ItemID;
        }

        else
        {
            empty = true;
        }

        
    }

    //public void ItemUsed()
    //{

    //}

    //public void Add()
    //{
    //    if (item)
    //    {
    //        empty = false;
    //        itemIcon = item.GetComponent<Item>().icon;
    //        itemID = item.GetComponent<Item>().ItemID;
    //    }
    //}

    public void OnPointerEnter(PointerEventData eventData)
    {
        hovered = true;

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hovered = false;

    }

    
}
