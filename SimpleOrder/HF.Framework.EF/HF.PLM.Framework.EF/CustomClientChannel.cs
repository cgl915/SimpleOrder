using System;
using System.Configuration;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;

namespace HF.PLM.Framework.EF
{
	public class CustomClientChannel<T> : ChannelFactory<T>
	{
		private string string_0;

		private string cGaLcglp7;

		private TimeSpan? nullable_0 = null;

		public CustomClientChannel(string configurationPath) : base(typeof(T))
		{
			this.string_0 = configurationPath;
			base.InitializeEndpoint((string)null, null);
		}

		public CustomClientChannel(string configurationPath, TimeSpan timeout) : base(typeof(T))
		{
			this.nullable_0 = new TimeSpan?(timeout);
			this.string_0 = configurationPath;
			base.InitializeEndpoint((string)null, null);
		}

        public CustomClientChannel(Binding binding, string configurationPath)
            : this(binding, (EndpointAddress)null, configurationPath)
		{
		}

		public CustomClientChannel(ServiceEndpoint serviceEndpoint, string configurationPath) : base(typeof(T))
		{
			this.string_0 = configurationPath;
			base.InitializeEndpoint(serviceEndpoint);
		}

		public CustomClientChannel(string endpointConfigurationName, string configurationPath) : this(endpointConfigurationName, null, configurationPath)
		{
		}

		public CustomClientChannel(Binding binding, EndpointAddress endpointAddress, string configurationPath) : base(typeof(T))
		{
			this.string_0 = configurationPath;
			base.InitializeEndpoint(binding, endpointAddress);
		}

		public CustomClientChannel(Binding binding, string remoteAddress, string configurationPath) : this(binding, new EndpointAddress(remoteAddress), configurationPath)
		{
		}

		public CustomClientChannel(string endpointConfigurationName, EndpointAddress endpointAddress, string configurationPath) : base(typeof(T))
		{
			this.string_0 = configurationPath;
			this.cGaLcglp7 = endpointConfigurationName;
			base.InitializeEndpoint(endpointConfigurationName, endpointAddress);
		}

		protected override ServiceEndpoint CreateDescription()
		{
			ServiceEndpoint serviceEndpoint = base.CreateDescription();
			if (this.cGaLcglp7 != null)
			{
				serviceEndpoint.Name = this.cGaLcglp7;
			}
			Configuration config = ConfigurationManager.OpenMappedExeConfiguration(new ExeConfigurationFileMap
			{
				ExeConfigFilename = this.string_0
			}, ConfigurationUserLevel.None);
			ServiceModelSectionGroup sectionGroup = ServiceModelSectionGroup.GetSectionGroup(config);
			ChannelEndpointElement channelEndpointElement = null;
			foreach (ChannelEndpointElement channelEndpointElement2 in sectionGroup.Client.Endpoints)
			{
				if (channelEndpointElement2.Contract == serviceEndpoint.Contract.ConfigurationName && (this.cGaLcglp7 == null || this.cGaLcglp7 == channelEndpointElement2.Name))
				{
					channelEndpointElement = channelEndpointElement2;
					break;
				}
			}
			if (channelEndpointElement != null)
			{
				if (serviceEndpoint.Binding == null)
				{
					serviceEndpoint.Binding = this.method_0(channelEndpointElement.Binding, sectionGroup);
				}
				if (serviceEndpoint.Address == null)
				{
					serviceEndpoint.Address = new EndpointAddress(channelEndpointElement.Address, this.method_3(channelEndpointElement.Identity), channelEndpointElement.Headers.Headers);
				}
				if (serviceEndpoint.Behaviors.Count == 0 && channelEndpointElement.BehaviorConfiguration != null)
				{
					this.method_2(channelEndpointElement.BehaviorConfiguration, serviceEndpoint, sectionGroup);
				}
				serviceEndpoint.Name = channelEndpointElement.Contract;
			}
			return serviceEndpoint;
		}

		private Binding method_0(string string_1, ServiceModelSectionGroup serviceModelSectionGroup_0)
		{
			BindingCollectionElement bindingCollectionElement = serviceModelSectionGroup_0.Bindings[string_1];
			Binding result;
			if (bindingCollectionElement.ConfiguredBindings.Count > 0)
			{
				IBindingConfigurationElement bindingConfigurationElement = bindingCollectionElement.ConfiguredBindings[0];
				Binding binding = this.method_1(bindingConfigurationElement);
				if (bindingConfigurationElement != null)
				{
					bindingConfigurationElement.ApplyConfiguration(binding);
				}
				if (this.nullable_0.HasValue)
				{
					binding.CloseTimeout = this.nullable_0.Value;
					binding.OpenTimeout = this.nullable_0.Value;
					binding.ReceiveTimeout = this.nullable_0.Value;
					binding.SendTimeout = this.nullable_0.Value;
				}
				result = binding;
			}
			else
			{
				result = null;
			}
			return result;
		}

		private Binding method_1(IBindingConfigurationElement ibindingConfigurationElement_0)
		{
			Binding result;
			if (ibindingConfigurationElement_0 is CustomBindingElement)
			{
				result = new CustomBinding();
			}
			else if (ibindingConfigurationElement_0 is BasicHttpBindingElement)
			{
				result = new BasicHttpBinding();
			}
			else if (ibindingConfigurationElement_0 is NetMsmqBindingElement)
			{
				result = new NetMsmqBinding();
			}
			else if (ibindingConfigurationElement_0 is NetNamedPipeBindingElement)
			{
				result = new NetNamedPipeBinding();
			}
			else if (ibindingConfigurationElement_0 is NetPeerTcpBindingElement)
			{
				result = new NetPeerTcpBinding();
			}
			else if (ibindingConfigurationElement_0 is NetTcpBindingElement)
			{
				result = new NetTcpBinding();
			}
			else if (ibindingConfigurationElement_0 is WSDualHttpBindingElement)
			{
				result = new WSDualHttpBinding();
			}
			else if (ibindingConfigurationElement_0 is WSHttpBindingElement)
			{
				result = new WSHttpBinding();
			}
			else if (ibindingConfigurationElement_0 is WSFederationHttpBindingElement)
			{
				result = new WSFederationHttpBinding();
			}
			else
			{
				result = null;
			}
			return result;
		}

		private void method_2(string string_1, ServiceEndpoint serviceEndpoint_0, ServiceModelSectionGroup serviceModelSectionGroup_0)
		{
			if (!string.IsNullOrEmpty(string_1))
			{
				EndpointBehaviorElement endpointBehaviorElement = serviceModelSectionGroup_0.Behaviors.EndpointBehaviors[string_1];
				for (int i = 0; i < endpointBehaviorElement.Count; i++)
				{
					BehaviorExtensionElement behaviorExtensionElement = endpointBehaviorElement[i];
					object obj = behaviorExtensionElement.GetType().InvokeMember("CreateBehavior", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod, null, behaviorExtensionElement, null);
					if (obj != null)
					{
						serviceEndpoint_0.Behaviors.Add((IEndpointBehavior)obj);
					}
				}
			}
		}

		private EndpointIdentity method_3(IdentityElement identityElement_0)
		{
			EndpointIdentity endpointIdentity = null;
			PropertyInformationCollection properties = identityElement_0.ElementInformation.Properties;
			EndpointIdentity result;
			if (properties["userPrincipalName"].ValueOrigin != PropertyValueOrigin.Default)
			{
				result = EndpointIdentity.CreateUpnIdentity(identityElement_0.UserPrincipalName.Value);
			}
			else if (properties["servicePrincipalName"].ValueOrigin != PropertyValueOrigin.Default)
			{
				result = EndpointIdentity.CreateSpnIdentity(identityElement_0.ServicePrincipalName.Value);
			}
			else if (properties["dns"].ValueOrigin != PropertyValueOrigin.Default)
			{
				result = EndpointIdentity.CreateDnsIdentity(identityElement_0.Dns.Value);
			}
			else if (properties["rsa"].ValueOrigin != PropertyValueOrigin.Default)
			{
				result = EndpointIdentity.CreateRsaIdentity(identityElement_0.Rsa.Value);
			}
			else if (properties["certificate"].ValueOrigin != PropertyValueOrigin.Default)
			{
				X509Certificate2Collection x509Certificate2Collection = new X509Certificate2Collection();
				x509Certificate2Collection.Import(Convert.FromBase64String(identityElement_0.Certificate.EncodedValue));
				if (x509Certificate2Collection.Count == 0)
				{
					throw new InvalidOperationException("UnableToLoadCertificateIdentity");
				}
				X509Certificate2 primaryCertificate = x509Certificate2Collection[0];
				x509Certificate2Collection.RemoveAt(0);
				result = EndpointIdentity.CreateX509CertificateIdentity(primaryCertificate, x509Certificate2Collection);
			}
			else
			{
				result = endpointIdentity;
			}
			return result;
		}

		protected override void ApplyConfiguration(string configurationName)
		{
		}
	}
}
