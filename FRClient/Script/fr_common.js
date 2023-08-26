
console.log("load common.");
var LAST_RT_HREF = "";


function send_common() {

    //返信のような気がする……
    if (window.innerWidth <600 && document.querySelectorAll("article").length > 0) {
        send_fr_skip("maybe reply");
        return;
    }

    //本文の取得
    let text = "";
    let editor = document.getElementsByClassName("DraftEditor-root");

    if (editor.length <= 0) {
        send_fr_skip("editor not found.");
        return;
    }
    text += editor[0].innerText;
    if (text.includes("いまどうしてる？")) {
        send_fr_skip("maybe no text");
        return;
    }

    //リツイートの取得（あれば）
    let rt_text = "";
    let at = document.querySelector('[data-testid = "attachments"]');
    if (at != null) {
        let rt = at.querySelector('[data-testid = "tweetText"]');
        if (rt != null) {
            rt_text = rt.innerText;
        }
    }

    //合成。🎴花札をセパレータとする（何故）
    let m_text = text.replace("🎴", "🃏");
    let m_rt = rt_text.replace("🎴", "🃏");
    let m_rt_href = LAST_RT_HREF.replace("🎴", "🃏");

    let message = m_text + "🎴" + m_rt + "🎴" + m_rt_href;

    //メッセージ送付（使う場所ごとに異なる）
    mylog("send from common:" + message);
    send_fr_message(message);
};

function on_click() {
    mylog("OnClick!");
    send_common();
}
function on_keydown(event) {
    //mylog("OnKeyDown!");
    if (event.isComposing || event.keyCode === 229) {
        //mylog("maybe IME enabled.");
        return;
    }
    if (!event.ctrlKey) {
        //mylog("!ctrlKey");
        return;
    }
    if (event.repeat) {
        //mylog("repeat");
        return;
    }
    if (event.code === "Enter") {
        mylog("Ctrl+Enter!");
        send_common();
    }
}
function on_retweet(event) {
    mylog("OnRetweet!");
    let element = event.currentTarget;
    while (element.parentNode) {
        element = element.parentNode;
        let tid = element.getAttribute("data-testid");
        //mylog("TID=" + tid);
        if (tid === "tweet") {
            let a_eles = element.getElementsByTagName("a");
            for (let i = 0; i < a_eles.length; i++) {
                let a_ele = a_eles[i];
                let is_rt = false;
                a_ele.childNodes.forEach((ele) => {
                    if (ele.tagName == "TIME") {
                        is_rt = true;
                    }
                });
                if (is_rt) {
                    LAST_RT_HREF = a_ele.href;
                    mylog("rt_href=" + LAST_RT_HREF);
                    break;
                }
            }
            break;
        }
    }
}
setInterval(() => {
    let button_element = document.querySelector('[data-testid = "tweetButton"]');
    if (button_element != null) {
        button_element.addEventListener("click", on_click, true);
        document.addEventListener("keydown", on_keydown, true);
        button_element.style.border = "5px solid blue";
    }

    let rt_elements = document.querySelectorAll('[data-testid = "retweet"]');
    if (rt_elements.length > 0) {
        rt_elements.forEach((ele) => {
            ele.style.backgroundColor = "#eef";
            ele.style.borderRadius = "6px";;
            ele.addEventListener("click", on_retweet, true);
        });
    }

    let img_elements = document.getElementsByTagName("h1");
    for (let i = 0; i < img_elements.length; i++) {
        img_elements[i].replaceChildren();
    }
}, 500);

let remove_count = 0;
const remove_loading = setInterval(() => {
    let img_elements = document.querySelectorAll('[aria-label="Loading…"]');
    if (img_elements.length > 0) {
        img_elements.forEach(ele => {
            ele.replaceChildren();
        });
        clearInterval(remove_loading);
    }
    remove_count++;
    if (remove_count > 300) {
        clearInterval(remove_loading);
    }

}, 10);

let old_error = "";
window.addEventListener('error', (event) => {
    //同じエラーが頻出したので、抑止します。
    if (old_error != event.message) {
        mylog(`ERR -> ${event.type}: ${event.message}`);
        old_error = event.message;
    }
});