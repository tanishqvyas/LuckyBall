using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //for text

public class game : MonoBehaviour
{

	// private Renderer rend;
	private SpriteRenderer rend;
	private int number;
	private int number2;
	private int curTime = 0;
	private int timeRate = 8;
	private int diff = 0;
	public Text timeLeft;
	public Text score;
	private int myscore = -1;
	private float spikeUp = 0.2f;
	private float spikeDown = -0.382f;

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


	   	if(number == 1)
	   	{
	   		rend.color = Color.red;
	   	}
	   	else if(number == 2)
	   	{
	   		rend.color = Color.green;
	   	}
	   	else if(number == 3)
	   	{
	   		rend.color = Color.cyan;
	   	}
	   	else if(number == 4)
	   	{
	   		rend.color = Color.yellow;
	   	}
	   	else if(number == 5)
	   	{
	   		rend.color = Color.white;
	   	}

	   	// Spikes show controller
	   	if(number != 1 && number2 != 1)
	   	{	
	   		redspike.transform.position = new Vector3(redspike.transform.position.x, spikeUp, redspike.transform.position.z);
	   	}

	   	if(number != 2 && number2 != 2)
	   	{
	   		greenspike.transform.position = new Vector3(greenspike.transform.position.x, spikeUp, greenspike.transform.position.z);
	   	}

	   	if(number != 3 && number2 != 3)
	   	{
	   		bluespike.transform.position = new Vector3(bluespike.transform.position.x, spikeUp, bluespike.transform.position.z);

	   	}

	   	if(number != 4 && number2 != 4)
	   	{
	   		yellowspike.transform.position = new Vector3(yellowspike.transform.position.x, spikeUp, yellowspike.transform.position.z);

	   	}

	   	if(number != 5 && number2 != 5)
	   	{
	   		whitespike.transform.position = new Vector3(whitespike.transform.position.x, spikeUp, whitespike.transform.position.z);
	   	}


	   	StartCoroutine("delay");

    }

}
