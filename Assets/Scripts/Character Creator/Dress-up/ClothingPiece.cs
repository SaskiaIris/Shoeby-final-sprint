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
    private ClothingType _clothingType;
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

    public bool IsCounting {
        get {
            return _isCounting;
        }
    }

    /*public ClothingType ClothingType {
        get {
            return _clothingType;
        }
    }*/

    public void SetEverything(GameObject gameObject, ClothingType clothingType, bool isThrowable, GameObject throwableVersion) {
        _thisGameObject = gameObject;
        _pieceName = FindRealName(_thisGameObject.name);
        _correspondingCarousel = FindCarousel();
        _clothingType = clothingType;
        _isThrowable = isThrowable;
        _throwableVersion = throwableVersion;
    }

    public void EnterGrab() {
        if(_isThrowable) {
            ResetTimer();
        } else {
            if(!CheckIfDuplicateExists()) {
                CreateDuplicate();
            }
        }
    }

    public void ExitGrab() {
        if(_isThrowable) {
            TurnKinematicOff();
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

    private void Despawn() {
        GameObject.Destroy(_thisGameObject);
        //TODO: test if next line still works
        _correspondingCarousel.GetComponent<RespawnClothing>().CheckIfPieceNeedsActivation(_pieceName);
    }

    private void TurnKinematicOff() {
        _thisGameObject.GetComponent<Rigidbody>().isKinematic = false;
    }

    private void CreateDuplicate() {
        GameObject duplicateGameObject = GameObject.Instantiate(_throwableVersion);
        duplicateGameObject.transform.position = _thisGameObject.transform.position;
        _thisGameObject.SetActive(false);
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

    public string FindRealName(string gameObjectName) {
        string realName = "";
        if(_isThrowable) {
            string throwableEndName = _throwableIdentifierString + _cloneIdentifierString;
            realName = RemoveEndOfString(gameObjectName, throwableEndName);
        } else {
            realName = RemoveEndOfString(gameObjectName, _environmentPieceIdentifierString);
        }
        return realName;
    }

    public GameObject FindCarousel() {
        string nameToSearchFor = _pieceName + _space + _carouselName;
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
