using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ClothingType {
    public string typeName;
    public string tagName;
    public List<GameObject> gameObjectPieces;
    public bool fullOutfit;
}