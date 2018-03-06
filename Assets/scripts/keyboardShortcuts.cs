using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// implements hotkey shortcuts for tutorial navigation buttons
public class keyboardShortcuts : MonoBehaviour {

    public string myKeyPress;                   // set in editor to set a different hotkey per button

    // look for hotkey press
    void Update() {
        if (Input.GetKeyDown(myKeyPress)) {
            // results in a cool looking, quick flash when the hotkey is pressed
            // before switching scenes
            ColorBlock colors = GetComponent<Button>().colors;
            colors.normalColor = Color.white;
            GetComponent<Button>().colors = colors;
            GetComponent<Button>().onClick.Invoke();
        }
    }
}
