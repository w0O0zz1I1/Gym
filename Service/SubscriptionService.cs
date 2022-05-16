using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class SubscriptionService
    {
        public static List<Subscription> GetByClientId(int id)
        {
            using (var container = new ModelDataBaseContainer())
            {
                var client = container.Clients.FirstOrDefault(c => c.Id == id);
                if (client is null)
                {
                    return null;
                }

                return client.Subscription.ToList();
            }
        }

        public static List<Subscription> AddVisit(int clientId)
        {
            using (var container = new ModelDataBaseContainer())
            {
                var client = container.Clients.FirstOrDefault(c => c.Id == clientId);
                if (client is null)
                {
                    return null;
                }
                var subscription = client.Subscription.FirstOrDefault(s => s.WorkOutsPassed < s.WorkOutsAmount);
                if (subscription is null)
                {
                    return null;
                }
                subscription.LastWorkOutDateTime = System.DateTime.Now;
                subscription.WorkOutsPassed = subscription.WorkOutsPassed + 1;
                container.SaveChanges();
                return client.Subscription.ToList();
            }
        }

        public static List<Subscription> AddSubscription(int clientId, decimal price, int workOutsAmount)
        {
            using (var container = new ModelDataBaseContainer())
            {
                var client = container.Clients.FirstOrDefault(c => c.Id == clientId);
                if (client is null)
                {
                    return null;
                }
                var subscription = new Subscription()
                {
                    Client = client,
                    DateCreateSubscription = System.DateTime.Now,
                    Price = price,
                    WorkOutsAmount = workOutsAmount,
                    LastWorkOutDateTime = null
                };
                container.Subscriptions.Add(subscription);
                container.SaveChanges();
                client.Subscription.Add(subscription);
                return client.Subscription.ToList();
            }
        }

        public static decimal? CheckPrice(string text)
        {
            var isSuccess = decimal.TryParse(text, out var price);
            if (isSuccess is false)
            {
                return null;
            }
            return price;
        }

        public static int? CheckWorkOutsAmount(string text)
        {
            var isSuccess = int.TryParse(text, out var workOutsAmount);
            if (isSuccess is false)
            {
                return null;
            }
            return workOutsAmount;
        }
    }
}
