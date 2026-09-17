using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerTreningow_
{
    public class UserProfile
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = "";
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string FolderName
        {
            get 
            {
                string shortId = Id.ToString().Substring(0, 8);
                return "user_" + shortId;
            }
        }

        public override string ToString() => Name;
    }
}
