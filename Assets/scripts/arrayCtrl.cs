using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class arrayCtrl : MonoBehaviour {
    public const int maxArraySize = 13;
    public Text[] arrayText = new Text[maxArraySize];           // the array to sort
    public Text[] arrayTagText = new Text[maxArraySize];        // matchint Texts above the array to display current array index value

    Color prevColor;                                            // original array text color

    // change the color of a Text after a delay
    // used to return array element to original color after highlighting
    IEnumerator returnToColor(Text txt, Color clr) {
        yield return new WaitForSeconds(programWalkThru.watchDelay);
        txt.color = clr;
    }

    // fill-in the array display for the array to sort
    public void initArray(int[] arr, int size) {
        int i;

        if (arr == null) {
            Debug.Log("initArray() passed null array");
            return;
        }

        if ((size < 0) || (size > maxArraySize)) {
            Debug.Log("initArray() passed illegal size " + size);
            return;
        }

        for (i = 0; i < size; i++) {
            arrayText[i].text = arr[i].ToString();
        }
    }

    // something has changed in the array, set the value at 'index' to 'val'
    // whenever something changes in the array, highlight it for user to see
    public void updateArrayElem(int index, string val) {
        if ((index < 0) || (index > maxArraySize)) {
            Debug.Log("updateArrayElem() passed illegal index " + index);
            return;
        }

        // highlight array entry
        arrayText[index].text = val;
        arrayText[index].color = Color.white;

        // return array entry to original color, after delay
        StartCoroutine(returnToColor(arrayText[index], prevColor));
    }

    // turn off old array index tag (if there is one) and turn on the
    // specified tag using the specified value
    public void updateArrayTag(int index, string val, int oldIndex) {
        if ((index < 0) || (index > maxArraySize)) {
            Debug.Log("updateArrayTag() passed illegal index " + index);
            return;
        }

        if (oldIndex > maxArraySize) {
            Debug.Log("updateArrayTag() passed illegal oldIndex " + oldIndex);
            return;
        }

        if (oldIndex >= 0) {
            arrayTagText[oldIndex].text = "";
        }

        arrayTagText[index].text = val;
    }

    // make sure there are no index tags above the array
    public void clearAllArrayTags() {
        int i;

        for (i = 0; i < maxArraySize; i++)
        {
            arrayTagText[i].text = "";
        }
    }

    // Use this for initialization
    void Start () {
        // capture original text color
        prevColor = arrayText[0].color;
    }
}
