using System.Runtime.Serialization;

namespace KAPMProjectManagementApi.Emun
{
    public enum EProjectTimeline
    {
        [EnumMember(Value = "Waiting")]
        Waiting,

        [EnumMember(Value = "On Progress")]
        OnProgress,

        [EnumMember(Value = "Done")]
        Done
    }

    public static class ProjectTimelineExtensions
    {
        private static readonly Dictionary<EProjectTimeline, string> _projectTimeline = new()
        {
            {EProjectTimeline.Waiting, "Waiting" },
            {EProjectTimeline.OnProgress, "On Progress" },
            {EProjectTimeline.Done, "Done" }
        };

        public static string ToString(this EProjectTimeline timeline) => _projectTimeline[timeline];
    }
}