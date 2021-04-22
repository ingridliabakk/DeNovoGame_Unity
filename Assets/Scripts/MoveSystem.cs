using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveSystem : MonoBehaviour
{
    public GameObject correctForm;
    private bool moving;

    private float startPosX;
    private float startPosY;

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButton(1))
        Debug.Log("Mouse up");
        

        if (moving) {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x-startPosX, mousePos.y - startPosY, this.gameObject.transform.localPosition.z);
        }
        
    }

    private void onMouseDown() {
        Debug.Log("mouse down");
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            moving = true;
        }
    }

    private void onMouseUp() {
        Debug.Log("mouse up");
        moving = false;
    }
}
