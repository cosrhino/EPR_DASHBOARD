<%@ Page Language="C#" Debug='True' AutoEventWireup="true" CodeFile="monitor.aspx.cs" Inherits="monitor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="https://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="X-UA-Compatible" content="IE=edge">
	<meta charset="UTF-8">
	<meta name="description" content="EPR dashboard">
	<meta name="author" content="Timothy Murray">
	<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
	
	<!--CSS -->
	<link rel="stylesheet" type="text/css" href="common/css/dashboard.css">
	<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" integrity="sha384-WskhaSGFgHYWDcbwN70/dfYBj47jz9qbsMId/iRN3ewGhXQFZCSftd1LZCfmhktB" crossorigin="anonymous">
	<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.1.0/css/all.css" integrity="sha384-lKuwvrZot6UHsBSfcMvOkWwlCMgc0TaWr+30HWe3a4ltaBwTZhyTEggF5tJv8tbt" crossorigin="anonymous">
	<link rel="shortcut icon" href="favicon.ico" type="image/x-icon" />
<title>UHS clinical systems dashboard</title>
</head>
<body >
<!-- navigation bar -->
<nav class="navbar navbar-expand-lg navbar-light nav-tabs" id="nav-tab" role="tablist" >
	<a class="navbar-brand" href="#">EPR Clinical Systems Dashboard</a>
		<button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavDropdown" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
		<span class="navbar-toggler-icon"></span>
		</button>
		<div class="collapse navbar-collapse" id="navbarNavDropdown">
			<ul class="nav nav-tabs navbar-nav" id="myTab" role="tablist">
				<li class="nav-item">
					<a class="nav-item nav-link" id="home-tab" data-toggle="tab" href="#home" role="tab" aria-controls="home" aria-selected="false">Interfaces</a>
				</li>
				<li class="nav-item">
					<a class="nav-item nav-link" id="activity-tab" data-toggle="tab" href="#activity" role="tab" aria-controls="activity" aria-selected="false">Activity</a>
				</li>
				<li class="nav-item">
					<a class="nav-item nav-link" id="racing-tab" data-toggle="tab" href="#racing" role="tab" aria-controls="racing" aria-selected="false">Racing pages</a>
				</li>
				<li class="nav-item">
					<a class="nav-item nav-link" id="daily-tab" data-toggle="tab" href="#daily" role="tab" aria-controls="daily" aria-selected="false">Daily Checks</a>
				</li>
				<li class="nav-item">
					<a class="nav-item nav-link" id="developments-tab" data-toggle="tab" href="#developments" role="tab" aria-controls="developments" aria-selected="false">Developments</a>
				</li>
				<li class="nav-item dropdown">
					<a class="nav-link dropdown-toggle" href="#" id="navbarDropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Links
					</a>
					<div class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
						<a class="dropdown-item" href="#">Action</a>
						<a class="dropdown-item"class="btn btn-primary" data-toggle="modal" data-target="#contact_list">Contacts</a>
						<a class="dropdown-item"class="btn btn-primary" data-toggle="modal" data-target="#info_list">Information</a>
						<a class="dropdown-item" href="http://10.168.228.138/CliniSysControlConsole/default.asp" target="_blank">CliniSys</a>
						<a class="dropdown-item" href="https://rhmvc2.suhtad.suht.swest.nhs.uk:9443/vsphere-client/" target="_blank">VM Cluster 1 controls (needs IE)</a>
						<a class="dropdown-item" href="https://rhmvc3.suhtad.suht.swest.nhs.uk:9443/vsphere-client/" target="_blank">VM cluster 2 controls (needs IE)</a>
					</div>
				</li>
			</ul>
		</div>
<img src="images/UHSdigital.png" alt="UHS digital" style="width:100px;height:70px;">
</nav>
<span id="labeluser"></span>
<!-- Alerts -->	
<!--This alert to show about dev
<div class="alert alert-primary alert-dismissible fade show" role="alert" id="devtime">These alerts are based on data in Dev, do not worry
		<button type="button" class="close" data-dismiss="alert" aria-label="Close">
			<span aria-hidden="true">&times;</span>
		</button>
	</div>-->

	<div id="alerts"></div>

<!-- Tabs -->

<div class="tab-content" id="tabContent">


<div class="tab-pane fade active show" id="home" role="tabpanel" aria-labelledby="home-tab">
<!--Carousel -->
<div class="button-js-do" align="center">Freeze</div>
<div id="interfaces-c" class="carousel slide" data-ride="carousel">
<form id="form1" runat="server">	
<asp:ScriptManager ID="scm" runat="server" EnablePageMethods="true" />

		<div class="carousel-inner">
			
			<div class="carousel-item active">
			<h3 class="slide-header">eQuest</h3>
				<div id="slide-equest"></div>
								<h3 class="slide-header">Database status</h3>
								<div id="slide-database">
									<div class="float-box">
										<div id="orainstances" runat="server" class="GridViewStyle"></div>			

				</div>
			</div>
			</div>
<div class="carousel-item">
			<h3 class="slide-header">eDocs</h3>
				<div id="slide-edocs">
					
				</div>
			<h3 class="slide-header">Worklist</h3>
				<div id="slide-worklist"></div>
			</div>

</div>
			<a class="carousel-control-prev text-secondary" href="#interfaces-c" role="button" data-slide="prev">
				<span class="carousel-control-prev-icon text-secondary" aria-hidden="true"></span>
				<span class="sr-only">Previous</span>
			</a>
			<a class="carousel-control-next text-secondary" href="#interfaces-c" role="button" data-slide="next">
				<span class="carousel-control-next-icon text-secondary" aria-hidden="true"></span>
				<span class="sr-only">Next</span>
			</a> 
</div>
<div class="button-js-do" align="center">Freeze</div>
</div> 
<!-- Activity -->
<div class="tab-pane fade" id="activity" role="tabpanel" aria-labelledby="activity-tab">
	<h3 class="slide-header">Hospital activity</h3>
<div id="slide-database">
		<div id="patientact"></div>
	</div>
	<h3 class="slide-header">CHARTS activity</h3>
<div id="slide-database">
		<div id="chartsact"></div>
	</div>
</div>

</form>

<!--Developments-->
<div class="tab-pane fade" id="developments" role="tabpanel" aria-labelledby="developments-tab">
	<h4>Developments</h4>
	<div class="alert alert-info" role="alert">R29 currently being tested <a href="http://sghdev3/dwl" class="alert-link" target="_blank"> link</a>
	</div>
	<div class="progress">
		<div class="progress-bar bg-warning" role="progressbar" style="width: 70%" aria-valuenow="70" aria-valuemin="0" aria-valuemax="100">DEVE</div>
	</div>
	<div class="progress">
		<div class="progress-bar bg-info" role="progressbar" style="width: 54%" aria-valuenow="54" aria-valuemin="0" aria-valuemax="100">UAT</div>

</div>
</br>
	<img src="developments/R29.png" alt="Release 29" width="99%">
</div>	

<!--Racing pages -->
<div class="tab-pane fade" id="racing" role="tabpanel" aria-labelledby="racing-tab">
	<h4>Racing page controls</h4>
	<div class="float-box"><iframe scrolling="no" frameborder='0' name="SGHWEB1" src="http://sghweb1:85/rpcheck2?BAVSFEVCNENCHJ=//BBHH3z9i,.2ein,@akj4" style="width:190px; height:280px;"></iframe></div>
    <div class="float-box"><iframe scrolling="no" frameborder='0' name="SGHWEB2" src="http://sghweb2:85/rpcheck2?BAVSFEVCNENCHJ=//BBHH3z9i,.2ein,@akj4" style="width:190px; height:280px;"></iframe></div>
    <div class="float-box"><iframe scrolling="no" frameborder='0' name="SGHWEB3" src="http://sghweb3:85/rpcheck2?BAVSFEVCNENCHJ=//BBHH3z9i,.2ein,@akj4" style="width:190px; height:280px;"></iframe></div>
	<div class="float-box"><iframe scrolling="no" frameborder='0' name="SGHWEB4" src="http://sghweb4:85/rpcheck2?BAVSFEVCNENCHJ=//BBHH3z9i,.2ein,@akj4" style="width:190px; height:280px;"></iframe></div>
	<div class="float-box"><iframe scrolling="no" frameborder='0' name="SGHWEB6" valign="top" src="http://sghweb6:85/rpcheck2?BAVSFEVCNENCHJ=//BBHH3z9i,.2ein,@akj4" style="width:190px; height:280px;"></iframe></div>
	<div class="float-box"><iframe scrolling="no" frameborder='0' name="SGHWEB7" src="http://sghweb7:85/rpcheck2?BAVSFEVCNENCHJ=//BBHH3z9i,.2ein,@akj4" style="width:190px; height:280px;"></iframe></div>
	<div class="float-box"><iframe scrolling="no" frameborder='0' name="SGHWEB8" src="http://sghweb8:85/rpcheck2?BAVSFEVCNENCHJ=//BBHH3z9i,.2ein,@akj4" style="width:190px; height:280px;"></iframe></div>

	
	
</div>

<!--Daily checks-->
<div class="tab-pane fade" id="daily" role="tabpanel" aria-labelledby="daily-tab">
	<h4>Daily checks</h4>
		<div class="float-box">
			<div id="dailychecks" runat="server" class="GridViewStyle"></div>
		</div>
</div>

<!-- end of tab containter -->
</div>
</div>
</body>
<footer>
<!--Information Modal -->
<div class="modal fade" id="info_list" tabindex="-1" role="dialog" aria-labelledby="ModalCenterTitle" aria-hidden="true">
  <div class="modal-dialog modal-dialog-centered" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="ModalCenterTitle">Dasboard information</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        Dashboard under construction. Welcoming new ideas
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
      </div>
    </div>
  </div>
</div>

<!--Contact Modal -->
<div class="modal fade" id="contact_list" tabindex="-1" role="dialog" aria-labelledby="ModalCenterTitle" aria-hidden="true">
  <div class="modal-dialog modal-dialog-centered" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="ModalCenterTitle">Useful contacts</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
		</div>
		<div class="modal-body">
			<ul>
				<li>EPR developments lead - Alastair Marchant</li>
				<li>EPR clinical operational lead - Timothy Murray</li>
				<li>EPR Symphony operational lead - Catherine Allitt</li>
				<li>EPR CaMiS operational lead - Nick Kernan</li>
				<li>EPR product delivery manager - Ryan beegan</li>
			</ul>
		</div>
		<div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
      </div>
    </div>
  </div>
</div>



<!-- Bootstrap javascripts -->
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <link rel="stylesheet" href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/themes/smoothness/jquery-ui.css">
	<script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js"></script>
	<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
	<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js" integrity="sha384-smHYKdLADwkXOn1EmN1qk/HfnUcbVRZyYmZ4qpPea6sjB/pTJ0euyQp0Mk8ck+5T" crossorigin="anonymous"></script>
	<script src="common/jslibs/moment.js" type="text/javascript"></script>
	<script src="common/jslibs/jqueryUHSEPR.js" type="text/javascript"></script>
	<script src="common/jslibs/dashboard_controls.js" type="text/javascript"></script>
</footer>
</html>