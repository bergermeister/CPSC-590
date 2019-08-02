﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TSGAMT2010.GA {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="GAMember", Namespace="http://schemas.datacontract.org/2004/07/GASvcLib")]
    [System.SerializableAttribute()]
    public partial class GAMember : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ViFitnessField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int[] ViMemField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ViMemSizeField;
        
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
        public int ViFitness {
            get {
                return this.ViFitnessField;
            }
            set {
                if ((this.ViFitnessField.Equals(value) != true)) {
                    this.ViFitnessField = value;
                    this.RaisePropertyChanged("ViFitness");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int[] ViMem {
            get {
                return this.ViMemField;
            }
            set {
                if ((object.ReferenceEquals(this.ViMemField, value) != true)) {
                    this.ViMemField = value;
                    this.RaisePropertyChanged("ViMem");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ViMemSize {
            get {
                return this.ViMemSizeField;
            }
            set {
                if ((this.ViMemSizeField.Equals(value) != true)) {
                    this.ViMemSizeField = value;
                    this.RaisePropertyChanged("ViMemSize");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="GA.IGASvc", CallbackContract=typeof(TSGAMT2010.GA.IGASvcCallback))]
    public interface IGASvc {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGASvc/MExecute")]
        void MExecute(int[][] aiDistMat, int aiNumThreads);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGASvcCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGASvc/MUpdateResult")]
        void MUpdateResult(TSGAMT2010.GA.GAMember aoRes);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGASvcChannel : TSGAMT2010.GA.IGASvc, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GASvcClient : System.ServiceModel.DuplexClientBase<TSGAMT2010.GA.IGASvc>, TSGAMT2010.GA.IGASvc {
        
        public GASvcClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public GASvcClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public GASvcClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public GASvcClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public GASvcClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void MExecute(int[][] aiDistMat, int aiNumThreads) {
            base.Channel.MExecute(aiDistMat, aiNumThreads);
        }
    }
}