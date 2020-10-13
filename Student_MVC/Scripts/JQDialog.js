//function getById(id) {
//    $.ajax({
//        type: "GET",
//        url: "https://localhost:44383/api/Student/" + id,
//        dataType: "json",
//        success: function (data) {
//            $('#nameText').val(data.name);
//            $('#genderText').val(data.gender);
//            $('#locationText').val(data.location);
//            editStud();
//        }
//    })
//}


$(document).ready(function () {
    var dialogbox = $(".AddForm");
    var adda = false;


    $('#btnAdd').click(function (data) {
        adda = true;
        console.log($(data).attr('data-are'));
        clearDialog();
        $('#EditButton').css('display', 'none');
        dialogbox.dialog('open');
    });
    dialogbox.dialog({
        autoOpen: false,
        modal: true,
        buttons: {
            //'Create': addEmployee,
            'Cancel': function () {
                dialogbox.dialog('close');
            }
        }
    });

    //$('#editbutton').click(function (data) {
    function getById(id) {
        console.log("eeee");
        
        console.log(id);
        $.ajax({
            type: "GET",
            url: "https://localhost:44383/api/Student/" + id,
            dataType: "json",
            success: function (data) {
                $('#nameText').val(data.name);
                $('#genderText').val(data.gender);
                $('#locationText').val(data.location);
                dialogbox.dialog('open');
            }
        })
    }



   

    $('#AddButton').click(addEmployee);

function addEmployee() {
    console.log("dwqqwd");
    var emp = {};
    emp.name = $('#nameText').val();
    emp.gender = $('#genderText').val();
    emp.location = $('#locationText').val();
    $.ajax({
        type: 'POST',
        url: 'https://localhost:44383/api/Student',
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        data: JSON.stringify(emp),
        success: function () {
            loadData();
            dialogbox.dialog('close');
        }
    })
    }
    function clearDialog() {
        $('#nameText').val("");
        $('#genderText').val("");
        $('#locationText').val("");
    }
});