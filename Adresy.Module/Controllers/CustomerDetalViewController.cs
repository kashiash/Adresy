using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adresy.Module.BusinessObjects;
using DevExpress.ExpressApp;

namespace Adresy.Module.Controllers
{
    public class CustomerDetalViewController: ViewController<DetailView>
    {

        public CustomerDetalViewController()
        {
            TargetObjectType = typeof(Customer);
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
            View.ObjectSpace.Committing -= ObjectSpace_Committing;
            View.ObjectSpace.Committing += ObjectSpace_Committing;

        }


        private void ObjectSpace_Committing(object sender, CancelEventArgs e)
        {

            var currentObject = View.CurrentObject as Customer;

            if (currentObject != null)
            {
                if (currentObject.MainAddress.IsValidToSave() == false)
                {
                    ObjectSpace.RemoveFromModifiedObjects(currentObject.MainAddress);
                    currentObject.MainAddress = null;
                }

                if (currentObject.MailingAddress.IsValidToSave() == false)
                {
                    ObjectSpace.RemoveFromModifiedObjects(currentObject.MailingAddress);
                    currentObject.MailingAddress = null;
                }
            }

        }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
            var currentObject = View.CurrentObject as Customer;
            if (currentObject != null)
            {
                var mainAddress = currentObject.MainAddress;
                var mailingAddress = currentObject.MailingAddress;
                if (mainAddress == null)
                {
                    mainAddress = ObjectSpace.CreateObject<Address>();
                    mainAddress.Customer = currentObject;
                    currentObject.MainAddress = mainAddress;
                }
                if (mailingAddress == null)
                {
                    mailingAddress = ObjectSpace.CreateObject<Address>();
                    currentObject.MailingAddress = mailingAddress;
                    mailingAddress.Customer = currentObject;
                }
            }

        }
        protected override void OnDeactivated()
        {
            View.ObjectSpace.Committing -= ObjectSpace_Committing;
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
