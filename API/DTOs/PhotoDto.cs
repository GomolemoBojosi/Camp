﻿using API.Entities;

namespace API.DTOs
{
    public class PhotoDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string PublicId { get; set; }
        public int CampgroundId { get; set; }
    }
}
