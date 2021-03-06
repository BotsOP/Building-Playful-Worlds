﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public InventoryObject inventory;
    [SerializeField] GameObject inventoryDisplay;
    private void Update() {
        ToggleInventory();
    }
    private void OnTriggerEnter(Collider other) 
    {
        var item = other.GetComponent<Item>();
        if(item)
        {
            inventory.AddItem(item.item, 1);
            Destroy(other.gameObject);
        }
    }

    private void OnApplicationQuit() 
    {
        inventory.Container.Clear();
    }

    private void ToggleInventory()
    {
        if(Input.GetKey(KeyCode.Tab))
            inventoryDisplay.SetActive(true);
        else
            inventoryDisplay.SetActive(false);
    }
}
