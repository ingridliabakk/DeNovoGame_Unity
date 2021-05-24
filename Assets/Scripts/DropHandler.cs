using System.Collections.Generic;
using UnityEngine;

//farge, bredde, rekkefølge
//access child comp
//validPlacement(box,pos)


public class DropHandler : MonoBehaviour
{

    public void HandleDrop(GameObject draggableBox, GameObject slot)
    {
        Draggable draggable = draggableBox.GetComponent<Draggable>();
        List<GameObject> validSlots = ValidWidth(draggableBox, slot);

        if (draggable == null || validSlots == null)
        {
            return;
        }

        foreach (GameObject s in validSlots)
        {
            if (IsOccupied(s))
            {
                return;
            }
        }

        if (validSlots.Count >= 0)
        {
            foreach (GameObject s in validSlots)
            {
                SetOccupied(s, true);
            }
            SetPosition(draggableBox, validSlots);
        }
    }

    private void SetPosition(GameObject draggableBox, List<GameObject> slots)
    {
        /**
        * Sets draggable box in center of slots
        */
        Transform boxParent = slots[0].GetComponent<SlotHandler>().transform;

        //sets box parent to the slot it is dropped at
        draggableBox.GetComponent<Draggable>().parentToReturnTo = boxParent;

        //makes box snap into center of slot
        draggableBox.transform.position = new Vector3(CalucualteCenterOfSlots(slots), boxParent.transform.position.y, 0);
    }

    private float CalucualteCenterOfSlots(List<GameObject> slots)
    {
        float firstXPos = GetSlotXPos(slots[0]);
        float lastXPos = GetSlotXPos(slots[slots.Count-1]);
        float center = (firstXPos + ((lastXPos - firstXPos) / 2));

        return center;
    }

    private float GetSlotXPos(GameObject slot)
    {
        return slot.transform.position.x;
    }

    private List<GameObject> ValidWidth(GameObject draggableBox, GameObject slot)
    {
        /**
         * returns a list of valid slot and neighbour
         */
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
