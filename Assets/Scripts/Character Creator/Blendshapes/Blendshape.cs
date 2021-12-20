using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Blendshape {
    public string shapeName;
    public int minIndex;
    public int maxIndex;
    public bool isMin; //to use to determine whether the min blendshape has to be used or the max at that moment
    public float currentBlendValue;
    public bool isSelected;

    public void flipMinMax() {
		isMin = !isMin;
    }
}