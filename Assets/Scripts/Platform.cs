using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    GameManager gameManager;
    private bool active = true;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (gameManager.GetLevel() > 8)
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
        if (Random.Range(0, 2) == 0)
        {
            GetComponent<Rigidbody>().AddForce(transform.up * -6.0f * Time.deltaTime, ForceMode.Impulse);
        }
        else
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * 10.0f * Time.deltaTime, ForceMode.Impulse);
        }
    }
}
