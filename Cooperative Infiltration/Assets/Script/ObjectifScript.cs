using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectifScript : MonoBehaviour
{


	private void Start()
	{
		
	}

	private void OnTriggerEnter(Collider other)
	{

		if(other.tag=="Player")
		{
			other.GetComponent<PlayerScript>().CmdFinGame(true);

			
		}
		Debug.Log("prout");
		//SceneManager.LoadScene(1);
		//On va mettre stop le jeu puis mettre une ui pour echec ou réaussite

	}
}
