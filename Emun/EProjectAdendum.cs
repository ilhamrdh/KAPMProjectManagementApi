using System.Runtime.Serialization;

namespace KAPMProjectManagementApi.Emun
{
    public enum EProjectAdendum
    {
        [EnumMember(Value = "Request")]
        Request,
        [EnumMember(Value = "Approve")]
        Approve,
        [EnumMember(Value = "Reject")]
        Reject
    }
}