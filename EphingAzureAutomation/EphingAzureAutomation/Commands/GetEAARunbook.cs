using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;

namespace EphingAzureAutomation
{
    [Cmdlet(VerbsCommon.Get, "EAARunbook")]
    public class GetEAARunbook: Cmdlet
    {
        [Parameter(Mandatory =false)]
        public string Name { get; set; }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            try
            {
                PowerShell ps = PowerShell.Create();
                ps.AddCommand("Get-AzureRMAutomationRunbook");
                ps.AddParameter("AutomationAccountName", ConnectEAAModule.AutomationAccount);
                ps.AddParameter("ResourceGroupName", ConnectEAAModule.ResourceGroup);
                var results = ps.Invoke();
                foreach (var result in results)
                {
                    var runbook = new EARunbook(result);
                    WriteObject(runbook);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
