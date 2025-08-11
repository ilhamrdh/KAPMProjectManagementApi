using System.Runtime.Serialization;

namespace KAPMProjectManagementApi.Emun
{
    public enum EProjectStatus
    {
        [EnumMember(Value = "Fast")]
        Fast,
        [EnumMember(Value = "Normal")]
        Normal,
        [EnumMember(Value = "Too Late")]
        TooLate,
        [EnumMember(Value = "Critical")]
        Critical,
    }

    public static class ProjectStatusExtensions
    {
        private static readonly Dictionary<EProjectStatus, string> _projectStatus = new()
        {
            { EProjectStatus.Fast, "Fast" },
            { EProjectStatus.Normal, "Normal" },
            { EProjectStatus.TooLate, "Too Late" },
            { EProjectStatus.Critical, "Critical" },
        };

        public static string ToString(this EProjectStatus projectStatus) => _projectStatus[projectStatus];
    }
}