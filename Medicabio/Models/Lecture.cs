using System;
namespace Medicabio.Models
{
    public class Lecture
    {
        public Lecture()
        {
        }

        public int Id { get; set; }
        public string Uuid { get; set; }
        public LectureDetails LectureDetails { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
    }
}
