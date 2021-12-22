using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureScaler : MonoBehaviour {
    bool isBusy = false;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void ScaleUp() {
        if(!isBusy)
            StartCoroutine(ScaleUp(transform, new Vector3(2f, 2f, 2f), 2f));
    }

    public void ScaleDown() {
        if(!isBusy)
            StartCoroutine(ScaleDown(transform, new Vector3(0.5f, 0.5f, 0.5f), 2f));
    }

    IEnumerator ScaleUp(Transform transform, Vector3 upScale, float duration) {
        isBusy = true;
        Vector3 initialScale = transform.localScale;

        for(float time = 0; time < duration * 2; time += Time.deltaTime) {
            float progress = /*Mathf.PingPong(time, duration)*/ time / duration;
            transform.localScale = Vector3.Lerp(initialScale, upScale, progress);
            yield return null;
        }
        isBusy = false;
        //transform.localScale = initialScale;
    }

    IEnumerator ScaleDown(Transform transform, Vector3 downScale, float duration) {
        isBusy = true;
        Vector3 initialScale = transform.localScale;

        for(float time = 0; time < duration * 2; time += Time.deltaTime) {
            float progress = /*Mathf.PingPong(time, duration)*/ time / duration;
            transform.localScale = Vector3.Lerp(initialScale, downScale, progress);
            yield return null;
        }
        isBusy = false;
        //transform.localScale = initialScale;
    }
}