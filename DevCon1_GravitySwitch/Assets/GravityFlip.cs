using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GravityFlip : MonoBehaviour
{
    public bool isFlipped;
    public GameObject cameraa;
    // Start is called before the first frame update
    void Start()
    {
        isFlipped = cameraa.GetComponent<Eyeballs>().isFlipped;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFlipped)
        {
            this.GetComponent<Rigidbody>().useGravity = false;
            if (!this.GetComponent<CharacterMove>().isGrounded)
            {
                this.GetComponent<Rigidbody>().AddForce(Vector3.up * 3, ForceMode.Acceleration);
            }
            
        }
        else
        {
            this.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
