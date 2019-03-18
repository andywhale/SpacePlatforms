using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private GameManager gameManager;
    private Transform cameraAngle;

	void Start () {
        cameraAngle = GameObject.FindWithTag("MainCamera").GetComponent<Transform>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
	
	void FixedUpdate () {
        if (GvrControllerInput.ClickButton)
        {
            GetComponent<Rigidbody>().AddForce(cameraAngle.forward * Time.deltaTime * 8.0f, ForceMode.Impulse);
        }
        if (GvrControllerInput.ClickButtonDown)
        {
            StopPlayer();
        }
        if (GvrControllerInput.AppButton)
        {
            StopPlayer();
        }
    }

    public void StopPlayer()
    {
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
        {
            collision.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(collision.gameObject.transform.forward * Time.deltaTime * 10, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            gameManager.PlatformHit(collision.gameObject);
        }
    }
}
