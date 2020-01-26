using PX.Data;
using PX.Objects.AR;
using PX.Objects.DR;
using PX.Objects.PM;
using PX.Objects.CR;

namespace ACUInsights
{
    public class ARInvoiceEntryExt : PXGraphExtension<ARInvoiceEntry>
    {
        protected virtual void ARInvoice_RowUpdated(PXCache sender, PXRowUpdatedEventArgs e)
        {
            var row = (ARInvoice)e.Row;
            if (row == null) return;
            ARInvoiceExt row1 = PXCache<ARInvoice>.GetExtension<ACUInsights.ARInvoiceExt>(row);

            if (row.RefNbr ==  " <NEW>")
                row1.UsrInserted = "In";
            else
                row1.UsrInserted = "Up";
        }
    }
}

