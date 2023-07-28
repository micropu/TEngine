//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;



namespace GameConfig
{ 
public partial class Tables
{
    public item.TbItem TbItem {get; }
    public Battle.TbSkill TbSkill {get; }
    public Battle.TbBuff TbBuff {get; }
    public Battle.TbBuffAttr TbBuffAttr {get; }

    public Tables(System.Func<string, ByteBuf> loader)
    {
        var tables = new System.Collections.Generic.Dictionary<string, object>();
        TbItem = new item.TbItem(loader("item_tbitem")); 
        tables.Add("item.TbItem", TbItem);
        TbSkill = new Battle.TbSkill(loader("battle_tbskill")); 
        tables.Add("Battle.TbSkill", TbSkill);
        TbBuff = new Battle.TbBuff(loader("battle_tbbuff")); 
        tables.Add("Battle.TbBuff", TbBuff);
        TbBuffAttr = new Battle.TbBuffAttr(loader("battle_tbbuffattr")); 
        tables.Add("Battle.TbBuffAttr", TbBuffAttr);

        PostInit();
        TbItem.Resolve(tables); 
        TbSkill.Resolve(tables); 
        TbBuff.Resolve(tables); 
        TbBuffAttr.Resolve(tables); 
        PostResolve();
    }

    public void TranslateText(System.Func<string, string, string> translator)
    {
        TbItem.TranslateText(translator); 
        TbSkill.TranslateText(translator); 
        TbBuff.TranslateText(translator); 
        TbBuffAttr.TranslateText(translator); 
    }
    
    partial void PostInit();
    partial void PostResolve();
}

}