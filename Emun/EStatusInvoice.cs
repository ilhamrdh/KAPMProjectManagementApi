using System.Runtime.Serialization;

namespace KAPMProjectManagementApi.Emun
{
    public enum EStatusInvoice
    {
        [EnumMember(Value = "Waiting")]
        Waiting,
        [EnumMember(Value = "Requsted")]
        Requsted,
        [EnumMember(Value = "On Progress")]
        OnProgress,
        [EnumMember(Value = "Deliver")]
        Deliver
    }
}