namespace Web6.Jwt
{
    public class UserInfo
    {
        public long Id { get; set; }
        public string Tckn { get; set; }
        public string Name { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public long LocationId { get; set; }
    }
}