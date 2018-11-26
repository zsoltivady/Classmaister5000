using Orarend_osszerako.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orarend_osszerako.UI
{
    public class UIRepository
    {
        private static volatile UIRepository instance;
        private static object syncRoot = new Object();

        private UIRepository() { }
        public static UIRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new UIRepository();
                    }
                }

                return instance;
            }
        }

        private int _currentClientId;

        public int CurrentClientId
        {
            get { return _currentClientId; }
            set { _currentClientId = value; }
        }
        private int _subjectId;
        public int SubjectId
        {
            get { return _subjectId; }
            set { _subjectId = value; }
        }
    }
}
