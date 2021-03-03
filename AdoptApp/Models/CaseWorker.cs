using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoptApp.Models
{
    [Table("CaseWorkers")]
    public class CaseWorker
    {
        [AutoIncrement]
        public int Id { get; set; }
        [PrimaryKey]
        public string CaseWorkerId { get; set; }
        public string Agency { get; set; }
        [Unique]
        public string UserName { get; set; }
        public string Password { get; set; }
        [Unique]
        public string Email { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        [OneToMany] 
        public List<Case> Cases { get; set; }
    }
}
