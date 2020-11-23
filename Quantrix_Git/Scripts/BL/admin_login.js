$(document).ready(function () {
    $(document).off("click", "#btnLogin").on("click", "#btnLogin", function () {
        if ($('#txtUserId').val() == "")
        {
            alert("Please Enter Username...!");
            $('#txtUserId').focus();
            return false;
        }
        else if ($('#txtUserPassword').val() == "") {
            alert("Please Enter Password...!");
            $('#txtUserPassword').focus();
            return false;
        }
        else { login();}
    });
});
function login()
{
    $.ajax({
        url: '/Admin/Login',
        type: 'POST',
        data: { username: $('#txtUserId').val(), password: $('#txtUserPassword').val() },
        success: function (result) {
            if (result.is_error_raised != true) {
                if (result.success == true) {

                    window.location.href = '/Admin/BannerManagement';

                }
                else {
                    alert('Invalid Username or Password...!');
                    return false;
                }
            }
            else {
                alert(result.message);
                return false;
            }
            
        },
        error: function (errorrslt) {
            
            console.log(errorrslt);
            alert('Internal error has been occured.Please contact development team...!');
            return false;
        }
    });
}