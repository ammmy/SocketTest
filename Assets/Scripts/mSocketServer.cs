using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mSocketServer : SocketServer
{
	public string host = "127.0.0.1";
	public int port = 3333;

	void Start ()
	{
		base.listen (host, port);
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.A)) {
			sendMessage ("from Unity server");
		}
	}

	protected override void OnMessage (string msg)
	{
		Debug.Log (msg);
	}
}