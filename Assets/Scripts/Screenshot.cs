using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class Screenshot : MonoBehaviour
{
    private int screenShotNumber = 0;
    private string screenShotName;
    private string folderPath;

    public OVRInput.Button button;
    public OVRInput.Controller controller;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            takeScreenShot();
        }

        if(OVRInput.GetDown(button, controller))
        {
            Debug.Log("hey");
        }


    }

    public void takeScreenShot()
    {
       folderPath = Directory.GetCurrentDirectory() + "/Screenshots/";
        if (!Directory.Exists(folderPath)) {
            Directory.CreateDirectory(folderPath);
        }

        screenShotNumber++;
        screenShotName = "Screenshot_" + screenShotNumber + ".png";
        ScreenCapture.CaptureScreenshot(Path.Combine(folderPath, screenShotName));
        Debug.Log("screenshot taken");
    }

    //void OnApplicationQuit()
    //{
    //    Debug.Log("Screenshots deleted");
    //    FileUtil.DeleteFileOrDirectory(folderPath);
    //}
}
