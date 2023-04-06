using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportKodyGabos
{
    public class CsvRow
    {
        public string KodTERC { get; set; }
        public string KodTERCGUS { get; set; }
        public string KodTERCwojGUS { get; set; }
        public string Wojewodztwo { get; set; }
        public string KodTERCpowGUS { get; set; }
        public string Powiat { get; set; }
        public string KodTERCgmi { get; set; }
        public string KodTERCgmiRodz { get; set; }
        public string Gmina { get; set; }
        public string KodTERCgmiGUS { get; set; }
        public string KodTERCgmiRodzGUS { get; set; }
        public string GminaGUS { get; set; }
        public string KodSIMC { get; set; }
        public string KodSIMCPodstawowa { get; set; }
        public string RodzajMiejscowosci { get; set; }
        public string Miejscowosc { get; set; }
        public string KodSIMCGUS { get; set; }
        public string KodSIMCPodstawowaGUS { get; set; }
        public string RodzajMiejscowosciGUS { get; set; }
        public string MiejscowoscGUS { get; set; }
        public string KodULICGUS { get; set; }
        public string UlicaCecha { get; set; }
        public string UlicaNazwa { get; set; }
        public string NumeracjaNieparzystaOd { get; set; }
        public string NumeracjaNieparzystaDo { get; set; }
        public string NumeracjaParzystaOd { get; set; }
        public string NumeracjaParzystaDo { get; set; }
        public string KodPocztowyPNA { get; set; }
        public string Zniesione { get; set; }
    }
}
