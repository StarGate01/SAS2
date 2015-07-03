using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading;

namespace SAS2_MW
{
    public class ScratchListener: IDisposable
    {

        private int PortNumber;
        private HttpListener Listener;
        private CancellationTokenSource ListeningThreadCancelToken;

        public event RequestEventHandler Request;
        public delegate string RequestEventHandler(object sender, RequestEventArgs args);
        protected virtual string OnRequest(RequestEventArgs args) { if (Request != null) return Request(this, args); return ""; }
        public struct RequestEventArgs
        {

            public String RawURL;

        }

        public ScratchListener(int portNumber)
        {
            PortNumber = portNumber;
            Listener = new HttpListener();
            Listener.Prefixes.Add("http://+:" + portNumber + "/");
            ListeningThreadCancelToken = new CancellationTokenSource();
            Listener.Start();
            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object cToken)
            {
                CancellationToken token = (CancellationToken)cToken;
                while (!token.IsCancellationRequested)
                {
                    IAsyncResult asyncResult = Listener.BeginGetContext(new AsyncCallback(HandleRequest), Listener);
                    asyncResult.AsyncWaitHandle.WaitOne();
                }
            }), ListeningThreadCancelToken.Token);
        }

        public void Dispose()
        {
            ListeningThreadCancelToken.Cancel();
            Listener.Close();
        }

        private void HandleRequest(IAsyncResult result)
        {
            HttpListener listener = (HttpListener)result.AsyncState;
            if (!listener.IsListening) return;
            try
            {
                HttpListenerContext context = listener.EndGetContext(result);
                HttpListenerRequest request = context.Request;
                string responseString = OnRequest(new RequestEventArgs() { RawURL = request.RawUrl });
                HttpListenerResponse response = context.Response;
                response.StatusCode = 200;
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                response.ContentLength64 = buffer.Length;
                System.IO.Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                output.Close();
            }
            catch { } //Thread is kill, every man for himself! xX_420BLAZEIT_Xx
        }

    }
}
