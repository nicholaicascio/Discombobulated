using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueKey : MonoBehaviour {

    public Collider col;

    void Start()
    {
        col = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider door)
    {
        if (door.tag == "Blue Door")
        {
            Debug.Log("hit the red door");
            Animator anim = door.GetComponent<Animator>();
            anim.SetBool("isOpen", true);
        }
    }
}
