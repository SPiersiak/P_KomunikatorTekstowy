﻿using System;
using System.Collections.Generic;
using System.Text;

namespace KomunikatorTekstowy.Models
{
    public class UserDetailData
    {
        public string UserId { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NumberOfAlbum { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; }
        public string EmailAddress { get; set; }
        public string WebsiteLink { get; set; }
    }
}
