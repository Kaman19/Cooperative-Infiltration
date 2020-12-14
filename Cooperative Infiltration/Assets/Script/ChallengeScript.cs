using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeScript : MonoBehaviour
{

	[SerializeField] GameObject spawn1,spawn2,spawn3,obj;

	public float shootForce = 30f;


	public	bool activation = true;
	public float delay = 4f;

	

    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
		

		if (activation)
		{
			StartCoroutine(SpawnAtt());
		}

		

		

    }

	void SpawnObj()
	{
		int pos = Random.Range(0, 3);

		GameObject b;

		switch (pos)
		{
			case 0:

				


				b = Instantiate(obj, spawn1.transform.position, Quaternion.identity);
				b.GetComponent<Rigidbody>().velocity = spawn1.transform.forward * shootForce;

				break;

			case 1:

				


				b = Instantiate(obj, spawn2.transform.position, Quaternion.identity);
				b.GetComponent<Rigidbody>().velocity = spawn2.transform.forward * shootForce;


				break;

			case 2:

				


				b = Instantiate(obj, spawn3.transform.position, Quaternion.identity);
				b.GetComponent<Rigidbody>().velocity = spawn3.transform.forward * shootForce;


				break;


		}


	}


	IEnumerator SpawnAtt()
	{
		activation = false;

		SpawnObj();

		yield return new WaitForSeconds(delay);

		activation = true;
	}
}
