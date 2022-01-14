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


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            takeScreenShot();
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

    void OnApplicationQuit()
    {
        //Debug.Log("Screenshots deleted");
        //FileUtil.DeleteFileOrDirectory(folderPath);
    }
}
