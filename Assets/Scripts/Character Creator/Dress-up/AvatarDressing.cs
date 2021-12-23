using System;
using System.Collections.Generic;
using UnityEngine;

public class AvatarDressing : MonoBehaviour
{
    [SerializeField]
    private int clothingLayerNumber = 3;

    [SerializeField]
    private string throwableIdentifierString = "Throwable" + "(Clone)";

    [SerializeField]
    private string environmentIdentifierString = "Environment";

    [SerializeField]
    private List<ClothingType> clothes = null;

	//Detect collisions between the GameObjects with Colliders attached
	void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.layer == clothingLayerNumber) {
			for(int i = 0; i < clothes.Count; i++) {
                if(collision.gameObject.tag == clothes[i].tagName) {
                    ChangeClothing(clothes[i].gameObjectPieces, collision.gameObject, clothes[i].fullOutfit);
                }
			}
        }
    }

    public void ChangeClothing(List<GameObject> clothingType, GameObject thrownClothing, bool isFullOutfit) {
        Debug.Log("POP something is thrown");
        string clothingNameThrown = RemoveEndOfString(thrownClothing.name, throwableIdentifierString);
        string clothingNameEnvironment;

        for(int i = 0; i < clothingType.Count; i++) {
            clothingNameEnvironment = RemoveEndOfString(clothingType[i].name, environmentIdentifierString);

            if(clothingNameEnvironment == clothingNameThrown) {
                clothingType[i].SetActive(true);
                Debug.Log("POP kleding active gezet");
            } else {
                clothingType[i].SetActive(false);
            }

            if(isFullOutfit) {
                for(int k = 0; k < clothes.Count; k++) {
                    if(!clothes[k].fullOutfit) {
                        for(int j = 0; j < clothes[k].gameObjectPieces.Count; j++) {
                            clothes[k].gameObjectPieces[j].SetActive(false);
                        }
                    }
                }
            } else {
                for(int l = 0; l < clothes.Count; l++) {
                    if(clothes[l].fullOutfit) {
                        for(int m = 0; m < clothes[l].gameObjectPieces.Count; m++) {
                            clothes[l].gameObjectPieces[m].SetActive(false);
                        }
                    }
                }
            }
        }
    }

    public String RemoveEndOfString(string stringToTrim, string removeThis) {
        string outputString = stringToTrim;
        int positionWordToRemove = stringToTrim.IndexOf(removeThis);

        if(positionWordToRemove >= 0) {
            outputString.Remove(positionWordToRemove);
            outputString.TrimEnd();
        }

        return outputString;
    }
}