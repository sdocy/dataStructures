using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Implements highlighting of algorithm code lines and setting/updating variables
public class programWalkThru : MonoBehaviour {
    const int numLinesSupported = 27;                           // maximum number of program lines
    const int numVarsSupported = 10;                            // maximum number of variable lines (not counting array)
    public const float watchDelay = 0.5f;                       // a good delay time for watching the algorithm in progress
    const float readDelay = 3.0f;                               // a good delay for understanding what the algorithm is doing

    public static float walkDelay = watchDelay;                 // delay currently being used
    public bool isPaused = false;                               // is the wlkThru currently paused?

    public Text[] program = new Text[numLinesSupported];        // text objects displaying algorithm code
    public Text[] variables = new Text[numVarsSupported];       // text objects disaplying variable values
    public Text forwardButton;
    public Text fastForwardButton;
    public Text stepThruText;                                   // tells user how to step through the text one line at a time
    public Button startButton;
    public Text finishedText;               // Text to display "Finished."

    int prevShineLine = -1;                             // the line that was previously shined, need to return it to original color
    Color prevColor;                                    // original program text color
    bool running = false;                               // is the walkThru currently running?

    public delegate void execCallBack(int version);     // callback to execute the algorithm specific to this scene
    execCallBack execCB;
    public delegate void stopCallBack();                // callback to stop the algorithm specific to this scene
    stopCallBack stopCB;

    // change the color of a Text after a delay
    // used to return program line to original color after highlighting
    IEnumerator returnToColor(Text txt, Color clr) {
        yield return new WaitForSeconds(watchDelay);
        txt.color = clr;
    }

    // set the variable at `line` to `txt`
    public void setVar(int line, string txt) {
        if (line < 0) return;

        // higlight variable
        variables[line].text = txt;
        variables[line].color = Color.white;

        // return variable to original color, after delay
        StartCoroutine(returnToColor(variables[line], prevColor));
    }

    // highlight the specied program line, turning off previously highlighted
    // program line fo there is one
    public void shine(int line) {
        if (line < 0) return;

        // turn off highlight on program line currently hightlighted, if there is one
        if (prevShineLine != -1) {
            program[prevShineLine].color = prevColor;

        }

        // highlight this program line and set it as the currently highlighted line
        prevShineLine = line;
        program[line].color = Color.white;
    }

    // player pushed 'forward' button, set walk through delay accordingly
    public void setForward() {
        walkDelay = readDelay;
        fastForwardButton.color = Color.green;
        forwardButton.color = Color.white;
    }

    // player pushed 'fast forward' button, set walk through delay accordingly
    public void setFastForward() {
        walkDelay = watchDelay;
        forwardButton.color = Color.green;
        fastForwardButton.color = Color.white;
    }

    // player hit 'stop' button, stop the walk through and set correct
    // button and walk through state
    public void stopWalkThru() {
        startButton.GetComponentInChildren<Text>().text = "Execute";
        stopCB();
        running = false;
        isPaused = false;
        stepThruText.gameObject.SetActive(false);
    }

    // player hit the main control button, can be used to start, pause, or resume
    // walk through based on current walk through state
    public void execProgram(int version) {
        if (!running) {
            // walkThru not started yet, start it
            finishedText.gameObject.SetActive(false);
            startButton.GetComponentInChildren<Text>().text = "Pause";
            running = true;
            execCB(version);
        }
        else if (isPaused) {
            // walkThru paused, resume it
            isPaused = false;
            startButton.GetComponentInChildren<Text>().text = "Pause";
            stepThruText.gameObject.SetActive(false);
        }
        else {
            // walkThru running, pause it
            isPaused = true;
            startButton.GetComponentInChildren<Text>().text = "Resume";
            stepThruText.gameObject.SetActive(true);
        }
    }

    // show "Finished." on screen and reset walk through state to allow restarting
    public void postProcessing() {
        // display "Finshed." on screen
        finishedText.gameObject.SetActive(true);

        programFinished();
    }

    // program has completed, set it up so user can restart if they want
    void programFinished() {
        startButton.GetComponentInChildren<Text>().text = "Restart";
        running = false;
    }

    // function to call to execute the algorithm
    public void setExecCallBack(execCallBack cb) {
        execCB = cb;
    }

    // function to call to stop execution of the algorithm
    public void setStopCallBack(stopCallBack cb) {
        stopCB = cb;
    }

    void Start() {
        // capture original text color
        prevColor = program[0].color;
        finishedText.gameObject.SetActive(false);
    }
}
