using System;
using System.Net;
using System.Threading;
using UnityEngine;

namespace AssetLayer.Unity { 

    public delegate void RequestHandler(HttpListenerContext context);


    public class HttpServer
    {
        public RequestHandler onRequestReceived;
        private HttpListener listener;
        private Thread listenerThread;
        private volatile bool isRunning;

        public HttpServer()
        {
            listener = new HttpListener();
            // Listen on localhost, port 8080, and all URIs starting with "test"
            listener.Prefixes.Add("http://localhost:8080/loginUnity/");
        }



        public void Start()
        {
            Debug.Log("HTTP server starting");
            listener.Start();
            isRunning = true;
            listenerThread = new Thread(HandleRequests);
            listenerThread.Start();
            Debug.Log("HTTP server started");
        }

        private void HandleRequests()
        {
            try
            {
                while (isRunning)
                {
                    if (listener.IsListening)
                    {
                        var context = listener.GetContext();
                        ThreadPool.QueueUserWorkItem(o =>
                        {
                            try
                            {
                                ProcessRequest(context);
                            }
                            catch (Exception ex)
                            {
                                Debug.LogError("Error processing request: " + ex.Message);
                            }
                        });
                    }
                    else
                    {
                        // If the listener is not listening, we should exit the loop
                        break;
                    }
                }
            }
            catch (HttpListenerException e)
            {
                if (e.ErrorCode == 995) // ERROR_OPERATION_ABORTED
                {
                    Debug.Log("Listener was closed, exiting listener thread.");
                }
                else
                {
                    Debug.LogError("Unhandled HttpListenerException: " + e.Message);
                }
            }
            catch (Exception ex)
            {
                Debug.LogError("Unhandled exception in listener thread: " + ex.Message);
            }
        }

        private void ProcessRequest(HttpListenerContext context)
        {
            Debug.Log("Request received ");
            onRequestReceived?.Invoke(context);
        }
        public void Stop()
        {
            Debug.Log("stopping login server");
            isRunning = false; // Signal the listener thread to stop
            listener.Stop();   // Stop listening for new requests

            if (listenerThread != null && listenerThread.IsAlive)
            {
                listenerThread.Join(); // Wait for the listener thread to finish
            }

            listener.Close(); // Safely close the listener
        }

    }
}

