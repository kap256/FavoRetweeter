
console.log("load for net");

function mylog(text) {

    console.log(text);
    window.chrome.webview.postMessage("LG" + text);
}

function send_fr_message(message) {

    console.log("send_fr_message:" + message);
    window.chrome.webview.postMessage("MS" + message);
};
function send_fr_skip(message) {

    console.log("send_fr_skip:" + message);
    window.chrome.webview.postMessage("SK" + message);

};