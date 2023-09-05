(function(window, undefined) {
    window.Asc.plugin.init = function(initData) {
      window.Asc.plugin.onDocumentContentReady = function() {
        alert("sample");
      }
    }
  })(window, undefined);