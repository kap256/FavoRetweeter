﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace FRClient.Properties {
    using System;
    
    
    /// <summary>
    ///   ローカライズされた文字列などを検索するための、厳密に型指定されたリソース クラスです。
    /// </summary>
    // このクラスは StronglyTypedResourceBuilder クラスが ResGen
    // または Visual Studio のようなツールを使用して自動生成されました。
    // メンバーを追加または削除するには、.ResX ファイルを編集して、/str オプションと共に
    // ResGen を実行し直すか、または VS プロジェクトをビルドし直します。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   このクラスで使用されているキャッシュされた ResourceManager インスタンスを返します。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("FRClient.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   すべてについて、現在のスレッドの CurrentUICulture プロパティをオーバーライドします
        ///   現在のスレッドの CurrentUICulture プロパティをオーバーライドします。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   
        ///console.log(&quot;init css&quot;);
        ///
        ///const FR_Client_Style = document.createElement(&quot;style&quot;);
        ///FR_Client_Style.type = &quot;text/css&quot;;
        ///FR_Client_Style.appendChild(document.createTextNode(&quot;&quot;));
        ///document.head.appendChild(FR_Client_Style);
        /// に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string css_init {
            get {
                return ResourceManager.GetString("css_init", resourceCulture);
            }
        }
        
        /// <summary>
        ///   
        ///console.log(&quot;reload css&quot;);
        ///
        ///FR_Client_Style.textContent = `__css_string__`; に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string css_reload {
            get {
                return ResourceManager.GetString("css_reload", resourceCulture);
            }
        }
        
        /// <summary>
        ///   
        ///console.log(&quot;load common&quot;);
        ///var LAST_RT_HREF = &quot;&quot;;
        ///
        ///function send_common() {
        ///
        ///    //本文の取得
        ///    let text = &quot;&quot;;
        ///    let editor = document.getElementsByClassName(&quot;DraftEditor-root&quot;);
        ///
        ///    if (editor.length &lt;= 0) {
        ///        console.log(&quot;editor not found.&quot;);
        ///        return;
        ///    }
        ///    text += editor[0].innerText;
        ///    if (text.includes(&quot;いまどうしてる？&quot;)) {
        ///        console.log(&quot;maybe no text&quot;);
        ///        return;
        ///    }
        ///
        ///    //リツイートの取得（あれば）
        ///    let rt_text = &quot;&quot;;
        ///    let at = document.querySelector(&apos;[data [残りの文字列は切り詰められました]&quot;; に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string fr_common {
            get {
                return ResourceManager.GetString("fr_common", resourceCulture);
            }
        }
        
        /// <summary>
        ///   
        ///console.log(&quot;load for net&quot;);
        ///function send_fr_message(message) {
        ///
        ///    console.log(&quot;send_fr_message:&quot; + message);
        ///    window.chrome.webview.postMessage(message);
        ///
        ///}; に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string fr_net {
            get {
                return ResourceManager.GetString("fr_net", resourceCulture);
            }
        }
        
        /// <summary>
        ///   (アイコン) に類似した型 System.Drawing.Icon のローカライズされたリソースを検索します。
        /// </summary>
        internal static System.Drawing.Icon icon {
            get {
                object obj = ResourceManager.GetObject("icon", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        /// <summary>
        ///   header[role=&quot;banner&quot;] {
        ///    display: none;
        ///}
        ///div[data-testid = &quot;cellInnerDiv&quot;]:has([data-testid = &quot;placementTracking&quot;]) {
        ///    display: none;
        ///}
        ///div[role=&quot;progressbar&quot;] +div:has([data-testid = &quot;tweetButtonInline&quot;]){
        ///    display: none;
        ///}
        ///
        ////*
        ///    リンクや画像の高さを制限する
        ///div[aria-labelledby]:has(a) * {
        ///    max-height: 100px;
        ///}
        ///
        ///*/ に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string style_twitter_common {
            get {
                return ResourceManager.GetString("style_twitter_common", resourceCulture);
            }
        }
        
        /// <summary>
        ///   header.{
        ///    display: none;
        ///}
        ///div[data-testid = &quot;cellInnerDiv&quot;]:has([data-testid = &quot;placementTracking&quot;]) {
        ///    display: none;
        ///}
        ///div[role=&quot;progressbar&quot;] +div:has([data-testid = &quot;tweetButtonInline&quot;]){
        ///    display: none;
        ///}
        ///
        ////*
        ///    リンクや画像の高さを制限する
        ///div[aria-labelledby]:has(a) * {
        ///    max-height: 100px;
        ///}
        ///
        ///*/ に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string style_twitter_post {
            get {
                return ResourceManager.GetString("style_twitter_post", resourceCulture);
            }
        }
        
        /// <summary>
        ///   
        ///console.log(&quot;load reloader&quot;);
        ///
        ///
        ///if (typeof FocusIntervalID !== &apos;undefined&apos;) {
        ///    clearInterval(FocusIntervalID);
        ///}
        ///if (typeof ReloadIntervalID !== &apos;undefined&apos;) {
        ///    clearInterval(ReloadIntervalID);
        ///}
        ///
        ///FocusIntervalID = setInterval(() =&gt; {
        ///    if (window.scrollY &gt; 100) {
        ///        return;
        ///    }
        ///    window.dispatchEvent(new Event(&quot;focus&quot;));
        ///    console.log(&quot;send focus&quot;);
        ///}, 1000 * __focus_interval__)
        ///
        ///function FRWEBVIEW_RELOAD_TWITTER() {
        ///    if (window.scrollY &gt; 100) {
        ///        console.l [残りの文字列は切り詰められました]&quot;; に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string tweet_reloader {
            get {
                return ResourceManager.GetString("tweet_reloader", resourceCulture);
            }
        }
    }
}
