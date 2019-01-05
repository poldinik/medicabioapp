using System.Linq;
using System.Collections.Generic;
using System;
using Entry = Microcharts.Entry;
using Chart = Microcharts.Chart;
using BarChart = Microcharts.BarChart;
using RadialGaugeChart = Microcharts.RadialGaugeChart;
using LineChart = Microcharts.LineChart;

namespace Medicabio.ViewModels
{
    using SkiaSharp;
    public class HomeViewModel
    {
        public HomeViewModel()
        {
        }

        private static readonly SKColor AccentColor = SKColor.Parse("#2C5DF9");

        private static readonly SKColor AccentDarkColor = SKColor.Parse("#484F64");

        private static readonly SKColor OrangeColor = SKColor.Parse("#FFD45F");

        private static readonly SKColor GreenColor = SKColor.Parse("#26C3AC");

        private static readonly SKColor PinkColor = SKColor.Parse("#FA6978");

        public Chart GoalsChart => new RadialGaugeChart()
        {
            Entries = new[]
            {
                new Entry(200)
                {
                
                    Color = SKColor.Parse("#266489")
                },
                new Entry(100)
                {

                    Color = SKColor.Parse("#68B9C0")
                },
                new Entry(50)
                {
                 
                    Color = SKColor.Parse("#90D585")    
                },
            },
            BackgroundColor = SKColors.Transparent,
        };

        public Chart AppointmentChart => new LineChart()
        {
            Entries = new[]
            {
                new Entry(200)
                {

                    Color = SKColor.Parse("#266489"),
                    Label = "Gennaio",
                  
                },
                new Entry(100)
                {

                    Color = SKColor.Parse("#68B9C0"),
                    Label = "Febbraio"
                },
                new Entry(50)
                {

                    Color = SKColor.Parse("#90D585"),
                    Label = "Marzo"
                },
                new Entry(23)
                {

                    Color = SKColor.Parse("#90D585"),
                    Label = "Aprile"
                },
                new Entry(100)
                {

                    Color = SKColor.Parse("#90D585"),
                    Label = "Maggio"
                },
                new Entry(50)
                {

                    Color = SKColor.Parse("#90D585"),
                    Label = "Giugno"
                },
                new Entry(50)
                {

                    Color = SKColor.Parse("#90D585"),
                    Label = "Luglio"
                },
                new Entry(45)
                {

                    Color = SKColor.Parse("#90D585"),
                    Label = "Agosto"
                },
                new Entry(50)
                {

                    Color = SKColor.Parse("#90D585"),
                    Label = "Settembre"
                },
                new Entry(21)
                {

                    Color = SKColor.Parse("#90D585"),
                    Label = "Ottobre"
                },
                new Entry(50)
                {

                    Color = SKColor.Parse("#90D585"),
                    Label = "Novembre"
                },
                new Entry(70)
                {

                    Color = SKColor.Parse("#90D585"),
                    Label = "Dicembre"
                },
            },
            BackgroundColor = SKColors.Transparent,
        };
    }
}
