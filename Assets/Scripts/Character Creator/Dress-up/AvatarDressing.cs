using System;
using System.Collections.Generic;
using UnityEngine;

public class AvatarDressing : MonoBehaviour {
    [SerializeField]
    private int clothingLayerNumber = 3;

    /*[SerializeField]
    private string throwableIdentifierString = "Throwable(Clone)";

    [SerializeField]
    private string environmentIdentifierString = "Environment";*/

    [SerializeField]
    private List<ClothingType> clothes = null;

    /*[SerializeField]
    private string nameOfCarousel = "Clothes Carousel";
    private GameObject clothingCarousel;*/

	private void Start() {
        //clothingCarousel = GameObject.Find(nameOfCarousel);
    }

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
        /*RemoveEndOfString(thrownClothing.name, throwableIdentifierString);*/
        Debug.Log("POP thrname " + clothingNameThrown);
        string clothingNameEnvironment;

        foreach(GameObject clothingInType in clothingType) {
            //clothingNameEnvironment = RemoveEndOfString(clothingInType.name, environmentIdentifierString);
            clothingNameEnvironment = clothingInType.GetComponent<ClothingPieceHandler>().GetRealName();
            Debug.Log("POP envname " + clothingNameEnvironment);

            if(clothingNameEnvironment == clothingNameThrown) {
                clothingInType.GetComponent<ClothingPieceHandler>().GetChild().SetActive(true);
                Debug.Log("POP kleding active gezet");
                Destroy(thrownClothing);
            } else {
                clothingInType.GetComponent<ClothingPieceHandler>().GetChild().SetActive(false);
                clothingInType.GetComponent<ClothingPieceHandler>().RespawnOnCarousel();
                //clothingCarousel.GetComponent<RespawnClothing>().CheckIfPieceNeedsActivation(clothingNameEnvironment);
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
            piece.GetComponent<ClothingPieceHandler>().GetChild().SetActive(false);
            piece.GetComponent<ClothingPieceHandler>().RespawnOnCarousel();
        }
    }
}