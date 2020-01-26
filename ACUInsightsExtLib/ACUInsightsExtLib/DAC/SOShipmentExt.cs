using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PX.Data;
using PX.Objects.SO;

namespace ACUInsights
{
    public class SOShipmentExt : PXCacheExtension<SOShipment>
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
