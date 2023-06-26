using DevExpress.Data.Filtering;
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
    public class Ulica : BaseObject
    {
        public Ulica(Session session) : base(session)
        { }



        private string _woj;
        public string WOJ
        {
            get => _woj;
            set => SetPropertyValue(nameof(WOJ), ref _woj, value);
        }

        private string _pow;
        public string POW
        {
            get => _pow;
            set => SetPropertyValue(nameof(POW), ref _pow, value);
        }

        private string _gmi;
        public string GMI
        {
            get => _gmi;
            set => SetPropertyValue(nameof(GMI), ref _gmi, value);
        }

        private string _rodzGmi;
        public string RODZ_GMI
        {
            get => _rodzGmi;
            set => SetPropertyValue(nameof(RODZ_GMI), ref _rodzGmi, value);
        }

        private string _sym;
        public string SYM
        {
            get => _sym;
            set => SetPropertyValue(nameof(SYM), ref _sym, value);
        }

        private string _symUl;
        public string SYM_UL
        {
            get => _symUl;
            set => SetPropertyValue(nameof(SYM_UL), ref _symUl, value);
        }

        private string _cecha;
        public string CECHA
        {
            get => _cecha;
            set => SetPropertyValue(nameof(CECHA), ref _cecha, value);
        }

        private string _nazwa1;
        public string NAZWA_1
        {
            get => _nazwa1;
            set => SetPropertyValue(nameof(NAZWA_1), ref _nazwa1, value);
        }

        private string _nazwa2;
        public string NAZWA_2
        {
            get => _nazwa2;
            set => SetPropertyValue(nameof(NAZWA_2), ref _nazwa2, value);
        }

        private string _stanNa;
        public string STAN_NA
        {
            get => _stanNa;
            set => SetPropertyValue(nameof(STAN_NA), ref _stanNa, value);
        }

       
        public Wojewodztwo Wojewodztwo
        {
            get => GetPropertyValue<Wojewodztwo>(nameof(Wojewodztwo));
            set => SetPropertyValue(nameof(Wojewodztwo), value);
        }

        [Association("Ulice-Powiat")]
        public Powiat Powiat
        {
            get => GetPropertyValue<Powiat>(nameof(Powiat));
            set => SetPropertyValue(nameof(Powiat), value);
        }

        [Association("Ulice-Gmina")]
        public Gmina Gmina
        {
            get => GetPropertyValue<Gmina>(nameof(Gmina));
            set => SetPropertyValue(nameof(Gmina), value);
        }



    }
}
