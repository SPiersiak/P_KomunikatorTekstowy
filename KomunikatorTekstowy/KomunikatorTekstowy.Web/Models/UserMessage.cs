using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KomunikatorTekstowy.Web.Models
{
    public class UserMessage
    {
        [Key]
        public string Id { get; set; }
        public string SenderId { get; set; }
        public string RecipentId { get; set; }
        public string Message{ get; set; }
        public DateTime Time { get; set; }

    }
}

