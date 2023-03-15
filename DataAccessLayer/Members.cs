using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Members
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int MembershipStatusID { get; set; }
        public string MembershipStatusName { get; set; }
        public string ProfilPhoto { get; set; }
        public string Info { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public string BirthdayStr { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public int SecurityQestionsID { get; set; }
        public string SecurityAnswer { get; set; }
        public int VisitorCounts { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string RegistrationDateStr { get; set; }
        public string RegistrationTimeStr { get; set; }
        public bool UserStatus { get; set; }
        public string UserStatusStr { get; set; }
    }
}
