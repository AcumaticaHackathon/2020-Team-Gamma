using PX.Data;
using PX.Objects.SO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUInsights
{
    public class SOOrderEntryExt : PXGraphExtension<SOOrderEntry>
    {
        protected virtual void SOOrder_RowUpdated(PXCache sender, PXRowUpdatedEventArgs e)
        {
            var row = (SOOrder)e.Row;
            if (row == null) return;
            SOOrderExt row1 = PXCache<SOOrder>.GetExtension<ACUInsights.SOOrderExt>(row);

            if (row.OrderNbr == " <NEW>")
                row1.UsrInserted = "I";
            else
                row1.UsrInserted = "U";
        }
    }
}
