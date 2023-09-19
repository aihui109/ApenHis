/* eslint-disable */

(function (window, undefined) {
  window.Asc.plugin.init = function (initData) {
    console.log('filler插件开始初始化');

    window.Asc.plugin.event_onDocumentContentReady = function () {
      console.log('filler插件:文档加载完成');
      // window.Asc.plugin.executeMethod("GetFormValue", ["2702"], function (res) {
      //   console.log(res)
      // });
      window.Asc.plugin.executeMethod ("SetFormValue", ["2702", "true"]);
      window.Asc.plugin.executeMethod ("GetAllForms", null, function (data) {
        for (var i = 0; i < data.length; i++) {
            if (data[i].InternalId == "2702") {
                this.Asc.plugin.executeMethod ("SelectContentControl", [data[i].InternalId]);
                break;
            }
        }
    });
    }
  }
})(window, undefined)
