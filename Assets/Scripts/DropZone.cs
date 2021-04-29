using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public Draggable.Slot typeOfItem = Draggable.Slot.RED;

    public void OnDrop(PointerEventData eventData) {
        Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if(d!= null) {
            if(typeOfItem == d.typeOfItem) {
                d.parentToReturnTo = this.transform;

            }
        }

    }
}
