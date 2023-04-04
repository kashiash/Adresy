using DevExpress.Persistent.Base;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;

using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Adresy.Module.BusinessObjects
{
    [DefaultClassOptions]


    public class Customer : XPObject
    {
        public Customer(Session session) : base(session) { }

        Address mailAddress;
        Address mainAddress;
        private string _name;
        [Persistent(nameof(Name))]
        public string Name
        {
            get { return _name; }
            set { SetPropertyValue(nameof(Name), ref _name, value); }
        }

        private string _vatId;
        [Persistent(nameof(VATID))]
        public string VATID
        {
            get { return _vatId; }
            set { SetPropertyValue(nameof(VATID), ref _vatId, value); }
        }

        [Association]
        public XPCollection<Address> Addresses
        {
            get { return GetCollection<Address>(nameof(Addresses)); }
        }


        [EditorAlias(EditorAliases.DetailPropertyEditor)]
        [ExpandObjectMembers(ExpandObjectMembers.Never)]
        public Address MainAddress
        {
            get => mainAddress;
            set => SetPropertyValue(nameof(MainAddress), ref mainAddress, value);
        }
        [EditorAlias(EditorAliases.DetailPropertyEditor)]
        [ExpandObjectMembers(ExpandObjectMembers.Never)]
        public Address MailingAddress
        {
            get => mailAddress;
            set => SetPropertyValue(nameof(MailingAddress), ref mailAddress, value);
        }

        private string _notes;
        [Size(SizeAttribute.Unlimited)]
        public string Notes
        {
            get { return _notes; }
            set { SetPropertyValue(nameof(Notes), ref _notes, value); }
        }
    }


}
