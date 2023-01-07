
console.log("load background");
browser.runtime.onMessage.addListener(notify);

function notify(message) {

    console.log("message recieve:" + message.mes);

    let sending = browser.runtime.sendNativeMessage(
        "756e7162_a066_4e77_favoretweeter",
        message.mes);

    console.log("Sended.");
}
