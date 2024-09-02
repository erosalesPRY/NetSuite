using System;
using NetSuiteSocket;
using NetSuiteSocket.Server;

namespace NetSuiteTCP
{
  public class Echo : WebSocketBehavior
  {
        int Id = 0;
    protected override void OnMessage (MessageEventArgs e)
    {
      Send (e.Data);
    }

    protected override void OnOpen(){
            base.OnOpen();
            Id++;
            Send(Id.ToString());
        }
  }
}
