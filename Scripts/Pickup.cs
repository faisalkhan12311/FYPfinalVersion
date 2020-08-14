using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pickup : MonoBehaviour
{

    public GameObject pickupText;
    private void OnTriggerStay(Collider other)
    {
        pickupText.SetActive(true);
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                pickupText.SetActive(false);
                Destroy(transform.parent.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        pickupText.SetActive(false);
    }
}
