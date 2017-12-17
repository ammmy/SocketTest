/* 参考
 * https://blog.sky-net.pw/article/36
 * https://qiita.com/msrks/items/0550603efc59f6e8ba09
 * https://qiita.com/haminiku/items/0661568d0e311c8e8381
 * http://kou-yeung.hatenablog.com/entry/2017/02/18/040901
 */

using UnityEngine;
using System.Collections;
using System.Net.Sockets;
using System.Text;
using System;

public class mTcpClient : MonoBehaviour
{
	public string host = "127.0.0.1";
	public int port = 3333;
	byte[] readbuf = new byte[1024];

	TcpClient client;
	NetworkStream stream;

	void Start ()
	{
		StartCoroutine (LateConnect ());
	}

	IEnumerator LateConnect ()
	{
		yield return new WaitForSeconds(1);
		Connect ();
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.D)) {
			string msg = "from Client\n";
			SendMessage (msg);
		}
	}

	void Connect ()
	{
		client = new TcpClient (host, port);
		stream = client.GetStream ();
		stream.ReadTimeout = 10;
		StartCoroutine (Read ());
	}

	public void SendMessage (string msg)
	{
		byte[] bytes = System.Text.Encoding.ASCII.GetBytes (msg);
		stream.Write (bytes, 0, bytes.Length);
	}

	IEnumerator Read ()
	{
		while (true) {
			stream.BeginRead (readbuf, 0, readbuf.Length, new AsyncCallback (ReadCallback), null);
			yield return null;
		}
	}

	void ReadCallback (IAsyncResult ar)
	{
		Encoding enc = Encoding.UTF8;
		int bytes = stream.EndRead (ar);
		string message = enc.GetString (readbuf, 0, bytes);
		message = message.Replace ("\r", "").Replace ("\n", "");
		Debug.Log (message);
	}
}