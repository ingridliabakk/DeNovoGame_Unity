using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	
	public Transform parentToReturnTo = null;

	public enum Type { DEFAULT, RED, BLUE, GREEN };
	public Type typeOfItem = Type.DEFAULT;

	public void OnBeginDrag(PointerEventData eventData)
	{
		Debug.Log("OnBeginDrag");

		//lag en ny boks
		//box = new GameObject();

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
		Debug.Log("OnEndDrag");
		//ref til parent, lag ny clone
		//clonen sin parent er boxcontainer
		this.transform.SetParent(parentToReturnTo);
		GetComponent<CanvasGroup>().blocksRaycasts = true;
	}
}