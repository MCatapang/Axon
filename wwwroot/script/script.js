let moreOptions = document.getElementById("moreOptions");
let optionsDropdown = document.getElementById("optionsDropdown");
let navLinkContainer = document.getElementById("navLinkContainer");
let navBar = document.getElementById("navBar");
let toggle = false;

function scrollFunction() {
    if(document.body.scrollTop > 40 || document.documentElement.scrollTop > 40) {
        document.getElementById("navBar").style.height = "75px";
        document.getElementById("navLinkContainer").style.transform = "translate(500px)";
        document.getElementById("navLogo").style.fontSize = "25px";
        document.getElementById("navLogo").style.color = "#0095ff";
        if(toggle) {
            optionsDropdown.style.top = "-300px";
            optionsDropdown.style.opacity = "0";
        }
    } else {
        document.getElementById("navBar").style.height = "125px";
        document.getElementById("navLinkContainer").style.transform = "translate(0px)";
        document.getElementById("navLogo").style.fontSize = "75px";
        document.getElementById("navLogo").style.color = "#ffffff";
        if(toggle) {
            optionsDropdown.style.top = "125px";
            optionsDropdown.style.opacity = "1";
        }
    }
}
window.onscroll = function() {
    scrollFunction();
}

moreOptions.addEventListener("click", function(){
    if(toggle == false) {
        optionsDropdown.style.top = "125px";
        optionsDropdown.style.opacity = "1";
        moreOptions.style.transform = "rotate(180deg)";
        moreOptions.style.color = "#0095ff";
        toggle = true;
    } else {
        optionsDropdown.style.top = "-100px";
        optionsDropdown.style.opacity = "0";
        moreOptions.style.transform = "";
        moreOptions.style.color = "#ffffff";
        toggle = false;
    }
});