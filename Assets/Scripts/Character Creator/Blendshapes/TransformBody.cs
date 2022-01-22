using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransformBody : MonoBehaviour {
    bool isBusy = false;

    [SerializeField]
    private Text selectedBodyPart;

    [SerializeField]
    private float timeForScaling = 1f;
    [SerializeField]
    private int scaleStep = 10;
    [SerializeField]
    private int middleSize = 0;
    [SerializeField]
    private float maxSize = 100f;

    [SerializeField]
    private List<Blendshape> blendshapes = null;

    private SkinnedMeshRenderer skinnedMeshRenderer;

    // Start is called before the first frame update
    void Start() {
        skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();

        foreach(Blendshape selectedShape in blendshapes) {
            if(selectedShape.isSelected) {
                selectedBodyPart.text = selectedShape.shapeName;
            }
        }
    }

    public void ScaleStart(bool isThisButtonRight) {
        if(!isBusy) {
            foreach(Blendshape shape in blendshapes) {
                if(shape.isSelected) {
                    StartCoroutine(ScaleBody(shape, isThisButtonRight, timeForScaling));
                }
            }
        }
    }

    public void ResetBlendshapes() {
        foreach(Blendshape shape in blendshapes) {
            skinnedMeshRenderer.SetBlendShapeWeight(shape.maxIndex, 0);
            skinnedMeshRenderer.SetBlendShapeWeight(shape.minIndex, 0);
            shape.currentBlendValue = skinnedMeshRenderer.GetBlendShapeWeight(shape.minIndex);
            shape.isMin = true;
        }
        skinnedMeshRenderer.SetBlendShapeWeight(8, 100);
        skinnedMeshRenderer.SetBlendShapeWeight(10, 100);
        skinnedMeshRenderer.SetBlendShapeWeight(12, 100);
        blendshapes[8].currentBlendValue = 100;
        blendshapes[10].currentBlendValue = 100;
        blendshapes[12].currentBlendValue = 100;
    }
	IEnumerator ScaleBody(Blendshape shape, bool buttonRight, float scaleScaleStep) {
        isBusy = true;

        int blendshapeIndex = 0;
        float currentSize = shape.currentBlendValue;
        float sizeToBe = 0;

        if(currentSize == middleSize) {
            if((buttonRight && shape.isMin) || (!buttonRight && !shape.isMin)) {
                shape.flipMinMax();
            }
        } else if(currentSize == maxSize) {
            if((!buttonRight && shape.isMin) || (buttonRight && !shape.isMin)) {
                isBusy = false;
                yield break;
            }
        }

        if(shape.isMin) {
            blendshapeIndex = shape.minIndex;

            if(!buttonRight) {
                sizeToBe = currentSize + scaleStep;
            } else {
                sizeToBe = currentSize - scaleStep;
            }
        } else {
            blendshapeIndex = shape.maxIndex;

            if(buttonRight) {
                sizeToBe = currentSize + scaleStep;
            } else {
                sizeToBe = currentSize - scaleStep;
            }
        }

        Debug.Log("FILE NAME: TransformBody.cs " + "MESSAGE: --- " + "The new value of the blendshape will be: " + sizeToBe);

        skinnedMeshRenderer.SetBlendShapeWeight(blendshapeIndex, Mathf.Lerp(currentSize, sizeToBe, scaleScaleStep));

        shape.currentBlendValue = skinnedMeshRenderer.GetBlendShapeWeight(blendshapeIndex);

        isBusy = false;

        yield return null;
    }

    public void SwitchBlendshape(bool isThisButtonUp) {
        int start = 0;
        int end = blendshapes.Count-1;
        for(int b = 0; b <= end; b++) {
            if(blendshapes[b].isSelected) {
                if(!isThisButtonUp) {
                    if(b != end) {
                        blendshapes[(b + 1)].isSelected = true;
                        Debug.Log("FILE NAME: TransformBody.cs " + "MESSAGE: --- " + "State 1: " + "Button pressed: down, we are NOT at the end of the list");
                    } else {
                        blendshapes[start].isSelected = true;
                        Debug.Log("FILE NAME: TransformBody.cs " + "MESSAGE: --- " + "State 2: " + "Button pressed: down, we ARE at the end of the list");
                    }
                } else {
                    if(b != start) {
                        blendshapes[(b - 1)].isSelected = true;
                        Debug.Log("FILE NAME: TransformBody.cs " + "MESSAGE: --- " + "State 3: " + "Button pressed: up, we are NOT at the beginning of the list");
                    } else {
                        blendshapes[end].isSelected = true;
                        Debug.Log("FILE NAME: TransformBody.cs " + "MESSAGE: --- " + "State 4: " + "Button pressed: up, we ARE at the end of the list");
                    }
                }
                Debug.Log("FILE NAME: TransformBody.cs " + "MESSAGE: --- " + "The number of the previously selected blendshape is: " + b);
                blendshapes[b].isSelected = false;
                break;
            }
        }
        foreach(Blendshape selectedShape in blendshapes) {
            if(selectedShape.isSelected) {
                selectedBodyPart.text = selectedShape.shapeName;
            }
        }
    }
}