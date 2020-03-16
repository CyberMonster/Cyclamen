Present `[Inject]` attribute.

This attribute is easy way to make dependency injection via property or field.

It better to use constructor injection. But some times when you can't use non default constructor use this attribute.

`[Inject]` usage:

```
public class Foo
{
    [Inject]
    private IBar _bar;

    public Foo()
        => this.InjectProperties(App.Factory);
}
```


```
public class Foo
{
    [Inject]
    private IBar Bar { get; set; }

    public Foo()
        => this.InjectProperties(App.Factory);
}
```