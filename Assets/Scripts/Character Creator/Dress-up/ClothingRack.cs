using System;
using System.Collections.Generic;
using UnityEngine;

public class ClothingRack : MonoBehaviour {
    [SerializeField]
    private int clothingLayerNumber = 3;

    [SerializeField]
    private List<GameObject> clothing = null;

    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.layer == clothingLayerNumber) {
            ActivateClothingOnRack(collision.gameObject);
        }
    }

    public void ActivateClothingOnRack(GameObject thrownPiece) {
        string clothingNameThrown;
        string clothingNameEnvironment;
        foreach(GameObject clothingInEnvironment in clothing) {
            Debug.Log("TREE something is thrown");
            clothingNameThrown = thrownPiece.GetComponent<ClothingPieceHandler>().GetRealName();
            Debug.Log("TREE thrname: " + clothingNameThrown);
            clothingNameEnvironment = clothingInEnvironment.GetComponent<ClothingPieceHandler>().GetRealName();
            Debug.Log("TREE envname: " + clothingNameEnvironment);

            if(clothingNameEnvironment == clothingNameThrown) {
                clothingInEnvironment.GetComponent<ClothingPieceHandler>().GetChild().SetActive(true);
                Destroy(thrownPiece);
            }
        }
    }
}