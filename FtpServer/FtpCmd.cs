namespace FtpServer{

    //FTPコマンド
    internal enum FtpCmd{
        Quit,
        Noop,
        User,
        Pass,
        Cwd,
        Port,
        Eprt,
        Pasv,
        Epsv,       
        Size,
        // 6.2.0.1 ローカルでSIZEコマンドが必要なので追加した(RFC:3659)
        Retr,
        Stor,
        Rnfr,
        Rnto,
        Abor,
        Dele,
        Rmd,
        Mkd,
        Pwd,
        Xpwd,
        List,
        Nlst,
        Type,
        Cdup,
        Syst,
        Unknown
    }
}
