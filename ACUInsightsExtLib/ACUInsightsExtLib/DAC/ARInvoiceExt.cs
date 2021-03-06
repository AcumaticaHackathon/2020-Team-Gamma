﻿using System;
using PX.Data;
using PX.Objects.AR;


namespace ACUInsights
{
    public class ARInvoiceExt : PXCacheExtension<ARInvoice>
    {
        #region UsrInserted
        public abstract class usrInserted : IBqlField { }
        [PXDBString(1, IsUnicode = true)]
        [PXUnboundDefault("R")]
        [PXUIField(DisplayName = "")]
        public virtual string UsrInserted { get; set; }
        #endregion
    }

}



