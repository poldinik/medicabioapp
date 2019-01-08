using System;
namespace Medicabio.Models
{
    public class Lecture
    {
        public int Id { get; set; }
        public string Uuid { get; set; }
        public LectureDetails LectureDetails { get; set; }
        public Pdf SchedulePdf { get; set; }
        public Location Location { get; set; }
        public string Image { get; set; }
    }
}
