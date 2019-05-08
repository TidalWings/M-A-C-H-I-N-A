using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour {

	public Texture2D cursorSprite;
	// public Texture2D cursorTextureTwo;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    void Start() {
        Cursor.SetCursor(cursorSprite, hotSpot, cursorMode);
    }
    // void Update() {
        // TODO: IF we want to do cursor changes
        // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // RaycastHit rayHit;
        // if (Physics.Raycast(ray, out rayHit)) {
        //     Debug.Log(rayHit.transform.tag.ToString());
        //     if (rayHit.transform.tag == "Item") {
        //         Cursor.SetCursor(cursorTextureTwo, hotSpot, cursorMode);
        //     } else {
        //         Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        //     }
        // }
    // }

    // void OnMouseEnter() {
    //     Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    // }

    // void OnMouseExit() {
    //     Cursor.SetCursor(null, Vector2.zero, cursorMode);
    // }
}
