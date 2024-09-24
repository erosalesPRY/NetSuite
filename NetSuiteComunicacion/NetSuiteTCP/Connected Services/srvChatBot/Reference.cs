﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NetSuiteTCP.srvChatBot {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="srvChatBot.IChatBotManagerSoap")]
    public interface IChatBotManagerSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DetalleContacto", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable DetalleContacto(string CodPersonal, string UserName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ListarContatos", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable ListarContatos(string NOMBRECONTACTO, string UserName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ListarMiembros", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable ListarMiembros(int IdContacto, string UserName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/LstHistorialDialogo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable LstHistorialDialogo(string IdContactoOrg, int IdContactoDes, string UserName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/LstHistorialDialogoContenido", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable LstHistorialDialogoContenido(string Idmsg, string UserName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/LstHistorialDialogoContenidoLikes", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable LstHistorialDialogoContenidoLikes(string IdContents, string UserName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IsMiembrodeGrupo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable IsMiembrodeGrupo(int IdContactGrupo, string CodPersonal, string UserName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/LstContactSendtoGrupo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable LstContactSendtoGrupo(int IdContactGrupo, string UserName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/RegistrarMensajeyContenidoServer", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(BaseBE))]
        string RegistrarMensajeyContenidoServer(NetSuiteTCP.srvChatBot.MensajeContenidoBE oMensajeContenidoBE);
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el nombre de contenedor (RegistrarMensajeyContenidoCliente) del mensaje RegistrarMensajeyContenidoCliente no coincide con el valor predeterminado (RegistrarMensajeyContenidoClient)
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/RegistrarMensajeyContenidoCliente", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(BaseBE))]
        NetSuiteTCP.srvChatBot.RegistrarMensajeyContenidoCliente1 RegistrarMensajeyContenidoClient(NetSuiteTCP.srvChatBot.RegistrarMensajeyContenidoCliente request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9037.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class MensajeContenidoBE : BaseBE {
        
        private int idMiembroField;
        
        private string textoField;
        
        private int idContactoOrigenField;
        
        private int idContactoDestinoField;
        
        private string jSonBEField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int IdMiembro {
            get {
                return this.idMiembroField;
            }
            set {
                this.idMiembroField = value;
                this.RaisePropertyChanged("IdMiembro");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Texto {
            get {
                return this.textoField;
            }
            set {
                this.textoField = value;
                this.RaisePropertyChanged("Texto");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int IdContactoOrigen {
            get {
                return this.idContactoOrigenField;
            }
            set {
                this.idContactoOrigenField = value;
                this.RaisePropertyChanged("IdContactoOrigen");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int IdContactoDestino {
            get {
                return this.idContactoDestinoField;
            }
            set {
                this.idContactoDestinoField = value;
                this.RaisePropertyChanged("IdContactoDestino");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string JSonBE {
            get {
                return this.jSonBEField;
            }
            set {
                this.jSonBEField = value;
                this.RaisePropertyChanged("JSonBE");
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(MensajeContenidoBE))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9037.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class BaseBE : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string descripcionField;
        
        private string observacionField;
        
        private int idEstadoField;
        
        private string imgEstadoField;
        
        private string nombreEstadoField;
        
        private string userNameField;
        
        private string idCodigoField;
        
        private int idUsuarioField;
        
        private string tokenField;
        
        private string ambienteField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Descripcion {
            get {
                return this.descripcionField;
            }
            set {
                this.descripcionField = value;
                this.RaisePropertyChanged("Descripcion");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Observacion {
            get {
                return this.observacionField;
            }
            set {
                this.observacionField = value;
                this.RaisePropertyChanged("Observacion");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int IdEstado {
            get {
                return this.idEstadoField;
            }
            set {
                this.idEstadoField = value;
                this.RaisePropertyChanged("IdEstado");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string ImgEstado {
            get {
                return this.imgEstadoField;
            }
            set {
                this.imgEstadoField = value;
                this.RaisePropertyChanged("ImgEstado");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string NombreEstado {
            get {
                return this.nombreEstadoField;
            }
            set {
                this.nombreEstadoField = value;
                this.RaisePropertyChanged("NombreEstado");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string UserName {
            get {
                return this.userNameField;
            }
            set {
                this.userNameField = value;
                this.RaisePropertyChanged("UserName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string IdCodigo {
            get {
                return this.idCodigoField;
            }
            set {
                this.idCodigoField = value;
                this.RaisePropertyChanged("IdCodigo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public int IdUsuario {
            get {
                return this.idUsuarioField;
            }
            set {
                this.idUsuarioField = value;
                this.RaisePropertyChanged("IdUsuario");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string Token {
            get {
                return this.tokenField;
            }
            set {
                this.tokenField = value;
                this.RaisePropertyChanged("Token");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string ambiente {
            get {
                return this.ambienteField;
            }
            set {
                this.ambienteField = value;
                this.RaisePropertyChanged("ambiente");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="RegistrarMensajeyContenidoCliente", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class RegistrarMensajeyContenidoCliente {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public int IdMiembro;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string Texto;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public int IdContactOrg;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=3)]
        public int IdContactDes;
        
        public RegistrarMensajeyContenidoCliente() {
        }
        
        public RegistrarMensajeyContenidoCliente(int IdMiembro, string Texto, int IdContactOrg, int IdContactDes) {
            this.IdMiembro = IdMiembro;
            this.Texto = Texto;
            this.IdContactOrg = IdContactOrg;
            this.IdContactDes = IdContactDes;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="RegistrarMensajeyContenidoClienteResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class RegistrarMensajeyContenidoCliente1 {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string RegistrarMensajeyContenidoClienteResult;
        
        public RegistrarMensajeyContenidoCliente1() {
        }
        
        public RegistrarMensajeyContenidoCliente1(string RegistrarMensajeyContenidoClienteResult) {
            this.RegistrarMensajeyContenidoClienteResult = RegistrarMensajeyContenidoClienteResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IChatBotManagerSoapChannel : NetSuiteTCP.srvChatBot.IChatBotManagerSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ChatBotManagerSoapClient : System.ServiceModel.ClientBase<NetSuiteTCP.srvChatBot.IChatBotManagerSoap>, NetSuiteTCP.srvChatBot.IChatBotManagerSoap {
        
        public ChatBotManagerSoapClient() {
        }
        
        public ChatBotManagerSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ChatBotManagerSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ChatBotManagerSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ChatBotManagerSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataTable DetalleContacto(string CodPersonal, string UserName) {
            return base.Channel.DetalleContacto(CodPersonal, UserName);
        }
        
        public System.Data.DataTable ListarContatos(string NOMBRECONTACTO, string UserName) {
            return base.Channel.ListarContatos(NOMBRECONTACTO, UserName);
        }
        
        public System.Data.DataTable ListarMiembros(int IdContacto, string UserName) {
            return base.Channel.ListarMiembros(IdContacto, UserName);
        }
        
        public System.Data.DataTable LstHistorialDialogo(string IdContactoOrg, int IdContactoDes, string UserName) {
            return base.Channel.LstHistorialDialogo(IdContactoOrg, IdContactoDes, UserName);
        }
        
        public System.Data.DataTable LstHistorialDialogoContenido(string Idmsg, string UserName) {
            return base.Channel.LstHistorialDialogoContenido(Idmsg, UserName);
        }
        
        public System.Data.DataTable LstHistorialDialogoContenidoLikes(string IdContents, string UserName) {
            return base.Channel.LstHistorialDialogoContenidoLikes(IdContents, UserName);
        }
        
        public System.Data.DataTable IsMiembrodeGrupo(int IdContactGrupo, string CodPersonal, string UserName) {
            return base.Channel.IsMiembrodeGrupo(IdContactGrupo, CodPersonal, UserName);
        }
        
        public System.Data.DataTable LstContactSendtoGrupo(int IdContactGrupo, string UserName) {
            return base.Channel.LstContactSendtoGrupo(IdContactGrupo, UserName);
        }
        
        public string RegistrarMensajeyContenidoServer(NetSuiteTCP.srvChatBot.MensajeContenidoBE oMensajeContenidoBE) {
            return base.Channel.RegistrarMensajeyContenidoServer(oMensajeContenidoBE);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        NetSuiteTCP.srvChatBot.RegistrarMensajeyContenidoCliente1 NetSuiteTCP.srvChatBot.IChatBotManagerSoap.RegistrarMensajeyContenidoClient(NetSuiteTCP.srvChatBot.RegistrarMensajeyContenidoCliente request) {
            return base.Channel.RegistrarMensajeyContenidoClient(request);
        }
        
        public string RegistrarMensajeyContenidoClient(int IdMiembro, string Texto, int IdContactOrg, int IdContactDes) {
            NetSuiteTCP.srvChatBot.RegistrarMensajeyContenidoCliente inValue = new NetSuiteTCP.srvChatBot.RegistrarMensajeyContenidoCliente();
            inValue.IdMiembro = IdMiembro;
            inValue.Texto = Texto;
            inValue.IdContactOrg = IdContactOrg;
            inValue.IdContactDes = IdContactDes;
            NetSuiteTCP.srvChatBot.RegistrarMensajeyContenidoCliente1 retVal = ((NetSuiteTCP.srvChatBot.IChatBotManagerSoap)(this)).RegistrarMensajeyContenidoClient(inValue);
            return retVal.RegistrarMensajeyContenidoClienteResult;
        }
    }
}
