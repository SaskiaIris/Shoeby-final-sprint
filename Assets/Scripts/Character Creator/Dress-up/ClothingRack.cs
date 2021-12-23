using System;
using System.Collections.Generic;
using UnityEngine;

public class ClothingRack : MonoBehaviour {
    [SerializeField]
    private int clothingLayerNumber = 3;

    [SerializeField]
    private string throwableIdentifierString = "Throwable" + "(Clone)";

    [SerializeField]
    private string environmentIdentifierString = "Environment";

    [SerializeField]
    private List<GameObject> clothing = null;

    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.layer == clothingLayerNumber) {
            ActivateClothingOnRack(collision.gameObject);
        }
    }

    public void ActivateClothingOnRack(GameObject thrownPiece) {
        foreach(GameObject clothingInEnvironment in clothing) {
            Debug.Log("TREE something is thrown");
            string clothingNameThrown = RemoveEndOfString(thrownPiece.name, throwableIdentifierString);
            string clothingNameEnvironment = RemoveEndOfString(clothingInEnvironment.name, environmentIdentifierString);

            if(clothingNameEnvironment == clothingNameThrown) {
                clothingInEnvironment.SetActive(true);
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