namespace AutoSyncLogNonSports.Criteria;

public class InsertLogCriteria : NonQueryCommand
{
    public int SiteDBGroupId { get; set; }

    public DataTable SiteDBCalculationLog_3rd { get; set; }

    public override bool IsValid() => SiteDBGroupId > 0 && SiteDBCalculationLog_3rd.Rows.Count > 0;

    public override string GetSettingKey() => "NAP_SettlementService_CalculationLog_3rdIns";
}