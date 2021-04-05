using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionButtons : MonoBehaviour
{
    public bool play = true;
    public bool rewind = false;
    public bool fastf = false;
    public GameObject timeline;


    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Play")
        {
            if(timeline.GetComponent<TimelineController>().isPaused == true)
            {
                timeline.GetComponent<TimelineController>().isPaused = false;
                timeline.GetComponent<TimelineController>().hitPause = true;
            }
            else if(timeline.GetComponent<TimelineController>().isPaused == false)
            {
                timeline.GetComponent<TimelineController>().isPaused = true;
                timeline.GetComponent<TimelineController>().hitPause = true;
            }
        }
        else if(other.gameObject.tag == "SForward")
        {
            timeline.GetComponent<TimelineController>().fastForward = true;
        }

        else if(other.gameObject.tag == "SBackward")
        {
            timeline.GetComponent<TimelineController>().rewinding = true;
        }
    }
    //void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("Entering");
    //    
//
    //    if (other.gameObject.tag == "Play")
    //    {
    //        timeline.GetComponent<TimelineController>().hitPause = true;
    //    }
    //    else if(other.gameObject.tag == "SForward")
    //    {
    //        timeline.GetComponent<TimelineController>().fastForward = true;
    //    }
//
    //    else if(other.gameObject.tag == "SBackward")
    //    {
    //        timeline.GetComponent<TimelineController>().rewinding = true;
    //    }
    //}
//
    void OnTriggerExit (Collider other)
    {
        //Debug.Log("Exiting");
        if(other.gameObject.tag == "SForward")
        {
            timeline.GetComponent<TimelineController>().fastForward = false;
        }
        else if(other.gameObject.tag == "SBackward")
        {
            timeline.GetComponent<TimelineController>().rewinding = false;
        }
    }
}
