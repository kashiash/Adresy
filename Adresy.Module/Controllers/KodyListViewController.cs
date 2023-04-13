using Adresy.Module.BusinessObjects;
using DevExpress.Data.ODataLinq.Helpers;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adresy.Module.Controllers
{
    public class KodyListViewController : ViewController<ListView>
    {
        SimpleAction dopiszGminyAction;
        SimpleAction dopiszPowiatyAction;
        SimpleAction dopiszWojewodztwaAction;
        public KodyListViewController() : base()
        {
            // Target required Views (use the TargetXXX properties) and create their Actions.
            TargetObjectType = typeof(Kody);


            dopiszWojewodztwaAction = new SimpleAction(this, $"{GetType().FullName}{nameof(dopiszWojewodztwaAction)}", PredefinedCategory.Unspecified);
            dopiszWojewodztwaAction.Execute += dopiszWojewodztwaAction_Execute;

            dopiszPowiatyAction = new SimpleAction(this, $"{GetType().FullName}{nameof(dopiszPowiatyAction)}", PredefinedCategory.Unspecified);
            dopiszPowiatyAction.Execute += dopiszPowiatyAction_Execute;


            dopiszGminyAction = new SimpleAction(this, $"{GetType().FullName}{nameof(dopiszGminyAction)}",PredefinedCategory.Unspecified);
            dopiszGminyAction.Execute += dopiszGminyAction_Execute;
            

        }
        private void dopiszGminyAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var kody = ObjectSpace.GetObjectsQuery<Kody>().GroupBy(k => new { k.Gmina,k.GminaGUS,k.KodTERCgmi,k.KodTERCgmiRodz, k.Powiat});

            foreach (var item in kody)
            {
                var gmina = ObjectSpace.GetObjectsQuery<Gmina>(true).Where(w => w.NazwaGminy == item.Key.Gmina && w.Powiat.NazwaPowiatu == item.Key.Powiat).FirstOrDefault();
                if (gmina == null)
                {
                    var powiat = ObjectSpace.GetObjectsQuery<Powiat>(true).Where(w => w.NazwaPowiatu == item.Key.Powiat).FirstOrDefault();

                    gmina = ObjectSpace.CreateObject<Gmina>();
                    gmina.NazwaGminy = item.Key.Gmina;
                    gmina.KodTerc = item.Key.KodTERCgmi;
                    gmina.KodRodz= item.Key.KodTERCgmiRodz;
                    gmina.Powiat = powiat;
                    gmina.Save();
                }
            }
            ObjectSpace.CommitChanges();
        }
        private void dopiszPowiatyAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var kody = ObjectSpace.GetObjectsQuery<Kody>().GroupBy(k => new { k.KodTERCpowGUS, k.Powiat,k.Wojewodztwo });

            foreach (var item in kody)
            {
                var powiat = ObjectSpace.GetObjectsQuery<Powiat>(true).Where(w => w.NazwaPowiatu == item.Key.Powiat && w.Wojewodztwo.NazwaWojewodztwa == item.Key.Wojewodztwo).FirstOrDefault();
                if (powiat == null)
                {
                    Wojewodztwo woj = ObjectSpace.GetObjectsQuery<Wojewodztwo>(true).Where(w => w.NazwaWojewodztwa == item.Key.Wojewodztwo).FirstOrDefault();

                    powiat = ObjectSpace.CreateObject<Powiat>();
                    powiat.NazwaPowiatu = item.Key.Powiat;
                    powiat.KodTerc = item.Key.KodTERCpowGUS;
                    powiat.Wojewodztwo = woj;
                    powiat.Save();
                }
            }
            ObjectSpace.CommitChanges();
        }
        private void dopiszWojewodztwaAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
           var kody = ObjectSpace.GetObjectsQuery<Kody>().GroupBy(k => new { k.KodTERCwojGUS, k.Wojewodztwo });

            foreach (var item in kody)
            {
                Wojewodztwo woj = ObjectSpace.GetObjectsQuery<Wojewodztwo>(true).Where(w => w.NazwaWojewodztwa == item.Key.Wojewodztwo).FirstOrDefault();
                if (woj == null)
                {
                    woj = ObjectSpace.CreateObject<Wojewodztwo>();
                    woj.NazwaWojewodztwa = item.Key.Wojewodztwo;
                    woj.KodTercGus = item.Key.KodTERCwojGUS;
                    woj.Save();
                }
            }
            ObjectSpace.CommitChanges();
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
    }

}
