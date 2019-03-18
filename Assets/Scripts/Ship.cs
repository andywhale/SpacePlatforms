using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

	void FixedUpdate () {
        GetComponent<Rigidbody>().AddForce(transform.forward * Time.deltaTime * 1.0f);
	}
}
