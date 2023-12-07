using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class MyYarnCommands : MonoBehaviour
{

    public InMemoryVariableStorage yarnInMemoryVariableStorage;

    public Material soft, medium, hard;

    public GameObject[] Tyres;






    void Start()
    {
        
    }


    void Update()
    {
        
    }


    [YarnCommand("change_tyres")]
    public void changeTyres()
    {
        string tyreNumber;
        yarnInMemoryVariableStorage.TryGetValue("$tyreNumber", out tyreNumber);

        string tyreChoice = "";

        if (tyreNumber == "1")
        {
            yarnInMemoryVariableStorage.TryGetValue("$tyreChoice1", out tyreChoice);
        }
        else if (tyreNumber == "2")
        {
            yarnInMemoryVariableStorage.TryGetValue("$tyreChoice2", out tyreChoice);
        }
        else if (tyreNumber == "3")
        {
            yarnInMemoryVariableStorage.TryGetValue("$tyreChoice3", out tyreChoice);
        }
        else
        {
            Debug.LogError("error finding tyre number");
        }



        if (tyreChoice == "softs")
        {
            for (int i = 0; i < Tyres.Length; i++)
            {
                Tyres[i].GetComponent<MeshRenderer>().enabled = true;
                Tyres[i].GetComponent<MeshRenderer>().material = soft;
            }
        }
        else if (tyreChoice == "mediums")
        {
            for (int i = 0; i < Tyres.Length; i++)
            {
                Tyres[i].GetComponent<MeshRenderer>().enabled = true;
                Tyres[i].GetComponent<MeshRenderer>().material = medium;
            }
        }
        else if (tyreChoice == "hards")
        {
            for (int i = 0; i < Tyres.Length; i++)
            {
                Tyres[i].GetComponent<MeshRenderer>().enabled = true;
                Tyres[i].GetComponent<MeshRenderer>().material = hard;
            }
        }
        else
        {
            Debug.LogError("error: could not find tyre choice");
        }
    }


    public double pitstop1Lap;
    public double pitstop2Lap;



    [YarnCommand("start_Race")]
    public void startRace()
    {

        float raceLength;
        yarnInMemoryVariableStorage.TryGetValue("$raceLength", out raceLength);

        string raceStops;
        yarnInMemoryVariableStorage.TryGetValue("$numberOfStops", out raceStops);

        if (raceStops == "1")
        {
            pitstop1Lap = Math.Round(raceLength / 2);
            string tyreChoice = "";
            yarnInMemoryVariableStorage.TryGetValue("$tyreChoice1", out tyreChoice);
            if (tyreChoice == "softs")
            {
                pitstop1Lap = Math.Round(pitstop1Lap - (0.2*raceLength));
            }
            if (tyreChoice == "hards")
            {
                pitstop1Lap = Math.Round(pitstop1Lap + (0.2*raceLength));
            }
        }

        else if (raceStops == "2")
        {
            pitstop1Lap = Math.Round(raceLength / 3);
            string tyreChoice1 = "";
            yarnInMemoryVariableStorage.TryGetValue("$tyreChoice1", out tyreChoice1);
            if (tyreChoice1 == "softs")
            {
                pitstop1Lap = Math.Round(pitstop1Lap - (0.1 * raceLength));
            }
            if (tyreChoice1 == "hards")
            {
                pitstop1Lap = Math.Round(pitstop1Lap + (0.1 * raceLength));
            }

            //pitstop2Lap = Math.Round(raceLength / 1.5);
            //Debug.Log(pitstop2Lap);
            string tyreChoice2 = "";
            yarnInMemoryVariableStorage.TryGetValue("$tyreChoice2", out tyreChoice2);
            if (tyreChoice2 == "softs")
            {
                //pitstop2Lap = Math.Round(pitstop2Lap - (0.1 * raceLength));
                pitstop2Lap = Math.Round(pitstop1Lap + (0.1 * raceLength));
            }
            else if (tyreChoice2 == "mediums")
            {
                pitstop2Lap = Math.Round(pitstop1Lap + (0.2 * raceLength));
            }
            else
            {
                pitstop2Lap = Math.Round(pitstop1Lap + (0.3*raceLength));
            }
        }

        Debug.Log(pitstop1Lap);
        Debug.Log(pitstop2Lap);

    }




}
