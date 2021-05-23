using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	
	public Transform parentToReturnTo = null;

	public enum Type { DEFAULT, RED, BLUE, GREEN };
	public Type typeOfItem = Type.DEFAULT;


	public void OnBeginDrag(PointerEventData eventData)
	{

		//lag en ny boks
		//Draggable box = new Draggable();
		//box.transform.

		parentToReturnTo = this.transform.parent;
		this.transform.SetParent(this.transform.parent.parent);

		GetComponent<CanvasGroup>().blocksRaycasts = false;
	}

	public void OnDrag(PointerEventData eventData)
	{
		//Debug.Log ("OnDrag");

		this.transform.position = eventData.position;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		//Debug.Log("OnEndDrag");
		//ref til parent, lag ny clone
		//clonen sin parent er boxcontainer

		this.transform.SetParent(parentToReturnTo); //fjernet denne for å få box på topp
		GetComponent<CanvasGroup>().blocksRaycasts = true;
	}
}