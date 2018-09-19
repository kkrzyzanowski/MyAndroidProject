using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCollider: MonoBehaviour {

    private static InputCollider objectCollider;
   
    public static InputCollider ObjectCollider
    
    {
        get
        {
            if(objectCollider != null)
            {
                return objectCollider;
            }
            else
            {
                objectCollider = new InputCollider();
                return objectCollider;
            }
        }
    }

    private Item item;
    public bool getHitted;
    public void CatchInput()
    {
        RaycastHit raycastHit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out raycastHit, 1000))
        {

            item = raycastHit.collider.gameObject.GetComponent<Item>();

            if (item != null)
            {
                item.OnInputStart();
            }
            else
            {
                Debug.Log("Item is null");
            }
        }
    }
}
