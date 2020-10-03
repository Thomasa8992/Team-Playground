using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item item;
    Sprite defaultSprite;
    Text amountText;

    private void Start() {
        defaultSprite = GetComponent<Image>().sprite;
        amountText = transform.GetChild(0).GetComponent<Text>();
    }
 
    private void Update() {
        CheckForItem();
    }

    public void CheckForItem() {
        if (transform.childCount > 1) {
            Debug.Log("found item");
            item = transform.GetChild(1).GetComponent<Item>();
            GetComponent<Image>().sprite = item.itemSprite;

            if(item.amountInStack > 1) {
                amountText.text = item.amountInStack.ToString();
            }
        } else {
            Debug.Log("found no item");
            item = null;
            GetComponent<Image>().sprite = defaultSprite;
            amountText.text = "";
        }

    }
}
