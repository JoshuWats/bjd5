using Bjd;
using Bjd.ctrl;
using Bjd.net;
using Bjd.option;
using System.Collections.Generic;

namespace SyslogServer
{
    public class Option : OneOption
    {

        //メニューに表示される文字列
        //public override string JpMenu { get { return "SYSLOGサーバ"; } }
        //public override string EnMenu { get { return "Syslog Server"; } }
        public override char Mnemonic { get { return 'Z'; } }

        public Option(Kernel kernel, string path, string nameTag)
            : base(kernel.IsJp(), path, nameTag)
        {

            var key = "useServer";
            Add(new OneVal(key, false, Crlf.Nextline, new CtrlCheckBox(Lang.Value(key))));

            var pageList = new List<OnePage>();
            key = "Basic";
            pageList.Add(Page1(key, Lang.Value(key), kernel));
            pageList.Add(PageAcl());
            Add(new OneVal("tab", null, Crlf.Nextline, new CtrlTabPage("tabPage", pageList)));

            Read(kernel.IniDb); //　レジストリからの読み込み
        }

        private OnePage Page1(string name, string title, Kernel kernel)
        {
            var onePage = new OnePage(name, title);

            onePage.Add(CreateServerOption(ProtocolKind.Udp, 514, 30, 10)); //サーバ基本設定

         // sample
         //   var key = "syslogText";
         //   onePage.Add(new OneVal(key, "Syslog Server : ", Crlf.Nextline, new CtrlTextBox(Lang.Value(key), 50)));

            return onePage;
        }

        //コントロール変化時の処理
        override public void OnChange()
        {
            var b = (bool)GetCtrl("useServer").Read();//「useServer」の値取得
            GetCtrl("tab").SetEnable(b);//「Basic」の有効・無効の設定
        }

    }
}
