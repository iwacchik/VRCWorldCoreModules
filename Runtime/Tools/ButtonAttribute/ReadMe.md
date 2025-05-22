# UdonSharp向けButtonAttribute

`PropertyAttribute`と`PropertyDrawer`を利用して、インスペクタ上にボタンを表示し指定メソッドを実行できます。

---

## 特徴

- インスペクタにボタン表示し、メソッドをクリックで実行できます(`プレイモード中のみ実行`)
- スクリプトに簡単導入

---

## 使い方

**public変数**を宣言して `[Button("実行したいメソッド名")]` を指定します。呼び出すメソッドは `public` / `private` どちらでも OK です。
`[Button("実行したいメソッド名,"ボタンラベル")]`でボタンに表示するテキストも指定できます。


> 引数ありメソッドを呼びたい場合は、引数なしメソッドを作成して実行できます

### 導入済みサンプル
```csharp
public class MyClass : UdonSharpBehaviour
{
    // 実行対象メソッド
    private Func() 
    {
        Debug.Log( $"Func 実行しました" );
    }
    public Func2(string str) 
    {
        Debug.Log( $"Func2 実行しました {str}" );
    }
        
    // UNITY_EDITORで囲むことで、実行ビルドには含まれないようにできます
#if UNITY_EDITOR
    [Button("Func")]
    public bool func = false;
    
    [Button("Func2Wrapper", "Func2を実行")]
    public bool func2 = false;
    public Func2Wrapper() 
    {
        Func2( "test" );
    }
#endif
}
```
