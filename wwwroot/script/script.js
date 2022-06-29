function scrollFunction() {
    if(document.body.scrollTop > 40 || document.documentElement.scrollTop > 40) {
        document.getElementById("navBar").style.height = "75px";
        document.getElementById("navLinkContainer").style.transform = "translate(500px)";
        document.getElementById("navLogo").style.fontSize = "25px";
        document.getElementById("navLogo").style.color = "#0095ff";
    } else {
        document.getElementById("navBar").style.height = "125px";
        document.getElementById("navLinkContainer").style.transform = "translate(0px)";
        document.getElementById("navLogo").style.fontSize = "75px";
        document.getElementById("navLogo").style.color = "#ffffff";
    }
}
window.onscroll = function() {
    scrollFunction();
}