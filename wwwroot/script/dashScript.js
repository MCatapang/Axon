let moreOptions = document.getElementById("moreOptions");
let optionsDropdown = document.getElementById("optionsDropdown");
let navLinkContainer = document.getElementById("navLinkContainer");
let navBar = document.getElementById("navBar");
let formPopUpButton = document.getElementById("formPopUpButton");
let formPopUp = document.getElementById("formPopUp");
let toggleDropdown = false;
let togglePopUpForm = false;

function scrollFunction() {
    if(document.body.scrollTop > 40 || document.documentElement.scrollTop > 40) {
        document.getElementById("navBar").style.height = "75px";
        document.getElementById("navLinkContainer").style.transform = "translate(500px)";
        document.getElementById("navLogo").style.fontSize = "25px";
        document.getElementById("navLogo").style.color = "#0095ff";
        if(toggleDropdown) {
            optionsDropdown.style.top = "-300px";
            optionsDropdown.style.opacity = "0";
        }
    } else {
        document.getElementById("navBar").style.height = "125px";
        document.getElementById("navLinkContainer").style.transform = "translate(0px)";
        document.getElementById("navLogo").style.fontSize = "75px";
        document.getElementById("navLogo").style.color = "#ffffff";
        if(toggleDropdown) {
            optionsDropdown.style.top = "125px";
            optionsDropdown.style.opacity = "1";
        }
    }
}
window.onscroll = function() {
    scrollFunction();
}




moreOptions.addEventListener("click", function(){
    if(toggleDropdown == false) {
        optionsDropdown.style.top = "125px";
        optionsDropdown.style.opacity = "1";
        moreOptions.style.transform = "rotate(180deg)";
        moreOptions.style.color = "#0095ff";
        toggleDropdown = true;
    } else {
        optionsDropdown.style.top = "-100px";
        optionsDropdown.style.opacity = "0";
        moreOptions.style.transform = "";
        moreOptions.style.color = "#ffffff";
        toggleDropdown = false;
    }
});

setInterval("setTime()", 1000);
const start = new Date();
const startHour = start.getHours();
const startMinute = start.getMinutes();
const startSecond = start.getSeconds();
function setTime() {
    
    let end = new Date();
    /* ----Temporarily commentd out for future implementation
    of Shift Runtime feature

    let endHour = end.getHours();
    let endMinute = end.getMinutes();
    let endSecond = end.getSeconds();

    let elapsedH = endHour - startHour;
    let elapsedM = endMinute - startMinute;
    let elapsedS = endSecond - startSecond; 
    
    if(elapsedM < 0) {
        elapsedM = 60 + elapsedM;
    }
    if(elapsedS < 0) {
        elapsedS = 60 + elapsedS;
    }
    if(elapsedM < 10) {
        elapsedM = "0" + elapsedM;
    }
    if(elapsedS < 10) {
        elapsedS = "0" + elapsedS;
    }

    let time = "" + elapsedH + ":" + elapsedM + ":" + elapsedS;

    */

    // Currently setting time to 
    document.getElementById("clock").innerText = end.toTimeString();
}

formPopUpButton.addEventListener("click", function(){
    console.log("Hellooooo");
    if(togglePopUpForm == false) {
        console.log("it's false");
        formPopUp.style.display = "flex";
        togglePopUpForm = true;
    } else {
        formPopUp.style.display = "none";
        togglePopUpForm = false;
    }
});