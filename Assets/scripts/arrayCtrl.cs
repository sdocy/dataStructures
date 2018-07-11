using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Implements array visualization, including
//    - initializing array
//    - changing the value of an array element, and highlighting the value which changed
//    - displaying array tag
//    - clearing all array-tags for start of new algorithm execution
public class arrayCtrl : MonoBehaviour {
    public const int maxArraySize = 13;
    public Text[] arrayText = new Text[maxArraySize];           // the array to sort
    public Text[] arrayTagText = new Text[maxArraySize];        // shows where the index of a for-loop counter currently points to within the array

    int numCompares = 0;
    public Text numComparesText;            // Text for displaying the number of compares performed

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

    // make sure there are no index tags displayed above the array
    // and reset the number of comparisons
    public void clearAllArrayTags() {
        int i;

        for (i = 0; i < maxArraySize; i++)
        {
            arrayTagText[i].text = "";
        }

        numCompares = 0;
        numComparesText.text = "# of comparisons : " + numCompares.ToString();
    }

    // count the comparison of array element to our value,
    // the basic performance criteria for search algorithms,
    // and update count displayed to screen
    public void addCompare() {
        numCompares++;
        numComparesText.text = "# of comparisons : " + numCompares.ToString();
    }

    void Start () {
        // capture original text color
        prevColor = arrayText[0].color;
    }
}
