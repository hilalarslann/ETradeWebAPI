using ETrade.Entities.Concrete;

namespace ETrade.UI.Models
{
    public class UserModel
    {
        public User User { get; set; }
        public List<County> Counties { get; set; }
        public string Msg { get; set; }
    }
}
