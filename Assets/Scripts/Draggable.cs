using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform parentToReturnTo = null;
    public enum Slot { RED, BLUE, GREEN };
    public Slot typeOfItem = Slot.RED;

    public enum Box { RED, BLUE, GREEN };
    public Box typeOfBox = Box.RED; //if for å finne ut hvilken bokstype?

    GameObject placeholder = null;

    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log ("OnBeginDrag");

        placeholder = new GameObject();
        placeholder.transform.SetParent(this.transform.parent);
        LayoutElement le = placeholder.AddComponent<LayoutElement>();
        le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        le.flexibleWidth = 0;
        le.flexibleHeight = 0;

        placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());


        parentToReturnTo = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;



        //highlight valid slots
        //have to turn of on onenddrag
        //DropZone[] zones = GameObject.FindObjectsOfType<DropZone>();
    }

    public void OnDrag(PointerEventData eventData) {
        this.transform.position = eventData.position;

        //move placeholder when box is hoovered over boxes
        for(int i =0; i< parentToReturnTo.childCount; i ++) {
            if(this.transform.position.x < parentToReturnTo.GetChild(i).position.x) {
                placeholder.transform.SetSiblingIndex(i);
                break;
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log ("OnEndDrag");
        this.transform.SetParent(parentToReturnTo);
        this.transform.SetSiblingIndex( placeholder.transform.GetSiblingIndex());

        GetComponent<CanvasGroup>().blocksRaycasts = true;

        Destroy(placeholder);

        //checks whats underneat 
        //EventSystems.current.RaycastAll(eventData);
    }
  
}
