using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Yarn.Unity;

public class CarController : MonoBehaviour
{

    public MyYarnCommands yarnCommands;
    public int currentLap;
    public int currentStop;
    public float currentSpeed;

    public GameObject RLT1;
    public GameObject RLT2;
    public GameObject RLT3;
    public GameObject RLT4;
    public GameObject RLT5;
    public GameObject RLT6;
    public GameObject PLT1;
    public GameObject PLT2;
    public GameObject PLT3;

    public GameObject currentTarget;



    public InMemoryVariableStorage yarnInMemoryVariableStorage;

    public Material soft, medium, hard;

    public GameObject[] Tyres;

    public bool addedLap;
    public bool stopped;

    public string currentTyres;
    public string tyreChoice;
    


    // Start is called before the first frame update
    void Start()
    {
        currentTarget = RLT1;
        currentLap = 0; 
        currentStop = 0;
        currentSpeed = 7.5f;
        tyreChoice = "";
    }

    // Update is called once per frame
    void Update()
    {


        if (yarnCommands.raceStarted == true && currentLap <= yarnCommands.raceLength)
        {
            transform.LookAt(currentTarget.transform.position);
            transform.position = Vector3.MoveTowards(transform.position, currentTarget.transform.position, currentSpeed * Time.deltaTime);
        }

        if (currentStop == 0)
        {
            yarnInMemoryVariableStorage.TryGetValue("$tyreChoice1", out currentTyres);
        }
        else if (currentStop == 1 && currentLap < yarnCommands.pitstop2Lap)
        {
            yarnInMemoryVariableStorage.TryGetValue("$tyreChoice2", out currentTyres);
        }
        else if (currentStop == 1 && currentLap >= yarnCommands.pitstop2Lap)
        {
            yarnInMemoryVariableStorage.TryGetValue("$tyreChoice3", out currentTyres);
        }
    }



    public void OnTriggerEnter(Collider other)
    {


        if (other.tag == "RLT1")
        {
            if (currentLap != yarnCommands.pitstop1Lap && currentLap != yarnCommands.pitstop2Lap)
            {
                currentTarget = RLT2;
                while (addedLap == false)
                {
                    currentLap = currentLap + 1;
                    if (currentTyres == "softs")
                    {
                        currentSpeed = currentSpeed - 0.3f;
                    }
                    else if (currentTyres == "mediums")
                    {
                        currentSpeed = currentSpeed - 0.2f;
                    }
                    else if (currentTyres == "hards")
                    {
                        currentSpeed = currentSpeed - 0.1f;
                    }

                    addedLap = true;
                }
            }
            else
            {
                currentTarget = PLT1;
                while (addedLap == false)
                {
                    currentLap = currentLap + 1;
                    addedLap = true;
                    currentSpeed = 7;
                }
            }
        }

        if (other.tag == "RLT2")
        {
            currentTarget = RLT3;
        }
        if (other.tag == "RLT3")
        {
            currentTarget = RLT4;
        }
        if (other.tag == "RLT4")
        {
            currentTarget = RLT5;
        }
        if (other.tag == "RLT5")
        {
            currentTarget = RLT6;
        }
        if (other.tag == "RLT6")
        {
            currentTarget = RLT1;
            addedLap = false;
        }


        if (other.tag == "PLT1")
        {
            currentTarget = PLT2;
        }
        if (other.tag == "PLT2")
        {
            currentTarget = PLT3;
            updateTyres();
            while (stopped == false)
             {
                currentStop = currentStop + 1;
                stopped = true;
             }
        }

        if (other.tag == "PLT3")
        {
            currentTarget = RLT2;
        }

    }


    public void updateTyres()
    {

        Debug.Log("changing tyres");


        if (currentStop == 0)
        {
            yarnInMemoryVariableStorage.TryGetValue("$tyreChoice2", out tyreChoice);
            Debug.Log(tyreChoice.ToString());
        }
        else if (currentStop == 1)
        {
            yarnInMemoryVariableStorage.TryGetValue("$tyreChoice3", out tyreChoice);
            Debug.Log(tyreChoice.ToString());
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
            Debug.Log("switching to softs");
        }
        else if (tyreChoice == "mediums")
        {
            for (int i = 0; i < Tyres.Length; i++)
            {
                Tyres[i].GetComponent<MeshRenderer>().enabled = true;
                Tyres[i].GetComponent<MeshRenderer>().material = medium;
            }
            Debug.Log("switching to mediums");
        }
        else if (tyreChoice == "hards")
        {
            for (int i = 0; i < Tyres.Length; i++)
            {
                Tyres[i].GetComponent<MeshRenderer>().enabled = true;
                Tyres[i].GetComponent<MeshRenderer>().material = hard;
            }
            Debug.Log("switching to hards");
        }
        else
        {
            Debug.LogError("error: could not find tyre choice");
        }
    }

}
