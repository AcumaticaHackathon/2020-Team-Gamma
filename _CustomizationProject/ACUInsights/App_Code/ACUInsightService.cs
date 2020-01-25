﻿using ACUInsights;
using PX.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for ACUInsightService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class ACUInsightService : System.Web.Services.WebService
{

    public ACUInsightService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public bool AddLog(int activeTime, int idleTime, string screenId, string userId)
    {
        PXDatabase.Insert<AIActivityLog>(new PXDataFieldAssign<AIActivityLog.activeTime>(activeTime),
            new PXDataFieldAssign<AIActivityLog.idleTime>(idleTime),
            new PXDataFieldAssign<AIActivityLog.screenID>(screenId),
            new PXDataFieldAssign<AIActivityLog.userID>(userId));

        return true;
    }

}
