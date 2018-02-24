using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keyboardShortcuts : MonoBehaviour {

    public string myKeyPress;                   // set in editor per button

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(myKeyPress)) {
            ColorBlock colors = GetComponent<Button>().colors;
            colors.normalColor = Color.white;
            GetComponent<Button>().colors = colors;
            GetComponent<Button>().onClick.Invoke();
        }
    }
}
