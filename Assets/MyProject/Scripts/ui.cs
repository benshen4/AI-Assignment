using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ui : MonoBehaviour
{

    public MyYarnCommands yarnCommands;
    public CarController carController;
    public TMP_Text lapsText;
    public TMP_Text speedText;
    public TMP_Text tyresText;


    // Update is called once per frame
    void Update()
    {
        if (yarnCommands.raceStarted == true)
        {
            speedText.text = ("Speed = ") + carController.currentSpeed.ToString();
            lapsText.text = carController.currentLap.ToString() + (" / ") + yarnCommands.raceLength;
            tyresText.text = ("Current Tyres: ") + carController.currentTyres.ToString();
        }

        else
        {
            lapsText.text = ("N/A");
            speedText.text = ("N/A");
            tyresText.text = ("N/A");
        }
    }
}
