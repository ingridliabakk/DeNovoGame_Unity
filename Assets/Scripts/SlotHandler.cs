using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

//farge, bredde, rekkefølge
//access child comp
//validPlacement(box,pos)

public class SlotHandler : MonoBehaviour, IDropHandler
{
	public Draggable.Type typeOfItem = Draggable.Type.DEFAULT;
	private bool Occupied = false;

	public void OnDrop(PointerEventData eventData)
	{
		GameObject box = eventData.pointerDrag;
		GameObject slot = gameObject;

		//Debug.Log(box.name + " was dropped on " + slot.name);

        GameObject dropArea = transform.parent.gameObject;
        DropHandler dropHandler = dropArea.GetComponent<DropHandler>();

		// checks that box is in DropArea or has a DropArea
		
		if (dropHandler != null)
        {
			if (box != null && slot != null)
			{
				dropHandler.HandleDrop(box, slot);
			}
        }
	}

	public void SetOccupied(bool b)
	{
		//exception
		Occupied = b;
	}

	public bool GetOccupied()
	{
		return Occupied;
	}
}
