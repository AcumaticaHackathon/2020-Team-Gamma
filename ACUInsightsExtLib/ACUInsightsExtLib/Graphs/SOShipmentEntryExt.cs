using PX.Data;
using PX.Objects.SO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUInsights
{
    public class SOShipmentEntryExt : PXGraphExtension<SOShipmentEntry>
    {
        protected virtual void SOShipment_RowUpdated(PXCache sender, PXRowUpdatedEventArgs e)
        {
            var row = (SOShipment)e.Row;
            if (row == null) return;
            SOShipmentExt row1 = PXCache<SOShipment>.GetExtension<ACUInsights.SOShipmentExt>(row);

            if (row.ShipmentNbr == " <NEW>")
                row1.UsrInserted = "I";
            else
                row1.UsrInserted = "U";
        }
    }
}
