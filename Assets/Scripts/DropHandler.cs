using System.Collections.Generic;
using UnityEngine;

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

        GameObject rightNeighbour = GetRightNeighbour(slot);
        

        if (draggable != null)
        {
            //dropZone.typeOfItem == draggable.typeOfItem ||

            if (widthDraggable == widthSlot)
            {
                draggable.parentToReturnTo = this.transform;
                Debug.Log("drag" + widthDraggable + "slot" + widthSlot);
                return true;
            }
            else if (rightNeighbour != null && widthDraggable == widthSlot + GetWidth(rightNeighbour))
            {
                return true;
            }
        }
        return false;
    }

    public GameObject GetRightNeighbour(GameObject slot)
    {
        int index = FindIndexOfObjectInList(slot);
        Debug.Log(AllSlots().Count + "hjkø" + index + 1);
        if (AllSlots().Count > index+1) {
            GameObject rightNeighbour = AllSlots()[index + 1];

            Debug.Log("index: " + index + " list size: " + AllSlots()[index+1]);
            return rightNeighbour;
        }
        return null;
    }

    public float GetWidth(GameObject gameObject)
    {
        RectTransform rtgameObject = (RectTransform)gameObject.transform;
        return rtgameObject.rect.width;
    }

    public List<GameObject> AllSlots()
    {
        List<GameObject> ListofSlots = new List<GameObject>();
        foreach (Transform child in transform)
        {
            ListofSlots.Add(child.gameObject);
        }
        return ListofSlots;
    }

    public int FindIndexOfObjectInList(GameObject gameObject)
    {
        return AllSlots().IndexOf(gameObject);
    }

}
