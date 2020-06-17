using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * @author Orion Qin
 */

public class ProximityParticle : MonoBehaviour
{
    private GameObject player;
    public GameObject parentObj;
    public ParticleSystem happyMode;
    public ParticleSystem sadMode;
    public ParticleSystem defaultMode;
    private int state;
    private int lastState;
    private int newState;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        defaultMode.Play();
        state = 0;
        lastState = -1;
        newState = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.V))
        {
            // Switch to happy state
            state = 1;
            //Notify state change
            newState = state;
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            // Switch to sad state
            state = 2;
            //Notify state change
            newState = state;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            // Back t default state
            state = 0;
            //Notify state change
            newState = state;
        }

        if (Vector3.Distance(player.transform.position, parentObj.transform.position) < 7)
        {

            //Happy Mode
            if (state == 1 && lastState != newState)
            {
                happyMode.Play();
                defaultMode.Stop();
                sadMode.Stop();

                //Obtain the last state
                lastState = newState;

            } else

            //Sad Mode
            if (state == 2 && lastState != newState)
            {
                happyMode.Stop();
                defaultMode.Stop();
                sadMode.Play();

                //Obtain the last state
                lastState = newState;

            } else 

            //Default Mode
            if (state == 0 && lastState != newState)
            {
                happyMode.Stop();
                defaultMode.Play();
                sadMode.Stop();

                //Obtain the last state
                lastState = newState;
            }

        }


    }
}
