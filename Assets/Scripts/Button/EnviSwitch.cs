using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviSwitch : MonoBehaviour
{
    public float duration = 0.25f; // seconds
    private Vector3 bushesOffPosition;
    private Vector3 catwalkOffPosition;
    private Vector3 bobOffPosition;
    public Vector3 bushesOnPosition = new Vector3(0.55f, 0.2f, -0.18f);
    public Vector3 catwalkOnPosition = new Vector3(1, -3, 1);
    public Vector3 bobOnPosition = new Vector3(0, 0, 0);
    private Coroutine ascent;
    private Coroutine descent;
    [SerializeField]
    private GameObject bushes, catwalk, bob, shapePillar;

    [SerializeField]
    private int clicked = 0;

    [SerializeField]
    private int amountOfClicksBush = 5;

    [SerializeField]
    private int amountOfClicksBob = 7;

    void Start()
    {
        bushesOffPosition = bushes.transform.localPosition;
        catwalkOffPosition = catwalk.transform.localPosition;
        bobOffPosition = bob.transform.localPosition;
        //catwalk = null;
    }

    public void Switch()
    {
        if (ascent != null)
        {
            StopCoroutine(ascent);
        }
        if (descent != null)
        {
            StopCoroutine(descent);
        }

        if (clicked == amountOfClicksBush)
        {
            //bushes.SetActive(true);
            ascent = StartCoroutine(AnimateAscent(bushesOffPosition, bushesOnPosition, bushes));
            descent = StartCoroutine(AnimateDescent(bobOnPosition, catwalkOnPosition, shapePillar));
        }
        else if (clicked == amountOfClicksBob)
        {
            //bob.SetActive(true);
            ascent = StartCoroutine(AnimateAscent(bobOffPosition, bobOnPosition, bob));
            descent = StartCoroutine(AnimateDescent(catwalkOffPosition, catwalkOnPosition, catwalk));
            //bushes.SetActive(false);
        }

        clicked++;
    }

    private IEnumerator AnimateAscent(Vector3 objectFromPosition, Vector3 objectToPosition, GameObject objectje)
    {
        objectje.SetActive(true);
        float t = 0;
        while (t < duration)
        {
            objectje.transform.position = Vector3.Lerp(objectFromPosition, objectToPosition, t / duration);
            t += Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator AnimateDescent(Vector3 objectFromPos, Vector3 objectToPos, GameObject objectje)
    {
        float t = 0;
        while (t < duration)
        {
            objectje.transform.position = Vector3.Lerp(objectFromPos, objectToPos, t / duration);
            t += Time.deltaTime;
            yield return null;
        }
        objectje.SetActive(false);
    }
}