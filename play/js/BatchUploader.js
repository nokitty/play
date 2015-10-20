var BatchUploader = (function () {
    function BatchUploader() {
        this.totalSize = 0;
        this.loadedSize = 0;
        this.currentIndex = 0;
        this.url = "";
        this.chunkSize = 256 * 1024;
        this.onProgress = null;
        this.onDone = null;
        this.onError = null;
        this.list = new Array();
        this.doneDataList = [];
    }
    BatchUploader.prototype.add = function (file) {
        var uploader = new Uploader(file);
        uploader.url = this.url;
        uploader.chunkSize = this.chunkSize;
        this.list.push(uploader);
        this.totalSize += file.size;
    };
    BatchUploader.prototype.start = function () {
        var _this = this;
        if (this.currentIndex != this.list.length) {
            var u = this.list[this.currentIndex];
            u.onError = function (msg) {
                if (_this.onError != null)
                    _this.onError(msg);
            };
            u.onProgress = function (p) {
                var p1 = (_this.loadedSize + u.file.size * p) / _this.totalSize;
                if (_this.onProgress != null)
                    _this.onProgress(p1);
            };
            u.onDone = function (data) {
                _this.doneDataList.push(data);
                _this.loadedSize += u.file.size;
                _this.start();
            };
            u.start();
            this.currentIndex++;
        }
        else {
            if (this.onDone != null)
                this.onDone(this.doneDataList);
        }
    };
    BatchUploader.prototype.stop = function () {
        this.list[this.currentIndex].stop();
    };
    return BatchUploader;
})();
