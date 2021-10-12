using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SpawnEnnemi : NetworkBehaviour
{
    public GameObject m_MyGameObejet;

    GameObject m_MyInstantiated;

    bool act = true;

    // Start is called before the first frame update
    void Start()
    {

        
        
    }

	private void Update()
	{
        if (isServer && act)
        {
            m_MyInstantiated = Instantiate(m_MyGameObejet);

            NetworkServer.Spawn(m_MyInstantiated);

            act = false;
        }
    }



}
