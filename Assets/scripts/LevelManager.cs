using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public void loadLevel(string name)
    {
        if (name == "") return;

        SceneManager.LoadScene(name);
    }
}
