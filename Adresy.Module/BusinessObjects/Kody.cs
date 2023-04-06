using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace Adresy.Module.BusinessObjects
{



    [DefaultClassOptions]
    public class Kody : XPObject
    {
        public Kody(Session session) : base(session) { }

        [Size(50)]
        public string KodTERC
        {
            get => GetPropertyValue<string>(nameof(KodTERC));
            set => SetPropertyValue(nameof(KodTERC), value);
        }

        [Size(50)]
        public string KodTERCGUS
        {
            get => GetPropertyValue<string>(nameof(KodTERCGUS));
            set => SetPropertyValue(nameof(KodTERCGUS), value);
        }

        [Size(50)]
        public string KodTERCwojGUS
        {
            get => GetPropertyValue<string>(nameof(KodTERCwojGUS));
            set => SetPropertyValue(nameof(KodTERCwojGUS), value);
        }

        [Size(100)]
        public string Wojewodztwo
        {
            get => GetPropertyValue<string>(nameof(Wojewodztwo));
            set => SetPropertyValue(nameof(Wojewodztwo), value);
        }

        [Size(50)]
        public string KodTERCpowGUS
        {
            get => GetPropertyValue<string>(nameof(KodTERCpowGUS));
            set => SetPropertyValue(nameof(KodTERCpowGUS), value);
        }

        [Size(100)]
        public string Powiat
        {
            get => GetPropertyValue<string>(nameof(Powiat));
            set => SetPropertyValue(nameof(Powiat), value);
        }

        [Size(50)]
        public string KodTERCgmi
        {
            get => GetPropertyValue<string>(nameof(KodTERCgmi));
            set => SetPropertyValue(nameof(KodTERCgmi), value);
        }

        [Size(50)]
        public string KodTERCgmiRodz
        {
            get => GetPropertyValue<string>(nameof(KodTERCgmiRodz));
            set => SetPropertyValue(nameof(KodTERCgmiRodz), value);
        }

        [Size(100)]
        public string Gmina
        {
            get => GetPropertyValue<string>(nameof(Gmina));
            set => SetPropertyValue(nameof(Gmina), value);
        }

        [Size(50)]
        public string KodTERCgmiGUS
        {
            get => GetPropertyValue<string>(nameof(KodTERCgmiGUS));
            set => SetPropertyValue(nameof(KodTERCgmiGUS), value);
        }

        [Size(50)]
        public string KodTERCgmiRodzGUS
        {
            get => GetPropertyValue<string>(nameof(KodTERCgmiRodzGUS));
            set => SetPropertyValue(nameof(KodTERCgmiRodzGUS), value);
        }

        [Size(100)]
        public string GminaGUS
        {
            get => GetPropertyValue<string>(nameof(GminaGUS));
            set => SetPropertyValue(nameof(GminaGUS), value);
        }

        [Size(50)]
        public string KodSIMC
        {
            get => GetPropertyValue<string>(nameof(KodSIMC));
            set => SetPropertyValue(nameof(KodSIMC), value);
        }

        [Size(50)]
        public string KodSIMCPodstawowa
        {
            get => GetPropertyValue<string>(nameof(KodSIMCPodstawowa));
            set => SetPropertyValue(nameof(KodSIMCPodstawowa), value);
        }

        [Size(50)]
        public string RodzajMiejscowosci
        {
            get => GetPropertyValue<string>(nameof(RodzajMiejscowosci));
            set => SetPropertyValue(nameof(RodzajMiejscowosci), value);
        }

        [Size(100)]
        public string Miejscowosc
        {
            get => GetPropertyValue<string>(nameof(Miejscowosc));
            set => SetPropertyValue(nameof(Miejscowosc), value);
        }

        [Size(50)]
        public string KodSIMCGUS
        {
            get => GetPropertyValue<string>(nameof(KodSIMCGUS));
            set => SetPropertyValue(nameof(KodSIMCGUS), value);
        }

        [Size(50)]
        public string KodSIMCPodstawowaGUS
        {
            get => GetPropertyValue<string>(nameof(KodSIMCPodstawowaGUS));
            set => SetPropertyValue(nameof(KodSIMCPodstawowaGUS), value);
        }

        [Size(50)]
        public string RodzajMiejscowosciGUS
        {
            get => GetPropertyValue<string>(nameof(RodzajMiejscowosciGUS));
            set => SetPropertyValue(nameof(RodzajMiejscowosciGUS), value);
        }

        [Size(100)]
        public string MiejscowoscGUS
        {
            get => GetPropertyValue<string>(nameof(MiejscowoscGUS));
            set => SetPropertyValue(nameof(MiejscowoscGUS), value);
        }

        [Size(50)]
        public string KodULICGUS
        {
            get => GetPropertyValue<string>(nameof(KodULICGUS));
            set => SetPropertyValue(nameof(KodULICGUS), value);
        }

        [Size(100)]
        public string UlicaCecha
        {
            get => GetPropertyValue<string>(nameof(UlicaCecha));
            set => SetPropertyValue(nameof(UlicaCecha), value);
        }

        [Size(100)]
        public string UlicaNazwa
        {
            get => GetPropertyValue<string>(nameof(UlicaNazwa));
            set => SetPropertyValue(nameof(UlicaNazwa), value);
        }

        [Size(50)]
        public string NumeracjaNieparzystaOd
        {
            get => GetPropertyValue<string>(nameof(NumeracjaNieparzystaOd));
            set => SetPropertyValue(nameof(NumeracjaNieparzystaOd), value);
        }

        [Size(50)]
        public string NumeracjaNieparzystaDo
        {
            get => GetPropertyValue<string>(nameof(NumeracjaNieparzystaDo));
            set => SetPropertyValue(nameof(NumeracjaNieparzystaDo), value);
        }

        [Size(50)]
        public string NumeracjaParzystaOd
        {
            get => GetPropertyValue<string>(nameof(NumeracjaParzystaOd));
            set => SetPropertyValue(nameof(NumeracjaParzystaOd), value);
        }

        [Size(50)]
        public string NumeracjaParzystaDo
        {
            get => GetPropertyValue<string>(nameof(NumeracjaParzystaDo));
            set => SetPropertyValue(nameof(NumeracjaParzystaDo), value);
        }

        [Size(50)]
        public string KodPocztowyPNA
        {
            get => GetPropertyValue<string>(nameof(KodPocztowyPNA));
            set => SetPropertyValue(nameof(KodPocztowyPNA), value);
        }

        [Size(50)]
        public string Zniesione
        {
            get => GetPropertyValue<string>(nameof(Zniesione));
            set => SetPropertyValue(nameof(Zniesione), value);
        }


    }
}
