using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryObject;

    public Slot[] Slots;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.I)) {
            inventoryObject.SetActive(!inventoryObject.activeInHierarchy);
        }
    }

    public void AddItem(Item pickedUpItem, Item startingItem = null) {
        Debug.Log("outside foreach");

        foreach (var slot in Slots) {
            Debug.Log("inside foreach");
            if (!slot.item) {
                Debug.Log("inside foreach if");
                pickedUpItem.transform.parent = slot.transform;
                return;
            } else {
                Debug.Log("didn't put it in slot");
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
