using UnityEngine;

public class ClothingDuplicate : MonoBehaviour {
    [SerializeField]
    private GameObject throwableVersion;

    [SerializeField]
    private string cloneText = "(Clone)";

    public void GrabDuplicate() {
        Debug.Log("method activated");
        if(GameObject.Find(throwableVersion.name + cloneText) == null) {
            GameObject newPiece = Instantiate(throwableVersion);
            newPiece.transform.position = transform.position;
			gameObject.SetActive(false);
		}
	}
}