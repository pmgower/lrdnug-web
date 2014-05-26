namespace lrdnug.api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Meeting
    {
        public int ID { get; set; }

        [Required]
        public string PresentationTitle { get; set; }

        [Required]
        public string SpeakerName { get; set; }

        [Required]
        public string SpeakerBio { get; set; }

        public string SpeakerTwitter { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime Date { get; set; }

        public DateTime StartTime { get; set; }

        public string SurveyURL { get; set; }
    }
}
