
function isNumber(evt) {
    debugger;
   evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
    
        return false;
    }

    return true;
}

//var regexEmail = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
var regexEmail = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
function regexValEmailID(val) {
    if (!regexEmail.test(val)) {
        //alert("Please Enter Valid UserID/EmailID.");
        //return false;
        return 1;
    }
    else
        return 0;
}

function ValidateEmailID(val) {
    if (regexEmail.test(val)) {
        return true;
    }
    else {
        return false;
    }
}

function fnValidatePAN(val) {
    if (val != "") {
        var panPat = /^([a-zA-Z]{5})(\d{4})([a-zA-Z]{1})$/;
        var code = /([C,P,H,F,A,T,B,L,J,G])/;
        var code_chk = val.substring(3, 4);
        if (val.search(panPat) == -1) {
            //alert("Invalid Pan No");
            //  ErrorPopup('Pan Format Not Correct')
            return false;
        }
            //else if (code.test(code_chk) == false) {
            //    //alert("Invaild PAN Card No.");
            //    return false;
            //}
        else
            return true;
    }
}

function validateMobile(mobileNo) {
    var regexMobile = /^(\+91-|\+91|0)?(\d{10}|\d{12})$/;
    var result;
    if (mobileNo.match(regexMobile)) {
        return true;    //Valid
    } else {
        return false;   //InValid
    }
}

function validateNRIMobile(mobileNo) {
    var regexMobile = /([^a-zA-Z])?^([0-9]){5,15}$/;

    if (mobileNo.match(regexMobile)) {
        return true;    //Valid
    } else {
        return false;   //InValid
    }
}

function validateMob(mobile) {
    var regexMobile = /^\d{10}$/g;
    var result;
    if (mobile.match(regexMobile)) {
        return true;    //Valid
    } else {
        return false;   //InValid
    }
}

function validate_Distributor_ARN(data) {
    //  var regexDistributor_ARN = /^(ARN-)\d{1,10}$/;
    data = data.trim();
    var result;
    if (data.split('ARN-')[1] != "") {
        return true;    //Valid
    } else {
        return false;   //InValid
    }
    return true;
}

function validate_EUIN(data) {
    var regexEUIN = /^(E)?\d{6,6}$/;
    var result;
    if (data.match(regexEUIN)) {
        return true;    //Valid
    } else {
        return false;   //InValid
    }
}

function isSpclChar(value) {
    var iChars = "!#$%^&*()+=-[]\\\';,./{}|\":<>?";
    for (var i = 0; i < value.length; i++) {
        if (iChars.indexOf(value.charAt(i)) != -1) {
            return false;
        }
    }
    return true;
}

function isAlphabetic(value) {
    var regex = /^[a-zA-Z ]*$/;
    if (!regex.test(value)) {
        return false //Invalid
    }
    else
        return true;
}

function isAlphaNumeric(e) {
    //var regex = /^([a-zA-Z0-9 ]+)$/
    //if (!regex.test(value)) {
    //    return false //Invalid
    //}
    //else
    //    return true;
    if ((e.keyCode >= 48 && e.keyCode <= 57) || (e.keyCode >= 65 && e.keyCode <= 90) || (e.keyCode >= 97 && e.keyCode <= 122))
        return true;
    else
        return false;
}

function isNumeric(value) {
    var regex = /^[0-9]+$/
    if (!regex.test(value)) {
        return false //Invalid
    }
    else {
        return true;
    }
}

function validateDate_ddmmyyyy(date) {
    //date considered in dd/mm/yy or dd-mm-yy format
    var datepart;
    datepart = (date.split('-').length != 1) ? date.split('-') : date.split('/');
    if (datepart.length != 3)
        return false;
    else {
        if (isNaN(Date.parse(datepart[2] + "-" + datepart[1] + "-" + datepart[0]))) {
            return false;
        }

        return true;
    }
}

function validateDate1(date) {
    if (new Date(date) == 'Invalid Date') {
        return false;
    }
    else {
        return true;
    }
}

function checkDecimal(el) {
    var ex = /^[0-9]+\.?[0-9]*$/;
    if (ex.test(el.value) == false) {
        el.value = el.value.substring(0, el.value.length - 1);
    }
}

function validateAmount(event, controlName) {

    _NoofDecimals = 4;
    if (event.which == 0 || event.which == 8) {
        return;
    }
    if (event.which == 190) {
        event.preventDefault();
    }
    if (event.which == 46) {
        event.preventDefault();
    }
    if ($(controlName).val().split('.').length > 2) {
        event.preventDefault();
    }
    if ($(controlName).val().split('.').length == 2) {
        if ($(controlName).val().split('.')[1].length >= _NoofDecimals) {
            event.preventDefault();
        }
    }
    if ($(controlName).val().split('.')[0].length > 9) {
        event.preventDefault();
    }
}


function validateAmount(event, _this, obj) {

    _NoofDecimals = 4;
    if (event.which == 0 || event.which == 8) {
        return;
    }
    if (event.which == 190) {
        event.preventDefault();
    }
    if (event.which == 46) {
        event.preventDefault();
    }
    if ($(_this).val().split('.').length > 2) {
        event.preventDefault();
    }
    if ($(_this).val().split('.').length == 2) {
        if ($(_this).val().split('.')[1].length >= _NoofDecimals) {
            event.preventDefault();
        }
    }
    if ($(_this).val().split('.')[0].length > 9) {
        event.preventDefault();
    }
}

function validateAllocationAmount(event, controlName) {
    if (event.which == 0 || event.which == 8) {
        return;
    }
    if (event.which == 190) {
        event.preventDefault();
    }
    if ($(controlName).val().split('.')[0].length > 2 && event.which != 46 && $(controlName).val().split('.').length == 1) {
        event.preventDefault();
    }
    if (event.which == 46 && $(controlName).val().split('.').length > 1) {
        event.preventDefault();
    }
    if ($(controlName).val().split('.').length == 2) {
        if ($(controlName).val().split('.')[1].length > 1) {
            event.preventDefault();
        }
    }
}
function validatePinCode(pinCode) {
    var pincode_regex = /^\d{6}$/;
    if (pinCode.match(pincode_regex)) {
        return true;    //Valid
    } else {
        return false;   //InValid
    }
}

function validateLumpsumDate(testdate) {
    var date_regex = /^(0[1-9]|1[0-2])\/(0[1-9]|1\d|2\d|3[01])\/(19|20)\d{2}$/;  //mm/dd/yyyy regex

    if (!date_regex.test(testdate)) {
        return false //Invalid
    }
    else
        return true;
}

function isUrlSpclChar(value) {
    var iChars = "!#$%^&*()+=-[]\\\';./{}|\":<>@?,";
    for (var i = 0; i < value.length; i++) {
        if (iChars.indexOf(value.charAt(i)) != -1) {
            return false;
        }
    }
    return true;
}

function validate_CommaRound4_Amount(event, controlName) {
    if (event.which == 0 || event.which == 8) {
        return;
    }
    if (event.which == 190) {
        event.preventDefault();
    }
    if (event.which == 46 && $(controlName).val().split('.').length > 1) {
        event.preventDefault();
    }
    if ($(controlName).val().split('.').length == 2) {
        if ($(controlName).val().split('.')[1].length > 3) {
            event.preventDefault();
        }
        if ($(controlName).val().split('.')[0].length > 9) {
            event.preventDefault();
        }
    }
    else {
        if ($(controlName).val().split('.')[0].length > 9) {
            event.preventDefault();
        }
    }
}

function ValidatePassword(strPwd) {
    var regex = /^([a-zA-Z0-9 !@#$&*()-_^`]+)$/

    if (!regex.test(strPwd)) {
        return false //Invalid
    }
    else
        return true;
}

function isAddressSpclChar(value) {
    var iChars = "!#$%^*+=[]\\\;{}|\":<>@?";
    for (var i = 0; i < value.length; i++) {
        if (iChars.indexOf(value.charAt(i)) != -1) {
            return false;
        }
    }
    return true;
}

function ValidatePasswordNew(strPwd) {
    var regexDigit = /\d/
    var regexAlpha = /[a-zA-Z]/
    var regexSpecial = /^(?=.*[!@#$%^&*])/g
    var notAllowd = /\`|\~|\|\(|\)|\+|\=|\[|\{|\]|\}|\||\\|\'|\<|\,|\.|\>|\?|\/|\""|\;|\:|\s/g
    var msg = "";
    if (!regexDigit.test(strPwd)) {
        msg = "Password should have at least one number";
        return msg;
    }
    else if (!regexAlpha.test(strPwd)) {
        msg = "Password should have alphabets";
        return msg;
    }
    else if (!regexSpecial.test(strPwd)) {
        msg = "Password should have atleast one special character from !@#$%^&*";
        return msg;
    }
    else if (notAllowd.test(strPwd)) {
        msg = "Password should only have special character from !@#$%^&*";
        return msg;
    }
    else {
        msg = "success";
        return msg;
    }

}

function validateAadhar(aadharno) {
    var regexMobile = /^\d{12}$/g;
    var result;
    if (aadharno.match(regexMobile)) {
        return true;    //Valid
    } else {
        return false;   //InValid
    }
}

function IsAlphabeticInput(event) {
    var inputValue = event.which;
    if (!(inputValue >= 65 && inputValue <= 122) && (inputValue != 32 && inputValue != 0 && inputValue != 8)) {
        event.preventDefault();
    }
    if (inputValue == 94 || inputValue == 95 || inputValue == 93 || inputValue == 91 || inputValue == 92) {
        event.preventDefault();
    }
}

function IsAlphabeticWithSpaceInput(event) {
    var inputValue = event.which;
    if (!(inputValue >= 65 && inputValue <= 122) && (inputValue != 32 && inputValue != 0 && inputValue != 8)) {
        event.preventDefault();
    }
    if (inputValue == 94 || inputValue == 95 || inputValue == 93 || inputValue == 91 || inputValue == 92) {
        event.preventDefault();
    }
}

function IsNumericVal(e, $this) {
    //  var inputValue = event.which;
    if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
        e.preventDefault();
        return false;
    }
}

function Validate_DD_MMM_YYYY(_date) {
    var pattern = new RegExp(/^(([0-9])|([0-2][0-9])|([3][0-1]))\ (jan|feb|mar|apr|may|jun|jul|aug|sep|oct|nov|dec)\ \d{4}$/);
    var match = pattern.test(_date);
    return match;
}

// validate special character.

var specialKeys = new Array();
specialKeys.push(8); //Backspace
specialKeys.push(9); //Tab
specialKeys.push(46); //Delete
specialKeys.push(36); //Home
specialKeys.push(35); //End
specialKeys.push(37); //Left
specialKeys.push(39); //Right

function validatePanNo(e) {
    var keyCode = e.keyCode == 0 ? e.charCode : e.keyCode;
    var ret = ((keyCode >= 48 && keyCode <= 57) || (keyCode >= 65 && keyCode <= 90) || (keyCode >= 97 && keyCode <= 122) || (specialKeys.indexOf(e.keyCode) != -1 && e.charCode != e.keyCode));

    return ret;
}

function ValidateDistributorDetails(DistributorARN, SubDistributorARN, EuinDec, EUIN) {
    var isValid = false;
    var _DistributorARN = '';

    if (DistributorARN.indexOf('ARN-') != -1) {
        _DistributorARN = DistributorARN;
    } else {
        _DistributorARN = 'ARN-' + DistributorARN;
    }

    $('#dvloader').show();
    $.ajax({
        type: "POST",
        url: SiteRoot + '/OnlineApi/ValidateDistributorDetails',
        contentType: "application/x-www-form-urlencoded",
        async: false,
        data: {
            ARNcode: _DistributorARN,
            SubARNCode: SubDistributorARN,
            EUINDeclaration: EuinDec,
            EUIN: EUIN
        },
        success: function (data) {
            $('#dvloader').hide();
            if (data.status == 1) {
                isValid = true;
            }
            else if (data.status == -100 || data.status == 401) {
                //RedirectToLogin();
            }
            else {
                if (SourcePageType != 'NfoDistLead') {
                    ErrorPopup(data.message);
                }
            }
        },
        error: function (data, success, error) {
            console.log(error);
            $('#dvloader').hide();
        }
    });
    $('#dvloader').hide();
    return isValid;
}

function clearFieldVal() {
    for (i = 0; i < arguments.length; i++) {
        $(arguments[i]).val('');
    }
}

$("#newFolioPopup").on('shown.bs.modal', function () {
    clearFieldVal("#txtPAN", "#txtName", "#txtEmail", "#txtDOB", "#txtMobile");
});

function inputNumberAllowPasteV(e, $this) {

    if ($(window).width() <= 768) {
        setTimeout(function () {
            $($this).val($($this).val().replace(/[^0-9]/g, ''));
        }, 1);
    } else {
        if (e.shiftKey || e.altKey) {
            e.preventDefault();
        }
        if (allowNumberOnlyV(e.keyCode) && allowOtherReqKeysV(e.keyCode)) {
            if ((e.keyCode != 86 && e.keyCode != 118)) {
                event.preventDefault();
            }
            setTimeout(function () {
                $($this).val($($this).val().replace(/[^0-9]/g, ''));
            }, 10);
        }
    }

};


function inputTextDataNameV(e, $this) {
    setTimeout(function () {
        if ($($this).val()[0] == ' ' && $($this).val().length > 0) {
            $($this).val($($this).val().trim());
        }
    }, 10);
    if ($(window).width() <= 768) {
        setTimeout(function () {
            $($this).val($($this).val().replace(/[^a-zA-Z ]/g, ''));
            if ($($this).val()[0] == ' ' && $($this).val().length > 0) {
                $($this).val($($this).val().trim());
            }
        }, 10);
    } else {
        if ($($this).val() == "" && e.keyCode == 32) {
            event.preventDefault();
        } else if (allowAlhpabatesOnlyV(e.keyCode) && allowOtherReqKeysV(e.keyCode) && allowSpaceV(e.keyCode)) {
            event.preventDefault();
        }
    }
};

function allowNumberOnlyV(keyCode) {
    if (!(keyCode >= 48 && keyCode <= 57) && !(keyCode >= 96 && keyCode <= 105)) {
        return true;
    } else {
        return false;
    }
}

function allowOtherReqKeysV(keyCode) {
    if (!(keyCode >= 33 && keyCode <= 40) && keyCode != 8 && keyCode != 46 && keyCode != 17 && keyCode != 9 && keyCode != 144 && keyCode != 116) {
        return true;
    } else {
        return false;
    }
}

function allowAlhpabatesOnlyV(keyCode) {
    if (!(keyCode >= 65 && keyCode <= 90)) {
        return true;
    } else {
        return false;
    }
}

function allowSpaceV(keyCode) {

    if (keyCode != 32) {
        return true;
    } else {
        return false;
    }
}

