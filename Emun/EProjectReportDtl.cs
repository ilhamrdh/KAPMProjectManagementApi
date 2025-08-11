using System.Runtime.Serialization;

namespace KAPMProjectManagementApi.Emun
{
    public enum EProjectReportDtl
    {
        [EnumMember(Value = "Done")]
        Done,
        [EnumMember(Value = "On Progress")]
        OnProgress
    }
}