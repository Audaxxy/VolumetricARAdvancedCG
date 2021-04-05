//Nathan Boldy 100653593
//This script handles pausing, unpausing, fast-forwarding, and rewinding volumetric video and audio simultaneously
//Note: Assumes Sound and Volumetric video are both set to looping

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Valve.VR;

public class TimelineController : MonoBehaviour
{
    public PlayableDirector controller;//Volumetric video controller
    public AudioSource audioController;//Audio controller
    private float audioCurrentTime;//Current time of AudioClip
    private double videoCurrentTime;//Current time of volumetric video
    public double maxTime = 31;//Max time for volumetric video (alembic uses doubles)
    public float maxAudioTime = 31;//Max time for volumetric video (AudioSources use floats)
    public bool isPaused = true;//Whether playback is paused or not

    public bool hitPause = false;
    public bool rewinding = false;
    public bool fastForward = false;

    public float timer = 0;
    public float controlTime = 0.25f;
    //public GameObject[] buttons;

    //public SteamVR_Action_Boolean SphereOnOff;
    // a reference to the hand
    //public SteamVR_Input_Sources handType;
    
    void Update()
    {
        timer += Time.deltaTime;
        //current times for audio and video every update
        videoCurrentTime = controller.time;
        audioCurrentTime = audioController.time;
    
        //If space is pressed while game is unpaused, pause audio and video
        //if(SteamVR_Input._default.inActions.leftTrigger.GetStateDown(SteamVR_Input_Sources.Any))
        //{
        //    Debug.Log("WTF");
        //}
        if (isPaused == false && hitPause == true)
        {
            audioController.Pause();
            controller.Pause();
            hitPause = false;
            //isPaused = true;
        }

        //If space is pressed while game is paused, unpause audio and video
        else if (isPaused == true && hitPause == true)
        {
            audioController.Play();
            controller.Resume();
            hitPause = false;
            //isPaused = false;
        }

        //If A is pressed, pause playback of audio and video and decrement time of each by 1.
        if (rewinding == true && timer > controlTime && controller.time >= 0)
        {
            //Pause
            Debug.Log("Rewind Time");
            audioController.Pause();
            controller.Pause();
            isPaused = true;
            timer = 0;
           
            //Exception handling for negative audio timeline
            if (audioCurrentTime - 1 >= 0)
            {
                //decrement audio time
                audioController.time = audioCurrentTime - 1;
            }
            //decrement video time
            controller.time = videoCurrentTime - 1;

            //Exception handling and audio/video syncing if decrement is engaged at start of sequence
            if (controller.time < 0)
            {
                controller.time = 0;
                audioController.time = 0;
            }

            //Ensuring values match altered values
            videoCurrentTime = controller.time;
            audioCurrentTime = audioController.time;
        }

        //If D is pressed, pause playback of audio and video and increment time of each by 1.
        if (fastForward == true && timer > controlTime && controller.time<=maxTime)
        {
            //Unpause
            audioController.Pause();
            controller.Pause();
            isPaused = true;
            timer = 0;

            //Exception handling for exceeding audio timeline
            if (audioCurrentTime + 1 <= maxAudioTime)
            {
                //increment audio time
                audioController.time = audioCurrentTime + 1;
            }

            //Exception handling and audio/video syncing if increment is engaged at end of sequence
            controller.time = videoCurrentTime + 1;
            if (controller.time >maxTime)
            {

                controller.time = maxTime;
                audioController.time = maxAudioTime;
            }

            //Ensuring values match altered values
            videoCurrentTime = controller.time;
            audioCurrentTime = audioController.time;
        }

    }

    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
    //        Debug.Log("Trigger is down");
    //        Sphere.GetComponent<MeshRenderer>().enabled = true;
    }
        //Set cu
}
