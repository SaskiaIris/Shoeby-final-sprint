using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ClothingType {
    private string _outfitName = "Outfit";

    public string tagName;
    
    public List<GameObject> gameObjectPieces;

    public bool FullOutfit {
        get {
            return CheckFullOutfit();
        }
    }

    private bool CheckFullOutfit() {
        bool isOutfit = false;
        if(tagName == _outfitName) {
            isOutfit = true;
        } else {
            isOutfit = false;
        }
        return isOutfit;
    }
}