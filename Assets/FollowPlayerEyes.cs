using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerEyes : MonoBehaviour {
    [SerializeField]
    private GameObject playerVRCamera;

    private float previousRotation;
    private float currentRotation;

    private float turningRotation;

    // Start is called before the first frame update
    void Start() {
        currentRotation = playerVRCamera.transform.rotation.eulerAngles.y;
        previousRotation = currentRotation;
    }

    // Update is called once per frame
    void Update() {
        Debug.Log("Current: " + currentRotation + " Previous: " + previousRotation);
        currentRotation = playerVRCamera.transform.rotation.eulerAngles.y;
        turningRotation = currentRotation - previousRotation;
        this.transform.RotateAround(playerVRCamera.transform.position, new Vector3(0, 1, 0), turningRotation);
        previousRotation = currentRotation;
    }
}
