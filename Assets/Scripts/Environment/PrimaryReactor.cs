using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryReactor : MonoBehaviour
{
    public PrimaryButtonWatcher watcher;
    public bool IsPressed = false; // used to display button state in the Unity Inspector window
    public Vector3 descentSpeed = new Vector3(1, 5, 1);
    public float descentDuration = 0.25f; // seconds
    private Vector3 offPosition;
    private Vector3 onPosition;
    private Coroutine descent;
    [SerializeField]
    private GameObject bushes;

    void Start()
    {
        watcher.primaryButtonPress.AddListener(onPrimaryButtonEvent);
        offPosition = bushes.transform.position;
        onPosition = Vector3.Scale(descentSpeed, offPosition);
    }

    public void onPrimaryButtonEvent(bool pressed)
    {
        IsPressed = pressed;
        if (descent != null)
            StopCoroutine(descent);
        if (pressed)
            bushes.SetActive(true);
            descent = StartCoroutine(AnimateDescent(bushes.transform.position, onPosition));
        //else
        //    descent = StartCoroutine(AnimateDescent(this.transform.position, offPosition));
    }

    public IEnumerator AnimateDescent(Vector3 fromPosition, Vector3 toPosition)
    {
        float t = 0;
        while (t < descentDuration)
        {
            transform.position = Vector3.Lerp(fromPosition, toPosition, t / descentDuration);
            t += Time.deltaTime;
            yield return null;
        }
    }
}