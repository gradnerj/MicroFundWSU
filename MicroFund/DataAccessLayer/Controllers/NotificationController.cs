using DataAccessLayer.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase {
        private readonly ApplicationDbContext _context;
        //private ApplicationDbContext db = new ApplicationDbContext();
        public NotificationController(ApplicationDbContext context) {
            _context = context;
        }

        [Route("dropnotification", Name ="dropnots")]
        [HttpGet]
        public IActionResult DropNotification(int notificationid) {

            var notiToDelete = _context.Notifications.FirstOrDefault(n => n.NotificationID == notificationid);
            _context.Notifications.Remove(notiToDelete);
            _context.SaveChanges();
            return RedirectToPage("/Index");
        }
        [Route("getnotscount")]
        [HttpGet]
        public string GetNotificationsCount(string userId) {
            var count = _context.Notifications.Where(n => n.UserID == userId).ToList().Count();
            var notifications = _context.Notifications.Where(n => n.UserID == userId).ToList();

            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            using (JsonWriter writer = new JsonTextWriter(sw)) {
                writer.Formatting = Formatting.Indented;
                writer.WriteStartObject();
                writer.WritePropertyName("COUNT");
                writer.WriteValue(count);
                writer.WriteEndObject();
            }
            return sb.ToString();
        }

        [Route("getnots")]
        [HttpGet]
        public string GetNotificationss(string userId) {
            var notifications = _context.Notifications.Where(n => n.UserID == userId).ToList();
            var json = JsonConvert.SerializeObject(notifications, Formatting.Indented);
            return json;
        }
                      

    [HttpPost]
        public string Echo(string str) {
            return str;
        }
    }
}
