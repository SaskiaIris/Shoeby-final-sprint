/*using UnityEngine;

public class DespawnThrownClothing : MonoBehaviour {
    private Vector3 lastPosition;
    private Vector3 amountMoved;

    [SerializeField]
    private float movementThreshold = 0.5f;

    [SerializeField]
    private int amountOfSecondsTillDespawn = 5;

    [SerializeField]
    private string nameOfCarousel = "Clothes Carousel";
    private GameObject clothingCarousel;

    [SerializeField]
    private string throwableIdentifierString = "Throwable(Clone)";

    private float timer = 0.0f;
    private int timerInSeconds = 0;
    private int amountOfMSInASecond = 60;

    private string nameOfObject;

    private bool startCounting = false;

    // Start is called before the first frame update
    void Start() {
        lastPosition = transform.position;
        clothingCarousel = GameObject.Find(nameOfCarousel);
    }

    // Update is called once per frame
    void Update() {
        if(startCounting) {
            timer += Time.deltaTime;
            timerInSeconds = (int) timer % amountOfMSInASecond;

            amountMoved = transform.position - lastPosition;
            if(amountMoved.x > movementThreshold || amountMoved.y > movementThreshold || amountMoved.z > movementThreshold) {
                timer = 0;
                timerInSeconds = 0;
            }

            if(timerInSeconds >= amountOfSecondsTillDespawn) {
                nameOfObject = gameObject.name;
                nameOfObject = RemoveEndOfString(nameOfObject, throwableIdentifierString);
                Destroy(gameObject);
                clothingCarousel.GetComponent<RespawnClothing>().CheckIfPieceNeedsActivation(nameOfObject);
            }
        }
    }

    public void SetStartCounting(bool value) {
        startCounting = value;
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
}*/