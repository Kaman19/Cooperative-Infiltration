using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BoutonTest : MonoBehaviour
{
    public GameObject pl;
    public void Spawn()
    {
        NetworkServer.AddPlayerForConnection(pl.GetComponent<Player>().connectionToClient, pl, 1);
    }
}
