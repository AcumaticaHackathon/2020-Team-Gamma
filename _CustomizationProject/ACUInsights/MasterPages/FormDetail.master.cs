using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PX.Web.UI;
using PX.Web.Controls;
using PX.Common;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

public partial class MasterPages_FormDetail : PX.Web.UI.BaseMasterPage, IPXMasterPage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!PX.Translation.ResourceCollectingManager.IsStringCollecting &&
			Request.AppRelativeCurrentExecutionFilePath != null &&
			!Request.AppRelativeCurrentExecutionFilePath.StartsWith("~/rest"))
		{
			Response.TryAddHeader("cache-control", "no-store, private");
		}
	}

	// We'll need this code in case we use ASP.NET standard localization
	protected void Page_Init(object sender, EventArgs e)
	{
		base.InsertDocumentsFrame(this.form1);

		Page.Header.Controls.Add(new System.Web.UI.LiteralControl(
			"<script type='text/javascript' src=\"" + ResolveUrl("~/Scripts/jquery-3.1.1.min.js") + "\"></script>"));

		if (!Page.IsPostBack)
		{
			var ds = PXPage.GetDefaultDataSource(this.Page);
			if (ds != null)
			{
				ds.ClientEvents.CommandPerformed = "commandResult";
			}
		}
	}

	protected void Page_Unload(object sender, EventArgs e)
	{
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

	public string GetRefNbrFieldValue()
	{
		PXDataSource ds = PXPage.GetDefaultDataSource(this.Page);
		object refNbrField = string.Empty;

		if (ds != null)
		{
			List<PropertyInfo> keyFields = GetPrimaryViewKeyFields(ds);

			if (keyFields.Any())
			{
				List<PropertyInfo> refNbrFields = keyFields.
					Where(f => f.Name.Contains("RefNbr", StringComparison.OrdinalIgnoreCase) ||
						f.Name.Contains("OrderNbr", StringComparison.OrdinalIgnoreCase)).ToList();

				if (refNbrFields.Any() && ds.DataGraph.Views[ds.DataGraph.PrimaryView].Cache.Current != null)
				{
					refNbrField = refNbrFields.First().GetValue(
						ds.DataGraph.Views[ds.DataGraph.PrimaryView].Cache.Current);
				}
			}
		}
		return refNbrField == null ? string.Empty : refNbrField.ToString();
	}

	public string GetDocTypeFieldValue()
	{
		PXDataSource ds = PXPage.GetDefaultDataSource(this.Page);
		string docTypeField = string.Empty;

		if (ds != null)
		{
			List<PropertyInfo> keyFields = GetPrimaryViewKeyFields(ds);

			if (keyFields.Any())
			{
				List<PropertyInfo> docTypeFields = keyFields.
					Where(f => f.Name.Contains("DocType", StringComparison.OrdinalIgnoreCase) ||
						f.Name.Contains("OrderType", StringComparison.OrdinalIgnoreCase)).ToList();

				if (docTypeFields.Any())
					docTypeField = docTypeFields.First().Name;
			}
		}

		return docTypeField;
	}

	public string GetRefNbrField()
	{
		PXDataSource ds = PXPage.GetDefaultDataSource(this.Page);
		string refNbrField = string.Empty;

		if (ds != null)
		{
			List<PropertyInfo> keyFields = GetPrimaryViewKeyFields(ds);

			if (keyFields.Any())
			{
				IEnumerable<PropertyInfo> docTypeFields = keyFields.
					Where(f => f.Name.Contains("RefNbr", StringComparison.OrdinalIgnoreCase) ||
						f.Name.Contains("OrderNbr", StringComparison.OrdinalIgnoreCase));

				if (docTypeFields.Any())
					refNbrField = docTypeFields.First().Name;
			}
		}
		return refNbrField;
	}

	#region Public properties
	public string DocTypeField
	{
		get { return GetDocTypeField(); }
	}

	public string RefNbrFieldValue
	{
		get { return GetRefNbrFieldValue(); }
	}

	public string RefNbrField
	{
		get { return GetRefNbrField(); }
	}

	public string UserID
	{
		get { return PXPage.GetDefaultDataSource(this.Page).DataGraph.Accessinfo.UserID.ToString(); }
	}

	public string FormattedScreenID
	{
		get { return ScreenID.Replace(".", ""); }
	}

	/// <summary>
	/// Gets or sets the screen title string.
	/// </summary>
	public string ScreenTitle
	{
		get { return this.usrCaption.ScreenTitle; }
		set { this.usrCaption.ScreenTitle = value; }
	}

	/// <summary>
	/// Gets or sets the screen ID text.
	/// </summary>
	public string ScreenID
	{
		get { return this.usrCaption.ScreenID; }
		set { this.usrCaption.ScreenID = value; }
	}

	/// <summary>
	/// Gets or sets the screen image url.
	/// </summary>
	public string ScreenImage
	{
		get { return this.usrCaption.ScreenImage; }
		set { this.usrCaption.ScreenImage = value; }
	}
	
	/// <summary>
	/// Gets or sets the customization availability.
	/// </summary>
	public bool CustomizationAvailable
	{
		get { return this.usrCaption.CustomizationAvailable; }
		set { this.usrCaption.CustomizationAvailable = value; }
	}

	/// <summary>
	/// Gets or sets the help menu availability.
	/// </summary>
	public bool HelpAvailable
	{
		get { return this.usrCaption.HelpAvailable; }
		set { this.usrCaption.HelpAvailable = value; }
	}

	/// <summary>
	/// Gets or sets the favorite maintenance availability
	/// </summary>
	public bool FavoriteAvailable
	{
		get { return this.usrCaption.FavoriteAvailable; }
		set { this.usrCaption.FavoriteAvailable = value; }
	}

	/// <summary>
	/// Gets or sets branch visibility in title.
	/// </summary>
	public bool BranchAvailable
	{
		get { return true; }
		set { }
	}

	/// <summary>
	/// Gets or sets the web services availability.
	/// </summary>
	public bool WebServicesAvailable
	{
		get { return this.usrCaption.WebServicesAvailable; }
		set { this.usrCaption.WebServicesAvailable = value; }
	}

	/// <summary>
	/// Gets or sets the audit history availability.
	/// </summary>
	public bool AuditHistoryAvailable
	{
		get { return this.usrCaption.AuditHistoryAvailable; }
		set { this.usrCaption.AuditHistoryAvailable = value; }
	}

	public void AddTitleModule(ITitleModule module)
	{
		module.Initialize(this.usrCaption);
	}

    #endregion
}
