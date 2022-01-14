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
        Debug.Log("FILE NAME: ClothingRack.cs " + "MESSAGE: --- " + "Something is thrown on the tree");
        foreach(GameObject clothingInEnvironment in clothing) {
            clothingNameThrown = thrownPiece.GetComponent<ClothingPieceHandler>().GetRealName();
            Debug.Log("FILE NAME: ClothingRack.cs " + "MESSAGE: --- " + "Name of the piece thrown on the tree: " + clothingNameThrown);
            clothingNameEnvironment = clothingInEnvironment.GetComponent<ClothingPieceHandler>().GetRealName();
            Debug.Log("FILE NAME: ClothingRack.cs " + "MESSAGE: --- " + "Name of the current piece in the for-loop" + clothingNameEnvironment);

            if(clothingNameEnvironment == clothingNameThrown) {
                clothingInEnvironment.GetComponent<ClothingPieceHandler>().SetActiveness(true);
                Destroy(thrownPiece);
            }
        }
    }
}