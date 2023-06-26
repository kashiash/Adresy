using DevExpress.ExpressApp.DC;
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
    [XafDefaultProperty(nameof(NazwaPowiatu))]
    public class Powiat : BaseObject
    {
        public Powiat(Session session) : base(session)
        { }


        Wojewodztwo wojewodztwo;
        string kodTerc;
        string nazwaPowiatu;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string NazwaPowiatu
        {
            get => nazwaPowiatu;
            set => SetPropertyValue(nameof(NazwaPowiatu), ref nazwaPowiatu, value);
        }


        [Size(4)]
        public string KodTerc
        {
            get => kodTerc;
            set => SetPropertyValue(nameof(KodTerc), ref kodTerc, value);
        }
        [Association("Wojewodztwo-Powiaty")]

        public Wojewodztwo Wojewodztwo
        {
            get => wojewodztwo;
            set => SetPropertyValue(nameof(Wojewodztwo), ref wojewodztwo, value);
        }

        [Association("Powiat-Gminy")]
        public XPCollection<Gmina> Gminy
        {
            get
            {
                return GetCollection<Gmina>(nameof(Gminy));
            }
        }

        [Association("Ulice-Powiat")]
        public XPCollection<Ulica> Ulice
        {
            get
            {
                return GetCollection<Ulica>(nameof(Ulice));
            }
        }
    }
}
