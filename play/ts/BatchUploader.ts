/// <reference path="uploader.ts" />
 
class BatchUploader
{
    private list: Array<Uploader>;
    private totalSize = 0;
    private loadedSize = 0;
    currentIndex: number;

    onProgress: (percentage: number) => void = null;
    onDone: (data: any) => void = null;
    onError: (msg: string) => void = null;

    add(file: File)
    {
        this.list.push(new Uploader(file));
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
            u.onDone = () =>
            {
                this.loadedSize += u.file.size;
                this.start();
            };
            u.start();
            this.currentIndex++;
        }
        else
        {
            if (this.onDone != null)
                this.onDone(null);
        }
    }
    stop()
    {
        this.list[this.currentIndex].stop();
    }
}