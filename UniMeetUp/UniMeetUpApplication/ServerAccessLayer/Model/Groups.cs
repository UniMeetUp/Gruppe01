using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniMeetUpApplication.Model
{
    public class Groups : ObservableCollection<Group>
    {
        public Groups()
        {
            Add(new Group("poul3"));
            Add(new Group("poul2"));
            Add(new Group("poul1"));
        }
    }
}
