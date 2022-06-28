function scrollFunction() {
    if(document.body.scrollTop > 40 || document.documentElement.scrollTop > 40) {
        document.getElementById("navBar").style.height = "100px";
    } else {
        document.getElementById("navBar").style.height = "125px";
    }
}
window.onscroll = function() {
    scrollFunction();
}