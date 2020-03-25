using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //for text

public class game : MonoBehaviour
{

	public GameObject coloPanel2;
	public GameObject coloPanel3;

	// Renderers for sprites of color panels
	private SpriteRenderer rend;
	private SpriteRenderer rend2;
	private SpriteRenderer rend3;

	private int number;
	private int number2;
	private int number3;

	private Color[] colorArray = {Color.red, Color.green, Color.cyan, Color.yellow, Color.white};

	private int curTime = 0;
	private int timeRate = 7;
	private int diff = 0;

	public Text timeLeft;
	public Text score;
	private int myscore = -1;
	
	private float spikeUp = 0.2f;
	private float spikeDown = -0.500f;

	// private float spikeMoveRate = 0.02f;
	public GameObject redspike;
	public GameObject greenspike;
	public GameObject bluespike;
	public GameObject yellowspike;
	public GameObject whitespike;


    // Start is called before the first frame update
    void Start()
    {	


    	redspike.transform.position = new Vector3(redspike.transform.position.x, spikeDown, redspike.transform.position.z);
       	greenspike.transform.position = new Vector3(greenspike.transform.position.x, spikeDown, greenspike.transform.position.z);
       	bluespike.transform.position = new Vector3(bluespike.transform.position.x, spikeDown, bluespike.transform.position.z);
       	yellowspike.transform.position = new Vector3(yellowspike.transform.position.x, spikeDown, yellowspike.transform.position.z);
       	whitespike.transform.position = new Vector3(whitespike.transform.position.x, spikeDown, whitespike.transform.position.z);


    	// Get Sprite renderer for the color tab
       	rend = GetComponent<SpriteRenderer>();
       	rend2 = coloPanel2.GetComponent<SpriteRenderer>();
       	rend3 = coloPanel3.GetComponent<SpriteRenderer>();

    	// Co routine to start counting time
    	StartCoroutine("LoseTime");
    	timeLeft.text = "Time Left : " + timeRate.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        diff = timeRate - curTime;
        timeLeft.text = "Time Left : " + diff.ToString();
    	


    	if (diff == -1)
        {
        	// Stop the timer coroutine
            StopCoroutine("LoseTime");
            timeLeft.text = "Time Left : 0";
            curTime = 0;
            
            StartCoroutine("ChangeColor");
            
        }

    }


    IEnumerator LoseTime()
    {
    	myscore++;
        score.text = "Luck Factor : " + myscore.ToString(); 
        while (true)
        {
            yield return new WaitForSeconds(1);
            curTime++;
        }
    }

    IEnumerator delay()
    {
        
        yield return new WaitForSeconds(1);

       	redspike.transform.position = new Vector3(redspike.transform.position.x, spikeDown, redspike.transform.position.z);
       	greenspike.transform.position = new Vector3(greenspike.transform.position.x, spikeDown, greenspike.transform.position.z);
       	bluespike.transform.position = new Vector3(bluespike.transform.position.x, spikeDown, bluespike.transform.position.z);
       	yellowspike.transform.position = new Vector3(yellowspike.transform.position.x, spikeDown, yellowspike.transform.position.z);
       	whitespike.transform.position = new Vector3(whitespike.transform.position.x, spikeDown, whitespike.transform.position.z);

	   	StartCoroutine("LoseTime");
    }

    public void ChangeColor()
    {
		// Random number for platform which is goind to be safe
	   	number = Random.Range(1,6);
	   	number2 = Random.Range(1,6);
	   	number3 = Random.Range(1,6);

	   	// Giving Color panels colors
	   	rend.color = colorArray[number-1];
	   	rend2.color = colorArray[number2-1];
	   	rend3.color = colorArray[number3-1];


	   	// Spikes show controller
	   	if(number != 1 && number2 != 1 && number3 != 1)
	   	{	
	   		redspike.transform.position = new Vector3(redspike.transform.position.x, spikeUp, redspike.transform.position.z);
	   	}

	   	if(number != 2 && number2 != 2 && number3 != 2)
	   	{
	   		greenspike.transform.position = new Vector3(greenspike.transform.position.x, spikeUp, greenspike.transform.position.z);
	   	}

	   	if(number != 3 && number2 != 3 && number3 != 3)
	   	{
	   		bluespike.transform.position = new Vector3(bluespike.transform.position.x, spikeUp, bluespike.transform.position.z);

	   	}

	   	if(number != 4 && number2 != 4 && number3 != 4)
	   	{
	   		yellowspike.transform.position = new Vector3(yellowspike.transform.position.x, spikeUp, yellowspike.transform.position.z);

	   	}

	   	if(number != 5 && number2 != 5 && number3 != 5)
	   	{
	   		whitespike.transform.position = new Vector3(whitespike.transform.position.x, spikeUp, whitespike.transform.position.z);
	   	}

	   	// Play sound
	   	FindObjectOfType<AudioManager>().Play("spikeup");



	   	StartCoroutine("delay");

    }

}
