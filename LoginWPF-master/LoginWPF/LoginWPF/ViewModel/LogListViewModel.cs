using LoginWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginWPF.ViewModel
{
    public class LogListViewModel
    {
        LoginDBEntities db = new LoginDBEntities();

        public List<LoginLog> LogList
        {
            get
            {
                var logs = db.LoginLog.OrderBy(log => log.DateTime).Skip(0).Take(10).ToList();
                return logs;
            }
        }
    }
}
