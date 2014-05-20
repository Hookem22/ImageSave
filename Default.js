function DownloadClick() {
    var imageList = getbyclass("imageSelected");
    var srcString = "";
    for (var i = 0, ii = imageList.length; i < ii; i++) {
        srcString += imageList[i].longDesc + ";;";
    }

    document.getElementById("DownloadTextBox").value = srcString;
    document.getElementById('DownloadButton').click();
}

function DownloadSuccess() {
}

function DownloadFail() {
}

function CheckChanged(ID, checkedClass) {
    var checkBoxDivName = "ImageRepeater_ctl0" + ID.toString() + "_checkBoxDiv";
    var checkBoxDiv = document.getElementById(checkBoxDivName);
    if (checkBoxDiv == null) {
        checkBoxDivName = "ImageRepeater_ctl" + ID.toString() + "_checkBoxDiv";
        checkBoxDiv = document.getElementById(checkBoxDivName);
    }
    if (checkBoxDiv == null) {
        checkBoxDivName = "ImageRepeater_checkBoxDiv_" + ID.toString();
        checkBoxDiv = document.getElementById(checkBoxDivName);       
    }

    var imageName = "ImageRepeater_ctl0" + ID.toString() + "_Image";
    var img = document.getElementById(imageName);
    if (img == null) {
        imageName = "ImageRepeater_ctl" + ID.toString() + "_Image";
        img = document.getElementById(imageName);
    }
    if (img == null) {
        imageName = "ImageRepeater_Image_" + ID.toString();
        img = document.getElementById(imageName);
    }

    var coverDivName = "ImageRepeater_ctl0" + ID.toString() + "_coverDiv";
    var coverDiv = document.getElementById(coverDivName);
    if (coverDiv == null) {
        coverDivName = "ImageRepeater_ctl" + ID.toString() + "_coverDiv";
        coverDiv = document.getElementById(coverDivName);
    }
    if (coverDiv == null) {
        coverDivName = "ImageRepeater_coverDiv_" + ID.toString();
        coverDiv = document.getElementById(coverDivName);
    }

    if (checkedClass == "checkBoxSelected") {
        img.className = "";
        coverDiv.className = "coverDiv";
        checkBoxDiv.className = "checkBoxNotSelected";
    }
    else {
        img.className = "imageSelected";
        coverDiv.className = "";
        checkBoxDiv.className = "checkBoxSelected";
    }

    var imageList = getbyclass("imageSelected");
    var srcString = "";
    for (var i = 0, ii = imageList.length; i < ii; i++) {
        srcString += imageList[i].longDesc + ";;";
    }

    document.getElementById("DownloadTextBox").value = srcString;
}

function SelectAll() {

    for (var i = 0; i < 50; i++) {
        var checkBoxDivName = "ImageRepeater_ctl0" + i.toString() + "_checkBoxDiv";
        var checkBoxDiv = document.getElementById(checkBoxDivName);
        if (checkBoxDiv == null) {
            checkBoxDivName = "ImageRepeater_ctl" + i.toString() + "_checkBoxDiv";
            checkBoxDiv = document.getElementById(checkBoxDivName);
        }
        if (checkBoxDiv == null) {
            checkBoxDivName = "ImageRepeater_checkBoxDiv_" + i.toString();
            checkBoxDiv = document.getElementById(checkBoxDivName);
        }
        if (checkBoxDiv == null) {
            break;
        }

        var imageName = "ImageRepeater_ctl0" + i.toString() + "_Image";
        var img = document.getElementById(imageName);
        if (img == null) {
            imageName = "ImageRepeater_ctl" + i.toString() + "_Image";
            img = document.getElementById(imageName);
        }
        if (img == null) {
            imageName = "ImageRepeater_Image_" + i.toString();
            img = document.getElementById(imageName);
        }

        var coverDivName = "ImageRepeater_ctl0" + i.toString() + "_coverDiv";
        var coverDiv = document.getElementById(coverDivName);
        if (coverDiv == null) {
            coverDivName = "ImageRepeater_ctl" + i.toString() + "_coverDiv";
            coverDiv = document.getElementById(coverDivName);
        }
        if (coverDiv == null) {
            coverDivName = "ImageRepeater_coverDiv_" + i.toString();
            coverDiv = document.getElementById(coverDivName);
        }

        img.className = "imageSelected";
        coverDiv.className = "";
        checkBoxDiv.className = "checkBoxSelected";
    }

    var imageList = getbyclass("imageSelected");
    var srcString = "";
    for (var i = 0, ii = imageList.length; i < ii; i++) {
        srcString += imageList[i].longDesc + ";;";
    }

    document.getElementById("DownloadTextBox").value = srcString;
}
function UnselectAll() {

    for (var i = 0; i < 50; i++) {
        var checkBoxDivName = "ImageRepeater_ctl0" + i.toString() + "_checkBoxDiv";
        var checkBoxDiv = document.getElementById(checkBoxDivName);
        if (checkBoxDiv == null) {
            checkBoxDivName = "ImageRepeater_ctl" + i.toString() + "_checkBoxDiv";
            checkBoxDiv = document.getElementById(checkBoxDivName);
        }
        if (checkBoxDiv == null) {
            checkBoxDivName = "ImageRepeater_checkBoxDiv_" + i.toString();
            checkBoxDiv = document.getElementById(checkBoxDivName);
        }
        if (checkBoxDiv == null) {
            break;
        }

        var imageName = "ImageRepeater_ctl0" + i.toString() + "_Image";
        var img = document.getElementById(imageName);
        if (img == null) {
            imageName = "ImageRepeater_ctl" + i.toString() + "_Image";
            img = document.getElementById(imageName);
        }
        if (img == null) {
            imageName = "ImageRepeater_Image_" + i.toString();
            img = document.getElementById(imageName);
        }

        var coverDivName = "ImageRepeater_ctl0" + i.toString() + "_coverDiv";
        var coverDiv = document.getElementById(coverDivName);
        if (coverDiv == null) {
            coverDivName = "ImageRepeater_ctl" + i.toString() + "_coverDiv";
            coverDiv = document.getElementById(coverDivName);
        }
        if (coverDiv == null) {
            coverDivName = "ImageRepeater_coverDiv_" + i.toString();
            coverDiv = document.getElementById(coverDivName);
        }

        img.className = "";
        coverDiv.className = "coverDiv";
        checkBoxDiv.className = "checkBoxNotSelected";
    }

    var imageList = getbyclass("imageSelected");
    var srcString = "";
    for (var i = 0, ii = imageList.length; i < ii; i++) {
        srcString += imageList[i].longDesc + ";;";
    }

    document.getElementById("DownloadTextBox").value = srcString;
}

function getbyclass(n) {
    var elements = document.getElementsByTagName("*");
    var result = [];
    for (z = 0; z < elements.length; z++) {
        if (elements[z].getAttribute("class") == n) {
            result.push(elements[z]);
        }
    }
    return result;
}

function ReturnPress(e, buttonid) {
    var evt = e ? e : window.event;
    var bt = document.getElementById(buttonid);
    if (bt) {
        if (evt.keyCode == 13) {
            bt.click();
            return false;
        }
    }
}