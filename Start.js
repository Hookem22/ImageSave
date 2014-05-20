var clientId;
function fnSetFocus(txtClientId) {

    clientId = txtClientId;
    setTimeout("fnFocus()", 1000);
}
function fnFocus() {
    var ckNull = document.getElementById(clientId);
    if (ckNull != null) {
        eval("document.getElementById('" + clientId + "').focus()");
    }
}

function SignUpClick() {
    fnSetFocus('nicknameTextBox');
    var couponRow = document.getElementById("CouponCodeRow");
    if (couponRow != null) {
        var panel = document.getElementById("popupRegister");
        panel.className = "popupRegisterCoupon";
    }
}

function LeftMouseOver() {
    document.getElementById("HeaderLabel").innerHTML = "Play for $2 to $100 against 2, 3, 6, or 10 People";
    document.getElementById("DemoDraftLabel").className = "marginTopHover";
    document.getElementById("DemoDraftLabel").innerHTML = "Demo Draft";

//    document.getElementById("DemoDraftBreak").className = "noShow";
//    document.getElementById("DemoDraftButton").className = "marginTop";
    document.getElementById("LeftMiddleDiv").className = "MiddleDivHover";
    document.getElementById("DemoArrow").className = "arrowLeft";
}
function LeftMouseOut() {
    document.getElementById("HeaderLabel").innerHTML = "Draft Your Team Right Now, Play For Cash Tonight";
    document.getElementById("DemoDraftLabel").className = "marginTop";
    document.getElementById("DemoDraftLabel").innerHTML = "Pick Your Team";

//    document.getElementById("DemoDraftBreak").className = "";
//    document.getElementById("DemoDraftButton").className = "noShow";
    document.getElementById("LeftMiddleDiv").className = "MiddleDiv";
    document.getElementById("DemoArrow").className = "noShow";
}
function CenterMouseOver() {
    document.getElementById("HeaderLabel").innerHTML = "Follow Your League with Real Time Stats";
    document.getElementById("InPlayLabel").className = "marginTopHover";
    document.getElementById("InPlayLabel").innerHTML = "Demo Stats";

//    document.getElementById("InPlayBreak").className = "noShow";
//    document.getElementById("InPlayButton").className = "marginTop";
    document.getElementById("CenterMiddleDiv").className = "MiddleDivHover";
    document.getElementById("InPlayArrow").className = "arrowLeft";
}
function CenterMouseOut() {
    document.getElementById("HeaderLabel").innerHTML = "Draft Your Team Right Now, Play For Cash Tonight";
    document.getElementById("InPlayLabel").className = "marginTop";
    document.getElementById("InPlayLabel").innerHTML = "Follow Your Team";

//    document.getElementById("InPlayBreak").className = "";
//    document.getElementById("InPlayButton").className = "noShow";
    document.getElementById("CenterMiddleDiv").className = "MiddleDiv";
    document.getElementById("InPlayArrow").className = "noShow";

}
function RightMouseOver() {
    document.getElementById("HeaderLabel").innerHTML = "Sign Up Now and Start Playing in Minutes";
    document.getElementById("PaidLabel").className = "marginTopHover";
    document.getElementById("PaidLabel").innerHTML = "Sign Up Now";

//    document.getElementById("StartSignUpButton").className = "";
    document.getElementById("RightMiddleDiv").className = "MiddleDivHover";
    document.getElementById("PaidArrow").className = "arrowRight";
}
function RightMouseOut() {
    document.getElementById("HeaderLabel").innerHTML = "Draft Your Team Right Now, Play For Cash Tonight";
    document.getElementById("PaidLabel").className = "marginTop";
    document.getElementById("PaidLabel").innerHTML = "Get Paid That Night";

//    document.getElementById("StartSignUpButton").className = "noShow";
    document.getElementById("RightMiddleDiv").className = "MiddleDiv";
    document.getElementById("PaidArrow").className = "noShow";

}
    