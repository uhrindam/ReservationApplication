using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReservationApplication.Areas.User.Controllers
{
    [Authorize(Roles = "A, U")]
    public class BookAnAppointmentController : Controller
    {
        // GET: User/BookAnAppointment
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult Backend()
        //{
        //    return new Dpc().CallBack(this);
        //}

    }
    //public class Dpc : DayPilotCalendar
    //{
    //    protected override void OnInit(InitArgs initArgs)
    //    {

    //        UpdateWithMessage("Welcome!", CallBackUpdateType.Full);

    //        if (Id == "days_resources")
    //        {
    //            Columns.Clear();
    //            Column today = new Column(DateTime.Today.ToShortDateString(), DateTime.Today.ToString("s"));
    //            today.Children.Add("A", "a", DateTime.Today);
    //            today.Children.Add("B", "b", DateTime.Today);
    //            Columns.Add(today);

    //            Column tomorrow = new Column(DateTime.Today.AddDays(1).ToShortDateString(), DateTime.Today.AddDays(1).ToString("s"));
    //            tomorrow.Children.Add("A", "a", DateTime.Today.AddDays(1));
    //            tomorrow.Children.Add("B", "b", DateTime.Today.AddDays(1));
    //            Columns.Add(tomorrow);

    //        }
    //        else if (Id == "resources")
    //        {
    //            Columns.Clear();
    //            Columns.Add("A", "A");
    //            Columns.Add("B", "B");
    //            Columns.Add("C", "C");
    //        }
    //    }

    //    protected override void OnBeforeCellRender(BeforeCellRenderArgs e)
    //    {
    //        if (Id == "dpc_today")
    //        {
    //            if (e.Start.Date == DateTime.Today)
    //            {
    //                if (e.IsBusiness)
    //                {
    //                    e.BackgroundColor = "#ffaaaa";
    //                }
    //                else
    //                {
    //                    e.BackgroundColor = "#ff6666";
    //                }
    //            }
    //        }
    //        if (e.IsBusiness)
    //        {
    //            //e.BackgroundColor = "red";
    //        }

    //    }

    //    protected override void OnBeforeEventRender(BeforeEventRenderArgs e)
    //    {

    //        if (Id == "dpcg")  // Calendar/GoogleLike
    //        {
    //            if (e.Id == "6")
    //            {
    //                e.BorderColor = "#1AAFE0";
    //                e.BackgroundColor = "#90D8F2";
    //            }
    //            if (e.Id == "8")
    //            {
    //                e.BorderColor = "#068c14";
    //                e.BackgroundColor = "#08b81b";
    //            }
    //            if (e.Id == "2")
    //            {
    //                e.BorderColor = "#990607";
    //                e.BackgroundColor = "#f60e13";
    //            }
    //        }
    //        else if (Id == "dpc_menu")  // Calendar/ContextMenu
    //        {
    //            if (e.Id == "7")
    //            {
    //                e.ContextMenuClientName = "menu2";
    //            }
    //        }
    //        else if (Id == "dpc_areas")  // Calendar/ActiveAreas
    //        {
    //            e.CssClass = "calendar_white_event_withheader";

    //            e.Areas.Add(new Area().Right(3).Top(3).Width(15).Height(15).CssClass("event_action_delete").JavaScript("dpc_areas.eventDeleteCallBack(e);"));
    //            e.Areas.Add(new Area().Right(20).Top(3).Width(15).Height(15).CssClass("event_action_menu").JavaScript("dpc_areas.bubble.showEvent(e, true);"));
    //            e.Areas.Add(new Area().Left(0).Bottom(5).Right(0).Height(5).CssClass("event_action_bottomdrag").ResizeEnd());
    //            e.Areas.Add(new Area().Left(15).Top(1).Right(46).Height(11).CssClass("event_action_move").Move());
    //        }
    //        else if (Id == "dpc_export_client")
    //        {
    //            string url = System.Web.VirtualPathUtility.ToAbsolute("~/Media/linked/i-circle-16.png");
    //            e.Areas.Add(new Area().Top(3).Right(3).Width(16).Height(16).Image(url).Visible());
    //        }

    //        if (e.Recurrent)
    //        {
    //            e.Html += " (R)";
    //        }

    //    }

    //    protected override void OnBeforeHeaderRender(BeforeHeaderRenderArgs e)
    //    {
    //        if (Id == "dpc_areas")
    //        {
    //            e.Areas.Add(new Area().Right(1).Top(0).Width(17).Bottom(1).CssClass("resource_action_menu").Html("<div><div></div></div>").JavaScript("alert(e.date);"));
    //        }
    //        if (Id == "dpc_autofit")
    //        {
    //            e.InnerHtml += " adding some longer text so the autofit can be tested";
    //        }

    //    }

    //    protected override void OnEventBubble(EventBubbleArgs e)
    //    {
    //        e.BubbleHtml = "This is an event bubble for id: " + e.Id;
    //    }

    //    protected override void OnEventClick(EventClickArgs e)
    //    {
    //        UpdateWithMessage("Event clicked: " + e.Text);
    //        //Redirect("http://www.daypilot.org/");
    //    }

    //    protected override void OnTimeRangeSelected(TimeRangeSelectedArgs e)
    //    {
    //        new EventManager(Controller).EventCreate(e.Start, e.End, "Default name", e.Resource);
    //        Update();
    //    }

    //    protected override void OnEventMove(DayPilot.Web.Mvc.Events.Calendar.EventMoveArgs e)
    //    {
    //        if (new EventManager(Controller).Get(e.Id) != null)
    //        {
    //            new EventManager(Controller).EventMove(e.Id, e.NewStart, e.NewEnd);
    //        }
    //        else // external drag&drop
    //        {
    //            new EventManager(Controller).EventCreate(e.NewStart, e.NewEnd, e.Text, e.NewResource, e.Id);
    //        }

    //        Update();
    //    }


    //    protected override void OnEventDelete(EventDeleteArgs e)
    //    {
    //        new EventManager(Controller).EventDelete(e.Id);
    //        Update();
    //    }

    //    protected override void OnEventResize(DayPilot.Web.Mvc.Events.Calendar.EventResizeArgs e)
    //    {
    //        new EventManager(Controller).EventMove(e.Id, e.NewStart, e.NewEnd);
    //        Update();
    //    }

    //    protected override void OnEventMenuClick(EventMenuClickArgs e)
    //    {
    //        switch (e.Command)
    //        {
    //            case "Delete":
    //                new EventManager(Controller).EventDelete(e.Id);
    //                Update();
    //                break;
    //        }
    //    }

    //    protected override void OnCommand(CommandArgs e)
    //    {
    //        switch (e.Command)
    //        {
    //            case "navigate":
    //                StartDate = (DateTime)e.Data["start"];
    //                Update(CallBackUpdateType.Full);
    //                break;

    //            case "refresh":
    //                UpdateWithMessage("Refreshed");
    //                break;

    //            case "selected":
    //                if (SelectedEvents.Count > 0)
    //                {
    //                    EventInfo ei = SelectedEvents[0];
    //                    SelectedEvents.RemoveAt(0);
    //                    UpdateWithMessage("Event removed from selection: " + ei.Text);
    //                }

    //                break;

    //            case "delete":
    //                string id = (string)e.Data["id"];
    //                new EventManager(Controller).EventDelete(id);
    //                Update(CallBackUpdateType.EventsOnly);
    //                break;

    //            case "previous":
    //                StartDate = StartDate.AddDays(-7);
    //                Update(CallBackUpdateType.Full);
    //                break;

    //            case "next":
    //                StartDate = StartDate.AddDays(7);
    //                Update(CallBackUpdateType.Full);
    //                break;

    //            case "today":
    //                StartDate = DateTime.Today;
    //                Update(CallBackUpdateType.Full);
    //                break;
    //        }
    //    }

        

    //    protected override void OnFinish()
    //    {
    //        // only load the data if an update was requested by an Update() call
    //        if (UpdateType == CallBackUpdateType.None)
    //        {
    //            return;
    //        }

    //        // this select is a really bad example, no where clause
    //        if (Id == "dpc_recurring")
    //        {
    //            Events = new EventManager(Controller, "recurring").Data.AsEnumerable();
    //            DataRecurrenceField = "recurrence";
    //        }
    //        else
    //        {
    //            Events = new EventManager(Controller).Data.AsEnumerable();
    //        }

    //        DataStartField = "start";
    //        DataEndField = "end";
    //        DataTextField = "text";
    //        DataIdField = "id";
    //        DataResourceField = "resource";

    //        DataAllDayField = "allday";
    //        //DataTagFields = "id, name";
    //    }
    //}
}
