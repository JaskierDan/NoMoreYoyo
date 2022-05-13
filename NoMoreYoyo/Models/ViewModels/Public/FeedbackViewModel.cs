using System.ComponentModel;

namespace NoMoreYoyo.Models
{
    public class FeedbackViewModel
    {
        [DisplayName("Title")]
        public string Title { get; set; }
        [DisplayName("Message")]
        public string FeedbackMessage { get; set; }
    }
}
