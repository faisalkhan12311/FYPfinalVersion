using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public GameObject inventory;
    public GameObject slotHolder;

    private int slots;
    private Transform[] slot;

    public GameObject itemPickedup;
    public bool itemAdded;

    bool paused= false;

    public void Start()
    {
        //slot being detected
        slots = slotHolder.transform.childCount;
        slot = new Transform[slots];
        detectInventorySlots();
    }
    public void detectInventorySlots()
    {
        for(int i=0; i < slots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i);
            //print(slot[i].name); 
        }
    }


    //using playmovement now
    //public void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Item")
    //    {
    //        print("colliding");
    //        itemPickedup = other.gameObject;
    //        AddItem(itemPickedup);
    //        //slotHolder.GetComponent<Slot>().Add();
    //    }
        
    //}

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Item")
        {
            itemAdded = false;
            
        }
    }
    private int i = 0;
    public void AddItem(GameObject Item)
    {
         //int i = 0;
        //for(int i=0; i < slots; i++)
        //{
            if (slot[i].GetComponent<Slot>().empty && itemAdded == false)
            {
                print("adding");
                slot[i].GetComponent<Slot>().item = itemPickedup;

                slot[i].GetComponent<Slot>().itemIcon = itemPickedup.GetComponent<Item>().icon;
                itemAdded = true;
                print("itemadded");
                //return;

            } else if (slot[i].GetComponent<Slot>().empty == false)
            {
                i = i + 1;
                print("using other slots");
                slot[i].GetComponent<Slot>().item = itemPickedup;

                slot[i].GetComponent<Slot>().itemIcon = itemPickedup.GetComponent<Item>().icon;
                itemAdded = true;
                print("using else");
                
            }
            
        //}
    }

    // Update is called once per frame
    void Update()
    {
      
        if (paused)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                hidePanel();
            }
        }
        else if (!paused)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                ShowPanel();
            }
        }

        //AddItem(itemPickedup);
    }

    public void hidePanel()
    {
        inventory.gameObject.SetActive(false);
        Time.timeScale = 1;
        paused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ShowPanel()
    {
        inventory.gameObject.SetActive(true);
        Time.timeScale = 0;
        paused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    
}
