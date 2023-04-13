using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adresy.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class CustomerGroup : BaseObject
    {
        public CustomerGroup(Session session) : base(session)
        { }


        string name;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }

        [Association("CustomerGroup-Customers")]
        public XPCollection<Customer> Customers
        {
            get
            {
                return GetCollection<Customer>(nameof(Customers));
            }
        }
    }
}
