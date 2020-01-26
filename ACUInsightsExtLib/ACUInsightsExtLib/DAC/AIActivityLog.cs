using System;
using ACUInsightsExtLib.Constants;
using PX.Data;

namespace ACUInsights
{
    [Serializable]
    [PXCacheName(AIMessages.INSIGHT_ACTIVITY_LOG)]
    public class AIActivityLog : IBqlTable
    {
        #region LogID
        [PXDBLongIdentity(IsKey = true)]
        public virtual long? Logid { get; set; }
        public abstract class logid : PX.Data.BQL.BqlLong.Field<logid> { }
        #endregion
        #region UserID
        [PXDBGuid()]
        public virtual Guid? UserID { get; set; }
        public abstract class userID : PX.Data.BQL.BqlGuid.Field<userID> { }
        #endregion
        #region ScreenID
        [PXDBString(8, IsFixed = true, InputMask = "")]
        public virtual string ScreenID { get; set; }
        public abstract class screenID : PX.Data.BQL.BqlString.Field<screenID> { }
        #endregion
        #region ActiveTime
        [PXDBInt()]
        [PXUIField(DisplayName = "Active Time")]
        public virtual int? ActiveTime { get; set; }
        public abstract class activeTime : PX.Data.BQL.BqlInt.Field<activeTime> { }
        #endregion
        #region IdleTime
        [PXDBInt()]
        [PXUIField(DisplayName = "Idle Time")]
        public virtual int? IdleTime { get; set; }
        public abstract class idleTime : PX.Data.BQL.BqlInt.Field<idleTime> { }
        #endregion
        #region DocType
        [PXDBString(10)]
        [PXUIField(DisplayName = "Doc Type")]
        public virtual string DocType { get; set; }
        public abstract class docType : PX.Data.BQL.BqlString.Field<docType> { }
        #endregion
        #region RefNbr
        [PXDBString(50)]
        [PXUIField(DisplayName = "Ref Nbr")]
        public virtual string RefNbr { get; set; }
        public abstract class refNbr : PX.Data.BQL.BqlString.Field<refNbr> { }
        #endregion
        #region Action
        [PXDBString(1, IsFixed = true)]
        [PXUIField(DisplayName = "Action")]
        public virtual string Action { get; set; }
        public abstract class action : PX.Data.BQL.BqlString.Field<refNbr> { }
        #endregion
        #region LastEditDateTime
        [PXDBDate()]
        [PXUIField(DisplayName = "Last Edit Date")]
        public virtual DateTime? LastEditDateTime { get; set; }
        public abstract class lastEditDateTime : PX.Data.BQL.BqlDateTime.Field<lastEditDateTime> { }
        #endregion
    }
}