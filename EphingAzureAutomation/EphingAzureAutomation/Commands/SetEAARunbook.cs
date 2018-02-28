using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;

namespace EphingAzureAutomation
{
    [Cmdlet(VerbsCommon.Set, "EAARunbook")]
    public class SetEAARunbook: Cmdlet
    {
        [Parameter]
        public string Name { get; set; }

    }
}
