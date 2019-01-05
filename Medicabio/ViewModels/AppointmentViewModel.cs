using System;
using System.Collections.Generic;
using Medicabio.Models;

namespace Medicabio.ViewModels
{
    public class AppointmentViewModel
    {
        public List<Appointment> Appointments { get; set; }
        public string Title { get; set; }

        public AppointmentViewModel()
        {
            Title = "Appuntamenti";
            Appointments = new List<Appointment>();

            var mockItems = new List<Appointment>
            {
                new Appointment { Patience = "Leonardo Verdi", Description = "Riparazione protesica dell'ernia inguinale", City = "Pistoia", Phone = "3402134567" },
               
            };

            foreach (var item in mockItems)
            {
                Appointments.Add(item);
            }
        }
    }
}
