using UnityEngine;

public class ClothingPieceHandler : MonoBehaviour {
	private ClothingPiece clothingPiece/* = new ClothingPiece()*/;

	[SerializeField]
	private bool setIsThrowable;

	/*[SerializeField]
	private GameObject setEnvironmentVersion;*/

	[SerializeField]
	private GameObject setThrowableVersion;

	// Start is called before the first frame update
	void OnEnable() {
		clothingPiece = new ClothingPiece(gameObject, setIsThrowable, setThrowableVersion);
		//clothingPiece.SetEverything(gameObject, setIsThrowable, setThrowableVersion);
	}

	private void Update() {
		if(clothingPiece.IsCounting) {
			clothingPiece.TimerCheck();
		}
	}

	public string GetRealName() {
		return clothingPiece.PieceName;
	}

	public GameObject GetChild() {
		return clothingPiece.GetChildObject();
	}

	public void RespawnOnCarousel() {
		clothingPiece.CarouselRespawn();
	}

	public void ToDoWhenEnterGrab() {
		clothingPiece.EnterGrab();
	}

	public void ToDoWhenExitGrab() {
		clothingPiece.ExitGrab();
	}
}