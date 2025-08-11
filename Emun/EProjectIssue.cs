using System.Runtime.Serialization;

namespace KAPMProjectManagementApi.Emun
{
    public enum EProjectIssue
    {
        [EnumMember(Value = "Solved")]
        Solved,
        [EnumMember(Value = "Waiting")]
        Waiting
    }
}