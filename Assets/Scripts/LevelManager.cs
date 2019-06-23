using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    [SerializeField] GameObject[] artefactTypes;
    [SerializeField] int numberOfArtefacts;
    [SerializeField] GameObject[] shipTypes;
    [SerializeField] int numberOfShips;
    [SerializeField] float areaMin = -100;
    [SerializeField] float areaMax = 100;
    private GameObject player;
    private GameObject[] artefactInstances;
    private GameObject[] shipInstances;

    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player");
        shipInstances = new GameObject[numberOfShips];
        GameObject ArtefactContainer = GameObject.Find("Artefacts");
        for (int i = 0; i < numberOfShips; i++)
        {
            GameObject shipType = shipTypes[Random.Range(0, shipTypes.Length)];
            Vector3 shipPosition = new Vector3(
                player.transform.position.x + Random.Range(areaMin, areaMax),
                player.transform.position.y + Random.Range(areaMin, areaMax),
                player.transform.position.z + Random.Range(areaMin, areaMax)
                );
            shipInstances[i] = Instantiate(shipType, shipPosition, Quaternion.identity);
            shipInstances[i].transform.SetParent(ArtefactContainer.transform);
        }
        artefactInstances = new GameObject[numberOfArtefacts];
        for (int i = 0; i < numberOfArtefacts; i++)
        {
            GameObject artefactType = artefactTypes[Random.Range(0, artefactTypes.Length)];
            Vector3 artefactPosition = new Vector3(
                player.transform.position.x + Random.Range(areaMin, areaMax),
                player.transform.position.y + Random.Range(areaMin, areaMax),
                player.transform.position.z + Random.Range(areaMin, areaMax)
                );
            artefactInstances[i] = Instantiate(artefactType, artefactPosition, Quaternion.identity);
            artefactInstances[i].transform.SetParent(ArtefactContainer.transform);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
