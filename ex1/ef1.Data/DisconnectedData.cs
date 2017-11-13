using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ex1.Data
{
    public class DisconnectedData
    {
        private Ex1DataContext _context;

        public DisconnectedData(Ex1DataContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior
              = QueryTrackingBehavior.NoTracking;
        }


    }
}
