using System.Runtime.Serialization;

namespace KAPMProjectManagementApi.Emun
{
    public enum ETypeInvoice
    {
        [EnumMember(Value = "DP")]
        DP,
        [EnumMember(Value = "Termin")]
        Termin,
        [EnumMember(Value = "1-100")]
        ZeroToHundred,
        [EnumMember(Value = "Monthly")]
        Monthly
    }
}