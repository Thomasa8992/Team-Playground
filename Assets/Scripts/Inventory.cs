using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryObject;

    [SerializeField]
    private Camera mainCamera;

    public Slot[] Slots;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.I)) {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            mainCamera.enabled = false;

            inventoryObject.SetActive(!inventoryObject.activeInHierarchy);
            if(!inventoryObject.activeInHierarchy) {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                mainCamera.enabled = true;
            }
        }
    }

    public void AddItem(Item pickedUpItem, Item startingItem = null) {
        foreach (var slot in Slots) {
            if (!slot.item) {
                pickedUpItem.transform.parent = slot.transform;
                return;
            } 
        }
    }

    private void OnTriggerEnter(Collider pickedUpItem) {
        if (pickedUpItem.GetComponent<Item>()) {
            Debug.Log(pickedUpItem.GetComponent<Item>());

            AddItem(pickedUpItem.GetComponent<Item>());
        }
    }
}
