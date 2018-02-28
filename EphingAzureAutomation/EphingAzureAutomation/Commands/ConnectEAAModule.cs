using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Collections;

namespace EphingAzureAutomation
{
    [Cmdlet("Connect", "EAAModule", DefaultParameterSetName ="NoEAAProfile")]
    public class ConnectEAAModule: Cmdlet
    {

        [Parameter(Mandatory =true, ParameterSetName ="NoEAAProfile")]
        public string AutomationAccountName { get; set; }

        [Parameter(Mandatory =true, ParameterSetName ="NoEAAProfile")]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName ="NoEAAProfile")]
        public string WorkspaceFolder { get; set; }

        [Parameter(Mandatory = false, ParameterSetName ="NoEAAProfile")]
        public Hashtable AzureRMAccountParameters { get; set; }

        [Parameter(Mandatory =true, ParameterSetName ="EAAProfile")]
        public string EAAProfile { get; set; }
        
        static string _fileMappingFolder;
        static string _automationAccountName;
        static string _resourceGroupName;
        static object _azureRMProfile;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            FileMappingFolder = WorkspaceFolder;
            ResourceGroup = ResourceGroupName;
            AutomationAccount = AutomationAccountName;
            PowerShell ps = PowerShell.Create();
            ps.AddCommand("Connect-AzureRmAccount");
            foreach(string key in AzureRMAccountParameters.Keys)
            {
                ps.AddParameter(key, AzureRMAccountParameters[key]);
            }
            AzureRMProfile = ps.Invoke();
        }

        public static string FileMappingFolder // set the private _fileMappingFolder - so other commands can get it
        {
            get
            {
                return _fileMappingFolder;
            }
            set
            {
                _fileMappingFolder = value;
            }
        }
        public static string AutomationAccount // set the private _automationAccountName - so other commands can get it
        {
            get
            {
                if (String.IsNullOrEmpty(_automationAccountName))
                {
                    throw new Exception("AutomationAccountName empty. Have you run Connect-EAAModule yet?");
                }
                else
                {
                    return _automationAccountName;
                }
            }
            set
            {
                _automationAccountName = value;
            }
        }
        public static string ResourceGroup // set the private _resourceGroupName - so other commands can get it
        {
            get
            {
                if (String.IsNullOrEmpty(_resourceGroupName))
                {
                    throw new Exception("ResourceGroupName empty. Have you run Connect-EAAModule yet?");
                }
                else
                {
                    return _resourceGroupName;
                }
            }
            set
            {
                _resourceGroupName = value;
            }
        }

        public static object AzureRMProfile
        {
            get
            {
                if(AzureRMProfile == null)
                {
                    throw new Exception("AzureRMProfile empty. Have you run Connect-EAAModule yet?");
                }
                else
                {
                    return _azureRMProfile;
                }
            }
            set
            {
                _azureRMProfile = value;
            }
        }
    }
}
