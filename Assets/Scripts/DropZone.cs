using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

//farge, bredde, rekkefølge
//access child comp
//validPlacement(box,pos)

public class DropZone : MonoBehaviour, IDropHandler
{
	public Draggable.Type typeOfItem = Draggable.Type.DEFAULT;

	public void OnDrop(PointerEventData eventData)
	{
		GameObject box = eventData.pointerDrag;
		GameObject slot = gameObject;

		Debug.Log(box + " was dropped on " + slot);

		Debug.Log("box "+ box.GetComponent<Draggable>().parentToReturnTo);
		Debug.Log("slot "+ slot);

        GameObject dropArea = transform.parent.gameObject;
        DropHandler dropHandler = dropArea.GetComponent<DropHandler>();
		Debug.Log("drophanler" + dropHandler);

		if (box != null)
		{
			if(dropHandler.ValidPosition(box, slot))
            {
				Debug.Log("box.getComp");
				box.GetComponent<Draggable>().parentToReturnTo = this.transform;

            }
		}

	}
}
