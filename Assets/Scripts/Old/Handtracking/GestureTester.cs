using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureTester : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void TestGesture(string gestureName) {
        Debug.Log(gestureName + " is now executed");
    }
}