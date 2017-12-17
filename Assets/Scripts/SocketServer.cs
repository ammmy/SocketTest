using UnityEngine;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;

public class SocketServer : MonoBehaviour
{
	TcpListener listener = null;
	List<TcpClient> clients = new List<TcpClient> ();
	readonly object lockObj = new object ();

	protected void listen (string host, int port)
	{
		IPAddress ip = IPAddress.Parse (host);
		listener = new TcpListener (ip, port);
		listener.Start ();
		listener.BeginAcceptSocket (OnRequested, listener);
	}

	public void sendMessage (string msg)
	{
		if (clients.Count == 0) {
			return;
		}
		byte[] body = System.Text.Encoding.UTF8.GetBytes (msg);

		foreach (var client in clients) {
			try {
				NetworkStream stream = client.GetStream ();
				stream.Write (body, 0, body.Length);
			} catch (Exception e) {
				Debug.Log (e);
				clients.Remove (client);
			}
		}
	}

	protected virtual void OnApplicationQuit ()
	{
		if (listener == null) {
			return;
		}

		if (clients.Count != 0) {
			foreach (var client in clients) {
				client.Close ();
			}
		}
		listener.Stop ();
	}

	protected virtual void OnMessage (string msg)
	{
	}

	void OnRequested (IAsyncResult ar)
	{
		lock (lockObj) {
			TcpListener listener = (TcpListener)ar.AsyncState;
			TcpClient client = listener.EndAcceptTcpClient (ar);
			clients.Add (client);
			NetworkStream stream = client.GetStream ();

			StreamReader reader = new StreamReader (stream);

			while (client.Connected) {
				while (!reader.EndOfStream) {
					OnMessage (reader.ReadLine ());
				}

				if (client.Client.Poll (1000, SelectMode.SelectRead) && (client.Client.Available == 0)) {
					clients.Remove (client);
					break;
				}
			}
			listener.BeginAcceptSocket (OnRequested, listener);
		}
	}
}
