using System;
using System.Collections.Generic;
using Medicabio.Models;

namespace Medicabio.ViewModels
{
    public class TopicsViewModel
    {
        public List<Topic> Topics { get; set; }
        public string Title { get; set; }

        public TopicsViewModel()
        {
            Title = "Argomenti";
            Topics = new List<Topic>();

            var mockItems = new List<Topic>
            {
                new Topic { Title = "Ernie" },
                new Topic { Title = "Woundcare" }
            };

            foreach (var item in mockItems)
            {
                Topics.Add(item);
            }
        }
    }
}
