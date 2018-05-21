## TODO

### Frontend
- [ ] Create the CRUD views manually.
- [ ] Add a Bootstrap 4 theme.
- [ ] Add AJAX functionality to some or all of the forms.

### Backend
- [x] Setup different routes to showcase how to do it.
> _Check Movies/Index.cshtml page for an example. Basically you just need to define the route in the @page directive_      

```CSharp
@page "{id:int?}/{searchString?}"
...
public async Task OnGetAsync(string searchString, int? id)

``` 

- [ ] Organize the code into projects.

### Infrastructure
- [ ] Deploy to Azure / AWS.
- [ ] Setup CI/CD with tests associated with them.

### Reference
- [ ] Read [this](https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/concurrency?view=aspnetcore-2.0) for a much data oriented tutorial and implement any missing features.


