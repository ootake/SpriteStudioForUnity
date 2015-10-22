# SpriteStudioForUnity

Introduction
---------------------
OPTPiX SpriteStudio 5 で制作したアニメーションデータを Unity 上で再生するためのプログラムです。

Usage
---------------------
Unityのタイトルメニューから[Window]=>[SpriteStudioForUnity]=>[Window]を選択するとウィンドウが表示されます。
Output Folderに出力先フォルダ名を設定し、Importボタンを押すとファイル選択ダイアログが開きます。
sspjファイルを選択するとインポートが開始されます。
Output Folderに出力されますので作成されたPrefabファイルをシーンに配置するとアニメーションされます。

Note
---------------------
作成されたアニメーションはSprite Studioと同様の表示を再現するため、
ssaeで設定されたタイミングにアニメーションカーブをConstantのキーフレームを設定しております。
滑らかにアニメーションさせる場合はssaeのfpsを高く設定してください。

License
---------------------
This software is released under the MIT License, see LICENSE.txt.
