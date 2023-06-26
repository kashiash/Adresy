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
    [XafDefaultProperty(nameof(NazwaGminy))]
    public class Gmina : BaseObject
    {
        public Gmina(Session session) : base(session)
        { }


        Powiat powiat;
        string kodRodz;
        string kodTerc;
        string nazwaGminy;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string NazwaGminy
        {
            get => nazwaGminy;
            set => SetPropertyValue(nameof(NazwaGminy), ref nazwaGminy, value);
        }


        [Size(4)]
        public string KodTerc
        {
            get => kodTerc;
            set => SetPropertyValue(nameof(KodTerc), ref kodTerc, value);
        }

        [Size(2)]
        public string KodRodz
        {
            get => kodRodz;
            set => SetPropertyValue(nameof(KodRodz), ref kodRodz, value);
        }

        
        [Association("Powiat-Gminy")]
        public Powiat Powiat
        {
            get => powiat;
            set => SetPropertyValue(nameof(Powiat), ref powiat, value);
        }
    }
}
