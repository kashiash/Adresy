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
    [XafDefaultProperty(nameof(NazwaWojewodztwa))]
    public class Wojewodztwo : BaseObject
    {
        public Wojewodztwo(Session session) : base(session)
        { }


        string kodTercGus;
        string kodTerc;
        string nazwaWojewodztwa;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string NazwaWojewodztwa
        {
            get => nazwaWojewodztwa;
            set => SetPropertyValue(nameof(NazwaWojewodztwa), ref nazwaWojewodztwa, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string KodTerc
        {
            get => kodTerc;
            set => SetPropertyValue(nameof(KodTerc), ref kodTerc, value);
        }

        
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string KodTercGus
        {
            get => kodTercGus;
            set => SetPropertyValue(nameof(KodTercGus), ref kodTercGus, value);
        }

        [Association("Wojewodztwo-Powiaty")]
        public XPCollection<Powiat> Powiaty
        {
            get
            {
                return GetCollection<Powiat>(nameof(Powiaty));
            }
        }
    }
}
