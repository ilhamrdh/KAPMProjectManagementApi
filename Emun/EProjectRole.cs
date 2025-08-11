using System.Runtime.Serialization;

namespace KAPMProjectManagementApi.Emun
{
    public enum EProjectRole
    {
        [EnumMember(Value = "Admin")]
        Admin,
        [EnumMember(Value = "BOD")]
        BOD,
        [EnumMember(Value = "PMO")]
        PMO,
        [EnumMember(Value = "Unit")]
        Unit,
        [EnumMember(Value = "Project Manager")]
        ProjectManager,
        [EnumMember(Value = "Consultant")]
        Consultant,
        [EnumMember(Value = "Site Manager")]
        SiteManager,
        [EnumMember(Value = "Logistics")]
        Logistics,
        [EnumMember(Value = "Security")]
        Security,
        [EnumMember(Value = "SHE")]
        SHE
    }
}