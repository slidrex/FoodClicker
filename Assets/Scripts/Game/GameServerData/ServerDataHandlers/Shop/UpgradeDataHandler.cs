using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Food Clicker/ID Data Handler/Shop/Upgrade data handler")]
public sealed class UpgradeDataHandler : ServerIDDataHandler<UpgradeFeedDataHandler>
{
    public void ConfigureDatabase()
    {
        var templates = RequestsCompositeRoot.Instance.ShopRequestController.GetUpgradeTemplates();
        int i = 0;

        foreach(var handler in Handlers)
        {
            handler.Configure(templates[i]);
            i++;
        }

    }
    public static UpgradeFeedData[] ModelToData(UpgradeDataModel[] ownedModels)
    {
        var allModels = DatabaseCompositeRoot.Instance.ServerHandlerDatabase.UpgradeDataHandler.GetDatabaseTemplates();
        var data = new UpgradeFeedData[allModels.Length];

        for(int i = 0; i < allModels.Length; i++)
        {
            var curTemplate = allModels[i];
            string description = curTemplate.BaseGpc == 0 ? $"+ {curTemplate.BaseGps} GPS" : $"+ {curTemplate.BaseGpc} GPC";
            var item = ownedModels.Where(x => x.Uid == curTemplate.Uid).FirstOrDefault();
            if (item != null)
            {
                data[i] = new UpgradeFeedData(curTemplate.Name, curTemplate.Sprite, description, item.Level, item.NextLevelPrice, item.Uid);
            }
            else data[i] = new UpgradeFeedData(curTemplate.Name, curTemplate.Sprite, description, -1, curTemplate.BasePrice, curTemplate.Uid);
            
        }
        return data;
    }
    public static UpgradeFeedData ModelToData(UpgradeDataModel ownedModel)
    {
        var template = DatabaseCompositeRoot.Instance.ServerHandlerDatabase.UpgradeDataHandler.GetDatabaseTemplates().Where(x => x.Uid == ownedModel.Uid).First();
        string description = template.BaseGpc == 0 ? $"+ {template.BaseGps} GPS" : $"+ {template.BaseGpc} GPC";
        

        return new UpgradeFeedData(template.Name, template.Sprite, description, ownedModel.Level, ownedModel.NextLevelPrice, template.Uid);
    }
    public UpgradeFeedDataHandler[] GetDatabaseTemplates()
    {
        return Handlers;
    }
}
