using UnityEngine;
using System.Collections;

public class ThrowObject : MonoBehaviour
{
    public Transform player;
    public Transform playerCam;
    public float throwForce = 100;
    bool hasPlayer = false;
    bool beingCarried = false;
    public AudioClip[] soundToPlay;
    //private AudioSource audioSource;
    public int dmg;
    private bool touched = false;

    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position, player.position);
        if (dist <= 2.5f)
        {
            hasPlayer = true;
        }
        else
        {
            hasPlayer = false;
        }
        if (hasPlayer && Input.GetButtonDown("Use"))
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = playerCam;
            beingCarried = true;
        }
        if (beingCarried)
        {
            if (touched)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                touched = false;
            }
            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                GetComponent<Rigidbody>().AddForce(playerCam.forward * throwForce);
                RandomAudio();
            }
            else if (Input.GetMouseButtonDown(1))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
            }
        }
    }
    void RandomAudio()
    {
        //if (audioSource.isPlaying){
        //return;
        //}
        //audioSource.clip = soundToPlay[Random.Range(0, soundToPlay.Length)];
        //audioSource.Play();

    }
    void OnTriggerEnter(Collider door)
    {
        if (beingCarried)
        {
            touched = true;
        }
    }
}