using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pikpo_job.rep
{
    class User
    {
        public int _userpermissions { get; set; }
        public string _username { get; set; }
        public User()
        {
            _userpermissions = -1;
        }
    }
}
