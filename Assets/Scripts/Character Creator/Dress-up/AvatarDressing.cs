using System;
using System.Collections.Generic;
using UnityEngine;

public class AvatarDressing : MonoBehaviour {
    [SerializeField]
    private int clothingLayerNumber = 3;

    [SerializeField]
    private List<ClothingType> clothes = null;

	//Detect collisions between the GameObjects with Colliders attached
	void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.layer == clothingLayerNumber) {
			foreach(ClothingType clothingOnAvatar in clothes) {
                if(collision.gameObject.tag == clothingOnAvatar.tagName) {
                    ChangeClothing(clothingOnAvatar.gameObjectPieces, collision.gameObject, clothingOnAvatar.FullOutfit);
                }
			}
        }
    }

    public void ChangeClothing(List<GameObject> clothingType, GameObject thrownClothing, bool isFullOutfit) {
        Debug.Log("POP something is thrown");
        string clothingNameThrown = thrownClothing.GetComponent<ClothingPieceHandler>().GetRealName();
        Debug.Log("POP thrname " + clothingNameThrown);
        string clothingNameEnvironment;

        foreach(GameObject clothingInType in clothingType) {
            clothingNameEnvironment = clothingInType.GetComponent<ClothingPieceHandler>().GetRealName();
            Debug.Log("POP envname " + clothingNameEnvironment);

            if(clothingNameEnvironment == clothingNameThrown) {
                clothingInType.GetComponent<ClothingPieceHandler>().GetChild().SetActive(true);
                Debug.Log("POP kleding active gezet");
                Destroy(thrownClothing);
            } else {
                clothingInType.GetComponent<ClothingPieceHandler>().GetChild().SetActive(false);
                clothingInType.GetComponent<ClothingPieceHandler>().RespawnOnCarousel(clothingNameEnvironment);
            }

            if(isFullOutfit) {
                for(int k = 0; k < clothes.Count; k++) {
                    if(!clothes[k].FullOutfit) {
                        SetRestInactive(clothes[k].gameObjectPieces);
                    }
                }
            } else {
                for(int l = 0; l < clothes.Count; l++) {
                    if(clothes[l].FullOutfit) {
                        SetRestInactive(clothes[l].gameObjectPieces);
                    }
                }
            }
        }
    }

    public void SetRestInactive(List<GameObject> clothingPieces) {
        foreach(GameObject piece in clothingPieces) {
            string pieceName = piece.GetComponent<ClothingPieceHandler>().GetRealName();
            piece.GetComponent<ClothingPieceHandler>().GetChild().SetActive(false);
            piece.GetComponent<ClothingPieceHandler>().RespawnOnCarousel(pieceName);
        }
    }
}