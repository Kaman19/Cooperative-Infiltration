using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{

	[SerializeField] GameObject cPuzzle, challenge;
	GameManagerScript gm;

	public int startCountDown = 60;

	int timeDelta = 0;
	float delay = 0;

	Text TxtCountDown;

	Vector3 temp,tempRot;



	// Start is called before the first frame update
	void Start()
    {
		

		TxtCountDown=GetComponent<Text>() ;
		TxtCountDown.text = "00 : " + startCountDown;
		timeDelta = startCountDown / 6;
		gm = GameObject.Find("GameManager").GetComponent<GameManagerScript>();

	}

	public void PosRetour( Vector3 posTem, Vector3 rotTemp)
	{
		temp = posTem;
		tempRot = rotTemp;
	}


	IEnumerator Timer()
	{
		while(startCountDown>0)
		{
			yield return new WaitForSeconds(1f);
			startCountDown--;

			TxtCountDown.text = "00 : " + startCountDown;

			if ((startCountDown == timeDelta) || (startCountDown == timeDelta * 2) || (startCountDown == timeDelta * 3) || (startCountDown == timeDelta * 4) || (startCountDown == timeDelta * 5) || (startCountDown == timeDelta * 6))
			{
				//Debug.Log("time");
				delay = GameObject.Find("Challenge").GetComponent<ChallengeScript>().delay;
				delay = delay / 2;
				GameObject.Find("Challenge").GetComponent<ChallengeScript>().delay = delay;
			}
			if(startCountDown==0)
			{
				GameObject.Find("Timer").GetComponent<TimerScript>().Stop();
				challenge.SetActive(false);
				GameObject.Find("Player").transform.position = temp;
				GameObject.Find("Player").transform.eulerAngles = tempRot;
				cPuzzle.SetActive(false);
				gm.pActiver = false;

			}

		}
			
	}

	public void Go()
	{
		//startCountDown = 60;
		StartCoroutine(Timer());
	}

	public void Stop()
	{
		startCountDown = 60;
		StopCoroutine(Timer());
	}
}
