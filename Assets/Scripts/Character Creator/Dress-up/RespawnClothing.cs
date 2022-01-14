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
		Debug.Log("FILE NAME: RespawnClothing.cs " + "MESSAGE: --- " + "Method: CheckIfPieceNeedsActivation() has been activated");
		string bushPieceName;
		if(GameObject.Find(deactivatedPieceName + space + throwableIdentifierString) == null && GameObject.Find(deactivatedPieceName + space + environmentIdentifierString) == null) {
			foreach(GameObject piece in piecesOnBushes) {
				bushPieceName = piece.name;
				bushPieceName = RemoveEndOfString(bushPieceName, environmentIdentifierString);
				Debug.Log("FILE NAME: RespawnClothing.cs " + "MESSAGE: --- " + "Current piece in for-loop: " + bushPieceName + " Searching for name: " + deactivatedPieceName);
				if(bushPieceName == deactivatedPieceName) {
					Debug.Log("FILE NAME: RespawnClothing.cs " + "MESSAGE: --- " + "Match found, " + deactivatedPieceName + " will be respawning on the bush");
					piece.GetComponent<ClothingPieceHandler>().SetActiveness(true);
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