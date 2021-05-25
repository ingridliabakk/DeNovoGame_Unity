using System.Collections.Generic;
using UnityEngine;

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

    public List<GameObject> ValidWidth(GameObject draggableBox, GameObject slot)
    {
        /**
         * returns a list of valid slots
         */
        List<GameObject> allSlots = AllSlots();
        List<GameObject> validSlots = new List<GameObject>();
   
        int startSlot = allSlots.IndexOf(slot);
        float widthBox = GetWidth(draggableBox);
        float count = 0;

        for (int i = startSlot; i < allSlots.Count; i++)
        {
            count += GetWidth(allSlots[i]);
            validSlots.Add(allSlots[i]);

            if (widthBox == count)
            {
                return validSlots;
            }
        }
        return null;
    }

private void SetPosition(GameObject draggableBox, List<GameObject> slots)
    {
        /**
         * Sets draggable box in center of slots
         */
        Transform boxParent = slots[0].GetComponent<SlotHandler>().transform;

        //sets box parent to the slot it is dropped at
        draggableBox.GetComponent<Draggable>().parentToReturnTo = boxParent;

        //update x pos to the center of slots, while y, z stays the same
        draggableBox.transform.position = new Vector3(CalucualteCenterOfSlots(slots), boxParent.transform.position.y, 0);
    }

    private float CalucualteCenterOfSlots(List<GameObject> slots)
    {
        float firstXPos = GetSlotXPos(slots[0]);
        float lastXPos = GetSlotXPos(slots[slots.Count - 1]);
        float center = (firstXPos + ((lastXPos - firstXPos) / 2));

        return center;
    }

    private float GetSlotXPos(GameObject slot)
    {
        return slot.transform.position.x;
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

    public List<GameObject> AllSlots()
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
