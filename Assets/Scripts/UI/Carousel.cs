using UnityEngine;

/*
* to use this script just place it on any gameobject in the scene, this element shouldn't have a collider so an empty game object is ideal
* add elements to the carouselObjects array, make sure these items have a collider
* make sure there are no elements with colliders in between the center and the carousel elements
*/
public class Carousel : MonoBehaviour {
    private GameObject[] carouselObjects;//the elements of the carousel
    
    //public bool resetCenterRotation = true;//do you want to reset the rotation of the carousel center (recommended to be true)
    public float distanceFromCenter = 0.4f;//the distance from the center of the carousel
    //public bool AssumeObject = true; // if true assume the object that is picked, otherwise (false) keep checking what the next item is through raycast.
    public int chosenObject = 0; //index of the object that is centered in the carousel
    public float speedOfRotation = 0.1f; //the speed in which the carousel rotates: values should be between 0.01f -> 1.0f, zero will stop the rotation


    private static float diameter = 360.0f; //the diameter is always 360 degrees
    //private Transform theRayCaster = null; //create an empty transform
    private float angle = 0.0f; //the angle for each object in the carousel
    private float newAngle = 0.0f; //the calculated angle
    private bool firstTime = true; //used to calculate the offset for the first time

    //Iris Oostra
    [SerializeField]
    private int maximumObjects = 5;

    public OVRInput.Button button;
    public OVRInput.Controller controller;

    private float[] objectAngles;
    private int[] currentVisibleIndexes;
    private Vector3 positionCarousel;
    private Vector3 axisCarousel;
    int currentSpawnAngle;

    void Start() {
        carouselObjects = new GameObject[transform.childCount];
        for(int i = 0; i < transform.childCount; i++) {
            carouselObjects[i] = transform.GetChild(i).gameObject;
        }
        currentSpawnAngle = 0;
        objectAngles = new float[maximumObjects];
        currentVisibleIndexes = new int[maximumObjects];
        positionCarousel = this.transform.position;
        axisCarousel = new Vector3(0, 1, 0);

        Debug.Log("FILE NAME: Carousel.cs " + "MESSAGE: --- " + "Name of the first displayed object: " + carouselObjects[0].name);//just display the name of the first chosen element in the console
        /*GameObject raycastHolder = new GameObject();//create an empty gameobject
        raycastHolder.name = "RaycastPicker"; //rename it to RaycastPicker
        theRayCaster = raycastHolder.transform; // assign the transform of the newlycreated gameobject to the raycast transform variable
        theRayCaster.position = transform.position; // place it at the positon of the carousel center*/
        /*if(resetCenterRotation) {
            transform.rotation = Quaternion.identity;//reset the rotation of the carousel center
        }*/

        angle = diameter / (float) maximumObjects;

        for(int c = chosenObject; c < currentVisibleIndexes.Length; c++) {
            currentVisibleIndexes[c] = c;
        }//TODO: fix this loop

        float ObjectAngle = angle;//create a temp value that keeps track of the angle of each element

        for(int m = 0; m < maximumObjects; m++) {
            objectAngles[m] = ObjectAngle;
            ObjectAngle += angle;
        }

        for(int i = 0; i < carouselObjects.Length; i++) { //loop through the objects
            carouselObjects[i].transform.position = this.transform.position;//Reset objects to the postion of the carousel center
            carouselObjects[i].transform.rotation = Quaternion.identity; //make sure their rotation is zero
            carouselObjects[i].transform.parent = this.transform; // make the element child to the carousel center
            carouselObjects[i].transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + distanceFromCenter);//move each carousel item from the center an amount of "DistanceFromCenter"

			if(i < maximumObjects) {
                carouselObjects[i].transform.RotateAround(positionCarousel, axisCarousel, objectAngles[i]);//position the element in their respective locations accordind to the center throufh rotation
            } else if(i >= maximumObjects) {
				carouselObjects[i].GetComponent<ClothingPieceHandler>().SetActiveness(false);
			}
        }
        //parent wel hier houden ^ net als de eerste positions van het resetten naar carousel center

        //Make sure an element is perfectly centered.
        if(maximumObjects % 2 != 0) {
            float rotateAngle = angle + angle / 2;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, rotateAngle, transform.eulerAngles.z);
            newAngle = rotateAngle;
        } else {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, angle, transform.eulerAngles.z);
            newAngle = angle;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// Correct the carrousel and make sure the first item in the array is the first element in the carousel
        ///
        /*theRayCaster.position = transform.position;
        string objectName = "";
        RaycastHit hit;
        if(Physics.Raycast(transform.position, -theRayCaster.forward, out hit, DistanceFromCenter)) {
            objectName = hit.collider.name;
        }

        if(objectName != carouselObjects[0].name) // only work if the first item presented isn't the first item in the array
        {
            for(int c = 0; c < carouselObjects.Length; c++) //loop through the array
            {
                if(carouselObjects[c].name == objectName) {
                    float angleMultiplier = c++; //the array starts with zero so adding 1 to c gives the correct value
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + Angle * angleMultiplier, transform.eulerAngles.z); //rotate the carousel to center the first object in the array
                    newAngle = transform.eulerAngles.y; //reset the angle to the newly calculated angle

                    break; //exit the loop so it won't do any unecessary calculations
                }
            }
        }*/
        ////////////////////////////////////////////////////////////////////////////////////////////////////////
    }

    // Update is called once per frame
    void Update() {
        /*if(AssumeObject == false) {
            // use raycast to dynamically check which item is selected not recommended unless necessary
            theRayCaster.position = transform.position;
            RaycastHit hit;
            if(Physics.Raycast(transform.position, -theRayCaster.forward, out hit, DistanceFromCenter)) {
                Debug.Log("FILE NAME: Carousel.cs " + "MESSAGE: --- " + "XXX??" + hit.collider.name);//display in the console which element is detected
            }
        }*/

        Quaternion newRotation = Quaternion.AngleAxis(newAngle, Vector3.up); // pick the rotation axis and angle
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, speedOfRotation);  //animate the carousel


        if(OVRInput.GetDown(button, controller)) {
            Debug.Log("hey");
        }
    }

    public void rotateTheCarousel()// call this function to rotate the carousel
    {
        if(firstTime) // if run the first time calcule the offset
        {
            newAngle = transform.eulerAngles.y;
            newAngle -= angle;
            firstTime = false; // stop this piece of code from running in the future
        } else {
            newAngle -= angle; //calculate the new angle
        }

        //if(AssumeObject == true) //here we check which element is selected and if we reached the end of the array we reset the index
        //{
            carouselObjects[currentVisibleIndexes[0]].GetComponent<ClothingPieceHandler>().SetActiveness(false);
            for(int i = 0; i < currentVisibleIndexes.Length; i++) {
                if(currentVisibleIndexes[i] >= carouselObjects.Length-1) {
                    currentVisibleIndexes[i] = 0;
                } else {
                    currentVisibleIndexes[i]++;
                }
            }
            carouselObjects[currentVisibleIndexes[maximumObjects-1]].GetComponent<ClothingPieceHandler>().SetActiveness(true);
            Debug.Log("FILE NAME: Carousel.cs " + "MESSAGE: --- " + "Carousel rotated to the right, current selected piece: " + carouselObjects[currentVisibleIndexes[0]].name); //show in the console the name of the selected element
        //}
        
        carouselObjects[currentVisibleIndexes[maximumObjects-1]].transform.RotateAround(positionCarousel, axisCarousel, objectAngles[currentSpawnAngle]);
        Debug.Log("Current angle: " + objectAngles[currentSpawnAngle]);

        if(currentSpawnAngle >= maximumObjects-1) {
            currentSpawnAngle = 0;
        } else {
            currentSpawnAngle++;
        } //TODO: make this neater

        /*if(currentVisibleIndexes[maximumObjects - 1] == carouselObjects.Length - 1) {
            currentSpawnAngle = maximumObjects-1;
        }*/
    }
}