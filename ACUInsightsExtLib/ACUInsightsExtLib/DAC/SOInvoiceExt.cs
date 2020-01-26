using PX.Data;
using PX.Objects.SO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUInsights
{
    public class SOInvoiceExt : PXCacheExtension<SOInvoice>
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
