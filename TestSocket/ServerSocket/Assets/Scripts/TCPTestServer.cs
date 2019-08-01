using System;
using System.Collections; 
using System.Collections.Generic; 
using System.Net; 
using System.Net.Sockets; 
using System.Text; 
using System.Threading; 
using UnityEngine;

public class TCPTestServer : MonoBehaviour {

    public static TCPTestServer instancia;
	#region private members 	
	/// <summary> 	
	/// TCPListener to listen for incomming TCP connection 	
	/// requests. 	
	/// </summary> 	
	private TcpListener tcpListener; 
	/// <summary> 
	/// Background thread for TcpServer workload. 	
	/// </summary> 	
	private Thread tcpListenerThread;  	
	/// <summary> 	
	/// Create handle to connected tcp client. 	
	/// </summary> 	
	private TcpClient connectedTcpClient;

    public string ipServer;
    public string valor;
    #endregion

    private void Awake()
    {
        instancia = this;
    }
    // Use this for initialization
    void Start() {
        ipServer = EnterIpServer.Instance.DireccionIp;
        // Start TcpServer background thread 		
        tcpListenerThread = new Thread (new ThreadStart(ListenForIncommingRequests)); 		
		tcpListenerThread.IsBackground = true; 		
		tcpListenerThread.Start(); 	
	}  	
	
	// Update is called once per frame
	void Update () { 		
		if (Input.GetKeyDown(KeyCode.Z))
        {             
			SendMessage();         
		}
        else if (Input.GetKeyDown(KeyCode.X))
        {
            SendMessage2();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            SendMessage3();
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            SendMessage4();
        }
	}  	
	
	/// <summary> 	
	/// Runs in background TcpServerThread; Handles incomming TcpClient requests 	
	/// </summary> 	
	private void ListenForIncommingRequests ()
    { 		
		try
        { 			
			// Create listener on localhost port 8052. 			
			tcpListener = new TcpListener(IPAddress.Parse(ipServer), 8052); 			//was 127.0.0.1
			tcpListener.Start();              
			Debug.Log("Server is listening");              
			Byte[] bytes = new Byte[1024];  			
			while (true)
            {
                using (connectedTcpClient = tcpListener.AcceptTcpClient())
                {
                    // Get a stream object for reading 					
                    using (NetworkStream stream = connectedTcpClient.GetStream())
                    {
                        int length;
                        // Read incomming stream into byte arrary. 						
                        while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
                        {
                            var incommingData = new byte[length];
                            Array.Copy(bytes, 0, incommingData, 0, length);
                            // Convert byte array to string message. 							
                            string clientMessage = Encoding.ASCII.GetString(incommingData);
                            Debug.Log("client message received as: " + clientMessage);

                            if (clientMessage.Length == 1)
                            {
                                Message1();
                                Debug.Log("se cogio uno");
                            }
                            else if (clientMessage.Length == 2)
                            {
                                Message2();
                                Debug.Log("se cogio dos");
                            }
                            else if (clientMessage.Length == 3)
                            {
                                Message3();
                                Debug.Log("se cogio tres");
                            }
                            else if (clientMessage.Length == 4)
                            {
                                Message4();
                                Debug.Log("se cogio cuatro");
                            }
                            else
                            {
                                Debug.Log("nada");
                            }
                        }
                    }
                } 			
			} 		
		} 		
		catch (SocketException socketException)
        { 			
			Debug.Log("SocketException " + socketException.ToString()); 		
		} 
        
	}  	

	/// <summary> 	
	/// Send message to client using socket connection. 	
	/// </summary> 	
	public void SendMessage()
    { 		
		if (connectedTcpClient == null)
        {             
			return;         
		}  		
		
		try
        { 			
			// Get a stream object for writing. 			
			NetworkStream stream = connectedTcpClient.GetStream(); 			
			if (stream.CanWrite)
            {
                string serverMessage = "1"; 			
				// Convert string message to byte array.                 
				byte[] serverMessageAsByteArray = Encoding.ASCII.GetBytes(serverMessage); 				
				// Write byte array to socketConnection stream.               
				stream.Write(serverMessageAsByteArray, 0, serverMessageAsByteArray.Length);
                Debug.Log("Server sent his message - should be received by client - 1");           
			}       
		} 		
		catch (SocketException socketException)
        {             
			Debug.Log("Socket exception: " + socketException);         
		} 	
	}

    private void SendMessage2()
    {
        if (connectedTcpClient == null)
        {
            return;
        }

        try
        {
            // Get a stream object for writing. 			
            NetworkStream stream = connectedTcpClient.GetStream();
            if (stream.CanWrite)
            {
                string serverMessage = "11";
                // Convert string message to byte array.                 
                byte[] serverMessageAsByteArray = Encoding.ASCII.GetBytes(serverMessage);
                // Write byte array to socketConnection stream.               
                stream.Write(serverMessageAsByteArray, 0, serverMessageAsByteArray.Length);
                Debug.Log("Server sent his message - should be received by client - 11");
            }
        }
        catch (SocketException socketException)
        {
            Debug.Log("Socket exception: " + socketException);
        }
    }

    private void SendMessage3()
    {
        if (connectedTcpClient == null)
        {
            return;
        }

        try
        {
            // Get a stream object for writing. 			
            NetworkStream stream = connectedTcpClient.GetStream();
            if (stream.CanWrite)
            {
                string serverMessage = "111";
                // Convert string message to byte array.                 
                byte[] serverMessageAsByteArray = Encoding.ASCII.GetBytes(serverMessage);
                // Write byte array to socketConnection stream.               
                stream.Write(serverMessageAsByteArray, 0, serverMessageAsByteArray.Length);
                Debug.Log("Server sent his message - should be received by client - 111");
            }
        }
        catch (SocketException socketException)
        {
            Debug.Log("Socket exception: " + socketException);
        }
    }

    private void SendMessage4()
    {
        if (connectedTcpClient == null)
        {
            return;
        }

        try
        {
            // Get a stream object for writing. 			
            NetworkStream stream = connectedTcpClient.GetStream();
            if (stream.CanWrite)
            {
                string serverMessage = "1111";
                // Convert string message to byte array.                 
                byte[] serverMessageAsByteArray = Encoding.ASCII.GetBytes(serverMessage);
                // Write byte array to socketConnection stream.               
                stream.Write(serverMessageAsByteArray, 0, serverMessageAsByteArray.Length);
                Debug.Log("Server sent his message - should be received by client - 1111");
            }
        }
        catch (SocketException socketException)
        {
            Debug.Log("Socket exception: " + socketException);
        }
    }


    public void Message1()
    {
        valor = "1";
    }

    public void Message2()
    {
        valor = "11";
    }

    public void Message3()
    {
        valor = "111";
    }

    public void Message4()
    {
        valor = "1111";
    }
}