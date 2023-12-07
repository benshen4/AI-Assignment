using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Yarn.Unity;

public class StartRace : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }


    //can move all this to myyarncommnads c# script.... new yarn command. declare variables from within...
    public InMemoryVariableStorage yarnInMemoryVariableStorage;

    public int raceDistance;
    public int numberOfStops;
    public bool raceComplete;
    public float speedMultiplier;

    //racedistance = yarnmemory racedistance
    //numberofstops = yarnmemory numberofstops
    //if numberofstops = 1, declare stint 1/2 ... calculate lengths
    //else = 2, declare stint 1/2/3 ... calculate lengths


    //firstly calculate race distance
    //calculate stops
    //calculate how many laps per stint

    // do while laps < raceDistance
    //   if normal lap
    //         run lap X times  (lap count +1)
    //             speedMultiplier = speedMultiplier - (0.2*tyreValue)
    //    else if pitstop
    //          run pitstop + outlap (lap count +1)
    //          tyrecolour change through yarn
    //          tyreValue change (1 for soft, 0.75 for med, 0.5 for hard)
    // end

    //bool raceFinished     set to true at end - to advance scene dialogue



}
