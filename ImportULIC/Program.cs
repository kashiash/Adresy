using System.Text;
using Adresy.Module.BusinessObjects;
using DevExpress.Xpo;

namespace ImportULIC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            // Specify the input and output file paths.
            string inputFile = "c:\\WymianaEurorent\\ULIC_Adresowy.csv";
         
            // Read the contents of the input file using the Windows-1252 encoding.
            string content;
            using (StreamReader reader = new StreamReader(inputFile, Encoding.GetEncoding(1250)))
            {
                content = reader.ReadToEnd();
            }

            // Write the contents to the output file using UTF-8 encoding.
            using (StreamWriter writer = new StreamWriter(outputFile, false, new UTF8Encoding(false)))
            {
                writer.Write(content);
            }

            //Console.WriteLine("Conversion complete.");

            List<CsvRow> rows = ReadCsv(inputFile);


            //Console.WriteLine("Conversion complete.");

            var _session = new Session() { ConnectionString = "Integrated Security=SSPI;Pooling=false;Data Source=.;Initial Catalog=Adresy" };
            var unitOfWork = new UnitOfWork(_session.DataLayer);

            int lk = 0;
            foreach (var row in rows)
            {
                lk++;
                Console.WriteLine($"{lk} {row.Miejscowosc} {row.KodPocztowyPNA} {row.Wojewodztwo}");
                var kod = new Ulica(unitOfWork)
                {
                    KodTERC = row.KodTERC,
                    KodTERCGUS = row.KodTERCGUS,
                    KodTERCwojGUS = row.KodTERCwojGUS,
                    Wojewodztwo = row.Wojewodztwo,
                    KodTERCpowGUS = row.KodTERCpowGUS,
                    Powiat = row.Powiat,
                    KodTERCgmi = row.KodTERCgmi,
                    KodTERCgmiRodz = row.KodTERCgmiRodz,
                    Gmina = row.Gmina,
                    KodTERCgmiGUS = row.KodTERCgmiGUS,
                    KodTERCgmiRodzGUS = row.KodTERCgmiRodzGUS,
                    GminaGUS = row.GminaGUS,
                    KodSIMC = row.KodSIMC,
                    KodSIMCPodstawowa = row.KodSIMCPodstawowa,
                    RodzajMiejscowosci = row.RodzajMiejscowosci,
                    Miejscowosc = row.Miejscowosc,
                    KodSIMCGUS = row.KodSIMCGUS,
                    KodSIMCPodstawowaGUS = row.KodSIMCPodstawowaGUS,
                    RodzajMiejscowosciGUS = row.RodzajMiejscowosciGUS,
                    MiejscowoscGUS = row.MiejscowoscGUS,
                    KodULICGUS = row.KodULICGUS,
                    UlicaCecha = row.UlicaCecha,
                    UlicaNazwa = row.UlicaNazwa,
                    NumeracjaNieparzystaOd = row.NumeracjaNieparzystaOd,
                    NumeracjaNieparzystaDo = row.NumeracjaNieparzystaDo,
                    NumeracjaParzystaOd = row.NumeracjaParzystaOd,
                    NumeracjaParzystaDo = row.NumeracjaParzystaDo,
                    KodPocztowyPNA = row.KodPocztowyPNA,
                    Zniesione = row.Zniesione
                };
                kod.Save();
                if (lk % 1000 == 0)
                {
                    unitOfWork.CommitChanges();
                    unitOfWork = new UnitOfWork(_session.DataLayer);
                }
            }
            unitOfWork.CommitChanges();

            Console.WriteLine("Conversion complete.");
            Console.ReadLine();
        }
    }
}