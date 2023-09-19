/* eslint-disable */

(function (window, undefined) {
  window.Asc.plugin.init = function (initData) {
    console.log('filler插件开始初始化');

    window.Asc.plugin.event_onDocumentContentReady = function () {
      console.log('filler插件:文档加载完成');
      // window.Asc.plugin.executeMethod("GetFormValue", ["2702"], function (res) {
      //   console.log(res)
      // });
      window.Asc.plugin.executeMethod ("GetAllForms", null, function (data) {
        for (var i = 0; i < data.length; i++) {
            if (data[i].Tag == "Text1") {
                // this.Asc.plugin.executeMethod ("SelectContentControl", [data[i].InternalId]);
                window.Asc.plugin.executeMethod ("SetFormValue", [data[i].InternalId, "true"]);
                continue;
            }
            if (data[i].Tag == "Text2") {
              window.Asc.plugin.executeMethod ("SetFormValue", [data[i].InternalId, "false"]);
              continue;
          }
        }
    });
    }
  }
})(window, undefined)
