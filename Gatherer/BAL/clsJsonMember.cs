using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAL
{
    public class clsJsonMember
    {


        public class SearchClone : SessionFields
        {
            public string LeftPanel { get; set; }
            public string CenterPanel { get; set; }
            public string RightPanel { get; set; }
            public string txtFromDate { get; set; }
            public string txtToDate { get; set; }
            public string txtSearchKey { get; set; }
            public string txtKeyWord { get; set; }
        }

        [Serializable()]
        public class SearchParams
        {
            public string AllRecIds { get; set; }
            public string RecIds { get; set; }
            public string AttributeIds { get; set; }
            public string AttrTypeIds { get; set; }
            public string AttrDesc { get; set; }
            public string Portfolio { get; set; }
            public string Assetclass { get; set; }
            public string Asset { get; set; }
            public string Group { get; set; }
            public string Fund { get; set; }
            public string IO { get; set; }
            public string IC { get; set; }
            public string PortfolioRecIds { get; set; }
            public string AssetclassRecIds { get; set; }
            public string AssetRecIds { get; set; }
            public string GroupRecIds { get; set; }
            public string FundRecIds { get; set; }
            public string IORecIds { get; set; }
            public string ICRecIds { get; set; }
            public string RecType { get; set; }
            public string flg { get; set; }
            public string SessionId { get; set; }
        }

        public class SearchAttributes
        {
            public string Attributes { get; set; }

        }
        public class SessionFields
        {
            public string LoginId { get; set; }
            public string LoginName { get; set; }
            public string SessionId { get; set; }
        }

        public class InstructionContact
        {
            public long UserId { get; set; }
            public long RequestId { get; set; }
            public long TemplateID { get; set; }
            public long InstructionContactsID { get; set; }

            public string LastModifiedDt { get; set; }
            public string LinkTo { get; set; }
            public string TemplateName { get; set; }
            public string Company { get; set; }
            public string Group { get; set; }
            public string Co_Person { get; set; }
            public string Phone { get; set; }
            public string Fax { get; set; }
            public string Email { get; set; }

            public int CC { get; set; }

            public string CC_Company { get; set; }
            public string CC_Group { get; set; }
            public string CC_Co_Person { get; set; }
            public string CC_Phone { get; set; }
            public string CC_Fax { get; set; }
            public string CC_Email { get; set; }

            public DateTime LMDateSort { get; set; }

        }

        public class JsonLogin
        {
            public string LoginName { get; set; }
            public string LoginPwd { get; set; }
            public string ErrorMsg { get; set; }
        }

        public class JsonMenus
        {
            public string MenuName { get; set; }
            public Int32 MenuId { get; set; }
            public Int32 ParentId { get; set; }
            public string URL { get; set; }
            public Int32 ChildMenuCount { get; set; }
            public List<JsonMenus> ChildMenus { get; set; }
        }

        public class JsonPublicHolidays
        {
            public Int64 RID { get; set; }
            public string Description { get; set; }
            public string EventDate { get; set; }
            public Int32 Typ { get; set; }
            public string SelectedYear { get; set; }
            public string Result { get; set; }
            public Int32 PendingStatus { get; set; }
            public Int32 PendingUseriD { get; set; }
            public Int32 DS { get; set; }
        }

        public class JsonPublicHolidaysFinal
        {
            public List<JsonPublicHolidays> lstPublicHolidays { get; set; }
        }

        public class JsonAttributeType
        {
            public string AttributeName { get; set; }
            public Int32 AttributeId { get; set; }
            public List<CountryList> lstCountry { get; set; }
            public List<CurrencyList> lstCurrncy { get; set; }
            public List<PortfolioList> lstPortfolio { get; set; }
            public List<AvilableAttributeList> lstAvilableAttributeList { get; set; }
        }

        public class JsonSetting : SessionFields
        {
            public string Id { get; set; }
            public string ExportTo { get; set; }
            public string Location { get; set; }
            public string User { get; set; }
            public string Password { get; set; }
            public string ConfPassword { get; set; }
            public string SPV { get; set; }
            public string Name { get; set; }
            public List<DisplayDetail> lstDisplayDetail { get; set; }
            public string Portfolio { get; set; }
            public string GTICode { get; set; }
            public string HiportCode { get; set; }
            public string SecurityId { get; set; }
            public string GSTApplicable { get; set; }
            public string GSTPercentage { get; set; }
            public string RITC { get; set; }
            public List<DisplayOther> lstDisplayOther { get; set; }
            public string RequestStatus { get; set; }
            public string RequesterId { get; set; }
        }

        public class DisplayDetail
        {
            public string Id { get; set; }
            public string SPV { get; set; }
        }

        public class DisplayOther : SessionFields
        {
            public string Id { get; set; }
            public string GSTApplicable { get; set; }
            public string GSTPercentage { get; set; }
            public string RITC { get; set; }
        }

        public class JsonRecordManagement : SessionFields
        {
            public int DrData { get; set; }
            public int RDs { get; set; }
            public int DS { get; set; }
            public int TI { get; set; }
            public int SPV { get; set; }
            public int RecordStatus { get; set; }
            public int AttributeStatus { get; set; }
            public int UserId { get; set; }
            public int RecordType { get; set; }
            public int CounterParty { get; set; }
            public int SubRecordType { get; set; }
            public int ArrpovedStatus { get; set; }
            public int TransferEnabled { get; set; }
            public int Underlyingmanager { get; set; }

            public long Id { get; set; }
            public long RecordId { get; set; }
            public long RequestID { get; set; }

            public string AlertMessage { get; set; }
            public string RecordTypeName { get; set; }
            public string SubRecordTypeName { get; set; }
            public string Discription { get; set; }
            public string Comment { get; set; }
            public string Code { get; set; }
            public string SecurityID { get; set; }
            public string HiportCode { get; set; }
            public string GTICode { get; set; }
            public string FundCode { get; set; }
            public string TaxEntType { get; set; }
            public string SuperPartnersCode { get; set; }
            public string MiddleCode { get; set; }
            public string Movements { get; set; }
            public string SettlementMethod { get; set; }
            public string LDate { get; set; }
            public string RecordTypeKey { get; set; }
            public string SubRecordTypeKey { get; set; }
            public string Status { get; set; }
            public string Action { get; set; }
            public string JPMClosureDate { get; set; }
            public string CustodyFee { get; set; }
            public List<DisplayDetail> lstRecordManagement;
            public string SearchCol { get; set; }
            public DateTime LDateSort { get; set; }




            public string AccountName { get; set; }
            public string AccountNumber { get; set; }
            public string AustraclearCode { get; set; }
            public string SWIFTCode { get; set; }
            public string AdditionalBankDetails { get; set; }

            public string TempId { get; set; }
        }

        public class JsonCurrencyMapping
        {
            public int DS { get; set; }
            public int UserId { get; set; }
            public int Count { get; set; }

            public long CurrencyId { get; set; }
            public long Id { get; set; }
            public long RecordId { get; set; }
            public long RequestID { get; set; }
            public long TotalCount { get; set; }

            public string GTICode { get; set; }
            public string PortfolioName { get; set; }
            public string CurrencyCode { get; set; }
            public string AccountNumber { get; set; }
            public string CurrencyName { get; set; }
            public string FileName { get; set; }
            public string Status { get; set; }
            public string Action { get; set; }
            public string Ldate { get; set; }
            public List<JsonCurrencyMapping> lstCurrencyMapping { get; set; }
        }

        public class JsonLoginMaster
        {
            public long UserId { get; set; }
            public string LoginId { get; set; }
            public string Password { get; set; }
            public string EmailId { get; set; }
            public int Access { get; set; }
            public List<DisplayOther> lstUserDetails { get; set; }

        }

        public class JsonUpcomingRecentChanges
        {
            public string EffectiveDate { get; set; }
            public DateTime EffectiveDateSort { get; set; }
            public string SystemName { get; set; }
            public string Label { get; set; }
            public string Notify { get; set; }
            public string Reminder { get; set; }
            public string Type { get; set; }
            public Int32 id { get; set; }
            public Int32 SID { get; set; }
            public Int64 Count { get; set; }
            public Int64 CountAttr { get; set; }
            public Int64 CountRec { get; set; }
            public Int64 CountHier { get; set; }
            public Int64 CountOther { get; set; }
            public string Description { get; set; }
            public long RequestId { get; set; }
            public string RLoginId { get; set; }
            public string RdateTime { get; set; }
        }

        public class JsonRequstDashBoard
        {
            public string RequestDate { get; set; }
            public string RequesterIds { get; set; }
            public DateTime RequestDateSort { get; set; }
            public string Action { get; set; }
            public string Type { get; set; }
            public string RLoginId { get; set; }
            public string Description { get; set; }
            public long RequestId { get; set; }
            public long Id { get; set; }
            public long RequesterId { get; set; }
            public string Status { get; set; }
            public string DisplayData { get; set; }
            public int Masterstatus { get; set; }
            public int LMSstatus { get; set; }
            public int MERstatus { get; set; }
            public int TAXstatus { get; set; }
            public int CRSstatus { get; set; }
            public string Effectivedate { get; set; }
            public string Reminder { get; set; }
            public long RecordID { get; set; }
            public bool Approved { get; set; }
        }

        public class JsonRequstDetails
        {
            public string Col1OLD { get; set; }
            public string Col2OLD { get; set; }
            public string Col3OLD { get; set; }
            public string Col4OLD { get; set; }
            public string Col5OLD { get; set; }
            public string Col6OLD { get; set; }
            public string Col7OLD { get; set; }
            public string Col8OLD { get; set; }
            public string Col9OLD { get; set; }
            public string Col10OLD { get; set; }
            public string Col11OLD { get; set; }
            public string Col12OLD { get; set; }
            public string Col13OLD { get; set; }
            public string Col14OLD { get; set; }
            public string Col15OLD { get; set; }
            public string Col16OLD { get; set; }
            public string Col17OLD { get; set; }
            public string Col18OLD { get; set; }
            public string Col19OLD { get; set; }
            public string Col20OLD { get; set; }
            public string Col21OLD { get; set; }
            public string Col22OLD { get; set; }
            public string Col23OLD { get; set; }
            public string Col24OLD { get; set; }
            public string Col25OLD { get; set; }
            public string Col26OLD { get; set; }
            public string Col27OLD { get; set; }
            public string Col28OLD { get; set; }
            public string Col29OLD { get; set; }
            public string Col30OLD { get; set; }
            public string Col31OLD { get; set; }
            public string Col32OLD { get; set; }
            public string Col33OLD { get; set; }
            public string Col34OLD { get; set; }
            public string Col35OLD { get; set; }
            public string Col36OLD { get; set; }
            public string Col37OLD { get; set; }
            public string Col38OLD { get; set; }
            public string Col39OLD { get; set; }
            public string Col40OLD { get; set; }
            public string Col41OLD { get; set; }
            public string Col42OLD { get; set; }
            public string Col43OLD { get; set; }
            public string Col44OLD { get; set; }
            public string Col45OLD { get; set; }
            public string Col46OLD { get; set; }
            public string Col47OLD { get; set; }
            public string Col48OLD { get; set; }
            public string Col49OLD { get; set; }
            public string Col50OLD { get; set; }
            public string Col51OLD { get; set; }
            public string Col52OLD { get; set; }
            public List<OldGST> DS1 { get; set; }
            public List<NewGST> DS2 { get; set; }
            public List<TSRate> TSRateOld { get; set; }
            public List<TSRate2> TSRateNew { get; set; }
            public List<JsonDAA> DAAOld { get; set; }
            public List<ApprovedJsonDAA> DAANew { get; set; }
            public string UserBy { get; set; }
            public string Actiondate { get; set; }
            public string Action { get; set; }
            public string Display { get; set; }
            public string RequestId { get; set; }
            public string ReferenceNumber { get; set; }
        }

        public class OldGST
        {
            public string Id;
            public string Portfolio;
            public string GTICode;
            public string HiportCode;
            public string SecurityID;
            public string GSTApplicable;
            public string GSTPercentage;
            public string RITC;
            public string TagFlag;
        }

        public class NewGST
        {
            public string Id;
            public string Portfolio;
            public string GTICode;
            public string HiportCode;
            public string SecurityID;
            public string GSTApplicable;
            public string GSTPercentage;
            public string RITC;
            public string TagFlag;
        }

        public class Jsonhierarchy
        {
            public long MasterItemsId { get; set; }
            public int SPV { get; set; }
            public int DAA { get; set; }
            public int DS { get; set; }
            public int ViewId { get; set; }
            public int HLevel { get; set; }
            public int PDS { get; set; }
            public int ActionFlag { get; set; }

            public long UserId { get; set; }
            public long RecordRequestId { get; set; }
            public long NodeId { get; set; }
            public long Parentid { get; set; }
            public long RecordId { get; set; }
            public long RequestId { get; set; }
            public long M_IndexNo { get; set; }

            public string MasterItemsName { get; set; }
            public string Label { get; set; }
            public string Relation { get; set; }
            public string RecordType { get; set; }
            public string SubRecordType { get; set; }
            public string HiportCode { get; set; }
            public string GTICode { get; set; }
            public string SecurityID { get; set; }
            public string Level { get; set; }
            public string FundCode { get; set; }
            public string Status { get; set; }
            public string TagFlag { get; set; }
            public string TmpAttr { get; set; }
            public string RecordIds { get; set; }

            public string SystemName { get; set; }
            public string Rules { get; set; }
            public int Fund { get; set; }
            public int Option { get; set; }
            public int Sector { get; set; }
            public int Portfolio { get; set; }
            public int InternalMandates { get; set; }
            public int ExternalMandates { get; set; }
            public int Unclassifieds { get; set; }
            public int Assets { get; set; }
            public int Groups { get; set; }
            public int LMS { get; set; }
            public int MER { get; set; }
            public int CRS { get; set; }
            public int TPS { get; set; }

            public List<JsonExp> JsonExpVar { get; set; }
            public List<JsonRules> JsonRulesVar { get; set; }

        }
        public class JsonRules
        {
            public string Rules { get; set; }
            public string SystemName { get; set; }
        }
        public class JsonExp
        {
            public long ParentId { get; set; }
            public long HID { get; set; }
            public long RecordId { get; set; }
            public int ShowHide { get; set; }
            public string Label { get; set; }
            public string ParentLabel { get; set; }
            public string RecordType { get; set; }
            public string SubRecordType { get; set; }
            public string Value { get; set; }
            public string SystemName { get; set; }
            public string Relation { get; set; }
        }

        public class JsonDAA
        {

            public int DS { get; set; }
            public int PH { get; set; }
            public int DAA { get; set; }
            public int ViewId { get; set; }
            public int Level { get; set; }
            public int Leaf { get; set; }
            public int SAAMap { get; set; }
            public int TAAMap { get; set; }
            public int CFAMap { get; set; }
            public int ChildCount { get; set; }

            public long HID { get; set; }
            public long NodeId { get; set; }
            public long ParentId { get; set; }
            public long RecordId { get; set; }
            public long RequestId { get; set; }
            public long M_IndexNo { get; set; }
            public long SectorTo { get; set; }
            public long SectorFrm { get; set; }
            public long UserId { get; set; }
            public long MasterItemsId { get; set; }

            public long OptIdTo { get; set; }
            public long OptIdFrm { get; set; }

            public string Label { get; set; }
            public string Relation { get; set; }
            public string RecordType { get; set; }
            public string HiportCode { get; set; }

            public string SAA_T_Dlr { get; set; }
            public string TAA_T_Dlr { get; set; }

            public string TAA_T_P_Age { get; set; }
            public string SAA_T_P_Age { get; set; }

            public string SAADisplay { get; set; }
            public string TAADisplay { get; set; }
            public string CFADisplay { get; set; }
            public string WeightingTo { get; set; }
            public string WeightFrm { get; set; }
            public string SectorNameTo { get; set; }
            public string SectorNameFrm { get; set; }
            public string RelationTo { get; set; }

            #region Mapping JSON
            public long SourceOptionId { get; set; }
            public long DestinationOptionId { get; set; }
            public long DestinationParentId { get; set; }
            public string SourceNodeId { get; set; }
            public string DestinationNodeId { get; set; }
            public string SourceWeighting { get; set; }
            public string DestinationWeighting { get; set; }

            #endregion
        }

        public class ApprovedJsonDAA
        {

            public int DS { get; set; }
            public int PH { get; set; }
            public int DAA { get; set; }
            public int ViewId { get; set; }
            public int Level { get; set; }
            public int Leaf { get; set; }
            public int SAAMap { get; set; }
            public int TAAMap { get; set; }
            public int CFAMap { get; set; }

            public long HID { get; set; }
            public long NodeId { get; set; }
            public long ParentId { get; set; }
            public long RecordId { get; set; }
            public long RequestId { get; set; }
            public long M_IndexNo { get; set; }
            public long SectorTo { get; set; }
            public long SectorFrm { get; set; }
            public long UserId { get; set; }
            public long MasterItemsId { get; set; }

            public long OptIdTo { get; set; }
            public long OptIdFrm { get; set; }

            public string Label { get; set; }
            public string Relation { get; set; }
            public string RecordType { get; set; }

            public string SAA_T_Dlr { get; set; }
            public string TAA_T_Dlr { get; set; }

            public string TAA_T_P_Age { get; set; }
            public string SAA_T_P_Age { get; set; }

            public string SAADisplay { get; set; }
            public string TAADisplay { get; set; }
            public string CFADisplay { get; set; }
            public string WeightingTo { get; set; }
            public string WeightFrm { get; set; }
            public string SectorNameTo { get; set; }
            public string SectorNameFrm { get; set; }
            public string RelationTo { get; set; }

            #region Mapping JSON
            public long SourceOptionId { get; set; }
            public long DestinationOptionId { get; set; }
            public long DestinationParentId { get; set; }
            public string SourceNodeId { get; set; }
            public string DestinationNodeId { get; set; }
            public string SourceWeighting { get; set; }
            public string DestinationWeighting { get; set; }

            #endregion
        }

        public class JsonDCP
        {
            public Int64 Id { get; set; }
            public Int64 UserId { get; set; }
            public Int64 RequestId { get; set; }
            public Int64 PortfolioId { get; set; }
            public Int64 AssetsClassId { get; set; }

            public string GTICode { get; set; }
            public string AssetsClass { get; set; }
            public string PortfolioName { get; set; }
            public string Action { get; set; }
            public string Ldate { get; set; }

            public List<JsonDCP> lstDCP { get; set; }
        }

        public class JsonAttribute : SessionFields
        {
            public string LinkedTo { get; set; }
            public Int64 RecordId { get; set; }
            public Int64 AttributeRequestId { get; set; }
            public Int64 RecordIdMain { get; set; }
            public Int64 AID { get; set; }
           
            public Int32 PendingUseriD { get; set; }
            public Int32 PendingStatus { get; set; }
            public Int64 RequestID { get; set; }
            public Int64 RecordRequestId { get; set; }
            public Int32 AttributeType { get; set; }
            public Int32 DS { get; set; }
            public Int32 LMS { get; set; }
            public Int32 MER { get; set; }
            public Int32 TPS { get; set; }
            public Int32 CRS { get; set; }

            public string Discription { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Pin { get; set; }
            public string Country { get; set; }
            public string display { get; set; }
            public string Result { get; set; }
            public string Title { get; set; }
            public string Name { get; set; }
            public string Phone { get; set; }
            public string Mobile { get; set; }
            public string Fax { get; set; }
            public string Email { get; set; }
            public string Website { get; set; }
            public string Amount { get; set; }
            public Int64 CurrencyID { get; set; }
            public string Value { get; set; }
            public string AreaCode { get; set; }
            public string LocNumber { get; set; }
            public string Extension { get; set; }
            public string Portfolio { get; set; }
            public string sponsor_name { get; set; }
            public string Customer_Contact { get; set; }
            public string New_Fund { get; set; }
            public string Customer_Telephone { get; set; }
            public string custody_account { get; set; }
            public string USD_Balance { get; set; }
            public string RequestDate { get; set; }
            public string LiveDate { get; set; }
            public string GTIAcNo { get; set; }
            public string EstimatedStock { get; set; }
            public string FundAcount { get; set; }
            public string TrancationVol { get; set; }
            public string MoneyAcount { get; set; }
            public string TrancationRequerid { get; set; }
            public string BaseCurrency { get; set; }
            public string AccountingService { get; set; }
            public string AccountingBenchmarks { get; set; }
            public string BeneficialOwner { get; set; }
            public string SecuiritesLending { get; set; }
            public string OwnRegiAddress { get; set; }
            public string ProxyVoting { get; set; }
            public string InvestManagerName { get; set; }
            public string TaxReclaim { get; set; }
            public string InvestManagerAddress { get; set; }
            public string ComplianceReportingService { get; set; }
            public string InvestmentInstrction { get; set; }
            public string PerformanceControl { get; set; }
            public string BICSenderCOde { get; set; }
            public string TargetedLiveDate { get; set; }
            public string InstIncomIndivi { get; set; }
            public string Markets { get; set; }
            public string PortfolioReporting { get; set; }
            public string TrancIntimation { get; set; }
            public string CorprateActionOnline { get; set; }
            public string FileDelivery { get; set; }
            public string FSR { get; set; }
            public string Assetsize { get; set; }
            public string IIOther { get; set; }

            public string ShortName { get; set; }
            public string FYE { get; set; }
            public string FYE2 { get; set; }
            public string Reporting_Curr { get; set; }
            public string TaxResidency { get; set; }
            public string CostBasic { get; set; }
            public string ShortSelling { get; set; }
            public string TypeOfPortfolio { get; set; }
            public string ReportingGroup { get; set; }
            public string AssetClassLink { get; set; }
            public string GernalLedger { get; set; }
            public string GSTReportEntity { get; set; }
            public string GSTReportType { get; set; }
            public string GSTReportFreq { get; set; }
            public string GSTStatus { get; set; }
            public string ReverseCharge { get; set; }
            public string GSTMangeFees { get; set; }
            public string OtherExpSundryMang { get; set; }
            public string LcltoForegion { get; set; }
            public string ProDisposalCostDomestic { get; set; }
            public string ProDisposalCostInter { get; set; }
            public string TAxProReprt { get; set; }
            public string AFIAmort { get; set; }
            public string ADSAmort { get; set; }
            public string ACNAmort { get; set; }
            public string FixedInterest { get; set; }
            public string Equities { get; set; }
            public string Future { get; set; }
            public string Option { get; set; }
            public string TPIMFixedInterest { get; set; }
            public string Discount { get; set; }
            public string TPIMEquities { get; set; }
            public string TPIMFuture { get; set; }
            public string TPIMOption { get; set; }
            public string TPIMDiscount { get; set; }
            public string CGTWeitingFactor { get; set; }
            public string EntityType { get; set; }
            public string TRApplicableTaxRate { get; set; }
            public string CGTIndextation { get; set; }
            public string CGTDiscounting { get; set; }
            public string SuperAssetHeld { get; set; }
            public string OtherAssetHeld { get; set; }
            public string TaxClarFutureandOpt { get; set; }
            public string TreatMentOFFixedInterest { get; set; }
            public string ClassificationFFX { get; set; }
            public string BankAccountElection { get; set; }
            public string FundLevelRule { get; set; }
            public string TOFA { get; set; }
            public string Effectivedate { get; set; }
            public string TransitionExistingParcles { get; set; }

            public string ServiceReqJPM { get; set; }
            public string DailyCompliane { get; set; }
            public string LevelCompliance { get; set; }
            public string ReportingTimeline { get; set; }
            public string SpecStandInstru { get; set; }
            public string SIRequirment { get; set; }
            public string PerformingReport { get; set; }
            public List<TSRate> lstTSRate { get; set; }
            public string Action { get; set; }
            public string RecordTypeNew { get; set; }
        }

        public class CountryList
        {
            public Int64 Id { get; set; }
            public string Country { get; set; }
        }

        public class AvilableAttributeList
        {
            public Int64 Id { get; set; }
            public string Description { get; set; }
            public string Type { get; set; }
            public Int64 TypeId { get; set; }
            public Int32 Status { get; set; }
        }

        public class CurrencyList
        {
            public Int64 Id { get; set; }
            public string CCode { get; set; }
        }

        public class PortfolioList
        {
            public Int64 Id { get; set; }
            public string PortfolioName { get; set; }
        }

        public class TSRate
        {
            public string Description { get; set; }
            public string Ds { get; set; }
            public string Ldate { get; set; }
            public string Name { get; set; }
            public string From { get; set; }
            public string To { get; set; }
            public string Rate { get; set; }
            public string Type { get; set; }
            public string TypeName { get; set; }
            public string EffectiveDate { get; set; }
            public string LinkedTo { get; set; }
        }

        public class TSRate2
        {
            public string Description { get; set; }
            public string Ds { get; set; }
            public string Ldate { get; set; }
            public string Name { get; set; }
            public string From { get; set; }
            public string To { get; set; }
            public string Rate { get; set; }
            public string Type { get; set; }
            public string TypeName { get; set; }
            public string EffectiveDate { get; set; }
            public string LinkedTo { get; set; }
        }

        public class Reporting
        {
            public int Include { get; set; }
            public int Attribute { get; set; }
            public int Status { get; set; }
            public string Display { get; set; }
            public string ExportType { get; set; }
            public string Format { get; set; }
        }

        public class CasualJson : SessionFields
        {
            public string Id { get; set; }
            public string Type { get; set; }
            public string Name { get; set; }
            public string Value { get; set; }
            public string ReqId { get; set; }
            public string HReqId { get; set; }
            public string Comment { get; set; }
            public string TempId { get; set; }
            public string SearchKey { get; set; }
        }

        public class Jsonclsfitsissue
        {
            public string id { get; set; }
            public string SystemName { get; set; }
            public string Module { get; set; }
            public string Logdate { get; set; }
            // public string Loddate { get; set; }
            public string Logtime { get; set; }

            public string Environment { get; set; }
            public string Version { get; set; }
            public string MainMenu { get; set; }
            public string Type { get; set; }

            public string DisplayMenu { get; set; }
            public string IssueDescription { get; set; }
            public string Priority { get; set; }
            public string Attachment { get; set; }
            public string AttachFile { get; set; }
            public string AttachPath { get; set; }


            public string issue_type { get; set; }
            public string r_status { get; set; }
            public string d_name { get; set; }
            public string UID { get; set; }
            public string Link { get; set; }
            public string SID { get; set; }
            public string grps { get; set; }

            // public string issue_desc { get; set; }
            public string Notes { get; set; }
            public string issueno { get; set; }
            public string issuenostr { get; set; }
            public string software { get; set; }
            public string SystmName { get; set; }
            public string UserName { get; set; }
            public string LogFlag { get; set; }
            public string Flag { get; set; }
            public string SearchColumn { get; set; }

        }

        public class JsonclsFileAttachment
        {
            public string fileid { get; set; }
            public string filename { get; set; }
            public string filepath { get; set; }
            public virtual ICollection<FileDetail> FileDetails { get; set; }
        }

        public class FileDetail
        {
            public Guid Id { get; set; }
            public string FileName { get; set; }
            public string Extension { get; set; }
            public int SupportId { get; set; }
        }

        public class Search : SessionFields
        {
            public string Id { get; set; }
            public string QueryhName { get; set; }
            public string Portfolio { get; set; }
            public string AssetClass { get; set; }
            public string Asset { get; set; }
            public string Group { get; set; }
            public string Fund { get; set; }
            public string InvestmentOption { get; set; }

            //More Options
            public string FDateCH { get; set; }
            public string TDateCH { get; set; }
            public string IncChangeHistory { get; set; }
            public string IncPending { get; set; }

            public string SearchString { get; set; }
            public string CurrMapping { get; set; }
            public string DCP { get; set; }
            public string GST { get; set; }
            public string IContact { get; set; }

            //Attribute Types
            public string Address { get; set; }
            public string Contactdetails { get; set; }
            public string Currency { get; set; }
            public string CustodyDetails { get; set; }
            public string Date { get; set; }
            public string Email { get; set; }
            public string Flatpercentage { get; set; }
            public string Freeformtext { get; set; }
            public string MiddleOfficeDetails { get; set; }
            public string Name { get; set; }
            public string Number { get; set; }
            public string Scaledrate { get; set; }
            public string TaxAccountingsetupdetails { get; set; }
            public string Telephone { get; set; }
            public string Tieredrate { get; set; }
            public string Website { get; set; }
            public string YesNo { get; set; }
            //Search By Attribute
            public string SearchByAttr { get; set; }
            public string FlagDS { get; set; }

        }

        public class SearchState
        {
            public string KeyWord { get; set; }
            public string Options { get; set; }
            public string Dates { get; set; }
            public string SavedQueries { get; set; }
            public string SearchResult { get; set; }
            public string Attributes { get; set; }
            public string SessionId { get; set; }
        }


        public class ActivityLog
        {
           
        }
    }
}
