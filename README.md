# JuscoBot
Actの設定をGoogleドライブにバックアップするためのソフトです。

[v0.0.0.1]

・とりあえず設定ファイルをアップロードするのみ対応

・ダウンロード機能はこれから対応予定 (今は自分でGoogleDrive行って手動で落として)

・ファイルの更新判定が超ザル

・バックアップに選べるフォルダが固定 (なので今はConfigフォルダとHojorinの設定以外のフォルダの設定ファイルがある場合は保存されません)


# Setup

(いつかきっと真面目に書く)


・Googleドライブにアクセスするために以下のサイトの「OAuthクライアントID取得」でjson取得まで実行
https://qiita.com/akabei/items/f25e4f79dd7c2f754f0e


・プラグイン側の「credentials ファイル」で設定して認証ボタンを押下

・ブラウザで認証すれば使えるようになります。

・認証を取り消す場合には (ActのAppData)/Config/JusocoBot/GoogleDriveToken フォルダを削除


# Software Used

[Microsoft .NET Framework 4.6.1](https://dotnet.microsoft.com/download/dotnet-framework)

[Google.Apis.Drive.v3](https://www.nuget.org/packages/Google.Apis.Drive.v3/)

[Google.APIs](https://www.nuget.org/packages/Google.Apis/)



↓ まだ実際には使ってないけど Discord対応を想定のため

[Discord.Net](https://github.com/discord-net/Discord.Net)

[NAudio](https://github.com/naudio/NAudio)
