//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tarea3.ServiceReference2 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="urn:TikTakToe", ConfigurationName="ServiceReference2.TikTakToePort")]
    public interface TikTakToePort {
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:TikTakToe#TikTakToe#placeToken", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc, SupportFaults=true, Use=System.ServiceModel.OperationFormatUse.Encoded)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        string placeToken(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:TikTakToe#TikTakToe#placeToken", ReplyAction="*")]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        System.Threading.Tasks.Task<string> placeTokenAsync(string token);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface TikTakToePortChannel : Tarea3.ServiceReference2.TikTakToePort, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TikTakToePortClient : System.ServiceModel.ClientBase<Tarea3.ServiceReference2.TikTakToePort>, Tarea3.ServiceReference2.TikTakToePort {
        
        public TikTakToePortClient() {
        }
        
        public TikTakToePortClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TikTakToePortClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TikTakToePortClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TikTakToePortClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string placeToken(string token) {
            return base.Channel.placeToken(token);
        }
        
        public System.Threading.Tasks.Task<string> placeTokenAsync(string token) {
            return base.Channel.placeTokenAsync(token);
        }
    }
}
