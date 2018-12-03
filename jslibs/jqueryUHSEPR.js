
//UHS jQuery functions

//Add an alert in the alerts section parameter is id of alert message
function addAlert(id, message) {
    $('#alerts').append(
        '<div class="alert alert-danger alert-dismissible fade show" role="alert" id="' + id + '">' + message + 
            '<button type="button" class="close" data-dismiss="alert" aria-label="Close">' +
            '&times;</button>' + '</div>');
}
;

//add a widget
function addWidget(id, slide, message, header) {
    $('#' + slide).append(
        '<div class="float-box"><div class="database-widget">' + header + '</div><div id="' + id + '"  class="monitordata" >' + message + '</div></div>');
}
;
//moment calculation
function momcalc(timecalc){
    var momres = moment(timecalc,"DD/MM/YYYY HH:mm:ss");
    var message = moment(momres,"DD/MM/YYYY HH:mm:ss").fromNow();
    return message;
}
;

//create bootstrap card
function addWidgetBS(id, slide, message, title, subtitle , warning) {
	if (warning ==1 ){
		warning = 'card text-white bg-warning mb-3';
	}
	else if (warning == 2 ) {
		warning = 'card text-white bg-success mb-3';
		//warning = 'card text-white mb-3';
	}
	else if (warning == 3) {
		warning = 'card text-white bg-danger mb-3';
	}
	else if (warning == 0) {
		warning = 'card bg-light mb-3';
	}
	
    $('#' + slide).append(
'<div class="float-box" ><div class="' + warning + '" style="max-width: 18rem;"><div class="card-header">' + title + '</div><div class="card-body"><h5 class="card-title"> ' + subtitle + '</h5><p id=' + id + ' class="card-text">'+ message + '</p></div></div></div>');
}
;



//Set the latest drug date and create an alert if no data
$(document).ready($(function () {
        $.ajax({
        type: 'POST',
        url: 'home.aspx/GetDrugDate',
        data: '{ }',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function(msg) {
            // Do something interesting here.
            //alert(msg.d);
            var res = msg.d;
			var widgid='latestdrug';
			var warning = 0;
			//does the alert exist?
			var momres = moment(res,"DD/MM/YYYY HH:mm:ss");
			//
			var message = moment(res,"DD/MM/YYYY HH:mm:ss").fromNow();
			var b = moment();
			var c = Math.round((moment().diff(momres)) / 1000);
			if ((c >= 800) && (c<= 1800)) {
				warning = 1;
			}
			else if (c > 1800 ){
				warning = 3
				};

		 //check to see if widget created
           if($('#' + widgid).length) {
  //it doesn't exist 
			$('#' + widgid ).text(message);
			}
			//if widget createdjust append date
          else {
              addWidgetBS(widgid, 'slide-edocs',message,'ePrescribing','Last drugs sent to eDocs',warning);
		  }
        }
    });
    setTimeout(arguments.callee, 180000);

}));

//Set the latest drug date and create an alert if no data
$(document).ready($(function () {
        $.ajax({
        type: 'POST',
        url: 'home.aspx/GetCasCard',
        data: '{ }',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function(msg) {
           
			var widgid = 'symph';
         //change the label to date
		   //check to see if widget created
			var warning = 0;
            var res = msg.d;
			if (res =="Duplicate CASCard") {	
					warning = 1;
			}
			//check to see if widget created
           if($("#" + widgid).length) {
			//it doesn't exist 
		
			$("#" + widgid ).text(res);
		   }
			//if widget createdjust append date
          else {
              addWidgetBS(widgid, 'slide-edocs',res,'Symphony CASCards','Symphony duplicates exist',warning);
		  }

		
		}
		});
    setTimeout(arguments.callee, 180000);
}));



//Alert if less than one instance up
//Counts the table rows
$(document).ready($(function () {
var rowCount = $('#orainstances tr').length;
if (rowCount < 3) {
	//Remove alert if it exists
	$('#ORA').alert('close');
	//Add alert
	addAlert('ORA','An Oracle instance has gone down');
}
else {
		//Remove alert if it exists
				$('#ORA').alert('close');
		   };

setTimeout(arguments.callee, 180000);
}))
;

//set the latest radiology message log date
$(document).ready($(function () {
    $.ajax({
        type: 'POST',
        url: 'home.aspx/GetRadiologyDate',
        data: '{ }',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function(msg) {
			var widgid = 'radlog';
         //change the label to date
		   //check to see if widget created
            var res = momcalc(msg.d);
            var warning = 0;
           //change the label to date
           if($("#" + widgid).length) {
  //it doesn't exist 
			$("#" + widgid ).text(res);
            //if widget createdjust append date
           }
            else {
                addWidgetBS(widgid, 'slide-equest',res,'Radiology results', 'Radiology log file last modified',warning);
			}
		  
        }
        
    });
    setTimeout(arguments.callee, 1800000);
}));

//set the latest pathology message log date
$(document).ready($(function () {
    $.ajax({
        type: 'POST',
        url: 'home.aspx/GetPathologyDate',
        data: '{ }',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function(msg) {
			//call the cs code
			
            var widgid = 'pathlog';
            var warning = 0;
            var res = momcalc(msg.d);
            var momres = moment(res,"DD/MM/YYYY HH:mm:ss");
			//
		
			var b = moment();
			var c = Math.round((moment().diff(momres)) / 1000);
			if ((c >= 120) && (c<= 300)) {
				warning = 1;
			}
			else if (c > 300 ){
				warning = 3
				};
           //change the label to date
		   //check to see if widget created
		   if($("#" + widgid).length) {
  //if it exists doesn't exist 
            $("#" + widgid ).text(res);
            if (warning>1) {
                $("#" + widgid ).parent().css("background-color", "orange");
            }
            else {
                $("#" + widgid ).parent().css("background-color", "white");
                $("#" + widgid ).parent().css("color", "black");
                $("#" + widgid ).css("color", "black");
            }
			}
			//if widget createdjust append date
         else {addWidgetBS(widgid, 'slide-equest',res,'Pathology results', 'Pathology log file last modified',warning);
		  }
        }
        
    });
    setTimeout(arguments.callee, 90000);
}));

//set the latest viewpoint message log date
$(document).ready($(function () {
    $.ajax({
        type: 'POST',
        url: 'home.aspx/GetViewpointDate',
        data: '{ }',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function(msg) {
			//call the cs code
			
            var widgid = 'vplog';
			var res = momcalc(msg.d);
           //change the label to date
		   //check to see if widget created
		   if($("#" + widgid).length) {
             //it doesn't exist  $("#" + widgid ).text(res);
             $("#" + widgid ).text(res);
             if (warning>1) {
                $("#" + widgid ).parent().css("background-color", "orange");
            }
            else {
                $("#" + widgid ).parent().css("background-color", "white");
                $("#" + widgid ).css("color", "black");
            }
			}
			//if widget createdjust append date
         else {
            addWidgetBS(widgid, 'slide-equest',res,'View point', 'Viewpoint log file last updated','0');
		  }
        }
        
    });
    setTimeout(arguments.callee, 180000);
}));

//set the latest request sent to labe centre message log date
$(document).ready($(function () {
    $.ajax({
        type: 'POST',
        url: 'home.aspx/GeteQuestrequest',
        data: '{ }',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function(msg) {
			//call the cs code
			
            var widgid = 'equestrequest';
			var res = momcalc(msg.d);
           //change the label to date
		   //check to see if widget created
		   if($("#" + widgid).length) {
  //it doesn't exist 
			
            $("#" + widgid ).text(res);
            if (warning>1) {
                $("#" + widgid ).parent().css("background-color", "orange");
            }
            else {
                $("#" + widgid ).parent().css("background-color", "white");
                $("#" + widgid ).css("color", "black");
            }
        }
			//if widget createdjust append date
         else {
             addWidgetBS(widgid, 'slide-equest',res,'eQuest request out', 'eQuest order log file last updated','0');
		  }
        }
        
    });
    setTimeout(arguments.callee, 180000);
}));


//set the latest ADT/PMI log message log date
//uses moment.js
$(document).ready($(function () {
    $.ajax({
        type: 'POST',
        url: 'home.aspx/GetAdtLogDate',
        data: '{ }',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function(msg) {
			var widgid = 'adtlog';
         //change the label to date
            var warning = 0;
            var res = momcalc(msg.d);
			var momres = moment(res,"DD/MM/YYYY HH:mm:ss");
			//
		
			var b = moment();
			var c = Math.round((moment().diff(momres)) / 1000);
			if ((c >= 120) && (c<= 300)) {
				warning = 1;
			}
			else if (c > 300 ){
				warning = 3
				};


		 //check to see if widget created
           if($("#" + widgid).length) {
  //it doesn't exist 
            $("#" + widgid ).text(res);
            if (warning>1) {
                $("#" + widgid ).parent().css("background-color", "orange");
            }
            else {
                $("#" + widgid ).parent().css("background-color", "white");
                $("#" + widgid ).css("color", "black");
            }
			}
			//if widget createdjust append date
          else {
              addWidgetBS(widgid, 'slide-worklist',res,'ADT/PMI interface','ADT log file last modified',warning);
		  }
        }
        
    });
    setTimeout(arguments.callee, 180000);
}));


//set the latest eQuest to IMPAC log date
//uses moment.js
$(document).ready($(function () {
    $.ajax({
        type: 'POST',
        url: 'home.aspx/GetIMPACsend',
        data: '{ }',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function(msg) {
			var widgid = 'impaclog';
         //change the label to date
            var warning = 0;
            var res = momcalc(msg.d);
			var momres = moment(res,"DD/MM/YYYY HH:mm:ss");
			//
			
			var message = moment(res,"DD/MM/YYYY HH:mm:ss").fromNow();
			var b = moment();
			var c = Math.round((moment().diff(momres)) / 1000);
			if ((c >= 500000) && (c<= 8500000)) {
				warning = 1;
			}
			else if (c > 8500000 ){
				warning = 3
				};


		 //check to see if widget created
           if($("#" + widgid).length) {
  //it doesn't exist 
            $("#" + widgid ).text(res);
            if (warning>1) {
                $("#" + widgid ).parent().css("background-color", "orange");
            }
            else {
                $("#" + widgid ).parent().css("background-color", "white");
                $("#" + widgid ).parent().css("color", "black");
            }
			}
			//if widget createdjust append date
          else {
              addWidgetBS(widgid, 'slide-equest',res,'IMPAC','Last message sent from eQuest to ARIA/MOSAIQ',warning);
            
		  }
        }
        
    });
    setTimeout(arguments.callee, 180000);
}));

//get latest eQuest
//uses moment.js
$(document).ready($(function () {
    $.ajax({
        type: 'POST',
        url: 'home.aspx/GetSentDate',
        data: '{ }',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function(msg) {
			var widgid = 'equestorder';
         //change the label to date

            var message = msg.d;
			var warning = 0;
			if (message != "No outstanding requests") {
		
               if (message > 50 && message < 300 )
               {
			
                warning = 1;
               }
			
			else if (message > 300 ){
				warning = 3};
			};

		 //check to see if widget created
           if($("#" + widgid).length) {
  //it doesn't exist 
            $("#" + widgid ).text(message);
            if (warning>1) {
                $("#" + widgid ).parent().css("background-color", "red");
            }
            else {
                $("#" + widgid ).parent().css("background-color", "white");
                $("#" + widgid ).css("color", "black");
            }
			}
			//if widget createdjust append date
          else {
              addWidgetBS(widgid, 'slide-equest',message,'eQuest orders out','Longest waiting order to be sent to Lab',warning);
		  }
        }
        
    });
    setTimeout(arguments.callee, 90000);
}));


//get instance 1
$(document).ready($(function () {
    $.ajax({
        type: 'POST',
        url: 'home.aspx/getOra1',
        data: '{ }',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function(msg) {
		var widgid = 'ora1';
		var warning = 0;
        var res = msg.d;
		if (res != "Cannot speak to instance") {
			if ((res > 500) && (res <= 800)){
           warning = 1;
			}
			else if (res > 800) {
			warning = 3;
								};
												};
        if($("#" + widgid).length) {
  //it doesn't exist 
            $("#" + widgid ).text(res);
            if (warning>1) {
                $("#" + widgid ).parent().css("background-color", "orange");
            }
            else {
                $("#" + widgid ).parent().css("background-color", "white");
                $("#" + widgid ).css("color", "black");
            }
			}
			//if widget createdjust append date
         else {
			addWidgetBS(widgid, 'slide-database', res, 'Node A','Active sessions',warning);
		  };
        }
		
        
    });
    setTimeout(arguments.callee, 180000);
}));

//get instance 2
$(document).ready($(function () {
    $.ajax({
        type: 'POST',
        url: 'home.aspx/getOra2',
        data: '{ }',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function(msg) {
		var widgid = 'ora2';
		var warning = 0;
        var res = msg.d;
		if (res != "Cannot speak to instance") {
			if ((res > 500) && (res <= 800)){
           warning = 1;
			}
			else if (res > 800) {
			warning = 3;
								};
												};
        if($("#" + widgid).length) {
  //it doesn't exist 
            $("#" + widgid ).text(res);
            if (warning>1) {
                $("#" + widgid ).parent().css("background-color", "orange");
            }
            else {
                $("#" + widgid ).parent().css("background-color", "white");
                $("#" + widgid ).css("color", "black");
            }
			}
			//if widget createdjust append date
         else {
			addWidgetBS(widgid, 'slide-database', res, 'Node B','Active sessions',warning);
		  };
        }
		
        
    });
    setTimeout(arguments.callee, 180000);
}));




//get the imported edocs

$(document).ready($(function () {
    $.ajax({
        type: 'POST',
        url: 'home.aspx/getImportdocs',
        data: '{ }',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function(msg) {
            var widgid = 'importdocs';
            var message = msg.d;
            var warning = 0;
            if (message=='No data found') 
            {
                warning = 1;
            };

            if($("#" + widgid).length) 
            {
                //it doesn't exist 
            $("#" + widgid ).text(message);
            if (warning>1) {
                $("#" + widgid ).parent().css("background-color", "orange");
            }
            else {
                $("#" + widgid ).parent().css("background-color", "white");
                $("#" + widgid ).css("color", "black");
            }
            }
            else 
            {
                addWidgetBS(widgid, 'dailychecks', message, 'Imported eDocs','Documents imported to eDocs',warning);
			
		    };
            }
        });
            setTimeout(arguments.callee, 500000000);
}));

//get EDA documents
$(document).ready($(function () {
    $.ajax({
        type: 'POST',
        url: 'home.aspx/getImportEDA',
        data: '{ }',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function(msg) {
            var widgid = 'importeda';
            var message = msg.d;
            var warning = 0;
            if (message=='No data found') 
            {
                warning = 1;
            };

            if($("#" + widgid).length) 
            {
                //it doesn't exist 
                $("#" + widgid ).text(message);
                if (warning>1) {
                    $("#" + widgid ).parent().css("background-color", "orange");
                }
                else {
                    $("#" + widgid ).parent().css("background-color", "white");
                    $("#" + widgid ).css("color", "black");
                }
            }
            else 
            {
			addWidgetBS(widgid, 'dailychecks', message, 'Imported ED discharges','Documents imported from symphony',warning);
		    };
            }
        });
            setTimeout(arguments.callee, 500000000);
}));

//get DWL mismatches
$(document).ready($(function () {
    $.ajax({
        type: 'POST',
        url: 'home.aspx/getDWLmismatch',
        data: '{ }',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function(msg) {
            var widgid = 'dwlmismatch';
            var message = msg.d;
            var warning = 0;
            if (message =='No data found') 
            {
                warning = 0;
            };

            if($("#" + widgid).length) 
            {
                //it doesn't exist 
            $("#" + widgid ).text(message);
            if (warning>1) {
                $("#" + widgid ).parent().css("background-color", "orange");
            }
            else {
                $("#" + widgid ).parent().css("background-color", "white");
                $("#" + widgid ).css("color", "black");
            }
            }
            else 
            {
			addWidgetBS(widgid, 'dailychecks', message, 'DWL mismatches','Patients with ADT different to current worklist entry',warning);
		    };
            }
        });
            setTimeout(arguments.callee, 500000000);
}));


//get current admissions
$(document).ready($(function () {
    $.ajax({
        type: 'POST',
        url: 'home.aspx/getAdmitcounts',
        data: '{ }',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function(msg) {
            var widgid = 'currentadmit';
            var message = msg.d;
            var warning = 0;
            if (message =='No data found') 
            {
                warning = 2;
            };

            if($("#" + widgid).length) 
            {
                //it doesn't exist 
            $("#" + widgid ).text(message);
            if (warning>1) {
                $("#" + widgid ).parent().css("background-color", "orange");
            }
            else {
                $("#" + widgid ).parent().css("background-color", "white");
                $("#" + widgid ).css("color", "black");
            }
            }
            else 
            {
                addWidgetBS(widgid, 'patientact', message, 'Current admissions','Patients currently admitted to the trust',warning);
			
		    };
            }
        });
            setTimeout(arguments.callee, 500000000);
}));

//get current admissions
$(document).ready($(function () {
    $.ajax({
        type: 'POST',
        url: 'home.aspx/GetUsersLogged',
        data: '{ }',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function(msg) {
            var widgid = 'userslogged';
            var message = msg.d;
            var warning = 0;
            if (message =='No data found') 
            {
                warning = 0;
            };

            if($("#" + widgid).length) 
            {
                //it doesn't exist 
            $("#" + widgid ).text(message);
            if (warning>1) {
                $("#" + widgid ).parent().css("background-color", "orange");
            }
            else {
                $("#" + widgid ).parent().css("background-color", "white");
                $("#" + widgid ).css("color", "black");
            }
            }
            else 
            {
                addWidgetBS(widgid, 'chartsact', message, 'Users today','Users who have logged in the last 6 hours' ,warning);
			
		    };
            }
        });
            setTimeout(arguments.callee, 500000000);
}));



//get DWL mismatches
$(document).ready($(function () {
    $.ajax({
        type: 'POST',
        url: 'home.aspx/GetTrackedTasks',
        data: '{ }',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function(msg) {
            var widgid = 'tracktask';
            var message = msg.d;
            var warning = 0;

            if($("#" + widgid).length) 
            {
                //it doesn't exist 
            $("#" + widgid ).text(message);
            if (warning>1) {
                $("#" + widgid ).parent().css("background-color", "orange");
            }
            else {
                $("#" + widgid ).parent().css("background-color", "white");
                $("#" + widgid ).css("color", "black");
            }
            }
            else 
            {
			addWidgetBS(widgid, 'chartsact', message, 'Tracked tasks','Tracked tasks created in CHARTS',warning);
		    };
            }
        });
            setTimeout(arguments.callee, 500000000);
}));

//get Application messages
$(document).ready($(function () {
    $.ajax({
        type: 'POST',
        url: 'home.aspx/GetApplicationMessages',
        data: '{ }',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function(msg) {
            var widgid = 'appmessages';
            var message = msg.d;
            var warning = 0;

            if($("#" + widgid).length) 
            {
                //it doesn't exist 
            $("#" + widgid ).text(message);
            if (warning>1) {
                $("#" + widgid ).parent().css("background-color", "orange");
            }
            else {
                $("#" + widgid ).parent().css("background-color", "white");
                $("#" + widgid ).css("color", "black");
            }
            }
            else 
            {
			addWidgetBS(widgid, 'dailychecks', message, 'Application messages','Application messages active',warning);
		    };
            }
        });
            setTimeout(arguments.callee, 500000000);
}));


//get broken messages
$(document).ready($(function () {
    $.ajax({
        type: 'POST',
        url: 'home.aspx/getBrokenMessages',
        data: '{ }',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function(msg) {
            var widgid = 'brokemessages';
            var message = msg.d;
            var warning = 0;
            if (message!=="No data found"){
                warning=0;
            };
            if($("#" + widgid).length) 
            {
                //it doesn't exist 
            $("#" + widgid ).text(message);
            if (warning>1) {
                $("#" + widgid ).parent().css("background-color", "orange");
            }
            else {
                $("#" + widgid ).parent().css("background-color", "white");
                $("#" + widgid ).css("color", "black");
            }
            }
            else 
            {
			addWidgetBS(widgid, 'dailychecks', message, 'Broken application messages','Application messages in Charts broken',warning);
		    };
            }
        });
            setTimeout(arguments.callee, 500000000);
}));