using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class programWalkThru : MonoBehaviour{
    const int numLinesSupported = 27;                           // maximum n umber of program lines
    const int numVarsSupported = 10;                            // maximum number of variable lines (not counting array)
    public const float watchDelay = 0.5f;                       // a good delay time for watching the algorithm in progress
    const float readDelay = 3.0f;                               // a good delay for understanding what the algorithm is doing

    public static float walkDelay = watchDelay;                 // delay currently being used
    public bool isPaused = false;                               // is the wlkThru currently paused?

    public Text[] program = new Text[numLinesSupported];
    public Text[] variables = new Text[numVarsSupported];
    public Text forwardButton;
    public Text fastForwardButton;
    public Text stepThruText;
    public Button startButton;

    int prevShineLine = -1;                             // the line that was previously shined, need to return it to original color
    Color prevColor;                                    // original program text color
    bool running = false;                               // is the walkThru currently running?

    public delegate void execCallBack(int version);     // callback to execute the algorithm specific to this scene
    execCallBack execCB;
    public delegate void stopCallBack();                // callback to stop the algorithm specific to this scene
    stopCallBack stopCB;

    IEnumerator returnToOrigColor(Text txt)
    {
        yield return new WaitForSeconds(watchDelay);
        txt.color = prevColor;
    }

    public void setVar(int line, string txt)
    {
        if (line < 0) return;

        variables[line].text = txt;
        variables[line].color = Color.white;
        StartCoroutine(returnToOrigColor(variables[line]));
    }

    public void shine(int line)
    {
        if (line < 0) return;

        if (prevShineLine != -1)
        {
            program[prevShineLine].color = prevColor;
            
        }
        prevShineLine = line;
        program[line].color = Color.white;
    }

    public void setForward()
    {
        walkDelay = readDelay;
        fastForwardButton.color = Color.green;
        forwardButton.color = Color.white;
    }

    public void setFastForward()
    {
        walkDelay = watchDelay;
        forwardButton.color = Color.green;
        fastForwardButton.color = Color.white;
    }

    public void stopWalkThru()
    {
        startButton.GetComponentInChildren<Text>().text = "Execute";
        stopCB();
        running = false;
        isPaused = false;
        stepThruText.gameObject.SetActive(false);
    }

    public void execProgram(int version)
    {
        if (!running)
        {
            // walkThru not started yet, start it
            startButton.GetComponentInChildren<Text>().text = "Pause";
            running = true;
            execCB(version);
        }
        else if (isPaused)
        {
            // walkThru paused, resume it
            isPaused = false;
            startButton.GetComponentInChildren<Text>().text = "Pause";
            stepThruText.gameObject.SetActive(false);
        }
        else
        {
            // walkThru running, pause it
            isPaused = true;
            startButton.GetComponentInChildren<Text>().text = "Resume";
            stepThruText.gameObject.SetActive(true);
        }
    }

    public void setExecCallBack(execCallBack cb)
    {
        execCB = cb;
    }

    public void setStopCallBack(stopCallBack cb)
    {
        stopCB = cb;
    }

    // Use this for initialization
    void Start () {
        // capture original text color
        prevColor = program[0].color;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
