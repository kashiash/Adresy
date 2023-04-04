using System.ComponentModel;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.Model.DomainLogics;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Xpo;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.Persistent.Validation;
using System.Drawing;

namespace Adresy.Module;

// For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ModuleBase.
public sealed class AdresyModule : ModuleBase {
    public AdresyModule() {
		// 
		// AdresyModule
		// 
		AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.ModelDifference));
		AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.ModelDifferenceAspect));
        AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.BaseObject));
        AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.AuditDataItemPersistent));
        AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.AuditedObjectWeakReference));
        AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.FileData));
        AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.FileAttachmentBase));
        AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.Event));
        AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.Resource));
        AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.HCategory));
		RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.SystemModule.SystemModule));
		RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Security.SecurityModule));
		RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.AuditTrail.AuditTrailModule));
		RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule));
		RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.CloneObject.CloneObjectModule));
		RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule));
		RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Dashboards.DashboardsModule));
		RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Office.OfficeModule));
		RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.ReportsV2.ReportsModuleV2));
		RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Scheduler.SchedulerModuleBase));
		RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.StateMachine.StateMachineModule));
		RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.TreeListEditors.TreeListEditorsModuleBase));
		RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Validation.ValidationModule));
		RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.ViewVariantsModule.ViewVariantsModule));
    }
    public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB) {
        ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDB);
        return new ModuleUpdater[] { updater };
    }
    public override void Setup(XafApplication application) {
        base.Setup(application);
        // Manage various aspects of the application UI and behavior at the module level.
    }
    public override void CustomizeTypesInfo(ITypesInfo typesInfo) {
        base.CustomizeTypesInfo(typesInfo);

        //ukrywanie wszystkich oid
        if (typesInfo.FindTypeInfo(typeof(XPObject)) is TypeInfo xpObjectTypeInfo)
        {
            var oidMemberInfo = xpObjectTypeInfo.FindMember(nameof(XPObject.Oid));
            oidMemberInfo.AddAttribute(new VisibleInDetailViewAttribute(false));
            oidMemberInfo.AddAttribute(new VisibleInListViewAttribute(false));
            oidMemberInfo.AddAttribute(new VisibleInLookupListViewAttribute(false));
            oidMemberInfo.Refresh();
        }

        Color backColor = Color.FromArgb(255, 205, 230, 247);
        Color fontColor = Color.FromArgb(255, 72, 70, 68);
        TypeConverter converter = TypeDescriptor.GetConverter(backColor);
        string backColorAsString = converter.ConvertToString(backColor);
        string fontColorAsString = converter.ConvertToString(fontColor);

        foreach (var typeInfo in XafTypesInfo.Instance.PersistentTypes)
        {
            AddHighlightAttribute(backColorAsString, fontColorAsString, typeInfo);
        }
    }

    private static void AddHighlightAttribute(string backColorAsString, string fontColorAsString, ITypeInfo typeInfo)
    {
        foreach (IMemberInfo memberInfo in typeInfo.Members)
        {
            var ruleRequiredFieldAttributes = memberInfo.FindAttributes<RuleBaseAttribute>();
            var apperanceFieldAttributes = memberInfo.FindAttributes<AppearanceAttribute>();
            if (ruleRequiredFieldAttributes.Any() && !apperanceFieldAttributes.Any(x => x.Id.StartsWith("HighlightColors")))
            {
                var appearanceAttribute = new AppearanceAttribute($"HighlightColors{memberInfo.Name}")
                {
                    Context = nameof(DetailView),
                    BackColor = backColorAsString,
                    FontColor = fontColorAsString
                };
                memberInfo.AddAttribute(appearanceAttribute);
            }
        }
    }
}
