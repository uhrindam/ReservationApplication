using BLL;
using BOL;
using ReservationApplication.Areas.User.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReservationApplication.ClassConverter
{
    public class ClassConverter
    {
        public static List<SchedulerReservations> ConvertToSchedulerReservation(List<APPOINTMENTS> appointments)
        {
            Random rnd = new Random();
            List<SchedulerReservations> reservations = new List<SchedulerReservations>();
            foreach (var item in appointments)
            {
                reservations.Add(
                    new SchedulerReservations()
                    {
                        Title = item.USERS.FullName + ", " + item.CategoryName,
                        Start = (DateTime)item.StartingPont,
                        End = (DateTime)item.EndingPoint,
                        NickName = item.NickName,
                        CategoryName = item.CategoryName,
                        Description = item.USERS.FullName + ", " + item.CategoryName + ", " + (int)item.CurrentPrice + ", " + (DateTime)item.ReservationDate,
                        TaskID = rnd.Next(1,10000000)
                    }
                    );
            }
            return reservations;
        }

        public static void ConvertToInsertAppointment(SchedulerReservations reservation)
        {
            CategoryBL catBL = new CategoryBL();
            UserBL userBL = new UserBL();
            AppointmentBL bl = new AppointmentBL();

            APPOINTMENTS appointment = new APPOINTMENTS()
            {
                CategoryName = reservation.CategoryName,
                StartingPont = reservation.Start,
                EndingPoint = reservation.End,
                NickName = reservation.NickName,

                CurrentPrice = catBL.GetByID(reservation.CategoryName).Price,
                //USERS = userBL.GetByID(reservation.NickName),
                //CATEGORIES = catBL.GetByID(reservation.CategoryName),
                ReservationDate = DateTime.Now,
                ID = CalculateAppointmentID(),
                IsNotDeleted = true
            };

            bl.Insert(appointment);
        }

        private static string CalculateAppointmentID()
        {
            Random rnd = new Random();
            return rnd.Next(1, 1000000000).ToString();
        }
    }
}