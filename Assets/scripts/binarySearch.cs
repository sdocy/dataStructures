using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class binarySearch : MonoBehaviour {
    const int arraySize = arrayCtrl.maxArraySize;
    public programWalkThru walkThru;
    public arrayCtrl arrCtrl;
    Coroutine runningCo;


    //
    // int binarySearchIterative(int[] arr, int size, int val) {
    //     int low = 0, high = size - 1, mid;
    //     int retVal = -1;
    //
    //     while (low <= high) {
    //         mid = (low + high) / 2;
    //         if (arr[mid] == val) {
    //             retVal = mid;
    //             break;
    //         }
    //
    //         if (val < arr[mid]) {
    //             high = mid - 1;
    //         } else {
    //             low = mid + 1;
    //         }
    //     }
    //
    //     return retVal;
    // }
    IEnumerator binarySearchIterative(int[] arr, int size, int val) {
        int low = 0, high = size - 1, mid = 1;                      // init mid to 1 for tag initial tag clearing
        int retVal = -1;

        // simulation variables for clearing old array tags
        int oldTagPos = 0;

        // display function parameter variables
        walkThru.shine(0);
        walkThru.setVar(0, "size = " + size);
        walkThru.setVar(1, "val = " + val);
        arrCtrl.initArray(arr, size);
        while (walkThru.isPaused) yield return null;
        yield return new WaitForSeconds(programWalkThru.walkDelay);

        // display local variables
        walkThru.shine(1);
        walkThru.setVar(2, "low = " + low);
        walkThru.setVar(3, "high = " + high);
        walkThru.setVar(4, "mid = undefined");
        arrCtrl.updateArrayTag(low, "l", 1);
        arrCtrl.updateArrayTag(high, "h", 1);
        while (walkThru.isPaused) yield return null;
        yield return new WaitForSeconds(programWalkThru.walkDelay);

        // display local variables
        walkThru.shine(2);
        walkThru.setVar(5, "retVal = " + retVal);
        while (walkThru.isPaused) yield return null;
        yield return new WaitForSeconds(programWalkThru.walkDelay);

        // highlight while-loop for initial while entry
        walkThru.shine(4);
        while (walkThru.isPaused) yield return null;
        yield return new WaitForSeconds(programWalkThru.walkDelay);
        /**/while (low <= high) {
            // save old mid value for clearing old mid array tag
            oldTagPos = mid;

            /**/mid = (low + high) / 2;
            // update variable value
            walkThru.shine(5);
            walkThru.setVar(4, "mid = " + mid);
            while (walkThru.isPaused) yield return null;
            yield return new WaitForSeconds(programWalkThru.walkDelay);

            // add a comparison
            arrCtrl.addCompare();

            // highlight conditional and array element being checked
            walkThru.shine(6);
            arrCtrl.updateArrayElem(mid, arr[mid].ToString());
            arrCtrl.updateArrayTag(mid, "m", oldTagPos);
            while (walkThru.isPaused) yield return null;
            yield return new WaitForSeconds(programWalkThru.walkDelay);
            /**/if (arr[mid] == val) {

                /**/retVal = mid;
                // update variable value
                walkThru.shine(7);
                walkThru.setVar(5, "retVal = " + retVal);
                while (walkThru.isPaused) yield return null;
                yield return new WaitForSeconds(programWalkThru.walkDelay);

                // highlight break statement
                walkThru.shine(8);
                while (walkThru.isPaused) yield return null;
                yield return new WaitForSeconds(programWalkThru.walkDelay);
                /**/break;
            }

            // highlight conditional
            walkThru.shine(11);
            while (walkThru.isPaused) yield return null;
            yield return new WaitForSeconds(programWalkThru.walkDelay);
            /**/if (val < arr[mid]) {

                oldTagPos = high;
                /**/high = mid - 1;
                // update variable value
                walkThru.shine(12);
                walkThru.setVar(3, "high = " + high);
                arrCtrl.updateArrayTag(high, "h", oldTagPos);
                while (walkThru.isPaused) yield return null;
                yield return new WaitForSeconds(programWalkThru.walkDelay);
            }

            //} else {                  // replace else with second if so we can instrument it
            // highlight conditional
            walkThru.shine(13);
            while (walkThru.isPaused) yield return null;
            yield return new WaitForSeconds(programWalkThru.walkDelay);
            /**/if (val > arr[mid]) {

                oldTagPos = low;
                /**/low = mid + 1;
                // update variable value
                walkThru.shine(14);
                walkThru.setVar(2, "low = " + low);
                arrCtrl.updateArrayTag(low, "l", oldTagPos);
                while (walkThru.isPaused) yield return null;
                yield return new WaitForSeconds(programWalkThru.walkDelay);
            }

            /**while**/
            // highlight while-loop
            walkThru.shine(4);
            while (walkThru.isPaused) yield return null;
            yield return new WaitForSeconds(programWalkThru.walkDelay);
        }

        // highlight return statement
        walkThru.shine(18);
        while (walkThru.isPaused) yield return null;
        yield return new WaitForSeconds(programWalkThru.walkDelay);
        // return retVal;     but coroutine can't return a value, so comment it out

        // wrap up algorithm execution
        walkThru.postProcessing();
    }

    // execute the specified version of the algorithm
    public void execProg(int version) {
        // an array for us to sort
        int[] arr = new int[arraySize] { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26 };
        int searchFor = 10;

        // in case we are restarting after stopping walkThru
        arrCtrl.clearAllArrayTags();

        switch (version) {
            case 1:
                runningCo = StartCoroutine(binarySearchIterative(arr, arraySize, searchFor));
                break;
            default:
                Debug.Log("Attempted to execute illegal algorithm version " + version);
                break;
        }
    }

    // stop program execution
    public void stopProg() {
        StopCoroutine(runningCo);
    }

    // Use this for initialization
    void Start () {
        // give the walkThru code the functions to call for starting and stopping execution
        walkThru.setExecCallBack(execProg);
        walkThru.setStopCallBack(stopProg);
    }
}
