namespace KAPMProjectManagementApi.Dto.Auth
{
    public class LoginResponseExternal
    {
        public string Status { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public Data Data { get; set; } = new Data();
    }


    public class Data
    {
        public string Token { get; set; } = string.Empty;
        public string Fcmtoken { get; set; } = string.Empty;
        public string Nama { get; set; } = string.Empty;
        public string Nipp { get; set; } = string.Empty;
        public string Jabatan { get; set; } = string.Empty;
        public string Grade { get; set; } = string.Empty;
        public string Id_organisasi { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;
        public string Id_posisi { get; set; } = string.Empty;
        public string Posisi { get; set; } = string.Empty;
        public string Id_area { get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;
        public string Cost_center { get; set; } = string.Empty;
        public string Lokasi_kerja { get; set; } = string.Empty;
        public string No_hp { get; set; } = string.Empty;
        public string Profile_URL { get; set; } = string.Empty;
        public string Id_company_code { get; set; } = string.Empty;
        public string Company_code { get; set; } = string.Empty;
        public string Id_job_fam { get; set; } = string.Empty;
        public string Text_job_fam { get; set; } = string.Empty;
        public string Text_korsa { get; set; } = string.Empty;
        public string Btrtl { get; set; } = string.Empty;
        public string Psubarea_text { get; set; } = string.Empty;
        public string Persg { get; set; } = string.Empty;
        public string Eg_text { get; set; } = string.Empty;
        public List<object> Bawahan { get; set; } = new List<object>();
        public object Asvri_code { get; set; } = string.Empty;
        public List<string> Role { get; set; } = new List<string>();
        public List<object> Menu_mobile { get; set; } = new List<object>();
        public List<object> Menu_cms { get; set; } = new List<object>();
        public List<string> Menu_web { get; set; } = new List<string>();
        public object Token_ws_int { get; set; } = string.Empty;
        public object Hris_menu { get; set; } = string.Empty;
    }
}