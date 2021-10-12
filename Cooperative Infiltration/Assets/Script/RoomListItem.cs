using UnityEngine;
using UnityEngine.Networking.Match;
using UnityEngine.UI;


public class RoomListItem : MonoBehaviour
{


	public delegate void JoinRoomDelegate(MatchInfoSnapshot _match);
	JoinRoomDelegate joinRoomCallback;

	[SerializeField]
	Text roomNameText;


	MatchInfoSnapshot match;

	public void Setup(MatchInfoSnapshot _match, JoinRoomDelegate _joinRoomCallback)
	{
		match = _match;
		joinRoomCallback = _joinRoomCallback;
		roomNameText.text = match.name;
	}

	public void JoinRoom()
	{
		joinRoomCallback.Invoke(match);
	}
}
