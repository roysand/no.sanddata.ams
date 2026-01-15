Here is some thing to remember

In the API program.cs add the following line to enable CORS:

```csharp
app.UseFastEndpoints(c =>
{
    c.Endpoints.Configurator = ep =>
    {
        ep.PreProcessor<ValidationPreProcessor>(Order.Before);
        ep.PostProcessor<LoggingPostProcessor>(Order.After);
    };
});

```
