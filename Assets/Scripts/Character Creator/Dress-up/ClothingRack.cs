using System.Collections.Generic;
using UnityEngine;

public class ClothingRack : MonoBehaviour {
    [SerializeField]
    private int clothingLayerNumber = 3;

    [SerializeField]
    private string throwableIdentifierString = "Throwable";

    [SerializeField]
    private string treeIdentifierString = "Tree";

    [SerializeField]
    private List<GameObject> clothing = null;

    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.layer == clothingLayerNumber) {
            ActivateClothingOnRack(collision.gameObject);
        }
    }

    public void ActivateClothingOnRack(GameObject thrownPiece) {
        foreach(GameObject clothingOnTree in clothing) {
            Debug.Log("something is thrown");
            string clothingNameThrown;
            string clothingNameTree;

            int positionThrowableString;
            int positionTreeString;

            clothingNameThrown = thrownPiece.name;
            clothingNameTree = clothingOnTree.name;

            positionThrowableString = clothingNameThrown.IndexOf(throwableIdentifierString);
            positionTreeString = clothingNameTree.IndexOf(treeIdentifierString);

            if(positionThrowableString >= 0) {
                Debug.Log("de naam thrown was: " + clothingNameThrown);
                clothingNameThrown = clothingNameThrown.Remove(positionThrowableString);
                clothingNameThrown.TrimEnd();
                Debug.Log("de naam van thrown is nu: " + clothingNameThrown);
            }

            if(positionTreeString >= 0) {
                Debug.Log("de naam Tree was: " + clothingNameTree);
                clothingNameTree = clothingNameTree.Remove(positionTreeString);
                clothingNameTree.TrimEnd();
                Debug.Log("de naam Tree is nu: " + clothingNameTree);
            }

            if(clothingNameTree == clothingNameThrown) {
                clothingOnTree.SetActive(true);
            }
        }
    }
}