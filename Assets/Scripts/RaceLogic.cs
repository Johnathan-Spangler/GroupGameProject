using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RaceLogic : MonoBehaviour
{
    public float lapNumber, displayValue;
    private float lapMins, lapSecs, timer;
    public bool lapped;

    public GameObject startObject;

    // Start is called before the first frame update
    void Start()
    {
        lapNumber = -1;
        startObject = GameObject.FindWithTag("Start");
    }

    // Update is called once per frame
    void Update()
    {
        if (lapped)
        {
            timer += Time.deltaTime;
        }
        while (timer >= 1f)
        {
            timer = 0;
            lapSecs++;
            if (lapSecs >= 60)
            {
                lapMins++;
                lapSecs = 0;
            }
            displayValue = lapMins + lapSecs / 100f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (lapped)
        {
            startObject.SetActive(true);
        }
        if (other.tag == "Start")
        {
            other.gameObject.SetActive(false);
            lapped = false;
        }
        if (other.tag == "End" && !lapped)
        {
            lapNumber++;
            lapped = true;
        }
    }
}
