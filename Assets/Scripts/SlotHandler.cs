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

		// bare kjør kode hvis box in dropzone
		if (dropHandler != null)
        {
			if (box != null && slot != null)
			{
				if(dropHandler.HandleDrop(box, slot))
				{

					//sets box parent to the slot it is dropped at
					box.GetComponent<Draggable>().parentToReturnTo = this.transform;

					//makes box snap into center of slot
					box.transform.position = transform.position; 
				}
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
