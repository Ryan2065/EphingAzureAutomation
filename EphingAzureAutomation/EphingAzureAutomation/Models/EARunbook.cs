using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;

namespace EphingAzureAutomation
{
    public class EARunbook
    {
        public string AutomationAccountName { get; }
        public DateTimeOffset CreationTime { get; }
        private string privateDescription;
        public string Description { get; set; }
        public int JobCount { get; }
        public string LastModifiedBy { get; }
        public DateTimeOffset LastModifiedTime { get; }
        public string Location { get; }
        private bool privateLogVerbose;
        public bool LogVerbose { get; set; }
        private bool privateLogProgress;
        public bool LogProgress { get; set; }
        public string Name { get; }
        public Hashtable Parameters { get; }
        public string ResourceGroupName { get; }
        public string RunbookType { get; }
        public string State { get; }
        private Hashtable privateTags;
        public Hashtable Tags { get; set; }

        public EARunbook(object Runbook)
        {
            Type RunbookType = Runbook.GetType();
            var RunbookProperty = RunbookType.GetProperty("Members");
            var RunbookMembers = RunbookProperty.GetValue(Runbook) as PSMemberInfoCollection<PSMemberInfo>;

            Type thisType = this.GetType();
            IList<PropertyInfo> thisProperties = new List<PropertyInfo>(thisType.GetProperties());

            foreach (var runbookMember in RunbookMembers)
            {
                switch (runbookMember.Name)
                {
                    case "AutomationAccountName":
                        this.AutomationAccountName = MemberConvert.GetString(runbookMember.Value);
                        break;
                    case "CreationTime":
                        this.CreationTime = MemberConvert.GetDateTimeOffset(runbookMember.Value);
                        break;
                    case "Description":
                        this.Description = MemberConvert.GetString(runbookMember.Value);
                        this.privateDescription = this.Description;
                        break;
                    case "JobCount":
                        var tempInt = MemberConvert.GetInt(runbookMember.Value);
                        break;
                    case "LastModifiedBy":
                        this.LastModifiedBy = MemberConvert.GetString(runbookMember.Value);
                        break;
                    case "LastModifiedTime":
                        this.LastModifiedTime = MemberConvert.GetDateTimeOffset(runbookMember.Value);
                        break;
                    case "Location":
                        this.Location = MemberConvert.GetString(runbookMember.Value);
                        break;
                    case "LogVerbose":
                        this.LogVerbose = MemberConvert.GetBool(runbookMember.Value);
                        this.privateLogVerbose = this.LogVerbose;
                        break;
                    case "LogProgress":
                        this.LogProgress = MemberConvert.GetBool(runbookMember.Value);
                        this.privateLogProgress = this.LogProgress;
                        break;
                    case "Name":
                        this.Name = MemberConvert.GetString(runbookMember.Value);
                        break;
                    case "Parameters":
                        this.Parameters = MemberConvert.GetHashtable(runbookMember.Value);
                        break;
                    case "ResourceGroupName":
                        this.ResourceGroupName = MemberConvert.GetString(runbookMember.Value);
                        break;
                    case "RunbookType":
                        this.RunbookType = MemberConvert.GetString(runbookMember.Value);
                        break;
                    case "State":
                        this.State = MemberConvert.GetString(runbookMember.Value);
                        break;
                    case "Tags":
                        this.Tags = MemberConvert.GetHashtable(runbookMember.Value);
                        this.privateTags = this.Tags;
                        break;
                    default:
                        break;
                }
            }

        }
    }
}
