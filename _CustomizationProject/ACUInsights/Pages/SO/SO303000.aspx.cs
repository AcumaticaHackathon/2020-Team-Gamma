using System;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using PX.Web.UI;

public partial class Page_SO303000 : PX.Web.UI.PXPage
{
	protected void Page_Init(object sender, EventArgs e)
	{
	}

	public string UserID
	{
		get { return PXPage.GetDefaultDataSource(this.Page).DataGraph.Accessinfo.UserID.ToString(); }
	}
}
