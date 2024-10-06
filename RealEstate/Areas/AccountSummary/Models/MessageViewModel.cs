using EntityLayer.Concrete;

namespace RealEstate.Areas.AccountSummary.Models
{
    public class MessageViewModel
    {
        public int ID { get; set; }
        public int SenderUserID { get; set; }
        public string SenderName { get; set; }
        public int ReceiverUserID { get; set; }
        public string ReceiverName { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}
