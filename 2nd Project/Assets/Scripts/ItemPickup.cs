using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public string itemName = "File";
    public float pickupRadius = 2f;
    public GameObject itemUI;

    private Transform playerTransform;
    private void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        
        float distance = Vector3.Distance(playerTransform.position, transform.position);

        if (distance <= pickupRadius)
        {
            // Laat UI zien
            if (itemUI != null)
            {
                itemUI.SetActive(true);
            }

            PickupItem();
        }
        else
        {
            // UI weghalen
            if (itemUI != null)
            {
                itemUI.SetActive(false);
            }
        }
    }

    private void PickupItem()
    {
        //Als item opgepakt is dan item weghalen en loggen

        Debug.Log("Picked up " + itemName);

        Destroy(gameObject);
    }
}