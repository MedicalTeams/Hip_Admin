using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthInformationProgram.Models
{
    public class BoundUserRole
    {
        Guid _roleId = new Guid();
        public Guid RoleId
        {
            get
            {
                return _roleId;
            }
            set
            {
                _roleId = value;
            }
        }

        string _roleName = string.Empty;
        public string RoleName
        {
            get
            {
                return _roleName;
            }
            set
            {
                _roleName = value;
            }
        }

        bool _userIsInRole = false;
        public bool UserIsInRole
        {
            get
            {
                return _userIsInRole;
            }
            set
            {
                _userIsInRole = value;
            }
        }
    }
}