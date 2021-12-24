/*using UnityEngine;

public class ClothingPieceHandler : MonoBehaviour
{
    //[SerializeField]
    private ClothingPiece clothingPiece = new ClothingPiece();

    [SerializeField]
    private ClothingType setClothingType;

    [SerializeField]
    private bool setIsThrowable;

    [SerializeField]
    private GameObject setThrowableVersion;

    // Start is called before the first frame update
    void Start() {
        clothingPiece.SetEverything(gameObject, setClothingType, setIsThrowable, setThrowableVersion);
    }

	private void Update() {
        if(clothingPiece.IsCounting) {
            clothingPiece.TimerCheck();
        }
	}

	public void ToDoWhenEnterGrab() {
        clothingPiece.EnterGrab();
    }

    public void ToDoWhenExitGrab() {
        clothingPiece.ExitGrab();
    }
}*/