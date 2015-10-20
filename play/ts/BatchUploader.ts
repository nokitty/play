/// <reference path="uploader.ts" />
 
class BatchUploader
{
    private list: Array<Uploader>;
    private totalSize = 0;
    private loadedSize = 0;
    private doneDataList: Array<UploaderDoneData>;
    currentIndex=0;
    url = "";
    chunkSize = 256 * 1024;

    onProgress: (percentage: number) => void = null;
    onDone: (datas: Array<UploaderDoneData>) => void = null;
    onError: (msg: string) => void = null;

    constructor() {
        this.list = new Array<Uploader>();
        this.doneDataList = [];
    }

    add(file: File)
    {
        var uploader = new Uploader(file);
        uploader.url = this.url;
        uploader.chunkSize = this.chunkSize;
        this.list.push(uploader);
        this.totalSize += file.size;
    }

    start()
    {
        if (this.currentIndex != this.list.length)
        {
            var u = this.list[this.currentIndex];
            u.onError = (msg) =>
            {
                if (this.onError != null)
                    this.onError(msg);
            };
            u.onProgress = (p) =>
            {
                var p1 = (this.loadedSize + u.file.size * p) / this.totalSize;
                if (this.onProgress != null)
                    this.onProgress(p1);
            };
            u.onDone = (data) =>
            {
                this.doneDataList.push(data);
                this.loadedSize += u.file.size;
                this.start();
            };
            u.start();
            this.currentIndex++;
        }
        else
        {
            if (this.onDone != null)
                this.onDone(this.doneDataList);
        }
    }
    stop()
    {
        this.list[this.currentIndex].stop();
    }
}