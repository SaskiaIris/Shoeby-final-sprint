using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnviSwitch : MonoBehaviour
{
    public float duration = 0.25f; // seconds
    private Vector3 clothingOffPosition;
    private Vector3 catwalkOffPosition;
    private Vector3 avatarOffPosition;
    public Vector3 clothingOnPosition = new Vector3(0.55f, 0.2f, -0.18f);
    public Vector3 catwalkOnPosition = new Vector3(1, -3, 1);
    public Vector3 avatarOnPosition = new Vector3(0, 0, 0);
    private Coroutine ascent;
    private Coroutine descent;
    [SerializeField]
    private GameObject clothing, catwalk, avatar, shapePillar;

    [SerializeField]
    private int clicked = 0;

    [SerializeField]
    private int amountOfClicksAvatar = 3;

    [SerializeField]
    private int amountOfClicksClothing = 5;

    [SerializeField]
    private UnityEvent resetBlendShapesWhenDressing;

    void Start() {
        clothingOffPosition = clothing.transform.localPosition;
        catwalkOffPosition = catwalk.transform.localPosition;
        avatarOffPosition = avatar.transform.localPosition;
    }

    public void Switch() {
        if (ascent != null) {
            StopCoroutine(ascent);
        }
        if (descent != null) {
            StopCoroutine(descent);
        }

        if (clicked == amountOfClicksClothing) {
            ascent = StartCoroutine(AnimateAscent(clothingOffPosition, clothingOnPosition, clothing));
            descent = StartCoroutine(AnimateDescent(avatarOnPosition, catwalkOnPosition, shapePillar));
            resetBlendShapesWhenDressing.Invoke();
        } else if (clicked == amountOfClicksAvatar) {
            ascent = StartCoroutine(AnimateAscent(avatarOffPosition, avatarOnPosition, avatar));
            descent = StartCoroutine(AnimateDescent(catwalkOffPosition, catwalkOnPosition, catwalk));
        }

        clicked++;
    }

    private IEnumerator AnimateAscent(Vector3 objectFromPosition, Vector3 objectToPosition, GameObject objectToMove) {
        objectToMove.SetActive(true);
        float t = 0;
        while (t < duration)
        {
            objectToMove.transform.position = Vector3.Lerp(objectFromPosition, objectToPosition, t / duration);
            t += Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator AnimateDescent(Vector3 objectFromPos, Vector3 objectToPos, GameObject objectToMove) {
        float t = 0;
        while (t < duration) {
            objectToMove.transform.position = Vector3.Lerp(objectFromPos, objectToPos, t / duration);
            t += Time.deltaTime;
            yield return null;
        }
        objectToMove.SetActive(false);
    }
}