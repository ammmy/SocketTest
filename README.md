# SocketTest
## UnityでのTCP/IP通信テスト
### 参考
https://blog.sky-net.pw/article/36  
https://qiita.com/msrks/items/0550603efc59f6e8ba09  
https://qiita.com/haminiku/items/0661568d0e311c8e8381  
http://kou-yeung.hatenablog.com/entry/2017/02/18/040901  


### シーン：
#### Sample
TCP/IP通信なしでの自動運転  
#### Socket
TCP/IP通信サンプルプログラム．  
サーバとクライアントをどちらも同じシーン上で実行．  
メッセージのやり取りをしているだけ，これをもとにクライアントで自動運転処理を行う必要がある．  
  
サーバ，クライアントそれぞれ別のプログラムと通信するテストを行いたい場合は付属のPythonコードで可能．

### 他のプログラムと通信するには
SocketシーンにあるTCPClientを削除して，それを同じ処理を他のプログラムに行わせる．  
行っている処理はサーバへの接続，送信，受信．
