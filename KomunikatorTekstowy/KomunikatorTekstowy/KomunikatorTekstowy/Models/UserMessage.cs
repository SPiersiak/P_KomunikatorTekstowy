using System;
using System.Collections.Generic;
using System.Text;

namespace KomunikatorTekstowy.Models
{
    public class UserMessage
    {
        public string Id { get; set; }
        public string SenderId { get; set; }
        public string RecipentId { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }
    }
}
