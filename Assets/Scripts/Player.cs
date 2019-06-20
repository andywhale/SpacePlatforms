using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

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
            GetComponent<Rigidbody>().AddForce(cameraAngle.forward * Time.deltaTime * 12.0f, ForceMode.Impulse);
        }
        if (GvrControllerInput.ClickButtonDown)
        {
            StopPlayer();
        }
        if (GvrControllerInput.AppButton)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void Steer(Vector2 newAngle)
    {
        cameraAngle.rotation = Quaternion.Euler(cameraAngle.eulerAngles.x + newAngle.x, cameraAngle.eulerAngles.y + newAngle.y, cameraAngle.eulerAngles.z);
    }

    public void MoveForward(float speed)
    {
        //GetComponent<Rigidbody>().AddForce(cameraAngle.forward * Time.deltaTime * speed, ForceMode.Acceleration);
        Vector3 newPosition = transform.position + cameraAngle.GetComponent<Transform>().transform.forward * speed * Time.deltaTime;
        transform.position = new Vector3(newPosition.x, newPosition.y, newPosition.z);
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
}
