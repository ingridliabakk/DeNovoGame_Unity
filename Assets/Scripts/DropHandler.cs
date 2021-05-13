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

        RectTransform rtDraggable = (RectTransform)draggable.transform;
        float widthDraggable = rtDraggable.sizeDelta.x;
            //.rect.width;

        Debug.Log("widthDraggable: "+ widthDraggable);

        RectTransform rtSlot = (RectTransform)dropZone.transform;
        float widthSlot = rtSlot.rect.width;

        Debug.Log("widthSlot: " + widthSlot);

        if (draggable != null)
        {
            //TODO: sjekk om slot og boks har samme bredde
            //dropZone.typeOfItem == draggable.typeOfItem ||

            if (dropZone.typeOfItem == draggable.typeOfItem || widthDraggable == widthSlot)
            {
                draggable.parentToReturnTo = this.transform;
                return true;
            }
            //elif i+1 om boks passer
        }
        return false;
    }

}
