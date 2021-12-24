using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnClothing : MonoBehaviour {
	[SerializeField]
	private List<GameObject> piecesOnBushes = null;

	[SerializeField]
	private string throwableIdentifierString = "Throwable(Clone)";

	[SerializeField]
	private string environmentIdentifierString = "Environment";

	//[SerializeField]
	private string space = " ";

	public void CheckIfPieceNeedsActivation(string deactivatedPieceName) {
		Debug.Log("Wow 0");
		string bushPieceName;
		if(GameObject.Find(deactivatedPieceName + space + throwableIdentifierString) == null && GameObject.Find(deactivatedPieceName + space + environmentIdentifierString) == null) {
			foreach(GameObject piece in piecesOnBushes) {
				bushPieceName = piece.name;
				bushPieceName = RemoveEndOfString(bushPieceName, environmentIdentifierString);
				if(bushPieceName == deactivatedPieceName) {
					Debug.Log("wow1");
					piece.GetComponent<ClothingPieceHandler>().GetChild().SetActive(true);
				}
			}
		}

	}

	public string RemoveEndOfString(string stringToTrim, string removeThis) {
		string outputString = stringToTrim;
		int positionWordToRemove = stringToTrim.IndexOf(removeThis);

		if(positionWordToRemove >= 0) {
			outputString = outputString.Remove(positionWordToRemove);
			outputString.TrimEnd();
		}

		return outputString;
	}
}