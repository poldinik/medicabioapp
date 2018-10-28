using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Medicabio.Models;

namespace Medicabio.ViewModels
{
    public class LectionsViewModel
    {
        public List<Lection> Lections { get; set; }
        public string Title { get; set; }

        public LectionsViewModel()
        {
            Title = "Corsi";
            Lections = new List<Lection>();

            var mockItems = new List<Lection>
            {
                new Lection { Title = "Clinical immersion", Description = "Riparazione protesica dell'ernia inguinale", Date = "23-10-2018 14:00", Location = "Azienda ospedaliero - universitaria Pisana", City = "Pisa" },
                new Lection { Title = "Woundcare", Description = "Descrizione evento woundcare", Date = "22-11-2018 15:00", Location = "Hotel Mediterraneo", City = "Firenze" }
            };

            foreach (var item in mockItems)
            {
                Lections.Add(item);
            }
        }
    }
}
