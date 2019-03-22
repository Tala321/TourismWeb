using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace TourismWebProject.Models
{
    public static class Check
    {

        // checks the date , if expired then set status false/2;
        public static void Start()
        {
            Thread thread = new Thread(new ThreadStart(ThreadFunc));
            thread.IsBackground = true;
            thread.Name = "ThreadFunc";
            thread.Start();
        }


        public static void ThreadFunc()
        {
            System.Timers.Timer t = new System.Timers.Timer();
            t.Elapsed += new System.Timers.ElapsedEventHandler(TimerWorker);
            t.Interval = 600000;
            t.Enabled = true;
            t.AutoReset = true;
            t.Start();
        }

        public static void TimerWorker(object sender, System.Timers.ElapsedEventArgs e)
        {
            TourismDbContext db = new TourismDbContext();

            foreach (var item in db.Reservation.ToList())
            {
                if(item.ReservationDateTo.Date<DateTime.Now)
                {
                    item.ReservationStatus = false;
                    db.SaveChanges();
                }
            }
            foreach (var item in db.Tour.ToList())
            {
                if (item.DateTo.Date < DateTime.Now)
                {
                    item.TourStatus = 2;
                    db.SaveChanges();
                }
            }
        }
    }
}