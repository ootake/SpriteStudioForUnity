◆OPTPiX_SpriteStudio_ParticleEffectSample ver.150813

本データを使用するには　OPTPiX SpriteStudio Ver5.5.1が必要です


■利用規約

1. 本パッケージ内のすべてのファイル（以下、「本ファイル」という）の著作権は株式
   会社ウェブテクノロジ（以下、「当社」という）が保有しています。

2. 本ファイル中のサンプルデータ（以下「サンプルデータ」という）は、ユーザー様が
   OPTPiX SpriteStudio を用いて開発したゲームアプリ等に組み込む目的、または、
   OPTPiX SpriteStudio 導入の検証目的でのみご使用いただけます。他の目的では使用
   しないでください。

3. OPTPiX SpriteStudio トライアル版および無料特別版のユーザー様は、当社が著作権
   を有するサンプルデータを使用している旨の表示を付することで、当社に対価を支払
   うことなく、サンプルデータを組み込んだゲームアプリ等を配布・販売することがで
   きます。

4. OPTPiX SpriteStudio 製品版ユーザー様は、当社の著作権表示を付することなく、ま
   た当社に対価を支払うことなく、サンプルデータを組み込んだゲームアプリ等を配布
   ・販売することができます。

5. 前2項記載以外の態様で、有償・無償を問わず本ファイルを転載・再配布することを
   禁止します。

6. 当社は、本ファイルの商品性、特定の目的への適合性、および権利非侵害等について
   一切の保証をしません。当社は、本ファイルに起因または関連し、あるいは本ファイ
   ルの使用またはその他の扱いによって生じる一切の損害について何らの責任も負わな
   いものとします。

----------------------------------------------------------------------

内容：effect2.sspj
effect001:light_magic:雷魔法
effect002:heavy_blow：打撃
effect003:explosion：爆発
effect004:flash：フラッシュ
effect005:slash：斬撃
effect006:frame projector：火炎放射
effect007:light shower：光の雨
effect008:poison：毒霧
effect009:halo：後光
effect010:fire：炎
effect011:lazer：レーザー
effect012:bubble：シャボン
effect013:moonslash：斬る
effect014:ripple：波紋
effect015:roundwave：衝撃波
effect016:burner：バーナー炎
effect017:bom：閃光爆発
effect018:blackonyx:黒水晶
effect019:hadou：波動弾
effect020:aura：オーラ
effect021:poisonmagic：毒魔法
effect022:starbow：ワープ
effect023:supernova：光球と波紋
effect024:bomflash：フラッシュアウト
effect025:bomcloud：キノコ雲
effect026:geyser：噴出
effect027:ringball：玉の輪
effect028:stadust：星くず
effect029:circumference：光の周回
effect030:glint：閃光
effect031:icemagic：氷魔法
effect032:icetrap：地面から氷
effect033:cristal：水晶
effect034:dust：砂埃
effect035:meteo：隕石落下
effect036:sakura:サクラ散る
effect037:hadou2：波動ビーム


作成参考:magiccircle.sspj
magiccircle:magiccircle:魔法陣


* 上記データは SS5Player for Unity(OPTPiX SpriteStudio 5 専用プレイヤー) で再生
  できる事を確認しています。
  SSPlayer for Unity などの旧プレイヤーではOPTPiX SpriteStudio 5 が持つ新機能
  (X/Y軸回転等)に対応していないため再生されないデータが含まれています。
  各種プレイヤーの仕様によって再現性に差が出ることがあるため、お使いになる場合
  は事前に確認することを推奨します。

* effect008 以降のデータは単色のイメージにカラーブレンドを利用して着彩し、複数
  のカラーバリエーションを表現し、重ね合わせたアニメーションが多くなっています。
  カラーブレンドを多用した複数のパーツを重ねる方法は、GPU負荷が高くなるため、
  低スペックのハードウェアではフレームレートが低くなる傾向があります。
  その場合はカラーブレンドを利用せず参照するイメージを多色分作成する、重ね合わ
  せるパーツ数を削減する等の工夫も検討してください。

* 魔法陣のデータのみ素材数が多いため別の画像ファイルになっています。その他のエ
  フェクトと同時に描画させる場合にテクスチャ切り替えによる処理負荷の増加を少し
  でも減らすよう、プレイヤー側では同じＺ座標上に重ねて表示しない、などの工夫を
  することを推奨します。
