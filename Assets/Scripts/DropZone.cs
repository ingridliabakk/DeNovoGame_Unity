using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

//farge, bredde, rekkefølge
//access child comp
//validPlacement(box,pos)

public class DropZone : MonoBehaviour, IDropHandler
{
	public Draggable.Type typeOfItem = Draggable.Type.DEFAULT;
	private bool Occupied = false;

	public void SetOccupied(bool b)
    {
		//exception
		Occupied = b;
    }


	public bool GetOccupied()
	{
		return Occupied;
	}

	public void OnDrop(PointerEventData eventData)
	{
		GameObject box = eventData.pointerDrag;
		GameObject slot = gameObject;

		//Debug.Log(box.name + " was dropped on " + slot.name);

        GameObject dropArea = transform.parent.gameObject;
        DropHandler dropHandler = dropArea.GetComponent<DropHandler>();

		if (box != null)
		{
			if(dropHandler.ValidPosition(box, slot))
            {
				box.GetComponent<Draggable>().parentToReturnTo = this.transform;
            }
		}

	}
}
