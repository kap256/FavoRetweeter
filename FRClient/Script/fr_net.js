
console.log("load for net");

function mylog(text) {

    console.log(text);
    window.chrome.webview.postMessage("LG" + text);
}

function send_fr_message(message) {

    console.log("send_fr_message:" + message);
    window.chrome.webview.postMessage("MS"+message);

};