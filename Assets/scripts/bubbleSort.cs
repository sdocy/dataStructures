using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Implements instrumented versions of the bubble sort sorting algorithm.
// Three versions of bubble sort are currently implemented :
//    - basic naive approach with two nested for-loops
//    - switch outer for-loop for a while-loop to detect when array is sorted (no swaps occurred)
//    - don't iterate over elements at the end of the array which are already in order
public class bubbleSort : MonoBehaviour {
    const int arraySize = arrayCtrl.maxArraySize;
    public programWalkThru walkThru;
    public arrayCtrl arrCtrl;
    Coroutine runningCo;


    //
    // Code instrumentation, these instructions update
    // the text info displayed on the screen for the
    // executing algorithm.
    //
    // walkThru.shine(n);                                               - highlight the line of code at index 'n', turning off the prior highlighted line of code
    // walkThru.setVar(n, "value");                                     - set the text for the variable at index 'n' to the specified value
    // arrCtrl.initArray(array, array_size);                            - initialize the on-screen array using the specified array and array size
    // arrCtrl.updateArrayElem(n, "value");                             - set the on-sreen array value at index 'n' to the specified value
    // arrCtrl.updateArrayTag(n, "value", m);                           - update the tag for the on-screen array, setting the index tag at 'n' to the specified value, and turning off the tag at index `m`
    // while (walkThru.isPaused) yield return null;                     - if code walk thru is paused, wait here until it is unpaused
    // yield return new WaitForSeconds(programWalkThru.walkDelay);      - delay execution of the next line of algorithm code or instrumentation code so the user can follow along
    // postProcessing();                                                - do whatever needs to be done after the algorithm has finished executing
    // /**/                                                             - precedes lines of the actual algorithm I am instrumenting 


    //
    // void bSort1(int[] arr, int size) {
    //     int i, j, tmp;
    //
    //     for (i = 0; i < size - 1; i++) {
    //         for (j = 0; j < size - 1; j++) {
    //             if (arr[j] > arr[j + 1]) {
    //                 tmp = arr[j];
    //                 arr[j] = arr[j + 1];
    //                 arr[j + 1] = tmp;
    //             }
    //         }
    //     }
    // }
    //
    IEnumerator bSort1(int[] arr, int size) {
        int i, j, tmp;

        // display function parameter variables
        walkThru.shine(0);
        walkThru.setVar(0, "size = " + size);
        arrCtrl.initArray(arr, size);
        while (walkThru.isPaused) yield return null;
        yield return new WaitForSeconds(programWalkThru.walkDelay);

        // display local variables
        walkThru.shine(1);
        walkThru.setVar(1, "i = undefined");
        walkThru.setVar(2, "j = undefined");
        walkThru.setVar(3, "tmp = undefined");
        while (walkThru.isPaused) yield return null;
        yield return new WaitForSeconds(programWalkThru.walkDelay);

        // highlight outer for-loop, set value of counter variable
        walkThru.shine(3);
        walkThru.setVar(1, "i = 0");
        while (walkThru.isPaused) yield return null;
        yield return new WaitForSeconds(programWalkThru.walkDelay);
        /**/for (i = 0; i < size - 1; i++) {

            // highlight inner for-loop, set value of counter variable
            walkThru.shine(4);
            walkThru.setVar(2, "j = 0");
            arrCtrl.updateArrayTag(0, "j", size - 1);
            while (walkThru.isPaused) yield return null;
            yield return new WaitForSeconds(programWalkThru.walkDelay);
            /**/for (j = 0; j < size - 1; j++) {

                // add a comparison
                arrCtrl.addCompare();

                // highlight conditional
                walkThru.shine(5);
                while (walkThru.isPaused) yield return null;
                yield return new WaitForSeconds(programWalkThru.walkDelay);
                /**/if (arr[j] > arr[j + 1]) {

                    /**/tmp = arr[j];
                    // update variable value
                    walkThru.shine(6);
                    walkThru.setVar(3, "tmp = " + tmp);
                    while (walkThru.isPaused) yield return null;
                    yield return new WaitForSeconds(programWalkThru.walkDelay);

                    /**/arr[j] = arr[j + 1];
                    // update array element value
                    walkThru.shine(7);
                    arrCtrl.updateArrayElem(j, arr[j].ToString());
                    while (walkThru.isPaused) yield return null;
                    yield return new WaitForSeconds(programWalkThru.walkDelay);

                    /**/arr[j + 1] = tmp;
                    // update array element value
                    walkThru.shine(8);
                    arrCtrl.updateArrayElem(j + 1, arr[j + 1].ToString());
                    while (walkThru.isPaused) yield return null;
                    yield return new WaitForSeconds(programWalkThru.walkDelay);
                }

                /**for**/
                // highlight inner for-loop, set value of counter variable
                walkThru.shine(4);
                walkThru.setVar(2, "j = " + (j + 1));
                arrCtrl.updateArrayTag(j + 1, "j", j);
                while (walkThru.isPaused) yield return null;
                yield return new WaitForSeconds(programWalkThru.walkDelay);
            }

            /**for**/
            // highlight outer for-loop, set value of counter variable
            walkThru.shine(3);
            walkThru.setVar(1, "i = " + (i + 1));
            while (walkThru.isPaused) yield return null;
            yield return new WaitForSeconds(programWalkThru.walkDelay);
        }
        // highlight final closing bracket
        walkThru.shine(11);

        // wrap up algorithm execution
        walkThru.postProcessing();
    }


    //
    // void bSort2(int[] arr, int size) {
    //     int j, tmp;
    //     bool sorted = false;
    //
    //     while (!sorted) {
    //         sorted = true;
    //         for (j = 0; j < size - 1; j++) {
    //             if (arr[j] > arr[j + 1]) {
    //                 tmp = arr[j];
    //                 arr[j] = arr[j + 1];
    //                 arr[j + 1] = tmp;
    //                 sorted = false;
    //             }
    //         }
    //     }
    // }
    //
    IEnumerator bSort2(int[] arr, int size) {
        int j, tmp;
        bool sorted = false;

        // display function parameter variables
        walkThru.shine(0);
        walkThru.setVar(0, "size = " + size);
        arrCtrl.initArray(arr, size);
        while (walkThru.isPaused) yield return null;
        yield return new WaitForSeconds(programWalkThru.walkDelay);

        // display local variables
        walkThru.shine(1);
        walkThru.setVar(1, "j = undefined");
        walkThru.setVar(2, "tmp = undefined");
        while (walkThru.isPaused) yield return null;
        yield return new WaitForSeconds(programWalkThru.walkDelay);

        // display local variables
        walkThru.shine(2);
        walkThru.setVar(3, "sorted = " + sorted);
        while (walkThru.isPaused) yield return null;
        yield return new WaitForSeconds(programWalkThru.walkDelay);

        // highlight while-loop for initial while entry
        walkThru.shine(4);
        while (walkThru.isPaused) yield return null;
        yield return new WaitForSeconds(programWalkThru.walkDelay);
        /**/while (!sorted) {

            /**/sorted = true;
            // update variable value
            walkThru.shine(5);
            walkThru.setVar(3, "sorted = " + sorted);
            while (walkThru.isPaused) yield return null;
            yield return new WaitForSeconds(programWalkThru.walkDelay);

            // highlight for-loop, set value of counter variable
            walkThru.shine(6);
            walkThru.setVar(1, "j = 0");
            arrCtrl.updateArrayTag(0, "j", size - 1);
            while (walkThru.isPaused) yield return null;
            yield return new WaitForSeconds(programWalkThru.walkDelay);
            /**/for (j = 0; j < size - 1; j++) {

                // add a comparison
                arrCtrl.addCompare();

                // highlight conditional
                walkThru.shine(7);
                while (walkThru.isPaused) yield return null;
                yield return new WaitForSeconds(programWalkThru.walkDelay);
                /**/if (arr[j] > arr[j + 1]) {

                    /**/tmp = arr[j];
                    // update variable value
                    walkThru.shine(8);
                    walkThru.setVar(2, "tmp = " + tmp);
                    while (walkThru.isPaused) yield return null;
                    yield return new WaitForSeconds(programWalkThru.walkDelay);

                    /**/arr[j] = arr[j + 1];
                    // update array element value
                    walkThru.shine(9);
                    arrCtrl.updateArrayElem(j, arr[j].ToString());
                    while (walkThru.isPaused) yield return null;
                    yield return new WaitForSeconds(programWalkThru.walkDelay);

                    /**/arr[j + 1] = tmp;
                    // update array element value
                    walkThru.shine(10);
                    arrCtrl.updateArrayElem(j + 1, arr[j + 1].ToString());
                    while (walkThru.isPaused) yield return null;
                    yield return new WaitForSeconds(programWalkThru.walkDelay);

                    /**/sorted = false;
                    // update variable value
                    walkThru.shine(11);
                    walkThru.setVar(3, "sorted = " + sorted);
                    while (walkThru.isPaused) yield return null;
                    yield return new WaitForSeconds(programWalkThru.walkDelay);
                }

                /**for**/
                // highlight for-loop, set value of counter variable
                walkThru.shine(6);
                walkThru.setVar(1, "j = " + (j + 1));
                arrCtrl.updateArrayTag(j + 1, "j", j);
                while (walkThru.isPaused) yield return null;
                yield return new WaitForSeconds(programWalkThru.walkDelay);
            }

            /**while**/
            // highlight while-loop
            walkThru.shine(4);
            while (walkThru.isPaused) yield return null;
            yield return new WaitForSeconds(programWalkThru.walkDelay);
        }
        // highlight final closing bracket
        walkThru.shine(14);

        // wrap up algorithm execution
        walkThru.postProcessing();
    }


    //
    // void bSort3(int[] arr, int size) {
    //     int j, tmp, i = 0;
    //     bool sorted = false;
    //
    //     while (!sorted) {
    //         sorted = true;
    //         for (j = 0; j < (size - 1 - i); j++) {
    //             if (arr[j] > arr[j + 1]) {
    //                 tmp = arr[j];
    //                 arr[j] = arr[j + 1];
    //                 arr[j + 1] = tmp;
    //                 sorted = false;
    //             }
    //         }
    //         i++;
    //     }
    // }
    //
    IEnumerator bSort3(int[] arr, int size) {
        int j, tmp, i = 0;
        bool sorted = false;

        // display function parameter variables
        walkThru.shine(0);
        walkThru.setVar(0, "size = " + size);
        arrCtrl.initArray(arr, size);
        while (walkThru.isPaused) yield return null;
        yield return new WaitForSeconds(programWalkThru.walkDelay);

        // display local variables
        walkThru.shine(1);
        walkThru.setVar(1, "j = undefined");
        walkThru.setVar(2, "tmp = undefined");
        walkThru.setVar(3, "i = " + i);
        while (walkThru.isPaused) yield return null;
        yield return new WaitForSeconds(programWalkThru.walkDelay);

        // display local variables
        walkThru.shine(2);
        walkThru.setVar(4, "sorted = " + sorted);
        while (walkThru.isPaused) yield return null;
        yield return new WaitForSeconds(programWalkThru.walkDelay);

        // need to initialize `j` internally here because it is used below to clear
        // the array tag at the end of each for-loop iteration, just set it to 0
        // for first iteration since there is no tag to clear
        j = 0;

        // highlight while-loop for initial while entry
        walkThru.shine(4);
        while (walkThru.isPaused) yield return null;
        yield return new WaitForSeconds(programWalkThru.walkDelay);
        /**/while (!sorted) {

            /**/sorted = true;
            // update variable value
            walkThru.shine(5);
            walkThru.setVar(4, "sorted = " + sorted);
            while (walkThru.isPaused) yield return null;
            yield return new WaitForSeconds(programWalkThru.walkDelay);

            // highlight for-loop, set value of counter variable
            walkThru.shine(6);
            walkThru.setVar(1, "j = 0");
            arrCtrl.updateArrayTag(0, "j", j);
            while (walkThru.isPaused) yield return null;
            yield return new WaitForSeconds(programWalkThru.walkDelay);
            /**/for (j = 0; j < (size - 1 - i); j++) {

                // add a comparison
                arrCtrl.addCompare();

                // highlight conditional
                walkThru.shine(7);
                while (walkThru.isPaused) yield return null;
                yield return new WaitForSeconds(programWalkThru.walkDelay);
                /**/if (arr[j] > arr[j + 1]) {

                    /**/tmp = arr[j];
                    // update variable value
                    walkThru.shine(8);
                    walkThru.setVar(2, "tmp = " + tmp);
                    while (walkThru.isPaused) yield return null;
                    yield return new WaitForSeconds(programWalkThru.walkDelay);

                    /**/arr[j] = arr[j + 1];
                    // update array element value
                    walkThru.shine(9);
                    arrCtrl.updateArrayElem(j, arr[j].ToString());
                    while (walkThru.isPaused) yield return null;
                    yield return new WaitForSeconds(programWalkThru.walkDelay);

                    /**/arr[j + 1] = tmp;
                    // update array element value
                    walkThru.shine(10);
                    arrCtrl.updateArrayElem(j + 1, arr[j + 1].ToString());
                    while (walkThru.isPaused) yield return null;
                    yield return new WaitForSeconds(programWalkThru.walkDelay);

                    /**/sorted = false;
                    // update variable value
                    walkThru.shine(11);
                    walkThru.setVar(4, "sorted = " + sorted);
                    while (walkThru.isPaused) yield return null;
                    yield return new WaitForSeconds(programWalkThru.walkDelay);
                }

                /**for**/
                // highlight for-loop, set value of counter variable
                walkThru.shine(6);
                walkThru.setVar(1, "j = " + (j + 1));
                arrCtrl.updateArrayTag(j + 1, "j", j);
                while (walkThru.isPaused) yield return null;
                yield return new WaitForSeconds(programWalkThru.walkDelay);
            }

            /**/i++;
            // update variable value
            walkThru.shine(14);
            walkThru.setVar(3, "i = " + i);
            while (walkThru.isPaused) yield return null;
            yield return new WaitForSeconds(programWalkThru.walkDelay);

            /**while**/
            // highlight while-loop
            walkThru.shine(4);
            while (walkThru.isPaused) yield return null;
            yield return new WaitForSeconds(programWalkThru.walkDelay);
        }
        // highlight final closing bracket
        walkThru.shine(15);
        
        // wrap up algorithm execution
        walkThru.postProcessing();
    }



    // execute the specified version of the algorithm
    public void execProg(int version) {
        // an array for us to sort
        int[] arr = new int[arraySize] { 11, 5, 9, 13, 4, 2, 12, 8, 1, 7, 10, 3, 6 };

        // in case we are restarting after stopping walkThru
        arrCtrl.clearAllArrayTags();

        switch (version) {
            case 1:
                runningCo = StartCoroutine(bSort1(arr, arraySize));
                break;
            case 2:
                runningCo = StartCoroutine(bSort2(arr, arraySize));
                break;
            case 3:
                runningCo = StartCoroutine(bSort3(arr, arraySize));
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
