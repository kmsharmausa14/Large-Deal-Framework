

function userValidBusiness() {

    var Requirement, Impact, Gaps, Owner, Level, ReviewDate;

    Requirement = document.getElementById("txtkeybusi").value;

    Impact = document.getElementById("txtimpact").value;

    Gaps = document.getElementById("txtgaps").value;

    Owner = document.getElementById("txtowner").value;

    Level = document.getElementById("ddllevel").value;

    ReviewDate = document.getElementById("datepicker").value;

    if (Requirement == '' || Impact == '' || Gaps == '' || Owner == '' || Level == '' || ReviewDate == '') {

        alert("All Fields are Mandatory");

        return false;

    }
    else {
        return true;
    }

}

function userValidTechnical() {

    var Requirement, Impact, Gaps, Owner, Level, ReviewDate;

    Requirement = document.getElementById("txtKeyReqTech").value;

    Impact = document.getElementById("txtImpactTech").value;

    Gaps = document.getElementById("txtGapsTech").value;

    Owner = document.getElementById("txtOwnerTech").value;

    Level = document.getElementById("ddLevelTech").value;

    ReviewDate = document.getElementById("txtDateTech").value;

    if (Requirement == '' || Impact == '' || Gaps == '' || Owner == '' || Level == '' || ReviewDate == '') {

        alert("All Fields are Mandatory");

        return false;

    }
    else {
        return true;
    }

}

function userValidService() {

    var Requirement, Impact, Gaps, Owner, Level, ReviewDate;

    Requirement = document.getElementById("txtKeyReqServ").value;

    Impact = document.getElementById("txtImpactServ").value;

    Gaps = document.getElementById("txtGapServ").value;

    Owner = document.getElementById("txtOwnerServ").value;

    Level = document.getElementById("ddLevelServ").value;

    ReviewDate = document.getElementById("txtDateServ").value;

    if (Requirement == '' || Impact == '' || Gaps == '' || Owner == '' || Level == '' || ReviewDate == '') {

        alert("All Fields are Mandatory");

        return false;

    }
    else {
        return true;
    }

}

function userValidTransition() {

    var Requirement, Impact, Gaps, Owner, Level, ReviewDate;

    Requirement = document.getElementById("txtKeyReqTrans").value;

    Impact = document.getElementById("txtImpactTrans").value;

    Gaps = document.getElementById("txtGapsTrans").value;

    Owner = document.getElementById("txtOwnrTrans").value;

    Level = document.getElementById("ddLevelTrans").value;

    ReviewDate = document.getElementById("txtDateTrans").value;

    if (Requirement == '' || Impact == '' || Gaps == '' || Owner == '' || Level == '' || ReviewDate == '') {

        alert("All Fields are Mandatory");

        return false;

    }
    else {
        return true;
    }

}

function userValidGovernance() {

    var Requirement, Impact, Gaps, Owner, Level, ReviewDate;

    Requirement = document.getElementById("txtKeyReqGov").value;

    Impact = document.getElementById("txtImpactGov").value;

    Gaps = document.getElementById("txtGapsGov").value;

    Owner = document.getElementById("txtOwnrGov").value;

    Level = document.getElementById("ddLevelGov").value;

    ReviewDate = document.getElementById("txtDateGov").value;

    if (Requirement == '' || Impact == '' || Gaps == '' || Owner == '' || Level == '' || ReviewDate == '') {

        alert("All Fields are Mandatory");

        return false;

    }
    else {
        return true;
    }

}

function userValidProcess() {

    var Requirement, Impact, Gaps, Owner, Level, ReviewDate;

    Requirement = document.getElementById("txtKeyReqProc").value;

    Impact = document.getElementById("txtImpactProc").value;

    Gaps = document.getElementById("txtGapsProc").value;

    Owner = document.getElementById("txtOwnrProc").value;

    Level = document.getElementById("ddLevelProc").value;

    ReviewDate = document.getElementById("txtDateProc").value;

    if (Requirement == '' || Impact == '' || Gaps == '' || Owner == '' || Level == '' || ReviewDate == '') {

        alert("All Fields are Mandatory");

        return false;

    }
    else {
        return true;
    }

}

function userValidHR() {

    var Requirement, Impact, Gaps, Owner, Level, ReviewDate;

    Requirement = document.getElementById("txtKeyReqHR").value;

    Impact = document.getElementById("txtImpactHR").value;

    Gaps = document.getElementById("txtGapsHR").value;

    Owner = document.getElementById("txtOwnrHR").value;

    Level = document.getElementById("ddLevelHR").value;

    ReviewDate = document.getElementById("txtDateHR").value;

    if (Requirement == '' || Impact == '' || Gaps == '' || Owner == '' || Level == '' || ReviewDate == '') {

        alert("All Fields are Mandatory");

        return false;

    }
    else {
        return true;
    }

}

function userValidCommercial() {

    var Requirement, Impact, Gaps, Owner, Level, ReviewDate;

    Requirement = document.getElementById("txtKeyReqCom").value;

    Impact = document.getElementById("txtImpactCom").value;

    Gaps = document.getElementById("txtGapsCom").value;

    Owner = document.getElementById("txtOwnrCom").value;

    Level = document.getElementById("ddLevelCom").value;

    ReviewDate = document.getElementById("txtDateCom").value;

    if (Requirement == '' || Impact == '' || Gaps == '' || Owner == '' || Level == '' || ReviewDate == '') {

        alert("All Fields are Mandatory");

        return false;

    }
    else {
        return true;
    }

}

function userValidIntegration() {

    var Requirement, Impact, Gaps, Owner, Level, ReviewDate;

    Requirement = document.getElementById("txtKeyReqInt").value;

    Impact = document.getElementById("txtImpactInt").value;

    Gaps = document.getElementById("txtGapsInt").value;

    Owner = document.getElementById("txtOwnrInt").value;

    Level = document.getElementById("ddLevelInt").value;

    ReviewDate = document.getElementById("txtDateInt").value;

    if (Requirement == '' || Impact == '' || Gaps == '' || Owner == '' || Level == '' || ReviewDate == '') {

        alert("All Fields are Mandatory");

        return false;

    }
    else {
        return true;
    }

}

function gvBusinessValidate(rowIndex) {

    var grid = document.getElementById('gridbusiness');
    if (grid != null) {
        var Inputs = grid.rows[rowIndex + 1].getElementsByTagName("input");
        for (i = 0; i < Inputs.length; i++) {
            if (Inputs[i].type == 'text') {
                if (Inputs[i].value == "") {
                    alert("Enter values,blank is not allowed");
                    return false;
                }

            }
        }
        return true;
    }
}

function gvtechnicalValidate(rowIndex) {

    var grid = document.getElementById('gridtechnical');
    if (grid != null) {
        var Inputs = grid.rows[rowIndex + 1].getElementsByTagName("input");
        for (i = 0; i < Inputs.length; i++) {
            if (Inputs[i].type == 'text') {
                if (Inputs[i].value == "") {
                    alert("Enter values,blank is not allowed");
                    return false;
                }

            }
        }
        return true;
    }
}


function gvServiceValidate(rowIndex) {

    var grid = document.getElementById('gridservice');
    if (grid != null) {
        var Inputs = grid.rows[rowIndex + 1].getElementsByTagName("input");
        for (i = 0; i < Inputs.length; i++) {
            if (Inputs[i].type == 'text') {
                if (Inputs[i].value == "") {
                    alert("Enter values,blank is not allowed");
                    return false;
                }

            }
        }
        return true;
    }
}

function gvtransValidate(rowIndex) {

    var grid = document.getElementById('gridtransition');
    if (grid != null) {
        var Inputs = grid.rows[rowIndex + 1].getElementsByTagName("input");
        for (i = 0; i < Inputs.length; i++) {
            if (Inputs[i].type == 'text') {
                if (Inputs[i].value == "") {
                    alert("Enter values,blank is not allowed");
                    return false;
                }

            }
        }
        return true;
    }
}

function gvgovernValidate(rowIndex) {

    var grid = document.getElementById('gridgovern');
    if (grid != null) {
        var Inputs = grid.rows[rowIndex + 1].getElementsByTagName("input");
        for (i = 0; i < Inputs.length; i++) {
            if (Inputs[i].type == 'text') {
                if (Inputs[i].value == "") {
                    alert("Enter values,blank is not allowed");
                    return false;
                }

            }
        }
        return true;
    }
}

function gvprocessValidate(rowIndex) {

    var grid = document.getElementById('gridprocess');
    if (grid != null) {
        var Inputs = grid.rows[rowIndex + 1].getElementsByTagName("input");
        for (i = 0; i < Inputs.length; i++) {
            if (Inputs[i].type == 'text') {
                if (Inputs[i].value == "") {
                    alert("Enter values,blank is not allowed");
                    return false;
                }

            }
        }
        return true;
    }
}

function gvHRValidate(rowIndex) {

    var grid = document.getElementById('gridhr');
    if (grid != null) {
        var Inputs = grid.rows[rowIndex + 1].getElementsByTagName("input");
        for (i = 0; i < Inputs.length; i++) {
            if (Inputs[i].type == 'text') {
                if (Inputs[i].value == "") {
                    alert("Enter values,blank is not allowed");
                    return false;
                }

            }
        }
        return true;
    }
}

function gvCommercialValidate(rowIndex) {

    var grid = document.getElementById('gridcommercial');
    if (grid != null) {
        var Inputs = grid.rows[rowIndex + 1].getElementsByTagName("input");
        for (i = 0; i < Inputs.length; i++) {
            if (Inputs[i].type == 'text') {
                if (Inputs[i].value == "") {
                    alert("Enter values,blank is not allowed");
                    return false;
                }

            }
        }
        return true;
    }
}

function gvIntegrationValidate(rowIndex) {

    var grid = document.getElementById('gridintegration');
    if (grid != null) {
        var Inputs = grid.rows[rowIndex + 1].getElementsByTagName("input");
        for (i = 0; i < Inputs.length; i++) {
            if (Inputs[i].type == 'text') {
                if (Inputs[i].value == "") {
                    alert("Enter values,blank is not allowed");
                    return false;
                }

            }
        }
        return true;
    }
}


function validateCharLimit(area) {
    //debugger;
    var limit = 50;
    var iChars = area.value.length;
    if (iChars > limit) {
        return false;
    }
    return true;
}

function ValidText(evt, val) {
    if (val.length >= 250) {
        alert("Only 250 characters allowed");
        val = val.substring(0, 250);
        return false;
    }
    return true;
}

function maxLengthPaste(field, maxChars) {
    event.returnValue = false;
    if ((field.value.length + window.clipboardData.getData("Text").length) > maxChars) {
        alert("Only 250 characters allowed")
        return false;
    }
    event.returnValue = true;
}

function show_alert() {
    var answer = (confirm("Are you sure you want to remove this Requirement?"));
    if (answer == true)
        return true;
    else {
        return false;
    }
}

function showTable1() {
    //debugger;
    if (document.getElementById('radiointegration').checked) {
        tblbussinesssolutuions.style.display = "block";
        
    }
}

function show_submit_alert() {
    return checknotapprovedcoments();
    var answer = (confirm("The RGY Type could not be changed after Submitting. Are you sure you want to submit?"));
    if (answer == true)
        return true;
    else {
        return false;
    }
}

function checknotapprovedcoments() {

    var approvalstatus = document.getElementById("ddlapproval").value;
    if (approvalstatus == 2) {
        var comenttext = document.getElementById("txtcomments").value;
        if (comenttext == '') {
            alert("Please enter Comments for your Not Approving.");
            return false;
        }
        //alert(comenttext);
        return true;
    }

}


function checkRGYtype() {

    var RGYval = document.getElementById("ddlrgytype").value;
    if (RGYval == 0) {
        alert("Please RGY Checklist Type.");
        return false;
    }
    if (RGYval == 2) {
        var yesorno = confirm("The RGYType cannot be changed once you have saved a Final Checklist. Are you sure you want to create a Final Checklist?");
        if (yesorno == true) {
            return true;
        }
        else {
            return false;
        }
    }
}

function Calculate() {

    var grid = document.getElementById("gvRGYWeightage");
    var sum = 0;
        for(var i=1; i<= 9; i++)
        {
            var Cell = grid.rows[1].cells[i].childNodes[1].value;
            sum = parseInt(sum) + parseInt(Cell); 
        }

    if (sum > 100) {
        alert("The Total Weightage should be Equal to 100. Current Total=" + sum);
        return false;
    }
    else if (sum < 100) {
        alert("The Total Weightage should be Equal to 100. Current Total=" + sum);
        return false;
    }
    else {
        return true;
    }

}

function validateQualificationScore() {
    debugger;
    var grid = document.getElementById("gvAccountQualification");
    var Cell1 = grid.rows[1].cells[3].innerText;
    var Cell2 = grid.rows[2].cells[3].innerText; ;
    var Cell3 = grid.rows[3].cells[3].innerText; ;

    return false;

}