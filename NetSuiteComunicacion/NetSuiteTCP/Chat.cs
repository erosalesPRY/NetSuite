using System;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using NetSuiteSocket;
using NetSuiteSocket.Server;

namespace NetSuiteTCP
{
    [Serializable]
    public class ChatPaqueteBE {
        public string name { get; set; }
        public string platform { get; set; }
        public string formId { get; set; }
        public string codPersonal { get; set; }
        public string userDestino { get; set; }
        public string  status { get; set; }
        public string idContacto { get; set; }

        public ChatPaqueteBE() { }


        public string ToSerializedJSon()
        {
            const string returnCarr = "\r\n";

            string cmll = "\"";
            Type typeData = this.GetType();
            int idx = 0;
            string Structura = "{";
            Structura += returnCarr;
            foreach (var propertyInfo in typeData.GetProperties())
            {
                if (propertyInfo.GetValue(this, propertyInfo.GetIndexParameters()) != null)
                {
                    Structura += ((idx==0)?"": ",") + propertyInfo.Name.ToString() + ":" + cmll +  propertyInfo.GetValue(this, propertyInfo.GetIndexParameters()) + cmll;
                }
                else
                {
                    Structura += ((idx == 0) ? "" : ",") + propertyInfo.Name.ToString() + ":" + cmll +cmll;
                }
                Structura += returnCarr;
                idx++;
            }
            Structura += "}";
            return Structura;
        }

    }
  public class Chat : WebSocketBehavior
  {
        private string     _name;
        private static int _number = 0;
        private string     _prefix;
        private const string cmll = "\"";
        private const string DosPuntos = ":";
        private const string KEYQParamUserName = "name";
        private const string KEYQParamPlataforma = "platform";
        private const string KEYQParamFormId = "formId";
        private const string KEYQParamCodPer = "CodPer";
        private const string KEYQParamIdContacto = "IdContac";

        const ushort CLOSE_NORMAL = 1000;
        const ushort CLOSE_GOING_AWAY = 1001;
        const ushort CLOSE_PROTOCOL_ERROR = 1002;
        const ushort CLOSE_UNSUPPORTED = 1003;
        const ushort CLOSE_NO_STATUS = 1005;

        public Chat ()
    {
      _prefix = "anon#";
    }

    public string Prefix {
      get {
        return _prefix;
      }

      set {
        _prefix = !value.IsNullOrEmpty () ? value : "anon#";
      }
    }

    private string getName ()
    {
      var name = QueryString["name"];

      return !name.IsNullOrEmpty () ? name : _prefix + getNumber ();
    }

    private static int getNumber ()
    {
      return Interlocked.Increment (ref _number);
    }

    protected override void OnClose (CloseEventArgs e)
    {
      if (_name == null)
        return;

            switch (e.Code) {
                case CLOSE_NO_STATUS:
                    //Cierra y comunica a todos los contactos su estado
                    ChatPaqueteBE chatPaqueteBE = new ChatPaqueteBE();
                    chatPaqueteBE.name = getName();
                    chatPaqueteBE.platform = QueryString[KEYQParamPlataforma];
                    chatPaqueteBE.codPersonal = QueryString[KEYQParamCodPer];
                    chatPaqueteBE.status = "0";
                    //Actualiza el estado del que cerro la session

                    //Avisar a todos los contactos que el usuario termino la session
                    Sessions.Broadcast("chatCloseContact|" +chatPaqueteBE.ToSerializedJSon());
                    break;
                default:
                    //cancela el cierre de alguna manera

                    break;
            }

         /*

      var fmt = "{0} got logged off...";
      var msg = String.Format (fmt, _name);

      Sessions.Broadcast (msg);*/

    }

        protected override void OnMessage(MessageEventArgs e)
        {
            string[] strPaquete = e.Data.Split('|');
            switch (strPaquete[0]) {
                case "CheckStatus":
                    string arrData = strPaquete[1];

                    break;
                default:
                     Sessions.Broadcast(e.Data);
                    break;
            }
           // ConeccionBE ContecionEtranteBE = new ConeccionBE(this._websocket.Url.Query);

        }

    protected override void OnOpen ()
    {
      _name = getName ();

        ChatPaqueteBE chatPaqueteBE = new ChatPaqueteBE ();
        chatPaqueteBE.name = _name;
        chatPaqueteBE.platform = QueryString[KEYQParamPlataforma];
        chatPaqueteBE.formId = QueryString[KEYQParamFormId];
        chatPaqueteBE.name = QueryString[KEYQParamUserName];
        chatPaqueteBE.codPersonal = QueryString[KEYQParamCodPer];
        chatPaqueteBE.idContacto= QueryString[KEYQParamIdContacto];
        chatPaqueteBE.status = "1";
            string oResponse = "chatPaqueteBE|" + chatPaqueteBE.ToSerializedJSon();

        Sessions.Broadcast (oResponse);
    }
  }
}
