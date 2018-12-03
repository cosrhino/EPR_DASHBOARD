using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Web.Services;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;



public partial class monitor : System.Web.UI.Page

{
   
//These are the singlerow objects   
   
   /* 
//Get latest ADT message
   [WebMethod]   

    public static string GetAdtDate()
    {
		OracleConnection oraConn;
		OracleCommand oraComm;
		OracleDataReader reader;
		string connectionString = ConfigurationManager.ConnectionStrings["live"].ConnectionString;
		oraConn = new OracleConnection(connectionString);
		oraComm = new OracleCommand(
"select " +
"nvl(to_char(max(admission_date),'DD-Mon-YYYY HH24:MI'),'No data') r " +
"from patient_adt " +
//"where cancelled_flag='N' "
"where cancelled_flag='N' " +
"and " +
"admission_date <= sysdate + .5/24 "
//"or " +
//"transfer_date between sysdate- .5/24 and sysdate) "
				
		, oraConn) ;
						
    try
	{
		oraConn.Open();
		reader = oraComm.ExecuteReader();
		oraComm.CommandTimeout = 40;
        reader.Read();
        string adtdate = reader["r"].ToString();
        return adtdate;
    }
	
	
		//catch (OracleException) 
		//{ 
		//   string adtdate = "didnt work";    
		//}
	finally
	{
		oraConn.Close();
	}  		
				
	}
*/	
	//get Last drug date
	 [WebMethod]   

    public static string GetDrugDate()
    {
		OracleConnection oraConn;
		OracleCommand oraComm;
		OracleDataReader reader;
		string connectionString = ConfigurationManager.ConnectionStrings["live"].ConnectionString;
		oraConn = new OracleConnection(connectionString);
		oraComm = new OracleCommand(
"select " +
"max(DRUG_DATE) r " +
"from epr.ext_patient_drug " +
"where drug_date < sysdate + 4/24 "
				
		, oraConn) ;
						
    try
	{
		oraConn.Open();
		reader = oraComm.ExecuteReader();
        reader.Read();
        string adtdate = reader["r"].ToString();
        return adtdate;
    }
	finally
	{
		oraConn.Close();
	}  		
				
	}
//get number of users logged in
	 [WebMethod]   

    public static string GetUsersLogged()
    {
		OracleConnection oraConn;
		OracleCommand oraComm;
		OracleDataReader reader;
		string connectionString = ConfigurationManager.ConnectionStrings["live"].ConnectionString;
		oraConn = new OracleConnection(connectionString);
		oraComm = new OracleCommand(
"SELECT count(distinct user_id) r " +
"FROM " +
"epr.application_logon_audit " +
"WHERE " +
"logon_date >= trunc(sysdate) +(6/24) "

				
		, oraConn) ;
						
    try
	{
		oraConn.Open();
		reader = oraComm.ExecuteReader();
        reader.Read();
        string adtdate = reader["r"].ToString();
        return adtdate;
    }
	finally
	{
		oraConn.Close();
	}  		
				
	}	
	//get any unsent to labeQuest requests
	 [WebMethod]   

    public static string GetSentDate()
    {
		OracleConnection oraConn;
		OracleCommand oraComm;
		OracleDataReader reader;
		string connectionString = ConfigurationManager.ConnectionStrings["live"].ConnectionString;
		oraConn = new OracleConnection(connectionString);
		oraComm = new OracleCommand(
"select count(*) r " +
"from err_request_item " +
"where status='R' " +
"and system_id='P' "
				
		, oraConn) ;
						
    try
	{
		oraConn.Open();
		reader = oraComm.ExecuteReader();
        reader.Read();
        string orderdate = reader["r"].ToString();
		if (string.IsNullOrEmpty(orderdate))
		{
		    orderdate="No outstanding requests";
		}
        return orderdate;
    }
	finally
	{
		oraConn.Close();
	}  		
				
	}
	
		//get Symphony cascard duplicates
	 [WebMethod]   

    public static string GetCasCard()
    {
		string cascard;
		OracleConnection oraConn;
		OracleCommand oraComm;
		OracleDataReader reader;
		string connectionString = ConfigurationManager.ConnectionStrings["live"].ConnectionString;
		oraConn = new OracleConnection(connectionString);
		oraComm = new OracleCommand(
"select	patient_no as SYMPHONY_CASCARD_DUPLICATE, " +
"count(patient_no) " +
"from EXTERNAL_DOCUMENT_LAST_CHECK " +
"group by PATIENT_NO " +
"having  count(patient_no) > 1 "
				
		, oraConn) ;
						
    try
	{
		oraConn.Open();
		reader = oraComm.ExecuteReader();
        reader.Read();
	if(reader.HasRows){
				cascard = "Duplicate CASCard";
			}
    else {cascard = "No duplicates";
	}
        return cascard;
    }
	finally
	{
		oraConn.Close();
	}  		
				
	}


	
		//Get safeguarding docs
	 [WebMethod]   

    public static string GetSafeguard()
    {
		string safeguard;
		OracleConnection oraConn;
		OracleCommand oraComm;
		OracleDataReader reader;
		string connectionString = ConfigurationManager.ConnectionStrings["live"].ConnectionString;
		oraConn = new OracleConnection(connectionString);
		oraComm = new OracleCommand(
"select	patient_no as SYMPHONY_CASCARD_DUPLICATE, " +
"count(patient_no) " +
"from EXTERNAL_DOCUMENT_LAST_CHECK " +
"group by PATIENT_NO " +
"having  count(patient_no) > 1 "
				
		, oraConn) ;
						
    try
	{
		oraConn.Open();
		reader = oraComm.ExecuteReader();
        reader.Read();
	if(reader.HasRows){
				safeguard = "Duplicate CASCard";
			}
    else {safeguard = "No duplicates";
	}
        return safeguard;
    }
	finally
	{
		oraConn.Close();
	}  		
				
	}	
//get oraccount for instance 1
   [WebMethod]   

    public static string getOra1()
    {
		string oracount;
		OracleConnection oraConn;
		OracleCommand oraComm;
		OracleDataReader reader;
		string connectionString = ConfigurationManager.ConnectionStrings["LIVEA"].ConnectionString;
		oraConn = new OracleConnection(connectionString);
		oraComm = new OracleCommand(
"SELECT count(*) AS r " + 
"FROM v$session "
				
		, oraConn) ;
						
    try
	{
		oraConn.Open();
		reader = oraComm.ExecuteReader();
        reader.Read();
	if(reader.HasRows){
			oracount = reader["r"].ToString();
			}
    else {
		oracount = "Cannot speak to instance";	
	}
        
        return oracount;
    }
	finally
	{
		oraConn.Close();
	}  		
				
	}
	
	
//get oraccount for instance 2
   [WebMethod]   

    public static string getOra2()
    {
		string oracount;
		OracleConnection oraConn;
		OracleCommand oraComm;
		OracleDataReader reader;
		string connectionString = ConfigurationManager.ConnectionStrings["LIVEB"].ConnectionString;
		oraConn = new OracleConnection(connectionString);
		oraComm = new OracleCommand(
"SELECT count(*) AS r " + 
"FROM v$session order by 1"
				
		, oraConn) ;
						
    try
	{
		oraConn.Open();
		reader = oraComm.ExecuteReader();
        reader.Read();
	if(reader.HasRows){
			oracount = reader["r"].ToString();
			}
    else {oracount = "Cannot speak to instance";	
	}
        
        return oracount;
    }
	finally
	{
		oraConn.Close();
	}  		
				
	}
	
	
//get up time of nodes
	[WebMethod]   

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
			rep_usage();
        }
    }

    private void BindGrid()
    {
        OracleConnection oraConn;
        OracleCommand oraComm;
        OracleDataReader reader;
        string connectionString = ConfigurationManager.ConnectionStrings["LIVE_MON"].ConnectionString;
        oraConn = new OracleConnection(connectionString);
        oraComm = new OracleCommand(
			"SELECT * FROM instances order by 1" 

		
		, oraConn);

        try
        {
            oraConn.Open();
            reader = oraComm.ExecuteReader();
			if(reader.HasRows){
				createReportTableHtml(reader);
			}
            reader.Close();
        }
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
		}
        finally
        {
            oraConn.Close();
        }
    }
	
	protected void createReportTableHtml(OracleDataReader reader){
		string html = "<table >";
		html += "<thead>";
		html += "<tr>";
			for(int i = 0; i < reader.FieldCount; i++){
				html += "<th class=databasecathead>" + Regex.Replace(reader.GetName(i),"_"," ") + "</th>";
			}
			html += "</tr>";
		html += "</thead>";
		html += "<tbody>";
		while(reader.Read()){
			html += "<tr>";
			for(int i = 0; i < reader.FieldCount; i++){
				html += "<td class=databasecat>" + reader.GetValue(i).ToString() + "</td>";
			}
			html += "</tr>";
		}
		html += "</tbody>";
		html += "</table>";
		orainstances.InnerHtml = html;
	}
    
	//file objects
	
	//Get the latest date of the radiology log
    [WebMethod]
    
    public static string GetAdtLogDate()
    {
		//@ is for verbatim string otherwise the \ is escaped
		//the path below must be on a share drive that the permissions for the app pool user are on
	string adtlogfile =@"\\rhmepri\Interfaces\CaMIS\HL7Server\@Logs\PMI.log";	
    string adtlogfilelastmodified = System.IO.File.GetLastWriteTime(adtlogfile).ToString();
        return adtlogfilelastmodified;
            
    }
    
	//Get the latest date of the Pathology log
    [WebMethod]
    
    public static string GetPathologyDate()
    {
		//@ is for verbatim string otherwise the \ is escaped
		//the path below must be on a share drive that the permissions for the app pool user are on
	string pathlogfile =@"\\rhmepri\Interfaces\Pathology\Results\@Logs\Trace.log";
    string pathologylastmodified = System.IO.File.GetLastWriteTime(pathlogfile).ToString();
        return pathologylastmodified;
            
    }
	
	//Get the latest date of the Pathology log
    [WebMethod]
    
    public static string GetRadiologyDate()
    {
		//@ is for verbatim string otherwise the \ is escaped
		//the path below must be on a share drive that the permissions for the app pool user are on
	string radlogfile =@"\\rhmepri\Interfaces\Radiology\@Logs\RadTrace.log";
    string radloglastmodified = System.IO.File.GetLastWriteTime(radlogfile).ToString();
        return radloglastmodified;
            
    }
     

	//Get the latest viewpoint message[WebMethod]
    [WebMethod]
	
    public static string GetViewpointDate()
    {
		//@ is for verbatim string otherwise the \ is escaped
		//the path below must be on a share drive that the permissions for the app pool user are on
	string vplogfile =@"\\rhmepri\Interfaces\ViewPoint\@Logs\Logfile.log";
    string vploglastmodified = System.IO.File.GetLastWriteTime(vplogfile).ToString();
        return vploglastmodified;
            
    } 
	
	//Get the latest eQuest order sent to Labcentre
    [WebMethod]
	
    public static string GeteQuestrequest()
    {
		//@ is for verbatim string otherwise the \ is escaped
		//the path below must be on a share drive that the permissions for the app pool user are on
	string orderlog =@"\\rhmepri\Interfaces\eQuest\Requesting\@Logs\Trace.log";
    string orderloglastmodified = System.IO.File.GetLastWriteTime(orderlog).ToString();
        return orderloglastmodified;
            
    } 

	//Get the latest IMPAC message sent out
    [WebMethod]
	
    public static string GetIMPACsend()
    {
		//@ is for verbatim string otherwise the \ is escaped
		//the path below must be on a share drive that the permissions for the app pool user are on
	string orderlog =@"\\rhmepri\Interfaces\Impac\XPLServer\@Logs\XPLMessages.log";
    string orderloglastmodified = System.IO.File.GetLastWriteTime(orderlog).ToString();
        return orderloglastmodified;
            
    } 
	
	//gt logged in user
	//This only works with the web config file set to windows authenitication
	
	[WebMethod]
	
	public static string GetUsername()
	{
		string username;
		username = HttpContext.Current.User.Identity.Name;
		username = Regex.Replace(username,".*\\\\(.*)", "$1",RegexOptions.None);

		return username;
	}


//return a table string
	[WebMethod]   

    public static string getImportdocs()
    {
		OracleConnection oraConn;
		OracleCommand oraComm;
		OracleDataReader reader;
		string html ;
		string connectionString = ConfigurationManager.ConnectionStrings["live"].ConnectionString;
		oraConn = new OracleConnection(connectionString);
		oraComm = new OracleCommand(
"select " + 
"TRUNC (RECIEVED_DATE) Received_date " +
",count(case when external_system_id='SUME' then 1 end) Somerset " +
",count(case when external_system_id='MEDI' then 1 end) Medisoft " +
"from EPR.PATIENT_IMPORTED_EDOCUMENT " +
"WHERE RECIEVED_DATE > TRUNC(SYSDATE-7) " +
"group by TRUNC (RECIEVED_DATE) " +
"order by 1 desc "
				
		, oraConn) ;
	try
    {
        oraConn.Open();
        reader = oraComm.ExecuteReader();
		if(reader.HasRows)
		{
			html = "<table class=GridViewStyle>";
			html += "<thead>";
			html += "<tr>";
			for(int i = 0; i < reader.FieldCount; i++)
			{
				html += "<th class=databasecathead >" + Regex.Replace(reader.GetName(i),"_"," ") + "</th>";
			}
			html += "</tr>";
			html += "</thead>";
			html += "<tbody>";
			while(reader.Read())
			{
				html += "<tr>";
				for(int i = 0; i < reader.FieldCount; i++)
				{
					html += "<td class=databasecat>" + Regex.Replace(reader.GetValue(i).ToString(),"00.00.00","") + "</td>";
				}
				html += "</tr>";
			}
			html += "</tbody>";
			html += "</table>";
			return html;
		}
		else 
		{
			string html2 = "No data found";
			return html2;
		}
        reader.Close();
	}
    finally
    {
        oraConn.Close();
    }
	}

//return a table string
	[WebMethod]   

    public static string getImportEDA()
    {
		OracleConnection oraConn;
		OracleCommand oraComm;
		OracleDataReader reader;
		string html ;
		string connectionString = ConfigurationManager.ConnectionStrings["live"].ConnectionString;
		oraConn = new OracleConnection(connectionString);
		oraComm = new OracleCommand(
"select " +
"trunc(date_creation) created_date  " +
",count(case when doc_type='MIU' then 1 end) Lymington  " +
",count(case when doc_type='EDA' then 1 end) UHS  " +
"from EPR.PATIENT_IMPORTED_EDOCUMENT  " +
"where DATE_CREATION > sysdate - 7   " +
"and EXTERNAL_SYSTEM_ID='SYMP' " +
"and PATIENT_IMPORTED_EDOCUMENT.VERSION=1 " + 
"group by trunc(date_creation) " +
"order by 1 desc "
				
		, oraConn) ;
	try
    {
        oraConn.Open();
        reader = oraComm.ExecuteReader();
		if(reader.HasRows)
		{
			html = "<table class=GridViewStyle>";
			html += "<thead>";
			html += "<tr>";
			for(int i = 0; i < reader.FieldCount; i++)
			{
				html += "<th class=databasecathead>" + Regex.Replace(reader.GetName(i),"_"," ") + "</th>";
			}
			html += "</tr>";
			html += "</thead>";
			html += "<tbody>";
			while(reader.Read())
			{
				html += "<tr>";
				for(int i = 0; i < reader.FieldCount; i++)
				{	
					html += "<td class=databasecat>" + Regex.Replace(reader.GetValue(i).ToString(),"00.00.00","") + "</td>";
				}
				html += "</tr>";
			}
			html += "</tbody>";
			html += "</table>";
			return html;
		}
		else 
		{
			string html2 = "No data found";
			return html2;
		}
        reader.Close();
	}
    finally
    {
        oraConn.Close();
    }
	}
	//return a table string
	[WebMethod]   

    public static string getDWLmismatch()
    {
		OracleConnection oraConn;
		OracleCommand oraComm;
		OracleDataReader reader;
		string html ;
		string connectionString = ConfigurationManager.ConnectionStrings["live"].ConnectionString;
		oraConn = new OracleConnection(connectionString);
		oraComm = new OracleCommand(
"select " +
"adt.patient_no " +
",adt.ADMISSION_NO " +
",adt.WARD_CODE " +
",pt.WARD " +
"from EPR.PATIENT_ADT adt " +
"inner join ( " +
"select " +
"adt.admission_no HICSS_ADMISSION " +
"/*This will return the last row in a group as ADT multi row*/ " +
",max( abs(adt.adt_sequence)) max_seq " +
"from epr.patient_adt adt " +
"where adt.cancelled_flag='N' " +
"and not exists (select pt.patient_no from epr.patient_test_patient pt where " +"adt.patient_no=pt.patient_no) " +
"and adt.admission_no not like '1%' " +
"group by adt.admission_no " +
") curr " +
"on curr.hicss_admission=adt.admission_no " +
"and curr.max_seq=abs(adt.adt_sequence) " +
"inner join patient_transfer pt " +
"on pt.admission_no=adt.admission_no and pt.CURRENT_LOCATION_FLAG='Y'and pt.MANAGED_CONSULT_FLAG='N' " +
"inner join EPR.PATIENT_TRANSFER_WORKLIST ptw " +
"on ptw.TRANSFER_UID=pt.UNIQUE_ID and ptw.WORKLIST_MODE='DOCTORS' and ptw.REMOVED_FROM_LIST_FLAG='N' " +
"group by " +
"adt.patient_no " +
",adt.ADMISSION_NO " +
",adt.WARD_CODE " +
",pt.WARD " +
"having count(case when adt.ward_code != pt.ward then 1 end) > 0 order by 2"
				
		, oraConn) ;
	try
    {
        oraConn.Open();
        reader = oraComm.ExecuteReader();
		if(reader.HasRows)
		{
			html = "<table class=GridViewStyle>";
			html += "<thead>";
			html += "<tr>";
			for(int i = 0; i < reader.FieldCount; i++)
			{
				html += "<th class=databasecathead>" + Regex.Replace(reader.GetName(i),"_"," ") + "</th>";
			}
			html += "</tr>";
			html += "</thead>";
			html += "<tbody>";
			while(reader.Read())
			{
				html += "<tr>";
				for(int i = 0; i < reader.FieldCount; i++)
				{
					html += "<td class=databasecat>" + Regex.Replace(reader.GetValue(i).ToString(),"00.00.00","") + "</td>";
				}
				html += "</tr>";
			}
			html += "</tbody>";
			html += "</table>";
			return html;
		}
		else 
		{
			string html2 = "No data found";
			return html2;
		}
        reader.Close();
	}
    finally
    {
        oraConn.Close();
    }
	}
	
	
	//return a table string
	[WebMethod]   

	public static string getAdmitcounts()
    {
		OracleConnection oraConn;
		OracleCommand oraComm;
		OracleDataReader reader;
		string html ;
		string connectionString = ConfigurationManager.ConnectionStrings["live"].ConnectionString;
		oraConn = new OracleConnection(connectionString);
		oraComm = new OracleCommand(
"select " +
"wd.DIRECTORATE_CODE " +
",COUNT(wd.directorate_code) admitted " +
"from EPR.PATIENT_ADT adt " +
"inner join ( " +
"select " +
"adt.admission_no HICSS_ADMISSION " +
",max( abs(adt.adt_sequence)) max_seq " +
"from epr.patient_adt adt " +
"where adt.cancelled_flag='N' " +
"and not exists (select pt.patient_no from epr.patient_test_patient pt where " +
"adt.patient_no=pt.patient_no) " +
"group by adt.admission_no " +
") curr " +
"on curr.hicss_admission=adt.admission_no " +
"and curr.max_seq=abs(adt.adt_sequence) " +
"inner join epr.ward wd " +
"on wd.CODE=adt.WARD_CODE " +
"and adt.PAS_DISCHARGE_DATE is null " +
"and adt.adt_sequence != 0 " +
"and adt.IS_CURRENT_FLAG='Y' " +
"and adt.LEGACY_ADMISSION_METHOD is null " +
"and wd.ORGANISATION_CODE='RHM' " +
"and wd.DIRECTORATE_CODE is not null " +
"group by rollup (wd.DIRECTORATE_CODE) " +
"order by 1 "
				
		, oraConn) ;
	try
    {
        oraConn.Open();
        reader = oraComm.ExecuteReader();
		if(reader.HasRows)
		{
			html = "<table class=GridViewStyle>";
			html += "<thead>";
			html += "<tr>";
			for(int i = 0; i < reader.FieldCount; i++)
			{
				html += "<th class=databasecathead>" + Regex.Replace(reader.GetName(i),"_"," ") + "</th>";
			}
			html += "</tr>";
			html += "</thead>";
			html += "<tbody>";
			while(reader.Read())
			{
				html += "<tr>";
				for(int i = 0; i < reader.FieldCount; i++)
				{
					html += "<td class=databasecat>" + Regex.Replace(reader.GetValue(i).ToString(),"00.00.00","") + "</td>";
				}
				html += "</tr>";
			}
			html += "</tbody>";
			html += "</table>";
			return html;
		}
		else 
		{
			string html2 = "No data found";
			return html2;
		}
        reader.Close();
	}
    finally
    {
        oraConn.Close();
    }
	}

	//return a table string
	[WebMethod]   

	public static string getBrokenMessages()
    {
		OracleConnection oraConn;
		OracleCommand oraComm;
		OracleDataReader reader;
		string html ;
		string connectionString = ConfigurationManager.ConnectionStrings["live"].ConnectionString;
		oraConn = new OracleConnection(connectionString);
		oraComm = new OracleCommand(
"SELECT app_message_id, SHORT_DESCRIPTION " +
"FROM " +
"APP_MESSAGE " +
"WHERE SYSDATE BETWEEN EFFECTIVE_FROM AND EFFECTIVE_TO " +
"AND INVALID_PAGE_STATE IS NOT NULL "
				
		, oraConn) ;
	try
    {
        oraConn.Open();
        reader = oraComm.ExecuteReader();
		if(reader.HasRows)
		{
			html = "<table class=GridViewStyle>";
			html += "<thead>";
			html += "<tr>";
			for(int i = 0; i < reader.FieldCount; i++)
			{
				html += "<th class=databasecathead>" + Regex.Replace(reader.GetName(i),"_"," ") + "</th>";
			}
			html += "</tr>";
			html += "</thead>";
			html += "<tbody>";
			while(reader.Read())
			{
				html += "<tr>";
				for(int i = 0; i < reader.FieldCount; i++)
				{
					html += "<td class=databasecat>" + Regex.Replace(reader.GetValue(i).ToString(),"00.00.00","") + "</td>";
				}
				html += "</tr>";
			}
			html += "</tbody>";
			html += "</table>";
			return html;
		}
		else 
		{
			string html2 = "No data found";
			return html2;
		}
        reader.Close();
	}
    finally
    {
        oraConn.Close();
    }
	}

	//get the tracked tasks, this uses a stored procedure to return a cursor
[WebMethod]   

	public static string GetTrackedTasks()
    {
		OracleConnection oraConn;
		OracleCommand oraComm;
        oraComm = new OracleCommand();
		string connectionString = ConfigurationManager.ConnectionStrings["LIVE"].ConnectionString;
		oraConn = new OracleConnection(connectionString);
		oraConn.Open();
		oraComm.Connection = oraConn;
		oraComm.CommandType= CommandType.StoredProcedure;
		oraComm.CommandText = "uhs_epr.pkg_epr_dashboard.tracked_tasks_count";
		OracleParameter p2 = oraComm.Parameters.Add("p_cursor", OracleDbType.RefCursor);
        p2.Direction = ParameterDirection.Output;
		string html ;

	try
    	{
				
                oraComm.ExecuteNonQuery();
                OracleDataReader reader = ((OracleRefCursor)p2.Value).GetDataReader();
				if(reader.HasRows)
		{
			html = "<table class=GridViewStyle>";
			html += "<thead>";
			html += "<tr>";
			for(int i = 0; i < reader.FieldCount; i++)
			{
				html += "<th class=databasecathead>" + Regex.Replace(reader.GetName(i),"_"," ") + "</th>";
			}
			html += "</tr>";
			html += "</thead>";
			html += "<tbody>";
			while(reader.Read())
			{
				html += "<tr>";
				for(int i = 0; i < reader.FieldCount; i++)
				{
					html += "<td class=databasecat>" + Regex.Replace(reader.GetValue(i).ToString(),"00.00.00","") + "</td>";
				}
				html += "</tr>";
			}
			html += "</tbody>";
			html += "</table>";
			return html;
				}
				else 
				{
					string html2 = "No data found";
					return html2;
				}
        		reader.Close();
			}
        catch (Exception e)
            {
				return e.Message;
            }
		finally
    		{	
        		oraConn.Close();
    		}
        }
	
	//update the report page
	private void rep_usage()
    {
		//get users
		string username;
		username = HttpContext.Current.User.Identity.Name;
		username = Regex.Replace(username,".*\\\\(.*)", "$1",RegexOptions.None);
		//get url
		string url = HttpContext.Current.Request.Url.AbsoluteUri;
		//stored procedure
		OracleConnection oraConn;
		OracleCommand oraComm;
        oraComm = new OracleCommand();
		string connectionString = ConfigurationManager.ConnectionStrings["UAT"].ConnectionString;
		oraConn = new OracleConnection(connectionString);
		oraComm.Connection = oraConn;
		oraComm.CommandType= CommandType.StoredProcedure;
		oraComm.CommandText = "uhs_epr.pkg_epr_dashboard.rep_usage";
		oraComm.Parameters.Add("p_user_id", OracleDbType.Varchar2,36,ParameterDirection.Input).Value=username;
		oraComm.Parameters.Add("p_page_url", OracleDbType.Varchar2,150,ParameterDirection.Input).Value=url;
	try
    	{
				oraConn.Open();
                oraComm.ExecuteNonQuery();
         
			}
        catch (Exception ex)
            {
				 Console.WriteLine(ex.Message);
            }
		finally
    		{	
        		oraConn.Close();
    		}
        }
	

[WebMethod]   

	public static string GetApplicationMessages()
    {
		OracleConnection oraConn;
		OracleCommand oraComm;
        oraComm = new OracleCommand();
		string connectionString = ConfigurationManager.ConnectionStrings["LIVE"].ConnectionString;
		oraConn = new OracleConnection(connectionString);
		oraConn.Open();
		oraComm.Connection = oraConn;
		oraComm.CommandType= CommandType.StoredProcedure;
		oraComm.CommandText = "uhs_epr.pkg_epr_dashboard.application_messages_active";
		OracleParameter p2 = oraComm.Parameters.Add("p_cursor", OracleDbType.RefCursor);
        p2.Direction = ParameterDirection.Output;
		string html ;

	try
    	{
				
                oraComm.ExecuteNonQuery();
                OracleDataReader reader = ((OracleRefCursor)p2.Value).GetDataReader();
				if(reader.HasRows)
		{
			html = "<table class=GridViewStyle>";
			html += "<thead>";
			html += "<tr>";
			for(int i = 0; i < reader.FieldCount; i++)
			{
				html += "<th class=databasecathead>" + Regex.Replace(reader.GetName(i),"_"," ") + "</th>";
			}
			html += "</tr>";
			html += "</thead>";
			html += "<tbody>";
			while(reader.Read())
			{
				html += "<tr>";
				for(int i = 0; i < reader.FieldCount; i++)
				{
					html += "<td class=databasecat>" + Regex.Replace(reader.GetValue(i).ToString(),"00.00.00","") + "</td>";
				}
				html += "</tr>";
			}
			html += "</tbody>";
			html += "</table>";
			return html;
				}
				else 
				{
					string html2 = "No data found";
					return html2;
				}
        		reader.Close();
			}
        catch (Exception e)
            {
				return e.Message;
            }
		finally
    		{	
        		oraConn.Close();
    		}
        }

}	