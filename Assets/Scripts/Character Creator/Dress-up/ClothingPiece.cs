using System;
using UnityEngine;

[Serializable]
public class ClothingPiece {
    private string _environmentPieceIdentifierString = "Environment";
    private string _throwableIdentifierString = "Throwable";
    private string _cloneIdentifierString = "(Clone)";
    private string _space = " ";

    private string _pieceName;
    private GameObject _thisGameObject;
    private bool _isThrowable;
    private GameObject _throwableVersion;

    private string _carouselName = "Carousel";
    private GameObject _correspondingCarousel;

    /// <summary>
    /// Variables for despawning the object when it has not been in hand for X seconds
    /// </summary>
    //TODO: maybe make this editable
    private int _amountOfSecondsTillDespawn = 10;
    //Timer
    private float _timer = 0.0f;
    private int _zero = 0;
    //TODO: make these two in own function
    private int _timerInSeconds = 0;
    private int _amountOfMSInASecond = 60;

    private bool _isCounting = false;

    public string PieceName {
        get {
            //return _pieceName;
            return FindRealName();
        }
    }

    public bool IsCounting {
        get {
            return _isCounting;
        }
    }

    public ClothingPiece(GameObject givenGameObject, bool isThrowable, GameObject throwableVersion) {
        _thisGameObject = givenGameObject;
        //ond werkt niet
        _pieceName = FindRealName();
        _correspondingCarousel = FindCarousel();
        _isThrowable = isThrowable;
        _throwableVersion = throwableVersion;
    }

    public void EnterGrab() {
        if(_isThrowable) {
            ResetTimer();
            TurnKinematicOffOrOn(true);
        } else {
            if(!CheckIfDuplicateExists() && CheckIfChildActive()) {
                Debug.Log("FILE NAME: ClothingPiece.cs " + "MESSAGE: --- " + "Duplicate of " + this.FindRealName() + " is made");
                CreateDuplicate();
            }
        }
    }

    public void ExitGrab() {
        if(_isThrowable) {
            TurnKinematicOffOrOn(false);
            StartTimer();
        }
    }

    private void StartTimer() {
        _isCounting = true;
    }

    private void ResetTimer() {
        _isCounting = false;
        _timer = _zero;
        _timerInSeconds = _zero;
    }

    public void TimerCheck() {
        _timer += Time.deltaTime;
        _timerInSeconds = (int) _timer % _amountOfMSInASecond;

        if(_timerInSeconds >= _amountOfSecondsTillDespawn) {
            Despawn();
        }
    }

    public void SetOnOff(bool value) {
		GetChildObject().SetActive(value);
        GetBoxCollider().enabled = value;
    }

    private GameObject GetChildObject() {
        return _thisGameObject.transform.GetChild(0).gameObject;
    }
    private Collider GetBoxCollider() {
        return _thisGameObject.GetComponent<BoxCollider>();
    }

    private void Despawn() {
        string destroyedName = FindRealName();
        GameObject.Destroy(_thisGameObject);
        //TODO: test if next line still works
        CarouselRespawn(destroyedName);
    }

    public void CarouselRespawn(string carouselPieceName) {
        //IDK!?
        _correspondingCarousel = FindCarousel();
        _correspondingCarousel.GetComponent<RespawnClothing>().CheckIfPieceNeedsActivation(carouselPieceName);
    }

    private void TurnKinematicOffOrOn(bool value) {
        _thisGameObject.GetComponent<Rigidbody>().isKinematic = value;
    }

    private bool CheckIfChildActive() {
        bool returnBool = false;
        if(GetChildObject().activeInHierarchy) {
            returnBool = true;
        } else {
            returnBool = false;
        }

        return returnBool;
    }

    private void CreateDuplicate() {
        GameObject duplicateGameObject = GameObject.Instantiate(_throwableVersion);
        duplicateGameObject.transform.position = _thisGameObject.transform.position;
        Debug.Log("FILE NAME: ClothingPiece.cs " + "MESSAGE: --- " + "Making a duplicate");
        SetOnOff(false); //Does this work?
    }

    private bool CheckIfDuplicateExists() {
        bool doesItExist = false;
        string nameToSearchFor = _pieceName + _throwableIdentifierString + _cloneIdentifierString;
        if(GameObject.Find(nameToSearchFor) == null) {
            doesItExist = false;
        } else {
            doesItExist = true;
        }
        return doesItExist;
    }

    public string FindRealName() {
        string realName = _thisGameObject.name;
        if(_isThrowable) {
            string throwableEndName = _throwableIdentifierString + _cloneIdentifierString;
            realName = RemoveEndOfString(realName, throwableEndName);
        } else {
            realName = RemoveEndOfString(realName, _environmentPieceIdentifierString);
        }
        return realName;
    }

    public GameObject FindCarousel() {
        string nameToSearchFor =/* _thisGameObject.tag + _space +*/ _carouselName;
        Debug.Log("FILE NAME: ClothingPiece.cs " + "MESSAGE: --- " + "Name of the carousel we are searching for: " + nameToSearchFor);
        GameObject foundCarousel = GameObject.Find(nameToSearchFor);
        return foundCarousel;
    }

    private string RemoveEndOfString(string stringToTrim, string removeThis) {
        string outputString = stringToTrim;
        int positionWordToRemove = stringToTrim.IndexOf(removeThis);

        if(positionWordToRemove >= 0) {
            outputString = outputString.Remove(positionWordToRemove);
            outputString.TrimEnd();
        }

        return outputString;
    }
}
