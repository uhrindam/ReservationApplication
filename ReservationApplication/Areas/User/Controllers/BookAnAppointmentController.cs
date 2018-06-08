using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DayPilot.Web.Mvc;
using DayPilot.Web.Mvc.Data;
using DayPilot.Web.Mvc.Enums;
using DayPilot.Web.Mvc.Events.Scheduler;
using DayPilot.Web.Mvc.Recurrence;

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

        public ActionResult Backend()
        {
            return new Dps().CallBack(this);
        }


        class Dps : DayPilotScheduler
        {
            protected override void OnInit(InitArgs e)
            {
                Resources.Add("Room A", "A");
                Resources.Add("Room B", "B");
                Resources.Add("Room C", "C");
                Resources.Add("Room D", "D");
                Resources.Add("Room E", "E");

                UpdateWithMessage("Welcome!", CallBackUpdateType.Full);
            }

            /*private void LoadResources()
            {
                Resources.Clear();
                foreach (DataRow r in new EventManager().GetResources().Rows)
                {
                    Resource res = new Resource((string)r["name"], Convert.ToString(r["id"]));
                    Resources.Add(res);
                }
            }

            protected override void OnEventResize(EventResizeArgs e)
            {
                if (e.Recurrent && !e.RecurrentException)
                {
                    new EventManager().EventCreateException(e.NewStart, e.NewEnd, e.Text, e.Resource, RecurrenceRule.EncodeExceptionModified(e.RecurrentMasterId, e.OldStart));
                    UpdateWithMessage("Recurrence exception was created.");
                }
                else
                {
                    new EventManager().EventMove(e.Id, e.NewStart, e.NewEnd, e.Resource);
                    UpdateWithMessage("The event was resized.");
                }
            }

            protected override void OnEventMove(EventMoveArgs e)
            {
                if (e.Recurrent && !e.RecurrentException)
                {
                    new EventManager().EventCreateException(e.NewStart, e.NewEnd, e.Text, e.NewResource, RecurrenceRule.EncodeExceptionModified(e.RecurrentMasterId, e.OldStart));
                    UpdateWithMessage("Recurrence exception was created.");
                }
                else
                {
                    new EventManager().EventMove(e.Id, e.NewStart, e.NewEnd, e.NewResource);
                    UpdateWithMessage("The event was moved.");
                }

            }

            protected override void OnCommand(CommandArgs e)
            {
                switch (e.Command)
                {
                    case "refresh":
                        Update();
                        break;
                }
            }


            protected override void OnBeforeEventRender(BeforeEventRenderArgs e)
            {
                if (e.Recurrent)
                {
                    if (e.RecurrentException)
                    {
                        e.Areas.Add(new Area().Right(5).Top(5).Visible().CssClass("area_recurring_ex"));
                    }
                    else
                    {
                        e.Areas.Add(new Area().Right(5).Top(5).Visible().CssClass("area_recurring"));
                    }
                }
            }

            protected override void OnFinish()
            {
                if (UpdateType == CallBackUpdateType.None)
                {
                    return;
                }

                Events = new EventManager().FilteredData(StartDate, StartDate.AddDays(Days)).AsEnumerable();

                DataIdField = "id";
                DataTextField = "name";
                DataStartField = "eventstart";
                DataEndField = "eventend";
                DataResourceField = "resource";
                DataRecurrenceField = "recurrence";
            }*/
        }




        /*public class EventManager
        {

            public DataTable FilteredData(DateTime start, DateTime end)
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [event] WHERE NOT (([eventend] <= @start) OR ([eventstart] >= @end))", ConfigurationManager.ConnectionStrings["daypilot"].ConnectionString);
                da.SelectCommand.Parameters.AddWithValue("start", start);
                da.SelectCommand.Parameters.AddWithValue("end", end);

                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }

            public void EventEdit(string id, string name, DateTime start, DateTime end, string resource, string recurrence)
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["daypilot"].ConnectionString))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE [event] SET [name] = @name, [eventstart] = @start, [eventend] = @end, [resource] = @resource, [recurrence] = @recurrence WHERE [id] = @id", con);
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.Parameters.AddWithValue("name", name);
                    cmd.Parameters.AddWithValue("start", start);
                    cmd.Parameters.AddWithValue("end", end);
                    cmd.Parameters.AddWithValue("resource", resource);
                    cmd.Parameters.AddWithValue("recurrence", (object)recurrence ?? DBNull.Value);
                    cmd.ExecuteNonQuery();

                }
            }

            public void EventEdit(string id, string name, DateTime start, DateTime end, string resource)
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["daypilot"].ConnectionString))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE [event] SET [name] = @name, [eventstart] = @start, [eventend] = @end, [resource] = @resource WHERE [id] = @id", con);
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.Parameters.AddWithValue("name", name);
                    cmd.Parameters.AddWithValue("start", start);
                    cmd.Parameters.AddWithValue("end", end);
                    cmd.Parameters.AddWithValue("resource", resource);
                    cmd.ExecuteNonQuery();

                }
            }

            public DataTable GetResources()
            {
                return GetResources("name");
            }

            public DataTable GetResources(string orderBy)
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [resource]", ConfigurationManager.ConnectionStrings["daypilot"].ConnectionString);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dt.DefaultView.Sort = orderBy;

                return dt.DefaultView.ToTable();

            }

            public void EventMove(string id, DateTime start, DateTime end, string resource)
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["daypilot"].ConnectionString))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE [event] SET [eventstart] = @start, [eventend] = @end, [resource] = @resource WHERE [id] = @id", con);
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.Parameters.AddWithValue("start", start);
                    cmd.Parameters.AddWithValue("end", end);
                    cmd.Parameters.AddWithValue("resource", resource);
                    cmd.ExecuteNonQuery();

                }
            }

            public Event Get(string id)
            {
                if (String.IsNullOrEmpty(id))
                {
                    return null;
                }

                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [event] WHERE id = @id", ConfigurationManager.ConnectionStrings["daypilot"].ConnectionString);
                da.SelectCommand.Parameters.AddWithValue("id", id);

                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    return new Event
                    {
                        Id = id,
                        Text = (string)dr["name"],
                        Start = (DateTime)dr["eventstart"],
                        End = (DateTime)dr["eventend"],
                        Resource = new SelectList(ResourceSelectList(), "Value", "Text", dr["resource"]),
                        Recurrence = dr.IsNull("recurrence") ? null : (string)dr["recurrence"]
                    };
                }
                return null;
            }

            public IEnumerable<SelectListItem> ResourceSelectList()
            {
                return
                    GetResources().AsEnumerable().Select(u => new SelectListItem
                    {
                        Value = Convert.ToString(u.Field<int>("id")),
                        Text = u.Field<string>("name")
                    });
            }

            internal void EventCreate(DateTime start, DateTime end, string text, string resource, string recurrenceJson)
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["daypilot"].ConnectionString))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO [event] (eventstart, eventend, name, resource) VALUES (@start, @end, @name, @resource); ", con);  // SELECT SCOPE_IDENTITY();
                    cmd.Parameters.AddWithValue("start", start);
                    cmd.Parameters.AddWithValue("end", end);
                    cmd.Parameters.AddWithValue("name", text);
                    cmd.Parameters.AddWithValue("resource", resource);
                    //cmd.Parameters.AddWithValue("recurrence", recurrence);
                    cmd.ExecuteScalar();

                    cmd = new SqlCommand("select @@identity;", con);
                    int id = Convert.ToInt32(cmd.ExecuteScalar());

                    RecurrenceRule rule = RecurrenceRule.FromJson(id.ToString(), start, recurrenceJson);
                    string recurrenceString = rule.Encode();
                    if (!String.IsNullOrEmpty(recurrenceString))
                    {
                        cmd = new SqlCommand("update [event] set [recurrence] = @recurrence where [id] = @id", con);
                        cmd.Parameters.AddWithValue("recurrence", rule.Encode());
                        cmd.Parameters.AddWithValue("id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            public class Event
            {
                public string Id { get; set; }
                public string Text { get; set; }
                public DateTime Start { get; set; }
                public DateTime End { get; set; }
                public SelectList Resource { get; set; }
                public string Recurrence { get; set; }
            }

            public void EventDelete(string id)
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["daypilot"].ConnectionString))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("DELETE FROM [event] WHERE id = @id", con);
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                }
            }

            public void EventCreateException(DateTime start, DateTime end, string text, string resource, string encodedRecurrence)
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["daypilot"].ConnectionString))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO [event] (eventstart, eventend, name, resource, recurrence) VALUES (@start, @end, @name, @resource, @recurrence); ", con);  // SELECT SCOPE_IDENTITY();
                    cmd.Parameters.AddWithValue("start", start);
                    cmd.Parameters.AddWithValue("end", end);
                    cmd.Parameters.AddWithValue("name", text);
                    cmd.Parameters.AddWithValue("resource", resource);
                    cmd.Parameters.AddWithValue("recurrence", encodedRecurrence);
                    cmd.ExecuteScalar();

                }

            }
        }*/


    }
}