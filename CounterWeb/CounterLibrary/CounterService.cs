using System.Linq;

namespace CounterLibrary
{
    public class CounterService
    {
        public void Initialize()
        {
            using (var dbCtx = new EntityFramework.CounterDatabaseEntities())
            {
                var counter = dbCtx.Counters.Single(ctr => ctr.Id == 1);
                counter.Counter1 = 0;
                dbCtx.SaveChanges();
            }
        }

        public int IncreaseCounter()
        {
            using (var dbCtx = new EntityFramework.CounterDatabaseEntities())
            {
                var counter = dbCtx.Counters.Single(ctr => ctr.Id == 1);
                counter.Counter1++;
                dbCtx.SaveChanges();
            }
            return GetCounter();
        }

        public int GetCounter()
        {
            var counter = new EntityFramework.Counter();
            using (var dbCtx = new EntityFramework.CounterDatabaseEntities())
            {
                counter = dbCtx.Counters.Single(ctr => ctr.Id == 1);
            }
            return counter.Counter1;
        }
    }
}
