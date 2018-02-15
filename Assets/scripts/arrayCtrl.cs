using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class arrayCtrl : MonoBehaviour {
    public const int maxArraySize = 13;
    public Text[] arrayText = new Text[maxArraySize];
    public Text[] arrayTagText = new Text[maxArraySize];

    Color prevColor;                                            // original array text color

    IEnumerator returnToOrigColor(Text txt)
    {
        yield return new WaitForSeconds(programWalkThru.watchDelay);
        txt.color = prevColor;
    }

    public void initArray(int[] arr, int size)
    {
        int i;

        if (arr == null)
        {
            Debug.Log("initArray() passed null array");
            return;
        }

        if ((size < 0) || (size > maxArraySize))
        {
            Debug.Log("initArray() passed illegal size " + size);
            return;
        }

        for (i = 0; i < size; i++)
        {
            arrayText[i].text = arr[i].ToString();
        }
    }

    public void updateArrayElem(int index, string val)
    {
        if ((index < 0) || (index > maxArraySize))
        {
            Debug.Log("updateArrayElem() passed illegal index " + index);
            return;
        }

        arrayText[index].text = val;
        arrayText[index].color = Color.white;
        StartCoroutine(returnToOrigColor(arrayText[index]));
    }

    public void updateArrayTag(int index, string val, int oldIndex)
    {
        if ((index < 0) || (index > maxArraySize))
        {
            Debug.Log("updateArrayTag() passed illegal index " + index);
            return;
        }

        if (oldIndex > maxArraySize)
        {
            Debug.Log("updateArrayTag() passed illegal oldIndex " + oldIndex);
            return;
        }

        if (oldIndex >= 0)
        {
            arrayTagText[oldIndex].text = "";
        }

        arrayTagText[index].text = val;
    }

    public void clearAllArrayTags()
    {
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
	
	// Update is called once per frame
	void Update () {
		
	}
}
