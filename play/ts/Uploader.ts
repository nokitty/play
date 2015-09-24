/// <reference path="../scripts/typings/jquery/jquery.d.ts" />

interface AjaxResult
{
    Success: boolean;
    Message: string;
    Data?: any;
}


class Uploader
{
    onProgress: (percentage: number) => void = null;
    onDone: () => void = null;
    onError: (msg: string) => void = null;

    url = '';
    chunkSize = 256 * 1024;

    private file: File;
    private chunks: number = 0;
    private name = '' + new Date().getTime() + Math.random();
    private chunk = 0;
    private isStop = false;

    constructor(file: File)
    {
        this.file = file;
        this.chunks = Math.ceil(this.file.size / this.chunkSize);
    }

    Start(): void
    {
        this.Upload();
    }

    Stop(): void
    {
        this.isStop = true;
    }

    private Upload()
    {
        if (this.isStop == true)
            return;

        //准备xhr对象
        var xhr = new XMLHttpRequest();
        xhr.open("post", this.url);
        xhr.responseType = 'json';
        xhr.onload = (ev) =>
        {
            var result: AjaxResult = xhr.response;
            if (result.Success == false)
            {
                this.isStop = true;
                if (this.onError != null)
                {
                    this.onError(result.Message);
                }
            }
            else
            {
                this.chunk++;
                if (this.chunk == this.chunks)
                {
                    if (this.onDone != null)
                    {
                        this.onDone();
                    }
                }
                else
                {
                    this.Upload();
                }
            }
        };
        xhr.onerror = (ev) =>
        {
            this.isStop = true;
            if (this.onError != null)
            {
                this.onError("请求出错！(" + xhr.status + ")");
            }
        }
        xhr.upload.onprogress = (ev) =>
        {
            if (ev.lengthComputable == true)
            {
                var loaded = ev.loaded + this.chunk * this.chunkSize;
                if (this.onProgress != null)
                {
                    this.onProgress(loaded / this.file.size);
                }
            }
        }

        //准备要发送的数据
        var start = this.chunk * this.chunkSize;
        var end = start + this.chunkSize;

        var data = new FormData();
        data.append("chunk", this.chunk);
        data.append("name", this.name);
        data.append("chunks", this.chunks);
        data.append("data", this.file.slice(start, end));

        xhr.send(data);
    }
}