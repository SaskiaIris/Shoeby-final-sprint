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
        foreach(GameObject clothingOnEnvironment in clothing) {
            Debug.Log("something is thrown");
            string clothingNameThrown;
            string clothingNameEnvironment;

            int positionThrowableString;
            int positionEnvironmentString;

            clothingNameThrown = thrownPiece.name;
            clothingNameEnvironment = clothingOnEnvironment.name;

            positionThrowableString = clothingNameThrown.IndexOf(throwableIdentifierString);
            positionEnvironmentString = clothingNameEnvironment.IndexOf(environmentIdentifierString);

            if(positionThrowableString >= 0) {
                Debug.Log("de naam thrown was: " + clothingNameThrown);
                clothingNameThrown = clothingNameThrown.Remove(positionThrowableString);
                clothingNameThrown.TrimEnd();
                Debug.Log("de naam van thrown is nu: " + clothingNameThrown);
            }

            if(positionEnvironmentString >= 0) {
                Debug.Log("de naam Environment was: " + clothingNameEnvironment);
                clothingNameEnvironment = clothingNameEnvironment.Remove(positionEnvironmentString);
                clothingNameEnvironment.TrimEnd();
                Debug.Log("de naam Environment is nu: " + clothingNameEnvironment);
            }

            if(clothingNameEnvironment == clothingNameThrown) {
                clothingOnEnvironment.SetActive(true);
            }
        }
    }
}