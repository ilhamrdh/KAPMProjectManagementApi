using System.Runtime.Serialization;

namespace KAPMProjectManagementApi.Emun
{
    public enum ETypeDeviation
    {
        [EnumMember(Value = "Positive")]
        Positive,
        [EnumMember(Value = "Negative")]
        Negative
    }
}