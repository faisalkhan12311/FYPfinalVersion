using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

namespace DTInventory
{

    public class SaveManager : MonoBehaviour
    {
        public GameObject saveNotify;

        public Vector3 savePos;
        public DateTime saveTime;
        public DTInventory inventory;
        public GameObject ar15, shotgun, sniper, ar15mag, bottle, conserve;

        private void Awake() 
        {
            if (PlayerPrefs.GetInt("save") == 1)
            {
                GameObject temp = GameObject.FindGameObjectWithTag("Player");
                temp.transform.position = new Vector3(PlayerPrefs.GetFloat("PosX"), PlayerPrefs.GetFloat("PosY"), PlayerPrefs.GetFloat("PosZ"));
            }
        }

        private void Start()
        {
            if (inventory == null)
                inventory = FindObjectOfType<DTInventory>();

            if (PlayerPrefs.GetInt("ar15Save") == 1)
            {
                inventory.AddItem(ar15.GetComponent<Item>());
            }

            if (PlayerPrefs.GetInt("ShotgunSave") == 1)
            {
                inventory.AddItem(shotgun.GetComponent<Item>());
            }
            if (PlayerPrefs.GetInt("BarretItemSave") == 1)
            {
                inventory.AddItem(sniper.GetComponent<Item>());
            }
            if (PlayerPrefs.GetInt("ar15magSave") == 1)
            {
                inventory.AddItem(ar15mag.GetComponent<Item>());
            }

            if (PlayerPrefs.GetInt("bottleSave") == 1)
            {
                inventory.AddItem(bottle.GetComponent<Item>());
            }
            if (PlayerPrefs.GetInt("conserveSave") == 1)
            {
                inventory.AddItem(conserve.GetComponent<Item>());
            }

        }

        public void OnSave()
        {
            PlayerPrefs.SetInt("save", 1);
            saveTime = DateTime.Now;
            savePos = GameObject.FindGameObjectWithTag("Player").transform.position;
            PlayerPrefs.SetFloat("PosX", savePos.x);
            PlayerPrefs.SetFloat("PosY", savePos.y);
            PlayerPrefs.SetFloat("PosZ", savePos.z);


            if (PlayerPrefs.GetInt("ar15") == 1)
            {
                PlayerPrefs.SetInt("ar15Save", 1);
            } else if (PlayerPrefs.GetInt("ar15") == 0)
            {
                PlayerPrefs.SetInt("ar15Save", 0);
            }

            if (PlayerPrefs.GetInt("Shotgun") == 1)
            {
                PlayerPrefs.SetInt("ShotgunSave", 1);
            } else if (PlayerPrefs.GetInt("Shotgun") == 0)
            {
                PlayerPrefs.SetInt("ShotgunSave", 0);
            }

            if (PlayerPrefs.GetInt("BarretItem") == 1)
            {
                PlayerPrefs.SetInt("BarretItemSave", 1);
            }
            else if (PlayerPrefs.GetInt("BarretItem") == 0)
            {
                PlayerPrefs.SetInt("BarretItemSave", 0);
            }

            if (PlayerPrefs.GetInt("ar15mag") == 1)
            {
                PlayerPrefs.SetInt("ar15magSave", 1);
            }
            else if (PlayerPrefs.GetInt("ar15mag") == 0)
            {
                PlayerPrefs.SetInt("ar15magSave", 0);
            }

            if (PlayerPrefs.GetInt("bottle") == 1)
            {
                PlayerPrefs.SetInt("bottleSave", 1);
            }
            else if (PlayerPrefs.GetInt("bottle") == 0)
            {
                PlayerPrefs.SetInt("bottleSave", 0);
            }

            if (PlayerPrefs.GetInt("conserve") == 1)
            {
                PlayerPrefs.SetInt("conserveSave", 1);
            }
            else if (PlayerPrefs.GetInt("conserve") == 0)
            {
                PlayerPrefs.SetInt("conserveSave", 0);
            }


            saveNotify.SetActive(true);
        }

        private void OnApplicationQuit()
        {
            PlayerPrefs.SetInt("ar15", 0);
            PlayerPrefs.SetInt("Shotgun", 0);
            PlayerPrefs.SetInt("BarretItem", 0);
            PlayerPrefs.SetInt("ar15mag", 0);
            PlayerPrefs.SetInt("bottle", 0);
            PlayerPrefs.SetInt("conserve", 0);
        }

    }
}