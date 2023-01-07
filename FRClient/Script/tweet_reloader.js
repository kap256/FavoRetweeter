
console.log("load reloader");


if (typeof FocusIntervalID !== 'undefined') {
    clearInterval(FocusIntervalID);
}
if (typeof ReloadIntervalID !== 'undefined') {
    clearInterval(ReloadIntervalID);
}

FocusIntervalID = setInterval(() => {
    if (window.scrollY > 100) {
        return;
    }
    window.dispatchEvent(new Event("focus"));
    console.log("send focus");
}, 1000 * __focus_interval__)

function FRWEBVIEW_RELOAD_TWITTER() {
    if (window.scrollY > 100) {
        console.log("maybe now reading.");
        return false;
    }
    let divs = document.querySelectorAll('[data-testid = "cellInnerDiv"]');

    for (let i = 0; i < divs.length; i++) {
        let maybe_button = (divs[i].firstChild.firstChild);
        if (maybe_button.getAttribute("role") === "button") {
            maybe_button.click();
            return true;
        }
    }
    return false;
}