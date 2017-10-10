using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * beta 0.0.0
 * wrirtten by yasu80
 * 20170626
 * 
 * not yet dilatant force added
 */

public class Sticky : MonoBehaviour {
    public GameObject me;
    public GameObject you;
    Vector3 stuckked_me = new Vector3(0, 0, 0);
    Vector3 stuckked_you = new Vector3(0, 0, 0);
    Vector3 base_collision = new Vector3(0, 0, 0);
    
    int k = 1000;

    public Rigidbody myRigidBody;
    public Rigidbody yourRigidBody;

    void OnCollisionEnter(Collision collision) {
        ContactPoint contact = collision.contacts[0];//Easy_Plus
        Quaternion rotate_me = Quaternion.FromToRotation(Vector3.up, contact.point);//Poop
        stuckked_you = contact.point;
        base_collision = stuckked_you;
        you = collision.gameObject;//Get Collision Object
        yourRigidBody = you.GetComponent<Rigidbody>();
        if (you.tag == "Untagged")
        {
            you.tag = "been";
        }
    }

    // Use this for initialization
    void Start () {
         myRigidBody  = GetComponent<Rigidbody>();
    }
	
    void FixedUpdate(){
        var direction = you.transform.position - me.transform.position;
        var distance = direction.magnitude;
        var gravity = k / distance;
        myRigidBody.AddForce(gravity * direction.normalized, ForceMode.Force);
    }
}
