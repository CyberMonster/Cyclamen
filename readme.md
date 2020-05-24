![Build and push](https://github.com/CyberMonster/Cyclamen/workflows/Build%20and%20push/badge.svg)

Present `[Inject]` attribute.

This attribute is an easy way to make dependency injection via property or field.

It was better to use constructor injection. But some times when you can't use non-default constructor use this attribute.

`[Inject]` usage:

```CSharp
public class Foo
{
    [Inject]
    private IBar _bar;

    public Foo()
        => this.InjectProperties(App.Factory);
}
```

```CSharp
public class Foo
{
    [Inject]
    private IBar Bar { get; set; }

    public Foo()
        => this.InjectProperties(App.Factory);
}
```
