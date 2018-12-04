using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGrabber : MonoBehaviour {

    public GameObject heldObject;
    static int itemHeld = 0;
    float objectDist = -0.1f;
    public GameObject hand;

    void Start () {
        hand = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && itemHeld == 2)
        {
            Debug.Log(heldObject + " was dropped");
            //hand.animation.Play("drop");
            heldObject.transform.parent = null;
            //heldObject.GetComponent(Rigidbody).isKinematic = false;
            heldObject.GetComponent<Rigidbody>().isKinematic = false;
            heldObject = null;
            itemHeld = 0;
        }
    }

    void OnMouseDown()
    {
        if (itemHeld == 0)
        {
            
            heldObject = gameObject;
            //hand.animation.Play("grab");
            heldObject.transform.parent = GameObject.FindWithTag("Player").transform;
            //heldObject.GetComponent(Rigidbody).isKinematic = true;
            heldObject.GetComponent<Rigidbody>().isKinematic = true;
            Vector3 handLocation = new Vector3(0, objectDist, 0);
            heldObject.transform.localPosition = handLocation;
            itemHeld = 1;
            Debug.Log(heldObject + " was picked up");
            
        }
    }


    void OnMouseUp()
    {
        if (itemHeld == 1)
        {
            itemHeld = 2;
            Debug.Log("mouse up");
        }
    }
}
