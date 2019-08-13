
using Bjd;
using Bjd.net;
using Bjd.log;
using Bjd.option;
using Bjd.server;
using Bjd.sock;

namespace SyslogServer
{

    partial class Server : OneServer
    {

        //コンストラクタ
        //このオブジェクトの生成時の処理（BJD起動・オプション再設定）
        public Server(Kernel kernel, Conf conf, OneBind oneBind)
            : base(kernel, conf, oneBind) { }

        //リモート操作（データの取得）Toolダイログとのデータ送受
        override public string Cmd(string cmdStr) { return ""; }

        //サーバ起動時の処理(falseを返すとサーバを起動しない)
        override protected bool OnStartServer() { return true; }

        //サーバ停止時の処理
        override protected void OnStopServer() { }

        //接続単位の処理
        override protected void OnSubThread(SockObj sockObj)
        {
            //UDPサーバの場合は、UdpObjで受ける
            var sockUdp = (SockUdp)sockObj;

            //１行受信
            var buf = sockUdp.RecvBuf;

            //そのままログに出力
            string msg = System.Text.Encoding.ASCII.GetString(buf);
            Logger.Set(LogKind.Normal, null , 7, string.Format("Syslog:SrcIp={0}:Msg={1}",sockUdp.RemoteIp,msg));

            //このメソッドを抜けると切断される
        }

        //RemoteServerでのみ使用される
        public override void Append(Bjd.log.OneLog oneLog)
        {

        }

    }
}

