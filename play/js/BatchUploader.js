var BatchUploader = (function () {
    function BatchUploader() {
        this.totalSize = 0;
        this.loadedSize = 0;
        this.onProgress = null;
        this.onDone = null;
        this.onError = null;
    }
    BatchUploader.prototype.add = function (file) {
        this.list.push(new Uploader(file));
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
            u.onDone = function () {
                _this.loadedSize += u.file.size;
                _this.start();
            };
            u.start();
            this.currentIndex++;
        }
        else {
            if (this.onDone != null)
                this.onDone(null);
        }
    };
    BatchUploader.prototype.stop = function () {
        this.list[this.currentIndex].stop();
    };
    return BatchUploader;
})();
