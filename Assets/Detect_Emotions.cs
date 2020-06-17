using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * @author Orion Qin
 */
public class Detect_Emotions : MonoBehaviour
{
    public ParticleSystem mode;
    public int state;
    private int mood;
    private int lastState;
    private int newState;

    // Start is called before the first frame update
    void Start()
    {
        
        if (state == 0)
            mode.Play();
    }




    // Update is called once per frame
    void Update()
    {
        //Obtain last state
        lastState = mood;
        if (Input.GetKeyDown(KeyCode.V))
        {
            // Switch to happy state
            mood = 1;
            //Notify state change
            newState = mood;
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            // Switch to sad state
            mood = 2;
            //Notify state change
            newState = mood;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            // Back t default state
            mood = 0;
            //Notify state change
            newState = mood;
        }

        if (lastState != newState && mood == state)
        {
            mode.Play();

        }
        if (mood != state)
        {
            mode.Stop();
        }
        

    }


}