using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;

namespace Core.Events
{
    /// <summary>
    /// Model wydarzenia
    /// </summary>
    class Event : IEvent
    {
        public string Title { get; set; }
        public string Comment { get; set; }

        public IDateRange DateRange { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
