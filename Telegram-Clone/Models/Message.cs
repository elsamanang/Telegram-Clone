using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramClone.Models
{
    public class Message
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string UserName { get; set; }
        public string UserPicture { get; set; }
        public string Phone { get; set; }
        public DateTime Time { get; set; }
        public string Content { get; set; }
    }
}
