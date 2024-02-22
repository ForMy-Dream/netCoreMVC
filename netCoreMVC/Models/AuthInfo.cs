namespace netCoreMVC.Models
{
    public class AuthInfo
    {
        //模拟JWT的payload
        public string UserName { get; set; }

        public List<string> Roles { get; set; }

        public bool IsAdmin { get; set; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public string ExpirationTime { get; set; }
    }
}
