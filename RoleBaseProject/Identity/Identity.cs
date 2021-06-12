
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace RoleBaseProject.Identity
{
    public class Identity : IIdentity
    {
        public Identity(int id, string name, string roles)
        {
            this.ID = id;
            this.Name = name;
            this.Roles = roles;
        }
        public Identity(string name, string data)
        {
            if (string.IsNullOrWhiteSpace(data))
                throw new ArgumentException();

            string[] values = data.Split('|');
            if (values.Length != 2)
                throw new ArgumentException();
            this.Name = name;
            this.ID = Convert.ToInt32(values[0]);
            Roles = values[1];
        }

        public string AuthenticationType
        {
            get { return "Custom"; }
        }

        public bool IsAuthenticated
        {
            get { return true; }
        }
        public string GetUserData()
        {
            return string.Format("{0}|{1}|{2}", ID,Name, Roles);
        }

        public int ID { get; private set; }
        public string Name { get; private set; }
       
        public string Roles { get; private set; }
    }
}