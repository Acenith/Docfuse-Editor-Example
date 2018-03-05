$(document).ready(function () {
    // Initialize Editor
    $(".textarea-editor").summernote({
        toolbar: [
            ["style", ["bold", "italic", "underline", "strikethrough", "clear"]],
            ["fontname", ["fontname"]],
            ["fontsize", ["fontsize"]],
            ["color", ["color"]],
            ["para", ["ul", "ol", "paragraph"]],
            ["fullscreen", ["fullscreen"]]
        ],
        //width: 800,
        height: 600,                 // set editor height
        minHeight: null,             // set minimum height of editor
        maxHeight: null,             // set maximum height of editor
        focus: false                  // set focus to editable area after initializing summernote
    });


    $('#save').on('click', function () {

        var data = $('#documentForm').serialize();

        $.ajax({
            url: '/Home/SaveDocument',
            type: 'post',
            dataType: 'json',
            data: data,
            success: function (res) {
                console.log(res);
            }
        });
            
    });
});