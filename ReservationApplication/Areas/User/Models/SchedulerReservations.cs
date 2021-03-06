﻿using BOL;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReservationApplication.Areas.User.Models
{
    /// <summary>
    /// this class is implementing the ISchedulerEvent, which is required to use the Kendo Scheduler.
    /// </summary>
    public class SchedulerReservations : ISchedulerEvent
    {
        public int TaskID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        private DateTime start;
        public DateTime Start
        {
            get
            {
                return start;
            }
            set
            {
                start = value.ToUniversalTime();
            }
        }

        private DateTime end;
        public DateTime End
        {
            get
            {
                return end;
            }
            set
            {
                end = value.ToUniversalTime();
            }
        }

        public string RecurrenceRule { get; set; }
        public int? RecurrenceID { get; set; }
        public string RecurrenceException { get; set; }
        public bool IsAllDay { get; set; }
        public int? OwnerID { get; set; }
        public string StartTimezone { get; set; }
        public string EndTimezone { get; set; }

        public string NickName { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public int CurrentPrice { get; set; }
        public int ProcessLengthInMunites { get; set; }

        private DateTime reservationDate;
        public DateTime ReservationDate
        {
            get
            {
                return reservationDate;
            }
            set
            {
                reservationDate = value.ToUniversalTime();
            }
        }
    }
}