
console.log("load content");

function mylog(text) {

    console.log(text);
}
function send_fr_message(message) {

    console.log("send_fr_message:" + message);
    browser.runtime.sendMessage(
        { "mes": message }
    );
};
function send_fr_skip(message) {

    console.log(message);
};