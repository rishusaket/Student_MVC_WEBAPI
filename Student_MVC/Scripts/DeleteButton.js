
function deleteStudent(id) {
    if (confirm("Are you sure you want to Delete")) {
     
            $.ajax({
                type: "POST",
                url: "https://localhost:44383/api/Student/" + id,
                dataType: "json",
                contentType: "application/json;charset=UTF-8",
                success: function (data) {
                    loadData();
                    
                    $.ajax({
                        type: "GET",
                        url: "https://localhost:44336/Student/Index",
                        contentType: "application/html;charset=utf-8",
                        dataType: "html",
                        success: function () {
                            
                        }
                    })
                },
                error: function (data) {
                }
            })
        }
}


//function editStudent(id,name,gender,location) {
//    console.log("wdqw");
//    $.ajax({
//        type: "POST",
//        url: "https://localhost:44383/api/Student/",
//        dataType: "json",
//        contentType: "application/json;charset=utf-8",
//        data: JSON.stringify(id,name,gender,location),
//        success: function (returnData) {

//        }

//    })
//}

$(document).ready(function () {
    loadData();
});  

    function loadData() {
        $.ajax({
            type: "GET",
            url: "https://localhost:44383/api/Student/",
            dataType: "json",
            success: function (returnValue) {
                var html = '';
                $(returnValue).each(function () {
                    html += '<table>';
                    html += '<tr>';
                    html += '<td style = "display:none">' + this.Id + '</td>';
                    html += '<td>' + this.name + '</td>';
                    html += '<td>' + this.gender + '</td>';
                    html += '<td>' + this.location + '</td>';
                    html += '<td><button type="button" id="deletebutton" onclick="deleteStudent(' + this.Id + ')">DELETE</button> | <button type="button" id="editbutton" onclick=getById(' + this.Id + ')>Edit</button></td>';
                    html += '</tr>';
                    html += '</table>';
                });
                $('#employeeTBL tbody').html(html);
            }
        })
}



    //var dialogBox = $("#dialog");
    ////var id;
    //function editStudent(id) {
    //    //this.id = id;
    //    console.log(id);
    //    $.ajax({
    //        type: "GET",
    //        url: "https://localhost:44383/api/Student/" + id,
    //        dataType: "json",
    //        success: function (data) {
    //            $('#nameText').val(data.name);
    //            $('#genderText').val(data.gender);
    //            $('#locationText').val(data.location);
    //            console.log(data.name);
    //            dialogBox.dialog('open');
    //        }
    //    })
        
    //}

    //dialogBox.dialog({
    //    autoOpen: false,
    //    modal: true,
    //    buttons: {
    //        'Update': function () { },
    //        'Cancel': function () {
    //            dialogBox.dialog('close');
    //        }
    //    }

    //});


