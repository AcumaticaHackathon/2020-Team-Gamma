using System;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using PX.Web.UI;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using PX.Common;

public partial class Page_SO301000 : PX.Web.UI.PXPage
{
	protected void Page_Init(object sender, EventArgs e)
	{
		Master.PopupWidth = 950;
		Master.PopupHeight = 600;

		// panel = (PXFormView)this.PanelAddSiteStatus.FindControl("formSitesStatus");
	}

	private List<PropertyInfo> GetPrimaryViewKeyFields(PXDataSource ds)
	{
		if (ds != null)
		{
			if (!string.IsNullOrEmpty(ds.DataGraph.PrimaryView))
			{
				Type primaryViewType = ds.DataGraph.Views[ds.DataGraph.PrimaryView].Cache.GetItemType();

				return primaryViewType.GetProperties().Where(p => p.CustomAttributes.Any(c =>
					c.NamedArguments.Any(n => n.MemberName.Equals("IsKey")))).ToList();
			}
		}

		return new List<PropertyInfo>();
	}

	public string GetDocTypeField()
	{
		PXDataSource ds = PXPage.GetDefaultDataSource(this.Page);
		string docTypeField = string.Empty;

		if (ds != null)
		{
			List<PropertyInfo> keyFields = GetPrimaryViewKeyFields(ds);

			if (keyFields.Any())
			{
				IEnumerable<PropertyInfo> docTypeFields = keyFields.
					Where(f => f.Name.Contains("DocType", StringComparison.OrdinalIgnoreCase) ||
						f.Name.Contains("OrderType", StringComparison.OrdinalIgnoreCase));

				if (docTypeFields.Any())
					docTypeField = docTypeFields.First().Name;
			}
		}

		return docTypeField;
	}

	public string DocTypeField
	{
		get { return GetDocTypeField(); }
	}

	public string UserID
	{
		get { return PXPage.GetDefaultDataSource(this.Page).DataGraph.Accessinfo.UserID.ToString(); }
	}
}
