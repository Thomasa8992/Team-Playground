using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipItem : MonoBehaviour
{
    Inventory inventory;

    GameObject currentSlot;
    Item currentSlotItem;

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            currentSlot = GetGameObjectUnderMouse();

            Debug.Log(currentSlot.GetComponent<Slot>().item);
        }    
    }

    private GameObject GetGameObjectUnderMouse() {
        GraphicRaycaster rayCaster = GetComponent<GraphicRaycaster>();
        PointerEventData eventData = new PointerEventData(EventSystem.current);

        eventData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();

        rayCaster.Raycast(eventData, results);

        foreach(var result in results) {
            return result.gameObject; 
        }

        return null;
    }
}
