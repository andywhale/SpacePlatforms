using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    [SerializeField] Material[] skyboxes;

    // Use this for initialization
    void Start () {
        RenderSettings.skybox = skyboxes[Random.Range(0, skyboxes.Length)];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
