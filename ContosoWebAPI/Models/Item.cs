using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ContosoWebAPI.Models
{
    public enum AssignmentTypes
    {
        Test, Assignment, Lab, Other
    }
    public class Item
    {
        public int ItemID { get; set; }
        public int CourseID { get; set; }
        public string Title { get; set; }
        public AssignmentTypes Type { get; set; }
        public int Percentage { get; set; }
        public DateTime DueDate { get; set; }

        [JsonIgnore]
        public virtual Course Course { get; set; }
    }
}