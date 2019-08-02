using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class TCPTestClient : MonoBehaviour
{
    public static TCPTestClient instancia;

    #region private members 	
    private TcpClient socketConnection;
    private Thread clientReceiveThread;

    public string ipClient;
    public string valor;
  //  public Text messajeText;
    #endregion

    private void Awake()
    {
        instancia = this;
    }
    // Use this for initialization 	
    void Start()
    {
        ipClient = EnterIpClient.Instance.DireccionIp;
        ConnectToTcpServer();
    }
    // Update is called once per frame
    void Update()
    {
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
    /// Setup socket connection. 	
    /// </summary> 	
    private void ConnectToTcpServer()
    {
        try
        {
            clientReceiveThread = new Thread(new ThreadStart(ListenForData));
            clientReceiveThread.IsBackground = true;
            clientReceiveThread.Start();
        }
        catch (Exception e)
        {
            Debug.Log("On client connect exception " + e);
        }
    }
    /// <summary> 	
    /// Runs in background clientReceiveThread; Listens for incomming data. 	
    /// </summary>     
    private void ListenForData()
    {
        try
        {
            socketConnection = new TcpClient(ipClient, 8052); //"localhost" //"192.168.111.13"
            Byte[] bytes = new Byte[1024];
            while (true)
            {
                Debug.Log("Conected");
                // Get a stream object for reading 				
                using (NetworkStream stream = socketConnection.GetStream())
                {
                   
                    int length;
                    // Read incomming stream into byte arrary. 					
                    while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        var incommingData = new byte[length];
                        Array.Copy(bytes, 0, incommingData, 0, length);
                        // Convert byte array to string message. 						
                        string serverMessage = Encoding.ASCII.GetString(incommingData);
                        Debug.Log("server message received as: " + serverMessage);

                        if (serverMessage.Length == 1)
                        {
                            Message1();
                            Debug.Log("se cogio uno");
                        }
                        else if (serverMessage.Length == 2)
                        {
                            Message2();
                            Debug.Log("se cogio dos");
                        }
                        else if (serverMessage.Length == 3)
                        {
                            Message3();
                            Debug.Log("se cogio tres");
                        }
                        else if (serverMessage.Length == 4)
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
        catch (SocketException socketException)
        {
            Debug.Log("Socket exception: " + socketException);
        }
    }
    /// <summary> 	
    /// Send message to server using socket connection. 	
    /// </summary> 	
    private void SendMessage()
    {
        if (socketConnection == null)
        {
            return;
        }
        try
        {
            // Get a stream object for writing. 			
            NetworkStream stream = socketConnection.GetStream();
            if (stream.CanWrite)
            {
                string clientMessage = "1";
                // Convert string message to byte array.                 
                byte[] clientMessageAsByteArray = Encoding.ASCII.GetBytes(clientMessage);
                // Write byte array to socketConnection stream.                 
                stream.Write(clientMessageAsByteArray, 0, clientMessageAsByteArray.Length);
               // messajeText.text = "Tecla: " + clientMessage;
                Debug.Log("Client sent his message - should be received by server - 1");
            }
        }
        catch (SocketException socketException)
        {
            Debug.Log("Socket exception: " + socketException);
        }
    }

    private void SendMessage2()
    {
        if (socketConnection == null)
        {
            return;
        }
        try
        {
            // Get a stream object for writing. 			
            NetworkStream stream = socketConnection.GetStream();
            if (stream.CanWrite)
            {
                string clientMessage = "11";
                // Convert string message to byte array.                 
                byte[] clientMessageAsByteArray = Encoding.ASCII.GetBytes(clientMessage);
                // Write byte array to socketConnection stream.                 
                stream.Write(clientMessageAsByteArray, 0, clientMessageAsByteArray.Length);
                Debug.Log("Client sent his message - 11");
            }
        }
        catch (SocketException socketException)
        {
            Debug.Log("Socket exception: " + socketException);
        }
    }

    private void SendMessage3()
    {
        if (socketConnection == null)
        {
            return;
        }
        try
        {
            // Get a stream object for writing. 			
            NetworkStream stream = socketConnection.GetStream();
            if (stream.CanWrite)
            {
                string clientMessage = "111";
                // Convert string message to byte array.                 
                byte[] clientMessageAsByteArray = Encoding.ASCII.GetBytes(clientMessage);
                // Write byte array to socketConnection stream.                 
                stream.Write(clientMessageAsByteArray, 0, clientMessageAsByteArray.Length);
                Debug.Log("Client sent his message - 111");
            }
        }
        catch (SocketException socketException)
        {
            Debug.Log("Socket exception: " + socketException);
        }
    }

    private void SendMessage4()
    {
        if (socketConnection == null)
        {
            return;
        }
        try
        {
            // Get a stream object for writing. 			
            NetworkStream stream = socketConnection.GetStream();
            if (stream.CanWrite)
            {
                string clientMessage = "1111";
                // Convert string message to byte array.                 
                byte[] clientMessageAsByteArray = Encoding.ASCII.GetBytes(clientMessage);
                // Write byte array to socketConnection stream.                 
                stream.Write(clientMessageAsByteArray, 0, clientMessageAsByteArray.Length);
                Debug.Log("Client sent his message - 1111");
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
