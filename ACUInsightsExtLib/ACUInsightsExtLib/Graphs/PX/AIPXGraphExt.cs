using PX.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUInsights
{
    public class AIPXGraphExt : PXGraphExtension<PXGraph>
    {
        #region Views and Actions
        public PXSelect<AIActivityLog> AILog;
        #endregion

        #region ctor
        public override void Initialize()
        {
            base.Initialize();

            if (!string.IsNullOrEmpty(Base.PrimaryView))
            {
                Type primaryViewType = Base.Views[Base.PrimaryView].Cache.GetItemType();
                PXAction updateInsight = PXNamedAction.AddAction(Base, primaryViewType, 
                    "Update Insight", "Update Insight", UpdateInsight);
                updateInsight.SetEnabled(false);
                updateInsight.SetVisible(false);
            }
        }
        #endregion

        private IEnumerable UpdateInsight(PXAdapter adapter)
        {
            //if (AILog.Current == null)
            //{
            //    AILog.Current = new AIActivityLog() 
            //    {
            //        ScreenID = Base.Accessinfo.ScreenID.Replace(".", ""),
            //        UserID = Base.Accessinfo.UserID
            //    };
            //}

            return adapter.Get();
        }

        #region Overriden Methods
        #endregion
    }
}
