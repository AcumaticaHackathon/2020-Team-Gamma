using System;
using PX.Data;
using PX.Objects.AR;


namespace ACUInsights
{
    public class ARInvoiceExt : PXCacheExtension<ARInvoice>
    {
        #region UsrInserted
        public abstract class usrInserted : IBqlField { }
        [PXDBString(2, IsUnicode = true)]
        public virtual string UsrInserted { get; set; }
        #endregion
    }

}



