using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//farge, bredde, rekkefølge
//access child comp
//validPlacement(box,pos)


public class DropHandler : MonoBehaviour
{
    public CircleCollider2D col2d;


    public void AccessChildComp()
    {

    }

    public bool ValidPosition(GameObject draggableBox, GameObject slot)
    {
        DropZone dropZone = slot.GetComponent<DropZone>();
        Draggable draggable = draggableBox.GetComponent<Draggable>();
       
        float widthDraggable = GetWidth(draggableBox);
        float widthSlot = GetWidth(slot);

        GetSlotNeighbours(slot);

        if (draggable != null)
        {
            //dropZone.typeOfItem == draggable.typeOfItem ||

            if (widthDraggable == widthSlot)
            {
                draggable.parentToReturnTo = this.transform;
                return true;
            }
            else
            {

            }
        }
        return false;
    }

    public float GetWidth(GameObject gameObject)
    {
        RectTransform rtgameObject = (RectTransform)gameObject.transform;
        return rtgameObject.rect.width;
    }

    public List<GameObject> GetSlotNeighbours()
    {
        List<GameObject> ListofSlots = new List<GameObject>();
        foreach (Transform child in transform)
        {
            ListofSlots.Add(child.gameObject);
        }
        return ListofSlots;
    }

}
