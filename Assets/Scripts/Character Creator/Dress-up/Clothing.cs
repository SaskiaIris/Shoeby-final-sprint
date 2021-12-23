using UnityEngine;

public class Clothing : MonoBehaviour {
    [SerializeField]
    private GameObject throwableVersion;

    [SerializeField]
    private string cloneText = "(Clone)";

    public void GrabDuplicate() {
        Debug.Log("method activated");
        if(GameObject.Find(throwableVersion.name + cloneText) == null) {
            GameObject newPiece = GameObject.Instantiate(throwableVersion);
            newPiece.transform.position = transform.position;
			this.gameObject.SetActive(false); // dit zorgt ervoor dat je de nieuwe meteen vastpakt, vraag mij ook niet waarom het werkt.
                                              // én nee: de oude wordt blijkbaar niet op inactive gezet.
		}
	}
}