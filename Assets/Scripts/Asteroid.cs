using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Asteroid : Hittable, IPointerUpHandler, IPointerDownHandler, IPointerExitHandler
{
    [SerializeField] GameObject hitState;
    [SerializeField] bool converted = false;
    Vector3 direction;
    bool clickStarted = false;
    float timeElapsed;
    const float TIMETOHOLD = 0.5f;
    const float DEFAULTRETICLESIZE = 0.1f;

    GvrControllerReticleVisual reticle;

    private void Start()
    {
        direction = new Vector3(Random.Range(0.0f, 2.0f), Random.Range(0.0f, 2.0f), Random.Range(0.0f, 2.0f));
        transform.rotation = Quaternion.Euler(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180));
        reticle = GameObject.FindGameObjectWithTag("Reticle").GetComponent<GvrControllerReticleVisual>();
    }

    public int getScore()
    {
        // Eventually this will be a percentage converted 0 - 1 (0.5 = 50%).
        if (converted) {
            return 1;
        }
        return 0;
    }

    void FixedUpdate()
    {
        transform.position += direction * Time.deltaTime;
        if (clickStarted)
        {
            timeElapsed += Time.deltaTime;
            reticle.sizeMeters = timeElapsed;
            if (timeElapsed > TIMETOHOLD)
            {
                if (hitState != null)
                {
                    ResetReticle();
                    Instantiate(hitState, transform.position, transform.rotation);
                    Destroy(gameObject);
                }
            }
        }
    }

    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData pointer)
    {
        if (hitState != null)
        {
            clickStarted = true;
        }
    }

    public void OnPointerExit(PointerEventData pointer)
    {
        clickStarted = false;
        ResetReticle();
    }

    public void OnPointerUp(PointerEventData pointer)
    {
        clickStarted = false;
        ResetReticle();
    }

    private void ResetReticle()
    {
        reticle.sizeMeters = DEFAULTRETICLESIZE;
    }
}
