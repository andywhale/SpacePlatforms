using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    GameManager gameManager;
    private bool active = true;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (gameManager.GetLevel() > 5)
        {
            EngageMovement();
        }
    }

    public bool IsActive()
    {
        return active;
    }

    public void Deactivate()
    {
        GetComponent<Light>().enabled = false;
        active = false;
    }

    public void EngageMovement()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * 5.0f * Time.deltaTime, ForceMode.Acceleration);
    }
}
