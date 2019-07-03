using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    public Transform player;
    public float rotateSpeed = 10;
    Vector3 camOffset;
	// Use this for initialization
	void Start () {
        camOffset = transform.position - player.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //transform.position = player.position + camOffset;
        var h=Input.GetAxis("Horizontal");

        transform.RotateAround(player.position, Vector3.up,h*rotateSpeed*Time.deltaTime );
    }
}
