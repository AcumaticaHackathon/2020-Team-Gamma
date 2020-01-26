using PX.Data;
using PX.Objects.SO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUInsights
{
    public class SOInvoiceEntryExt : PXGraphExtension<SOInvoiceEntry>
    {
        protected virtual void SOInvoice_RowUpdated(PXCache sender, PXRowUpdatedEventArgs e)
        {
            var row = (SOInvoice)e.Row;
            if (row == null) return;
            SOInvoiceExt row1 = PXCache<SOInvoice>.GetExtension<ACUInsights.SOInvoiceExt>(row);

            if (row.RefNbr == " <NEW>")
                row1.UsrInserted = "I";
            else
                row1.UsrInserted = "U";
        }
    }
}
