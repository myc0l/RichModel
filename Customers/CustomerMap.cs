using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RichModelDDD.Customers
{
    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Id(x => x.Id);

            Map(x => x.Name).CustomType<string>().Access.CamelCaseField(Prefix.Underscore);
            Map(x => x.Email).CustomType<string>().Access.CamelCaseField(Prefix.Underscore);
            Map(x => x.moneySpent).CustomType<decimal>().Access.CamelCaseField(Prefix.Underscore);

            Component(x => x.Status, y =>
            {
                y.Map(x => x.Type, "Status").CustomType<int>();
                y.Map(x => x.ExpirationDate, "StatusExpirationDate").CustomType<DateTime?>()
                    .Access.CamelCaseField(Prefix.Underscore)
                    .Nullable();
            });

            HasMany(x => x.PurchasedMovies).Access.CamelCaseField(Prefix.Underscore); ;
        }
    }
}
