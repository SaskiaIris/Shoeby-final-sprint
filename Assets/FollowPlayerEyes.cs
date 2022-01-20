using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerEyes : MonoBehaviour {
    [SerializeField]
    private GameObject playerVRCamera;

    /*[SerializeField]
    private float minimumHeightChange = 2;*/

    private float previousRotation;
    private float currentRotation;

    private float turningRotation;

    /*private float beeStartPosition;
    private float previousPosition;
    private float currentPosition;

    private float newPosition;*/

    // Start is called before the first frame update
    void Start() {
        currentRotation = playerVRCamera.transform.rotation.eulerAngles.y;
        previousRotation = currentRotation;
        /*beeStartPosition = this.transform.position.y;
        currentPosition = playerVRCamera.transform.position.y;
        previousPosition = currentPosition;*/
    }

    // Update is called once per frame
    void Update() {
        Debug.Log("Current: " + currentRotation + " Previous: " + previousRotation);
        currentRotation = playerVRCamera.transform.rotation.eulerAngles.y;
        turningRotation = currentRotation - previousRotation;
        this.transform.RotateAround(playerVRCamera.transform.position, new Vector3(0, 1, 0), turningRotation);
        previousRotation = currentRotation;

        /*currentPosition = playerVRCamera.transform.position.y;
        if(previousPosition > newPosition) {
            newPosition = previousPosition - currentPosition + beeStartPosition;
        } else {
            newPosition = currentPosition - previousPosition + beeStartPosition;
        }

        this.transform.position = new Vector3(this.transform.position.x, newPosition, this.transform.position.z);
        previousPosition = currentPosition;*/
    }
}
