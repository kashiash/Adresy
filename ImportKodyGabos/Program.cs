using System;
using System.IO;
using System.Text;
using Adresy.Module.BusinessObjects;
using DevExpress.Xpo;
using ImportKodyGabos;

class Program
{
    static void Main(string[] args)
    {

        // Trzeba doinstalowac nugety:
        // Install-Package System.Text.Encoding.CodePages

        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        
        // Specify the input and output file paths.
        string inputFile  = "c:\\WymianaEurorent\\gabos.csv";
        string outputFile = "c:\\WymianaEurorent\\gabos_utf8.csv";

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

        List<CsvRow> rows = ReadCsv(outputFile);
      

        //Console.WriteLine("Conversion complete.");

      var  _session = new Session() { ConnectionString = "Integrated Security=SSPI;Pooling=false;Data Source=.;Initial Catalog=Adresy" };
      var  unitOfWork = new UnitOfWork(_session.DataLayer);

        int lk = 0;
        foreach (var row in rows)
        {
            lk++;
            Console.WriteLine($"{lk} {row.Miejscowosc} {row.KodPocztowyPNA} {row.Wojewodztwo}");
            var kod = new Kody(unitOfWork)
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

    }

    static List<CsvRow> ReadCsv(string filePath)
    {
        List<CsvRow> rows = new List<CsvRow>();

        using (StreamReader sr = new StreamReader(filePath))
        {
            string headerLine = sr.ReadLine(); // Read the header line and ignore it

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] columns = line.Split(',');

                CsvRow row = new CsvRow
                {
                    KodTERC = columns[0],
                    KodTERCGUS = columns[1],
                    KodTERCwojGUS = columns[2],
                    Wojewodztwo = columns[3],
                    KodTERCpowGUS = columns[4],
                    Powiat = columns[5],
                    KodTERCgmi = columns[6],
                    KodTERCgmiRodz = columns[7],
                    Gmina = columns[8],
                    KodTERCgmiGUS = columns[9],
                    KodTERCgmiRodzGUS = columns[10],
                    GminaGUS = columns[11],
                    KodSIMC = columns[12],
                    KodSIMCPodstawowa = columns[13],
                    RodzajMiejscowosci = columns[14],
                    Miejscowosc = columns[15],
                    KodSIMCGUS = columns[16],
                    KodSIMCPodstawowaGUS = columns[17],
                    RodzajMiejscowosciGUS = columns[18],
                    MiejscowoscGUS = columns[19],
                    KodULICGUS = columns[20],
                    UlicaCecha = columns[21],
                    UlicaNazwa = columns[22],
                    NumeracjaNieparzystaOd = columns[23],
                    NumeracjaNieparzystaDo = columns[24],
                    NumeracjaParzystaOd = columns[25],
                    NumeracjaParzystaDo = columns[26],
                    KodPocztowyPNA = columns[27],
                    Zniesione = columns[28]
                };
                rows.Add(row);
            }
        }

        return rows;
    }
}
