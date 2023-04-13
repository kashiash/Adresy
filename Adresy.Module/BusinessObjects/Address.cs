using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DevExpress.XtraCharts;

namespace Adresy.Module.BusinessObjects
{

    [DefaultClassOptions]

   // [RuleCriteria("AddressIsValidStreet", DefaultContexts.Save, "IsValidStreet == true",
   //"Ulica jest wymagana", SkipNullOrEmptyValues = false)]

    // [RuleCriteria("AddressIsValidCity", DefaultContexts.Save, "IsValidCity = true",
    //"Miejscowość jest wymagana", SkipNullOrEmptyValues = false, UsedProperties = "City")]

    [XafDefaultProperty(nameof(Street))]
    public class Address : XPObject
    {
        public Address(Session session) : base(session) { }

        
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        // [RuleRequiredField("", DefaultContexts.Save, CustomMessageTemplate = "Ulica jest wymagana")]

        // [RuleCriteria("AddressIsValidStreet", DefaultContexts.Save, "IsValidStreet == true",
        //"Ulica jest wymagana", SkipNullOrEmptyValues = false)]



        public string Street
        {
            get => street;
            set => SetPropertyValue(nameof(Street), ref street, value);
        }

        Powiat powiat;
        Wojewodztwo wojewodztwo;
        string country;
        string city;
        string street;



        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        // [RuleRequiredField("", DefaultContexts.Save, CustomMessageTemplate = "Miejscowość jest wymagana")]


        public string City
        {
            get => city;
            set => SetPropertyValue(nameof(City), ref city, value);
        }



        public Wojewodztwo Wojewodztwo
        {
            get => wojewodztwo;
            set => SetPropertyValue(nameof(Wojewodztwo), ref wojewodztwo, value);
        }

        
        public Powiat Powiat
        {
            get => powiat;
            set => SetPropertyValue(nameof(Powiat), ref powiat, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Country
        {
            get => country;
            set => SetPropertyValue(nameof(Country), ref country, value);
        }



        [Association]
        public Customer Customer
        {
            get { return GetPropertyValue<Customer>(nameof(Customer)); }
            set { SetPropertyValue<Customer>(nameof(Customer), value); }
        }


        [NonPersistent]
        [Browsable(false)]
        [RuleFromBoolProperty("AddressIsValidStreet", DefaultContexts.Save,
    "Ulica jest wymagana!", SkipNullOrEmptyValues = false, UsedProperties = "Street")]
        public bool IsValidStreet
        {
            get
                {
                return IsValidToSave() == false || string.IsNullOrEmpty(Street) == false;
            }
    }

        public bool IsValidCity
        {
            get
            {
                return IsValidToSave() == false || string.IsNullOrEmpty(City) == false;
            }
    }

    public bool IsValidToSave()
        {
            return this.Session.IsNewObject(this) == false || string.IsNullOrEmpty(Street) == false || string.IsNullOrEmpty(City) == false;
        }


    }
}
