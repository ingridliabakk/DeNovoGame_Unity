using System.Collections.Generic;
using UnityEngine;

//farge, bredde, rekkefølge
//access child comp
//validPlacement(box,pos)


public class DropHandler : MonoBehaviour
{

    public bool HandleDrop(GameObject draggableBox, GameObject slot)
    {

        Draggable draggable = draggableBox.GetComponent<Draggable>();
        GameObject rightNeighbour = GetRightNeighbour(slot);
        List<GameObject> validSlot = ValidPosition(draggableBox, slot);

        if (draggable == null || IsOccupied(slot) || validSlot == null)
        {
            Debug.Log("false");
            return false;
        }

        if (validSlot.Count == 1)
        {
            draggable.parentToReturnTo = this.transform;
            SetOccupied(slot, true);
            return true;
        }
        else if (validSlot.Count > 1)
        {
            if (!IsOccupied(rightNeighbour))
            {
                //draggable.parentToReturnTo = this.transform;
                SetOccupied(slot, true);
                SetOccupied(rightNeighbour, true);
                return true;
            }
        }

        Debug.Log(draggableBox.name + " did not fit on " + slot.name);
        return false;
    }
    /**
     * returns a list of valid slot and neighbour
     */
    private List<GameObject> ValidPosition(GameObject draggableBox, GameObject slot)
    {
        List<GameObject> validSlots = new List<GameObject>();
        float widthDraggable = GetWidth(draggableBox);
        float widthSlot = GetWidth(slot);

        GameObject rightNeighbour = GetRightNeighbour(slot);

        if (widthDraggable == widthSlot)
        {
            validSlots.Add(slot);
            return validSlots;
        }
        else if (rightNeighbour != null && widthDraggable == widthSlot + GetWidth(rightNeighbour))
        {
            validSlots.Add(slot);
            validSlots.Add(rightNeighbour);
            return validSlots;
        }
        return null;
    }

    private GameObject GetRightNeighbour(GameObject slot)
    {
        int index = FindIndexOfObjectInList(slot);

        if (AllSlots().Count > index + 1)
        {
            GameObject rightNeighbour = AllSlots()[index + 1];

            return rightNeighbour;
        }
        return null;
    }

    private float GetWidth(GameObject gameObject)
    {
        RectTransform rtgameObject = (RectTransform)gameObject.transform;
        return rtgameObject.rect.width;
    }

    private List<GameObject> AllSlots()
    {
        List<GameObject> ListofSlots = new List<GameObject>();
        foreach (Transform child in transform)
        {
            ListofSlots.Add(child.gameObject);
        }
        return ListofSlots;
    }

    private int FindIndexOfObjectInList(GameObject gameObject)
    {
        return AllSlots().IndexOf(gameObject);
    }

    private bool IsOccupied(GameObject slot)
    {
        SlotHandler dropZone = slot.GetComponent<SlotHandler>();
        return dropZone.GetOccupied();
    }

    private void SetOccupied(GameObject slot, bool b)
    {
        SlotHandler dropZone = slot.GetComponent<SlotHandler>();
        dropZone.SetOccupied(b);
    }

    void OnTriggerEnter(Collider BoxCollider2D)
    {
    }

    private void ListOfOccupied()
    {
        List<int> list = new List<int>();
        foreach (GameObject slot in AllSlots())
        {
            if (IsOccupied(slot))
            {
                list.Add(1);
            }
            list.Add(0);
        }
        print(list);
    }

}
