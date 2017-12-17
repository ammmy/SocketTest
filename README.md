# SocketTest
## UnityでのTCP/IP通信テスト
### 参考
https://blog.sky-net.pw/article/36  
https://qiita.com/msrks/items/0550603efc59f6e8ba09  
https://qiita.com/haminiku/items/0661568d0e311c8e8381  
http://kou-yeung.hatenablog.com/entry/2017/02/18/040901  

Unityと他のプログラムとの通信を行うために，TCP/IP通信を利用したテストプログラムを作成した．  
(Unity 5.6.0f3で作成)

### シーン：
#### Sample
TCP/IP通信なしでの自動運転  
#### Socket
TCP/IP通信サンプルプログラム．  
サーバとクライアントをどちらも同じシーン上で実行．  
メッセージのやり取りをしているだけ，これをもとにクライアントで自動運転処理を行う必要がある．  
  
Dキーを押すとmTcpClient.csがサーバにメッセージ"from Client"を送信する．  
それを受信したmSocketServer.csが"from Client"とコンソールに表示する．  
  
Aキーを押すとmSocketServer.csがクライアントにメッセージ"from Unity server"を送信する．  
それを受信したmTcpClient.csが"from Unity server"とコンソールに表示する．  
  
サーバへの接続はmTcpClient.csがプログラム開始1秒後に自動で行う．  
サーバ，クライアントそれぞれ別のプログラムと通信するテストを行いたい場合は付属のPythonコードで可能．

### 他のプログラムと通信するには
SocketシーンにあるTCPClientを削除して，それと同じ処理を他のプログラムに行わせる．  
行っている処理はサーバへの接続，送信，受信．
