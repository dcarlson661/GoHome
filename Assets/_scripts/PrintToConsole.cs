using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PrintToConsole : MonoBehaviour {

    public Vector2 location     = new Vector2(2.0f, 3.0f);
    public Vector2 homeLocation = new Vector2(5.0f, 1.0f);
    public Vector2 pathToHome;
    public bool    GotHome      = false;

    public Text home,player,status;

	// Use this for initialization
	void Start () {
        pathToHome = homeLocation - location;
        print("Welcome to Go Home!");
        print("A game where you need to find your way back.");
        PrintStats();
	}

    // Update is called once per frame
    void Update() {
        if (!GotHome)
        { 
        updateMovement(KeyCode.LeftArrow,  new Vector2(-1, 0));
        updateMovement(KeyCode.RightArrow, new Vector2(1, 0));
        updateMovement(KeyCode.UpArrow,    new Vector2(0, 1));
        updateMovement(KeyCode.DownArrow,  new Vector2(0, -1));
        }
    }
    void updateMovement(KeyCode kc, Vector2 movementVector)
    {
        if (Input.GetKeyDown(kc))
        {
            location   = location + movementVector;
            pathToHome = homeLocation - location;
            PrintStats();
            if (location == homeLocation)
            {
                GotHome = true;
                status.color= new Color(1f, 0.5f, 0.8f);
                status.text = "Your Home!";
                print("I am at home");
            }
            else
            {
                status.color = new Color(1f, pathToHome.x, pathToHome.y);
                status.text = "Distance " + pathToHome.magnitude.ToString() +" Keep Moving.";
            }
        }
        //else kc is not up,down,left or right so do nothing
    }

    void PrintStats()
    {
        home.text = "Home:"+homeLocation.ToString();
        print("home :"             + homeLocation);
        player.text = "Player:" + location.ToString();
        print("location: "         + location);
        print("Distance to home: " + pathToHome.magnitude);
    }
}
