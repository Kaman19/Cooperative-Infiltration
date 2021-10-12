using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarScript : MonoBehaviour
{

	Image bar;


	float val, pc, pvBase;
	// Start is called before the first frame update
	void Start()
    {
		bar = transform.Find("bar").GetComponent<Image>();
		//pvBase = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().pv;
	}

 //   // Update is called once per frame
 //   void Update()
 //   {
	//	val = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().pv;

	//	pc = val / pvBase;

	//	pc = pc * 100;

	//	bar.fillAmount = pc / 100;
	//}
}
