﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfChatApp.ChatServices {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Message", Namespace="http://schemas.datacontract.org/2004/07/ChatWcfService")]
    [System.SerializableAttribute()]
    public partial class Message : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageTextField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SenderField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime TimestampField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MessageText {
            get {
                return this.MessageTextField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageTextField, value) != true)) {
                    this.MessageTextField = value;
                    this.RaisePropertyChanged("MessageText");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Sender {
            get {
                return this.SenderField;
            }
            set {
                if ((object.ReferenceEquals(this.SenderField, value) != true)) {
                    this.SenderField = value;
                    this.RaisePropertyChanged("Sender");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Timestamp {
            get {
                return this.TimestampField;
            }
            set {
                if ((this.TimestampField.Equals(value) != true)) {
                    this.TimestampField = value;
                    this.RaisePropertyChanged("Timestamp");
                }
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ChatServices.IChatService", CallbackContract=typeof(WpfChatApp.ChatServices.IChatServiceCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface IChatService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/Connect", ReplyAction="http://tempuri.org/IChatService/ConnectResponse")]
        bool Connect();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/Connect", ReplyAction="http://tempuri.org/IChatService/ConnectResponse")]
        System.Threading.Tasks.Task<bool> ConnectAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/Disconnect", ReplyAction="http://tempuri.org/IChatService/DisconnectResponse")]
        bool Disconnect();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/Disconnect", ReplyAction="http://tempuri.org/IChatService/DisconnectResponse")]
        System.Threading.Tasks.Task<bool> DisconnectAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/GetChatHistory", ReplyAction="http://tempuri.org/IChatService/GetChatHistoryResponse")]
        WpfChatApp.ChatServices.Message[] GetChatHistory();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/GetChatHistory", ReplyAction="http://tempuri.org/IChatService/GetChatHistoryResponse")]
        System.Threading.Tasks.Task<WpfChatApp.ChatServices.Message[]> GetChatHistoryAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/SendMessage", ReplyAction="http://tempuri.org/IChatService/SendMessageResponse")]
        bool SendMessage(string sender, string messageText);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/SendMessage", ReplyAction="http://tempuri.org/IChatService/SendMessageResponse")]
        System.Threading.Tasks.Task<bool> SendMessageAsync(string sender, string messageText);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IChatServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatService/OnMessageAdded")]
        void OnMessageAdded(WpfChatApp.ChatServices.Message message);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IChatServiceChannel : WpfChatApp.ChatServices.IChatService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ChatServiceClient : System.ServiceModel.DuplexClientBase<WpfChatApp.ChatServices.IChatService>, WpfChatApp.ChatServices.IChatService {
        
        public ChatServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public ChatServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public ChatServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ChatServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ChatServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public bool Connect() {
            return base.Channel.Connect();
        }
        
        public System.Threading.Tasks.Task<bool> ConnectAsync() {
            return base.Channel.ConnectAsync();
        }
        
        public bool Disconnect() {
            return base.Channel.Disconnect();
        }
        
        public System.Threading.Tasks.Task<bool> DisconnectAsync() {
            return base.Channel.DisconnectAsync();
        }
        
        public WpfChatApp.ChatServices.Message[] GetChatHistory() {
            return base.Channel.GetChatHistory();
        }
        
        public System.Threading.Tasks.Task<WpfChatApp.ChatServices.Message[]> GetChatHistoryAsync() {
            return base.Channel.GetChatHistoryAsync();
        }
        
        public bool SendMessage(string sender, string messageText) {
            return base.Channel.SendMessage(sender, messageText);
        }
        
        public System.Threading.Tasks.Task<bool> SendMessageAsync(string sender, string messageText) {
            return base.Channel.SendMessageAsync(sender, messageText);
        }
    }
}