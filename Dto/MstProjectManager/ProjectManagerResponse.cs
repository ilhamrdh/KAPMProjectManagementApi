namespace KAPMProjectManagementApi.Dto.MstProjectManager
{
    public class ProjectManagerResponse
    {
        public string Nipp { get; set; } = string.Empty;

        public string Name { get; set; } = default!;

        public string Active { get; set; } = "Y";
    }
}