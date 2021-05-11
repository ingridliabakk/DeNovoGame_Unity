using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//farge, bredde, rekkefølge
//access child comp
//validPlacement(box,pos)


public class DropHandler : MonoBehaviour
{
    public Draggable.Type typeOfItem = Draggable.Type.DEFAULT; //TODO: remove

    public void AccessChildComp()
    {

    }

    public bool ValidPosition(GameObject draggableBox, GameObject slot)
    {
        DropZone dropZone = slot.GetComponent<DropZone>();
        Draggable draggable = draggableBox.GetComponent<Draggable>();

        Debug.Log("zone " + dropZone.typeOfItem + "item " + draggable.typeOfItem);
        if (draggable != null)
        {
            if (dropZone.typeOfItem == draggable.typeOfItem)
            {
                draggable.parentToReturnTo = this.transform;
                return true;
            }
        }
        return false;
    }

}
