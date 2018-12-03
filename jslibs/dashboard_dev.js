function devTable() {
$(document).ready(function(){
    $.ajax({
         type : 'GET',
		dataType : 'json',
		async: false,
        cache:false,
        success: function(data){
            /*console.log(data);*/
            var event_data = '';
            $.each(data.user, function(index, value){
                /*console.log(value);*/
                event_data += '<tr>';
                event_data += '<td>'+value.name+'</td>';
                event_data += '<td>'+value.id+'</td>';
                event_data += '</tr>';
            });
            $("#list_table_json").append(event_data);
        },
        error: function(d){
            /*console.log("error");*/
            alert("404. Please wait until the File is Loaded.");
        }
    });
});
}