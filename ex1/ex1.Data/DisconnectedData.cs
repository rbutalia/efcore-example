
using ex1.Domain;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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

        public List<KeyValuePair<int, string>> GetCompanyReferenceList()
        {
            var companies = _context.Companies.OrderBy(s => s.CompanyName)
              .Select(s => new { s.CompanyID, s.CompanyName })
              .ToDictionary(t => t.CompanyID, t => t.CompanyName).ToList();
            return companies;
        }

        public Company LoadCompanyGraph(int id)
        {
            var company =
              _context.Companies
              .Include(s => s.Menus)
              .Include(s => s.Orders)
              .Include(s => s.WorkFlowSteps)
              .FirstOrDefault(s => s.CompanyID == id);
            return company;
        }

        public void SaveCompanyGraph(Company company)
        {
            //_context.ChangeTracker.TrackGraph
            //  (company, e => ApplyStateUsingIsKeySet(e.Entry));
            _context.SaveChanges();
        }

        public void DeleteCompanyGraph(int id)
        {
            //goal:  delete samurai , quotes and secret identity
            //       also delete any joins with battles
            //EF Core supports Cascade delete by convention
            //Even if full graph is not in memory, db is defined to delete
            //But always double check!
            var samurai = _context.Companies.Find(id); //NOT TRACKING !!
            _context.Entry(samurai).State = EntityState.Deleted; //TRACKING
            _context.SaveChanges();
        }
    }
}
