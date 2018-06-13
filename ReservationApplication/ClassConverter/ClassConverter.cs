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
            List<SchedulerReservations> reservations = new List<SchedulerReservations>();
            foreach (var item in appointments)
            {
                reservations.Add(
                    new SchedulerReservations()
                    {
                        Title = item.USERS.FullName + ", " + item.CategoryName,
                        Description = item.USERS.FullName + ", " + item.CategoryName + ", " + (int)item.CurrentPrice + ", " + (DateTime)item.ReservationDate,
                        Start = item.StartDate.Value.AddHours(2),
                        End = item.EndDate.Value.AddHours(2),
                        NickName = item.NickName,
                        CategoryName = item.CategoryName,
                        TaskID = item.ID,
                        ProcessLengthInMunites = (int)item.CATEGORIES.ProcessLengthInMunites
                    }
                    );
            }
            return reservations;
        }

        private static APPOINTMENTS CreateAPPOINTMENTSobject(SchedulerReservations reservation)
        {
            return new APPOINTMENTS()
            {
                CategoryName = reservation.CategoryName,
                StartDate = reservation.Start,
                EndDate = reservation.End,
                NickName = reservation.NickName,
                CurrentPrice = reservation.CurrentPrice,
                ReservationDate = reservation.ReservationDate,
                ID = reservation.TaskID
            };
        }

        public static void ConvertToInsertAppointment(SchedulerReservations reservation)
        {
            AppointmentBL bl = new AppointmentBL();
            bl.Insert(CreateAPPOINTMENTSobject(reservation));
        }

        private static int CalculateAppointmentID()
        {
            AppointmentBL bl = new AppointmentBL();
            return bl.GetAll().Last().ID + 1;
        }

        public static SchedulerReservations DataConverter(SchedulerReservations appointment)
        {
            CategoryBL categBL = new CategoryBL();
            CATEGORIES categ = categBL.GetByID(appointment.CategoryName);
            appointment.CurrentPrice = (int)categ.Price;
            appointment.End = appointment.Start.AddMinutes((int)categ.ProcessLengthInMunites);
            appointment.TaskID = CalculateAppointmentID();
            appointment.ReservationDate = DateTime.Now;

            UserBL userBL = new UserBL();
            appointment.Title = userBL.GetByID(appointment.NickName).FullName + ", " + categ.CategoryName;
            appointment.Description = appointment.Title + ", " + appointment.CurrentPrice + ", " + appointment.ReservationDate;

            return appointment;
        }

        private static bool CheckForOverlapping(SchedulerReservations appointment)
        {
            AppointmentBL appBL = new AppointmentBL();
            List<BOL.APPOINTMENTS> newappointments = appBL.GetAll().Where(x => x.StartDate > DateTime.Now).ToList();
            foreach (var item in newappointments)
            {
                if (item.StartDate <= appointment.End && appointment.Start <= item.EndDate)
                    return false;
            }
            return true;
        }

        private static bool ValidateAppointmentEnd(SchedulerReservations appointment)
        {
            CategoryBL categBL = new CategoryBL();
            return appointment.Start.AddMinutes((int)categBL.GetByID(appointment.CategoryName).ProcessLengthInMunites).Hour <= 17;
        }

        private static bool ValidateAppointmentStart(SchedulerReservations appointment)
        {
            CategoryBL categBL = new CategoryBL();
            return appointment.Start >= DateTime.Now;
        }

        public static string ReservationValidation(SchedulerReservations appointment)
        {
            if (appointment.CategoryName == null)
                return "A foglalás sikertelen: Nincs kivaálsztva kategória!";
            if (!CheckForOverlapping(appointment))
                return "A foglalás sikertelen: Két időpont nem fedheti egymást!";
            if (!ValidateAppointmentEnd(appointment))
                return "A foglalás sikertelen: Az időpont nem fejeződhet be a munkaidő lejárta után!";
            if (!ValidateAppointmentStart(appointment))
                return "A foglalás sikertelen: Az aktuális időpontnál régebbi időpontot nem lehet lefoglalni!";
            return String.Empty;
        }
    }
}